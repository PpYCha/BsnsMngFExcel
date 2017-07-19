using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXml
{
    public class MyExcelReader : IDisposable
    {
        private ExcelPackage excelPackage;

        public MyExcelReader(string filename)
        {
            excelPackage = new ExcelPackage(new System.IO.FileInfo(filename));
        }

        public Object ReadValue(string sheetName, string cellAddress)
        {
            ExcelWorksheet ws = excelPackage.Workbook.Worksheets.FirstOrDefault(w => w.Name.ToLower() == sheetName.ToLower());
            if (ws != null)
            {
                ExcelAddress excelAddress = new ExcelAddress(cellAddress);

                return ws.GetValue(excelAddress.Start.Row, excelAddress.Start.Column);
            }
            else
            {
                throw new Exception("Sheet not found:" + sheetName);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    excelPackage.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MyExcelReader() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
