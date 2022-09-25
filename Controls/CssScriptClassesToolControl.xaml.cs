//------------------------------------------------------------------------------
// <copyright file="CssClassesToolControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using WpfCssControlLibrary.Dialogs;
using WpfCssControlLibrary.Model;
using Css_Classes2019.Window;


namespace WpfCssControlLibrary.Controls
{
    /// <summary>
    /// Interaction logic for CssClassesToolControl.
    /// </summary>
    public partial class CssClassesToolControl : UserControl
    {
        public static BrowserWindow Browser = new BrowserWindow();
        public static double IsXsize = 600.0;
        public static double IsYsize = 600.0;
        public static double ThirdXsize = 200.0;
        public static double ThirdYsize = 200.0;
        public static double TwoThirdXsize = 400.0;
        public static double TwoThirdYsize = 400.0;

        private static CssModel? _context = null;

        private readonly CssAnimationBuildControl _cssAnimationControl = new CssAnimationBuildControl();
        private readonly CssBuildControl _cssControl = new CssBuildControl();



        /// <summary>
        /// Initializes a new instance of the <see cref="CssClassesToolControl"/> class.
        /// </summary>
        public CssClassesToolControl(int width, int height)
        {
            Width=Width;
            Height=Height;
            this.InitializeComponent();

            this.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            this.VerticalAlignment = VerticalAlignment.Stretch;

            //    Title = Title = "CssScripterSqlite (loading)";
            Loaded += OnLoaded;
            IsXsize = Width;
            IsYsize = Height;
            ToCssPage();
            SizeChanged += MainWindow_SizeChanged;
            //   Width = 950.0;
        }

        public string LastChosen = string.Empty;

        public void FillLastChosen()
        {
            if (_cssControl != null)
            {
                LastChosen = _cssControl.ShowCssText.Text;
                if (string.IsNullOrWhiteSpace(LastChosen) == false)
                {
                    LastChosen = LastChosen.Trim();
                }
            }
        }



        //public static void ReConnect()
        //{
        //    _context = null;
        //    _context = new CssModel();
        //}

        public static string LastDbError = string.Empty;

        public static CssModel Context
        {
            get
            {
                if (_context == null)
                {
                    // System.Data.DataTable table = VisibleServerList.GetVisibleServers();
                    

                   try
                   {
                       LastDbError = string.Empty;
                       _context = new CssModel();
                       _context.Database.EnsureCreated();
                    }
                   catch (Exception e)
                   {
                        LastDbError = e.Message;

                       MessageBox.Show(e.Message, "No DataBase Found", MessageBoxButton.OK);

                       throw;
                   }
                   
                   
                   // _context.Database.EnsureCreated();
                }
                return _context;
            }
        }

       


        public static CssClassesToolControl MainToolControl { get; private set; }



        public Action<List<string>> OutputErrors { get; set; }



        public ColorPage _CssColorPage { get; set; } = new ColorPage();
        public bool IsColorPage { get; set; }

        public CssBuildControl UseCssControl
        {
            get { return _cssControl; }
        }

        public CssAnimationBuildControl UseCssAnimationControl
        {
            get { return _cssAnimationControl; }
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            IsXsize = e.NewSize.Width;
            IsYsize = e.NewSize.Height;

            TwoThirdXsize = .666 * IsXsize;
            TwoThirdYsize = .666 * IsYsize;
            ThirdXsize = IsXsize - TwoThirdXsize;
            ThirdYsize = IsYsize - TwoThirdYsize;
            _cssControl.TwoThirdWidth = TwoThirdXsize;
            _cssControl.ThirdWidth = ThirdXsize;
            _cssControl.MaxHeight = IsYsize;

            _cssAnimationControl.MaxHeight = IsYsize;

        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            MainToolControl = this;


            Browser.Closing += Browser_Closing;

        }



        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (Browser != null)
            {
                Browser.Closing -= Browser_Closing;
                Browser.Close();
            }
        }

        public void ToCssPage()
        {
            TopGrid.Children.Clear();
            TopGrid.Children.Add(_cssControl);
            IsColorPage = false;
            this.InvalidateVisual();
        }

        public void ToCssAnimationPage()
        {
            TopGrid.Children.Clear();
            TopGrid.Children.Add(_cssAnimationControl);
            _cssAnimationControl.ActionBox.MaxWidth = TwoThirdXsize;

           // _cssAnimationControl.CssSettings.Width = TwoThirdXsize - 3.0;
            IsColorPage = false;
            this.InvalidateVisual();
        }

        public void ToColorPage(ColorSelector select)
        {
          //  _CssColorPage.Selector = select;
         //   TopGrid.Children.Clear();
         //   TopGrid.Children.Add(_CssColorPage);
            TopGrid.Children.Add(select);
            this.InvalidateVisual();
            IsColorPage = true;
        }

        private void Browser_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Browser.Hide();
        }

        private const string EdgeName = "Microsoft.MicrosoftEdge_8wekyb3d8bbwe!MicrosoftEdge";


        public static void OpenBrowserPage(string htmlpage)
        {
            string userdir = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = userdir + @"/scriptfiletest.html";

            File.WriteAllText(path, htmlpage);

            var uri = new System.Uri(path);
            var converted = uri.AbsoluteUri;
            string target = "microsoft-edge:" + path;
           

            try
            {
                var launcher = new ApplicationActivationManager();
                uint pid;
                launcher.ActivateApplication(EdgeName,
                               path,
                               ActivateOptions.None,
                               out pid);

                // ProcessStartInfo si = new ProcessStartInfo("Edge", converted);
                // Process.Start(si);
            }
            catch
                (
                 System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }



        }

        // Edge launcher code below as MIT Licence under  Copyright(c) Microsoft  at github https://github.com/MicrosoftEdge/edge-launcher
        // All rights reserved.
        // MIT License
        // Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files(the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
        // The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
        // THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


        public enum ActivateOptions
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0x00000000,  // No flags set
            /// <summary>
            /// The design mode
            /// </summary>
            DesignMode = 0x00000001,  // The application is being activated for design mode, and thus will not be able to
                                      // to create an immersive window. Window creation must be done by design tools which
                                      // load the necessary components by communicating with a designer-specified service on
                                      // the site chain established on the activation manager.  The splash screen normally
                                      // shown when an application is activated will also not appear.  Most activations
                                      // will not use this flag.
                                      /// <summary>
                                      /// The no error UI
                                      /// </summary>
            NoErrorUI = 0x00000002,  // Do not show an error dialog if the app fails to activate.                                
            /// <summary>
            /// The no splash screen
            /// </summary>
            NoSplashScreen = 0x00000004,  // Do not show the splash screen when activating the app.
        }

        /// <summary>
        /// Interface IApplicationActivationManager
        /// </summary>
        [ComImport, Guid("2e941141-7f97-4756-ba1d-9decde894a3d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface IApplicationActivationManager
        {
            // Activates the specified immersive application for the "Launch" contract, passing the provided arguments
            // string into the application.  Callers can obtain the process Id of the application instance fulfilling this contract.
            /// <summary>
            /// Activates the application.
            /// </summary>
            /// <param name="appUserModelId">The application user model identifier.</param>
            /// <param name="arguments">The arguments.</param>
            /// <param name="options">The options.</param>
            /// <param name="processId">The process identifier.</param>
            /// <returns>IntPtr.</returns>
            IntPtr ActivateApplication([In] String appUserModelId, [In] String arguments, [In] ActivateOptions options, [Out] out UInt32 processId);
            /// <summary>
            /// Activates for file.
            /// </summary>
            /// <param name="appUserModelId">The application user model identifier.</param>
            /// <param name="itemArray">The item array.</param>
            /// <param name="verb">The verb.</param>
            /// <param name="processId">The process identifier.</param>
            /// <returns>IntPtr.</returns>
            IntPtr ActivateForFile([In] String appUserModelId, [In] IntPtr /*IShellItemArray* */ itemArray, [In] String verb, [Out] out UInt32 processId);
            /// <summary>
            /// Activates for protocol.
            /// </summary>
            /// <param name="appUserModelId">The application user model identifier.</param>
            /// <param name="itemArray">The item array.</param>
            /// <param name="processId">The process identifier.</param>
            /// <returns>IntPtr.</returns>
            IntPtr ActivateForProtocol([In] String appUserModelId, [In] IntPtr /* IShellItemArray* */itemArray, [Out] out UInt32 processId);
        }

        /// <summary>
        /// Class ApplicationActivationManager.
        /// </summary>
        /// <remarks>
        ///     implementation was made from community members at stackoverflow http://stackoverflow.com/questions/12925748/iapplicationactivationmanageractivateapplication-in-c
        /// </remarks>
        [ComImport, Guid("45BA127D-10A8-46EA-8AB7-56EA9078943C")]//Application Activation Manager
        class ApplicationActivationManager : IApplicationActivationManager
        {
            /// <summary>
            /// Activates the application.
            /// </summary>
            /// <param name="appUserModelId">The application user model identifier.</param>
            /// <param name="arguments">The arguments.</param>
            /// <param name="options">The options.</param>
            /// <param name="processId">The process identifier.</param>
            /// <returns>IntPtr.</returns>
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)/*, PreserveSig*/]
            public extern IntPtr ActivateApplication([In] String appUserModelId, [In] String arguments, [In] ActivateOptions options, [Out] out UInt32 processId);
            /// <summary>
            /// Activates for file.
            /// </summary>
            /// <param name="appUserModelId">The application user model identifier.</param>
            /// <param name="itemArray">The item array.</param>
            /// <param name="verb">The verb.</param>
            /// <param name="processId">The process identifier.</param>
            /// <returns>IntPtr.</returns>
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            public extern IntPtr ActivateForFile([In] String appUserModelId, [In] IntPtr /*IShellItemArray* */ itemArray, [In] String verb, [Out] out UInt32 processId);
            /// <summary>
            /// Activates for protocol.
            /// </summary>
            /// <param name="appUserModelId">The application user model identifier.</param>
            /// <param name="itemArray">The item array.</param>
            /// <param name="processId">The process identifier.</param>
            /// <returns>IntPtr.</returns>
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            public extern IntPtr ActivateForProtocol([In] String appUserModelId, [In] IntPtr /* IShellItemArray* */itemArray, [Out] out UInt32 processId);
        }

        //public void FixRegistry()
        //{
        //    // HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION

        //    //Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
        //    //    "ImagePlacement.exe",
        //    //    "11999",
        //    //    RegistryValueKind.DWord);

        //    try
        //    {
        //        Registry.SetValue(
        //            @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION",
        //            "CssScripter.exe",
        //            "11999",
        //            RegistryValueKind.DWord);
        //    }
        //    catch (SecurityException se)
        //    {
        //        MessageBox.Show("To use the Sample web page format views, Run this program as an Administrator once or Add the registry key "
        //                        +
        //                        @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"
        //                        + "will need to add a value for 'CssScripter.exe' of 11999");
        //    }
        //    catch (Exception ee)
        //    {
        //        //MessageBox.Show("To use the Sample web page format views, Run this program as an Administrator once or Add the registry key "
        //        //                              +
        //        //                              @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"
        //        //                              + "will need to add a value for 'CssScripter.exe' of 11999");
        //    }
        //}

    }
}