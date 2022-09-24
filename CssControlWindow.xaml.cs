using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using WpfCssControlLibrary.Controls;
using WpfCssControlLibrary.Converters;
using WpfCssControlLibrary.Dialogs;
using WpfCssControlLibrary.Model;


namespace WpfCssControlLibrary
{
    /// <summary>
    /// Interaction logic for CssControlWindow.xaml
    /// </summary>
    public partial class CssControlWindow : Window
    {

        Random rand = new();
        //  DirectoryInfo vlcLibDirectory;
       // private static CssModel? _context = null;


        private CssClassesToolControl? _toolcontent = new CssClassesToolControl(700,700);

        #region ctor

        public CssControlWindow()
        {
            InitializeComponent();
            DataContext = this;

            

            Top.Children.Add(_toolcontent);
            Closing +=MainWindow_Closing;
        }

        #endregion

        private void MainWindow_Closing(object? sender, CancelEventArgs e)
        {
           
        }




        // define an event handler
        public event PropertyChangedEventHandler PropertyChanged;

        #region properties

        // sqlite dc Context property



        //public static CssModel Context
        //{
        //    get
        //    {
        //        if (_context == null)
        //        {
        //            try
        //            {
        //                _context = new CssModel();
        //                _context.Database.EnsureCreated();

        //            }
        //            catch (Exception e)
        //            {
        //                System.Windows.MessageBox.Show(e.Message, "No DataBase Found", MessageBoxButton.OK);

        //                throw;
        //            }
        //        }
        //        return _context;
        //    }
        //}


        #endregion

    }
}
