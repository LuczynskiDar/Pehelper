using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Http;

namespace Pehelper.Models
{

    public class RegisterViewModel
    {
    // other properties omitted
        // public string Name { get; set; }
        public IFormFile Avatar { get; set; }
    }

    public class RowElement
    {
        public string Row { get; set; }
        public int ItemsInRow {get; set;}
        public RowElement(string row, int itemsInRow)
        {
            this.Row = row;
            this.ItemsInRow = itemsInRow;
        }
    }

    public class FormData
    {
        public int ColumnNumber {get; set;}
        public string ColumnName { get; set; }
        public int ItemsInRow { get; set;}
        public List<RowElement> RowElementList { get; set; }
        public DataTable SheetDataTable { get; set; }
        public string FileName { get; set; }
        // public string FilePath { get; set; }

        // public IFormFile Avatar { get; set; }

        public FormData AddColumnNumber( int columnNumber)
        {
            this.ColumnNumber = columnNumber;
            return this;
        }

        public FormData AddColumnName( string columnName)
        {
            this.ColumnName = columnName;
            return this;
        }
        public FormData AddItemsInRow( int itemsInRow)
        {
            this.ItemsInRow = itemsInRow;
            return this;
        }
        public FormData AddRowElementList (List<RowElement> rowElementList)
        {
            this.RowElementList = rowElementList;
            return this;
        }
        public FormData AddSheetDataTable(DataTable sheetDataTable)
        {
            this.SheetDataTable = sheetDataTable;
            return this;
        }

        public FormData AddFileName(string fileName)
        {
            this.FileName = fileName;
            return this;
        }

    }
}