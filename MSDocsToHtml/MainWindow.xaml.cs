using eShopping.Common.Converter;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSDocsToHtml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _fileLoc = "select a file";
        private bool _convertEnabled = false;

        public string FileLoc
        {
            get => _fileLoc;
            set
            {
                _fileLoc = value;
                OnPropertyChanged();
            }
        }

        public bool ConvertEnabled
        {
            get => _convertEnabled;
            set
            {
                _convertEnabled = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            btnBrowse.Click += BtnBrowse_Click;
            btnToHtml.Click += BtnToHtml_Click;
        }

        private void BtnToHtml_Click(object sender, RoutedEventArgs e)
        {
            var savefi = new SaveFileDialog();
            var res = savefi.ShowDialog();

            if(savefi.CheckPathExists && res.HasValue && res.Value)
            {
                try
                {
                    var html = ConverterLocator.Converter(FileLoc, savefi.FileName);
                    html.Convert();
                    MessageBox.Show($"File Convert Complete!\n\n{savefi.FileName}");

                    _fileLoc = "select a file";
                    _convertEnabled = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("File Convert Failed!");
                }
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var opfi = new OpenFileDialog();
            opfi.Multiselect = false;
            var res = opfi.ShowDialog();

            if (opfi.CheckFileExists && res.HasValue && res.Value)
            {
                FileLoc = opfi.FileName;
                ConvertEnabled = true;
            }
            else
            {
                ConvertEnabled = false;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
