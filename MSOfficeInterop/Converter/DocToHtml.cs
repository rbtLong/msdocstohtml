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
    using Application = Microsoft.Office.Interop.Word.Application;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DocToHtml : FileConverter, IConverter
    {
        public StringBuilder Convert()
        {
            Application objWord = new Application();

            if (File.Exists(FileToSave))
            {
                File.Delete(FileToSave);
            }
            try
            {
                objWord.Documents.Open(FileName: FullFilePath);
                objWord.Visible = false;
                if (objWord.Documents.Count > 0)
                {
                    Microsoft.Office.Interop.Word.Document oDoc = objWord.ActiveDocument;
                    oDoc.SaveAs(FileName: FileToSave, FileFormat: 10);
                    oDoc.Close(SaveChanges: false);
                }
            }
            finally
            {
                objWord.Application.Quit(SaveChanges: false);
            }
            return base.ReadConvertedFile();
        }
        ~DocToHtml()
        {
            base.DeleteFiles();
        }
    }
}
