using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Composition;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfCssControlLibrary.Dialogs;
using WpfCssControlLibrary.Model;


using Microsoft.Win32;

namespace WpfCssControlLibrary.Controls
{

    /// <summary>
    /// Interaction logic for CssBuildControl.xaml
    /// </summary>
    public partial class CssBuildControl : UserControl, INotifyPropertyChanged
    {
       
        public CssBuildControl()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += OnLoaded;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int FindNextCssStyleId()
        {
            var items = from tut in CssClassesToolControl.Context.CssStyles
                        select tut;
            

            foreach (var item in items)
            {
                if (item.Id >= _nextCssStyleId)
                {
                    _nextCssStyleId = item.Id + 1;
                }
            }
            return (_nextCssStyleId);
        }

        public int FindNextCssStyleItemId()
        {
            var items = from tut in CssClassesToolControl.Context.CssStyleItems
                        select tut;

            foreach (var item in items)
            {
                if (item.Id >= _nextCssStyleItemId)
                {
                    _nextCssStyleItemId = item.Id + 1;
                }
            }
            return (_nextCssStyleItemId);
        }

        public int FindNextCssColorTypeId()
        {
            var items = from tut in CssClassesToolControl.Context.CssColorTypes
                        select tut;

            foreach (var item in items)
            {
                if (item.Id >= _nextCssColorTypeId)
                {
                    _nextCssColorTypeId = item.Id + 1;
                }
            }
            return (_nextCssColorTypeId);
        }

        public int FindNextCssColorId()
        {
            var items = from tut in CssClassesToolControl.Context.CssColors
                        select tut;

            foreach (var item in items)
            {
                if (item.Id >= _nextCssColorId)
                {
                    _nextCssColorId = item.Id + 1;
                }
            }
            return (_nextCssColorId);
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            CssClassesToolControl.MainToolControl.SizeChanged += CurrentMainOnSizeChanged;
            var id = -1;
            if (CurrentCssStyle != null)
            {
                id = CurrentCssStyle.Id;
            }
            LoadStyleList();
        }

       

        private void CurrentMainOnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            OnPropertyChanged(nameof(FromHeight));
            OnPropertyChanged(nameof(FromWidth));
        }

        public void CreateStyle()
        {
            CurrentCssStyle = null;

            //  CurrentCssStyle = CssClassesToolControl.Context.CssStyles.Create();
            CurrentCssStyle = new CssStyle();

            CurrentCssStyle.Id = FindNextCssStyleId();
            _styleName = string.Format("StyleClass{0}", rand.Next(10000));

            OnPropertyChanged("StyleName");
            CurrentCssStyle.StyleName = _styleName;

            CssSettings = new CssItem();
            CssSettings.CssStyleId = CurrentCssStyle.Id;
            CssSettings.CurrentCssStyle = CurrentCssStyle;
            CssSettings.MaxWidth = TwoThirdWidth;
            CssClassesToolControl.Context.CssStyles.Add(CurrentCssStyle);
            CssClassesToolControl.Context.SaveChanges();
            CssStyleObservableCollection = new ObservableCollection<CssStyle>(CssClassesToolControl.Context.CssStyles);
        }

        public void FillAnimationList()
        {
            AnimationList.Items.Clear();

            var lm = from im in CssClassesToolControl.Context.CssAnimations
                     select im;


            foreach (var anm in lm)
            {
                var tbl = new TextBlock();
                tbl.Text = anm.AnimationName;
                tbl.Tag = anm.Id;
                AnimationList.Items.Add(tbl);
            }
        }

        public void LoadStyleList()
        {
            CssStyleObservableCollection = new ObservableCollection<CssStyle>(
                CssClassesToolControl.Context.CssStyles);
            if (CssStyleObservableCollection.Count > 0)
            {
                if (CurrentCssStyle == null || CssStyleObservableCollection.Contains(CurrentCssStyle) == false)
                {
                    CurrentCssStyle = CssStyleObservableCollection.First();
                }

                _styleName = CurrentCssStyle.StyleName;
                CssSettings = new CssItem();
                CssSettings.CssStyleId = CurrentCssStyle.Id;
                CssSettings.CurrentCssStyle = CurrentCssStyle;
                CssSettings.MaxWidth = TwoThirdWidth;
                LoadStyle();
                OnPropertyChanged("StyleName");
            }
            else
            {
                CreateStyle();
            }
            InvalidateVisual();
        }

        public void LoadStyle()
        {
            CssSettings = new CssItem();
            CssSettings.CssStyleId = CurrentCssStyle.Id;
            CssSettings.CurrentCssStyle = CurrentCssStyle;
            CssSettings.MaxWidth = TwoThirdWidth;
            CssSettings.LoadStyleItems();
            FillAnimationList();
        }

        private void CreateStyleButton_OnClick(object sender, RoutedEventArgs e)
        {
            CreateStyle();
        }

        private void DeleteStyleButton_OnClick(object sender, RoutedEventArgs e)
        {
            var deletecolor = new List<CssColor>();
            var deletecolortype = new List<CssColorType>();
            var deletestyleitem = new List<CssStyleItem>();

            foreach (var item in CurrentCssStyle.CssStyleItems)
            {
                foreach (var cty in item.CssColorTypes)
                {
                    foreach (var col in cty.CssColors)
                    {
                        deletecolor.Add(col);
                    }
                    deletecolortype.Add(cty);
                }
                deletestyleitem.Add(item);
            }

            foreach (var col in deletecolor)
            {
               CssClassesToolControl.Context.CssColors.Remove(col);
            }
            CssClassesToolControl.Context.SaveChanges();
            foreach (var cty in deletecolortype)
            {
                CssClassesToolControl.Context.CssColorTypes.Remove(cty);
            }
            CssClassesToolControl.Context.SaveChanges();
            foreach (var item in deletestyleitem)
            {
               CssClassesToolControl.Context.CssStyleItems.Remove(item);
            }
            CssClassesToolControl.Context.SaveChanges();
            CssClassesToolControl.Context.CssStyles.Remove(CurrentCssStyle);
            CssClassesToolControl.Context.SaveChanges();

            //  CreateStyle();
            LoadStyleList();
        }

        private void StyleNameListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                CurrentCssStyle = e.AddedItems[0] as CssStyle;
                _styleName = CurrentCssStyle.StyleName;
                OnPropertyChanged(nameof(StyleName));
                LoadStyle();
            }
        }

        private void ChooseStyleMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var chooseStyle = new ChooseStyle();
            chooseStyle.ChosenStyle = CurrentCssStyle;
            chooseStyle.CssStyleObservableCollection = CssStyleObservableCollection;
            chooseStyle.ShowDialog();
            if (chooseStyle.ChosenStyle != null)
            {
                CurrentCssStyle = chooseStyle.ChosenStyle;
                _styleName = CurrentCssStyle.StyleName;
                OnPropertyChanged(nameof(StyleName));
                LoadStyle();
            }
        }



        private void AnimationButton_OnClick(object sender, RoutedEventArgs e)
        {
            CssClassesToolControl.MainToolControl.ToCssAnimationPage();
        }

        public void ShowStyleText()
        {
            _buildCssForStyle.CurrentCssStyle = CurrentCssStyle;
            try
            {
                if (AnimationList.SelectedIndex >= 0 && UseWithAnimation.IsChecked == true)
                {
                    var cc = (int)(AnimationList.SelectedItem as TextBlock).Tag;
                    ShowCssText.Text = _buildCssForStyle.BuildStyle(cc);
                }
                else
                {
                    ShowCssText.Text = _buildCssForStyle.BuildStyle();
                }
            }
            catch (Exception ee)
            {
                ShowCssText.Text = ee.Message;
            }
        }

        private void ClipboardCopyButton_OnClick(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(ShowCssText.Text);
        }

        private void BuildStyleButton_OnClick(object sender, RoutedEventArgs e)
        {
            ShowStyleText();
        }

        private void ShowStyleButton_OnClick(object sender, RoutedEventArgs e)
        {
           // var fileGenerator = new FileGenerator();

            string style;
            if (AnimationList.SelectedIndex > 0 && UseWithAnimation.IsChecked == true)
            {
                var cc = (int)(AnimationList.SelectedItem as TextBlock).Tag;
                style = _buildCssForStyle.BuildStyle(cc);
            }
            else
            {
                style = _buildCssForStyle.BuildStyle();
            }

            string html = string.Empty;
            string title = _currentCssStyle.StyleName;
            
         //   html = "<!DOCTYPE html>\r\n";
            html = "<!DOCTYPE HTML PUBLIC \" -//W3C//DTD HTML 4.0 Transitional//EN\">";
            html += "<html lang = \"en\" xmlns = \"http://www.w3.org/1999/xhtml\">\r\n";
            html += "<head>\r\n";
            html += "<meta charset = \"utf-8\"/>\r\n";
            html += "<title>";
            html += _currentCssStyle.StyleName;
            html += "\r\n</title>\r\n";
            html += "<style>\r\n\r\n";
            html += style;
            html += "\r\n</style>\r\n";
            html += "</head>\r\n";
            html += "<body>\r\n";
            html += "<div class=\"";
            html += _currentCssStyle.StyleName;
            html += "\">\r\n";
            html += "<p>This is a test of the style ";
            html += _currentCssStyle.StyleName;
            html += "</p>";
            html += "</div>\r\n";
            html += "</body>\r\n";
            html += "</html>";

                

          CssClassesToolControl.OpenBrowserPage(html);
  //         BrowserWindow browserwindow = new BrowserWindow();
     //     browserwindow.SetBrowserText(html, title);
      //      browserwindow.ShowDialog();

        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


      

        private void ExportButton_OnClick(object sender, RoutedEventArgs e)
        {
            var chooseStyleGroup = new ChooseStyleGroup();

            chooseStyleGroup.CssStyleObservableCollection = CssStyleObservableCollection;
            chooseStyleGroup.ShowDialog();

           // CssStyle OriginalCssStyle = CurrentCssStyle;

            if (chooseStyleGroup.ChosenStyleGroup.Count > 0)
            {
                var dialog = new SaveFileDialog();
                dialog.Filter = "Css documents (.css)|*.css|All Files (*.*)|*.*";
                dialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                dialog.FileName = "CssStyle" + rand.Next(10000).ToString() + ".css";
                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                      
                        StreamWriter streamwriter = File.CreateText(dialog.FileName);
                        foreach (CssStyle st in chooseStyleGroup.ChosenStyleGroup)
                        {
                            _buildCssForStyle.CurrentCssStyle = st;
                            string txt = _buildCssForStyle.BuildStyle();
                            txt += "\r\n";
                            streamwriter.Write(txt);
                           
                        }
                        streamwriter.Flush();
                        streamwriter.Close();

                       
                        

                    }
                    catch (Exception ee)
                    {
                        string tt = ee.Message;
                    }
                }
            }
        }

        public string ExportData(out string fname)
        {
            var chooseStyleGroup = new ChooseStyleGroup();

            chooseStyleGroup.CssStyleObservableCollection = CssStyleObservableCollection;
            chooseStyleGroup.ShowDialog();
            fname = "CssStyle" + rand.Next(10000).ToString() + ".css";
            string cssbuffer = string.Empty;
         
            try
            {
                
                foreach (CssStyle st in chooseStyleGroup.ChosenStyleGroup)
                {
                    _buildCssForStyle.CurrentCssStyle = st;
                    string txt = _buildCssForStyle.BuildStyle();
                    txt += "\r\n";
                    cssbuffer += txt;

                }
            }
            catch (Exception ee)
            {
                string tt = ee.Message;
            }
            return (cssbuffer);
        }

        private void WriteFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            //   string style = _buildCssForStyle.BuildStyle();

            string style;
            if (AnimationList.SelectedIndex > 0 && UseWithAnimation.IsChecked == true)
            {
                var cc = (int)(AnimationList.SelectedItem as TextBlock).Tag;
                style = _buildCssForStyle.BuildStyle(cc);
            }
            else
            {
                style = _buildCssForStyle.BuildStyle();
            }
            var dialog = new SaveFileDialog();
            dialog.Filter = "Css documents (.css)|*.css|All Files (*.*)|*.*";
            dialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            dialog.FileName = CurrentCssStyle.StyleName + ".css";
            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, style);
            }
        }

        private void CopyStyleButton_OnClick(object sender, RoutedEventArgs e)
        {
            //var createdStyle = CssClassesToolControl.Context.CssStyles.Create();
            var createdStyle = new CssStyle();
            createdStyle.Id = FindNextCssStyleId();
            createdStyle.StyleName = "copyOf" + CurrentCssStyle.StyleName;
            CssClassesToolControl.Context.CssStyles.Add(createdStyle);
            CssClassesToolControl.Context.SaveChanges();

            foreach (var item in CurrentCssStyle.CssStyleItems)
            {
                //var createdItem = CssClassesToolControl.Context.CssStyleItems.Create();
                var createdItem = new CssStyleItem();

                createdItem.Id = FindNextCssStyleItemId();
                createdItem.CssStyleId = createdStyle.Id;
                createdItem.ItemName = item.ItemName;
                createdItem.ItemValue = item.ItemValue;
                createdItem.StyleOrder = item.StyleOrder;

                CssClassesToolControl.Context.CssStyleItems.Add(createdItem);
                CssClassesToolControl.Context.SaveChanges();

                foreach (var cty in item.CssColorTypes)
                {
                    //var createdColorType = CssClassesToolControl.Context.CssColorTypes.Create();
                    var createdColorType = new CssColorType();
                    createdColorType.Id = FindNextCssColorTypeId();
                    createdColorType.CssStyleItemId = createdItem.Id;
                    createdColorType.Shape = cty.Shape;
                    createdColorType.Size = cty.Size;
                    createdColorType.Repeats = cty.Repeats;
                    createdColorType.ColorType = cty.ColorType;
                    createdColorType.Angle = cty.Angle;
                    createdColorType.Center = cty.Center;
                    CssClassesToolControl.Context.CssColorTypes.Add(createdColorType);
                    CssClassesToolControl.Context.SaveChanges();

                    foreach (var col in cty.CssColors)
                    {
                        //    var createdColor = CssClassesToolControl.Context.CssColors.Create();
                        var createdColor = new CssColor();
                        createdColor.Id = FindNextCssColorId();
                        createdColor.CssColorTypeId = createdColorType.Id;
                        createdColor.ColorValue = col.ColorValue;
                        createdColor.Stop = col.Stop;
                        createdColor.ColorOrder = col.ColorOrder;
                        CssClassesToolControl.Context.CssColors.Add(createdColor);
                        CssClassesToolControl.Context.SaveChanges();
                    }
                }
            }


            //  CreateStyle();
            LoadStyleList();
        }

        private void AnimationList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UseWithAnimation.IsChecked == false)
            {
                UseWithAnimation.IsChecked = true;
            }
        }


        #region fields

        private int _nextCssStyleId = 1;
        private string _styleName;
        private readonly Random rand = new Random();
        private CssItem _cssSettings;
        private ObservableCollection<CssStyle> _cssStyleObservableCollection = new ObservableCollection<CssStyle>();
        private CssStyle _currentCssStyle;
        private readonly BuildCssForStyle _buildCssForStyle = new BuildCssForStyle();
        private double _fromHeight = 800.0;
        private double _fromWidth = 800.0;
        private int _nextCssStyleItemId = 1;
        private int _nextCssColorTypeId = 1;
        private int _nextCssColorId = 1;
        private double _thirdwidth;
        private double _twoThirdwidth;

        #endregion

        #region Properties

        public double FromHeight
        {
            get
            {
                _fromHeight = CssClassesToolControl.IsYsize;
                return _fromHeight;
            }
        }

        public double FromWidth
        {
            get
            {
                _fromWidth = CssClassesToolControl.IsXsize;
                return _fromWidth;
            }
        }

        public double ThirdWidth
        {
            get { return _thirdwidth; }
            set
            {
                _thirdwidth = value;
                OnPropertyChanged();
            }
        }

        public double TwoThirdWidth
        {
            get { return _twoThirdwidth; }
            set
            {
                _twoThirdwidth = value;
                OnPropertyChanged();
            }
        }

        public string StyleName
        {
            get { return _styleName; }
            set
            {
                if (value == _styleName) return;
                _styleName = value;
                CurrentCssStyle.StyleName = _styleName;
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public CssItem CssSettings
        {
            get { return _cssSettings; }
            set
            {
                if (Equals(value, _cssSettings)) return;
                _cssSettings = value;
                _cssSettings.ItemHead = "Style " + _styleName + " Settings";
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CssStyle> CssStyleObservableCollection
        {
            get { return _cssStyleObservableCollection; }
            set
            {
                if (Equals(value, _cssStyleObservableCollection)) return;
                _cssStyleObservableCollection = value;
                OnPropertyChanged();
            }
        }

        public CssStyle CurrentCssStyle
        {
            get { return _currentCssStyle; }
            set
            {
                _currentCssStyle = value;
                ShowStyleText();
            }
        }
        #endregion


        private void ReconnectButton_OnClick(object sender, RoutedEventArgs e)
        {
          //  Reconnect rr = new Reconnect();
          //  rr.ErrorMessage.Text = CssClassesToolControl.LastDbError;
        //    rr.ShowDialog();
//
        }

        private void ShowCssText_OnMouseEnter(object sender, MouseEventArgs e)
        {
            CssClassesToolControl.MainToolControl.UseCssControl.ShowStyleText();
        }

        private void ShowCssText_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
