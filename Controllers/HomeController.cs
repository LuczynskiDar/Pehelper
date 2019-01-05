using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pehelper.Models;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;


namespace Pehelper.Controllers
{
    public class HomeController : Controller
    {
        ExcelOperator xlOperator = new ExcelOperator();
        public static DataTable XlDataTable{get; set;} 
        public List<RowElement> RowElementsList {get; set;} 
        public string FileName {get; set;}
        public string FilePath { get; set; }
        public string TempFileName { get; set; }
        
        private DataTable GetXlDatatable(dynamic myPath)
        {
            return xlOperator.ReadExcell(myPath);
        }
        private List<RowElement> SplitData( DataTable data, FormData formData)
        {
            var dataSplitter = new DataSplitter(data, 
                                                formData.ItemsInRow, 
                                                formData.ColumnNumber,
                                                formData.ColumnName);    
            dataSplitter.SplitData();
            
            return dataSplitter.ListOfRows;
        }

        public IActionResult Index()
        {
            FormData data = null;
            return View (data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Run")]
        [Route("Home")]
        public IActionResult Index (FormData model) {
           
            XlDataTable = HttpContext.Session.Get<DataTable>("MyTable");
            model.AddFileName(HttpContext.Session.Get<string>("name"))
                    .AddRowElementList(SplitData(XlDataTable, model));
            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IFormFile file)
        {
            
            FormData formData = null;
            if (ModelState.IsValid)
            {        
                if (file != null)
                {
                    formData = new FormData();
                    var filePath = Path.GetTempFileName();
                    FileName = Path.GetFileName(file.FileName);
                    TempFileName = System.Guid.NewGuid().ToString() +'_'+ FileName;
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), 
                        "Temp", 
                        TempFileName);
                    
                    using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                    {
                        await file.CopyToAsync(fileStream);
                        fileStream.Close();
                        XlDataTable = GetXlDatatable(path);
                        System.IO.File.Delete(path);
                        
                    }

                    formData.AddFileName(FileName);
 
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
                        
            HttpContext.Session.Set<DataTable>("MyTable", XlDataTable);
            HttpContext.Session.Set<string>("name",FileName);

            return View(formData);
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Peheler compiles desired quantity of items together and separates them with semicolon.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "See the contact points below:";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : 
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
