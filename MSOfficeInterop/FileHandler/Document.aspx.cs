using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eShopping.Common.Converter;

namespace eShopping.WebForms.FileHandler
{
    public partial class Document : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ConvertAndLoadDocumentInEditor();
            }
        }

        private void ConvertAndLoadDocumentInEditor()
        {
            //To save every file with different name
            string randamName = DateTime.Now.ToFileTime().ToString();

            string relativePath = Server.MapPath("~") + "/_Temp/";

            //Complete path of the file.
            string FilePath = relativePath + randamName + flDocument.FileName;

            string GeneratedName = randamName + flDocument.FileName.Split('.')[flDocument.FileName.Split('.').Count() - 2] + ".html";

            flDocument.SaveAs(FilePath);

            //Converter functionality needs the file name to save as.
            string FileToSave = HttpContext.Current.Server.MapPath("~") + "_Temp\\" + GeneratedName;

            //Get the instance of IConverter interface
            IConverter doc = ConverterLocator.Converter(FilePath, FileToSave);

            //Call the Converter class and set th test of editor to converted excel.
            editor.Text = doc.Convert().ToString().Replace("�", "");
        }
    }
}