using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime;

namespace Pehelper.Models
{
    public class DataSplitter
    {
        public int ItemsInRowQuantity {get; set;}
        public int ColumnNumber {get; set;}
        public string ColumnName {get; set;}
        public DataTable ReadData{get;set;}
        public List<RowElement> ListOfRows {get; set;}
        public DataSplitter(DataTable readData, int? intendedQty, int? intendedColumn = 0, string columnName = null)
        {
            this.ReadData = readData;
            ReadData = readData;
            
            if (((intendedQty ?? 0) == 0)) this.ItemsInRowQuantity = 1;
            else this.ItemsInRowQuantity = intendedQty.GetValueOrDefault();
            if (((intendedColumn ?? 0) == 0)) this.ColumnNumber = 0;
            else this.ColumnNumber = ValidateColumnNumber(intendedColumn.GetValueOrDefault());             
            this.ColumnName = ValidateColumnName(columnName);
            this.ListOfRows =  new List<RowElement>();
        }

        public dynamic IsColumnIntOrString()
        {
            if(ColumnName == null) return ColumnNumber;
            else return ColumnName;
        } 

        public int ValidateColumnNumber(int tempColumnNumber)
        {
 
            return (tempColumnNumber <=ReadData.Columns.Count) ? tempColumnNumber : 0;
        }

        public string ValidateColumnName(string tempColumnName)
        {
            if(tempColumnName == null) return null;
            return (ReadData.Columns.Contains(tempColumnName)) ? tempColumnName : null;
        }

        public void SplitData()
        {
            var tempValue ="";
            var counter = 1;
            dynamic getColumn;
            if(ReadData == null) return;
            else if(ColumnName != null) getColumn = ColumnName;
            else getColumn = ColumnNumber;
            for (int k = 0; k < ReadData.Rows.Count; k++)
            {
                
                tempValue += (ReadData.Rows[k][getColumn].ToString() + @";");

                if (counter % ItemsInRowQuantity == 0) 
                {
                        ListOfRows.Add(
                            new RowElement(
                                    tempValue, 
                                    ItemsInRowQuantity));

                    tempValue ="";
                }
                // else if(ReadData.Rows.Count/counter == 1 ) 
                else if(counter / ReadData.Rows.Count == 1 ) 
                {
                        ListOfRows.Add(
                            new RowElement(
                                    tempValue, 
                                    ReadData.Rows.Count % ItemsInRowQuantity));
                    
                }
                
                counter+=1;
              
            }
        }

        public override string ToString()
        {
            string temp = "\n";
            ListOfRows.ForEach( item => temp+=(item.Row.ToString() + "\n"));
            return temp;
        }

        public void RunMe(string print)
        {
            Console.WriteLine(print);
        }  
    }
}