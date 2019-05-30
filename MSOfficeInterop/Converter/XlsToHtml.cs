// -----------------------------------------------------------------------
// <copyright file="DocToHtml.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace eShopping.Common.Converter
{
    using System;
    using System.IO;
    using System.Text;
    using Application = Microsoft.Office.Interop.Excel.Application;
    using System.Collections;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class XlsToHtml : FileConverter, IConverter
    {

        public StringBuilder Convert()
        {
            Application excel = new Application();

            if (File.Exists(FileToSave))
            {
                File.Delete(FileToSave);
            }
            try
            {
                excel.Workbooks.Open(Filename: FullFilePath);
                excel.Visible = false;
                if (excel.Workbooks.Count > 0)
                {
                    IEnumerator wsEnumerator = excel.ActiveWorkbook.Worksheets.GetEnumerator();
                    object format = Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml;
                    int i = 1;
                    while (wsEnumerator.MoveNext())
                    {
                        var wsCurrent = (Microsoft.Office.Interop.Excel.Worksheet)wsEnumerator.Current;
                        var output = $"{FileToSave}.{i.ToString()}";
                        wsCurrent.SaveAs(Filename: output, FileFormat: format);
                        ++i;
                        break;
                    }
                    excel.Workbooks.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                excel.Application.Quit();
            }
            //return base.ReadConvertedFile();
        }
        ~XlsToHtml()
        {
            //base.DeleteFiles();
        }
    }
}
