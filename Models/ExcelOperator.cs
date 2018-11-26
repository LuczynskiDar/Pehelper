using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.OpenXml4Net.OPC;
using NPOI.POIFS.FileSystem;
using NPOI.HSSF.Extractor;
using NPOI.Util;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.Record;
using System.Windows;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Pehelper.Models
{
    public class ExcelOperator
    {
        public DataTable dataXls { get; set; }
        public List<object[]> dataList { get; set; }
        public ExcelOperator()
        {
            dataXls = new DataTable("readXls");
            dataList = new List<object[]>();
        }        
        public void GetExcell(dynamic input)
        {
            if(input.GetType() == typeof(string))
            {
                string myPath = input;
                using (var file = new FileStream(myPath, FileMode.Open, FileAccess.Read)) 
                {
                    try
                    {
                        IWorkbook wb = WorkbookFactory.Create(file);
                        ISheet ws = wb.GetSheetAt(0);
                        var columnQty = ws.GetRow(0).PhysicalNumberOfCells;
                    
                        for (int row = 0; row <= ws.LastRowNum; row++)
                        {
                            object[] rowArray = new object[columnQty];   
                            var myRow = ws.GetRow(row);
                            if (ws.GetRow(row) != null) //null is when the row only contains empty cells 
                            {
                               
                                if(columnQty == myRow.PhysicalNumberOfCells)
                                {
                                    for (int i = 0; i < columnQty; i++)
                                    {   
                                        
                                        rowArray[i] = myRow.GetCell(i).StringCellValue;                  
                                    }
                                    
                                    dataList.Add(rowArray);
                                }
                                else
                                {
                                    //Todo: to implement the skipped row counter and row indicator
                                }                        
                      
                            }
                        }
                    }
                    catch (OfficeXmlFileException e)
                    {

                        //Todo: to implement   
                        string toImplement =  e.Message;
                    }
                }
                
            }
            else if(input.GetType() == typeof(FormFile))
            {
                FileStream fs = input;               
                IWorkbook wb = WorkbookFactory.Create(fs);                
                ISheet ws = wb.GetSheetAt(0);
                var columnQty = ws.GetRow(0).PhysicalNumberOfCells;
                //Todo: not implemented
            }
            else return;
        }
        public void XlsDataToDataTable()
        {
            // Add columns to data table
            object[] columnNames= (object[])dataList[0];

            for (int k = 0; k < columnNames.Length; k++)
            {

                if (dataXls.Columns.Contains(columnNames[k].ToString()))
                {
                            dataXls.Columns.Add(
                                (columnNames[k].ToString() + k.ToString()), 
                                columnNames[k].GetType());

                }  

                else
                {
                    dataXls.Columns.Add(
                            columnNames[k].ToString(), 
                            columnNames[k].GetType()); 
                }  
             
            }

            //Add rows to data table, where row 0 is used to create names of columns
            for (int i = 1; i < dataList.Count; i++)
            {
                dataXls.Rows.Add(dataList[i]);

            }
     
        } 
        public DataTable ReadExcell(dynamic input)
        {   
            GetExcell (input);
            XlsDataToDataTable();
            return dataXls;                
        }       
    }
}