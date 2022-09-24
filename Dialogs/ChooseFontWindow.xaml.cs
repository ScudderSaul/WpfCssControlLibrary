using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;


namespace WpfCssControlLibrary.Dialogs
{
    /// <summary>
    /// Interaction logic for ChooseFontWindow.xaml
    /// </summary>
    public partial class ChooseFontWindow : Window, INotifyPropertyChanged
    {
        private List<string> _fontFamilyNames = new List<string>
        {
            "Arial, \"Helvetica Neue\", Helvetica, sans-serif",
            "\"Arial Black\", \"Arial Bold\", Gadget, sans-serif",
            "\"Arial Narrow\", Arial, sans-serif",
            "\"Arial Rounded MT Bold\", \"Helvetica Rounded\", Arial, sans-serif",
            "\"Avant Garde\", Avantgarde, \"Century Gothic\", CenturyGothic, \"AppleGothic\", sans-serif",
            "Calibri, Candara, Segoe, \"Segoe UI\", Optima, Arial, sans-serif",
            "Candara, Calibri, Segoe, \"Segoe UI\", Optima, Arial, sans-serif",
            "\"Century Gothic\", CenturyGothic, AppleGothic, sans-serif",
            "\"Franklin Gothic Medium\", \"Franklin Gothic\", \"ITC Franklin Gothic\", Arial, sans-serif",
            "Futura, \"Trebuchet MS\", Arial, sans-serif",
            "Geneva, Tahoma, Verdana, sans-serif",
            "\"Gill Sans\", \"Gill Sans MT\", Calibri, sans-serif",
            "\"Helvetica Neue\", Helvetica, Arial, sans-serif",
            "Impact, Haettenschweiler, \"Franklin Gothic Bold\", Charcoal, \"Helvetica Inserat\", \"Bitstream Vera Sans Bold\", \"Arial Black\", sans serif",
            "\"Lucida Grande\", \"Lucida Sans Unicode\", \"Lucida Sans\", Geneva, Verdana, sans-serif",
            "Optima, Segoe, \"Segoe UI\", Candara, Calibri, Arial, sans-serif",
            "\"Segoe UI\", Frutiger, \"Frutiger Linotype\", \"Dejavu Sans\", \"Helvetica Neue\", Arial, sans-serif",
            "Tahoma, Verdana, Segoe, sans-serif",
            "\"Trebuchet MS\", \"Lucida Grande\", \"Lucida Sans Unicode\", \"Lucida Sans\", Tahoma, sans-serif",
            "Verdana, Geneva, sans-serif",
            "Baskerville, \"Baskerville Old Face\", \"Hoefler Text\", Garamond, \"Times New Roman\", serif",
            "\"Big Caslon\", \"Book Antiqua\", \"Palatino Linotype\", Georgia, serif",
            "\"Bodoni MT\", Didot, \"Didot LT STD\", \"Hoefler Text\", Garamond, \"Times New Roman\", serif",
            "\"Book Antiqua\", Palatino, \"Palatino Linotype\", \"Palatino LT STD\", Georgia, serif",
            "\"Calisto MT\", \"Bookman Old Style\", Bookman, \"Goudy Old Style\", Garamond, \"Hoefler Text\", \"Bitstream Charter\", Georgia, serif",
            "Cambria, Georgia, serif",
            "Didot, \"Didot LT STD\", \"Hoefler Text\", Garamond, \"Times New Roman\", serif",
            "Garamond, Baskerville, \"Baskerville Old Face\", \"Hoefler Text\", \"Times New Roman\", serif",
            "Georgia, Times, \"Times New Roman\", serif",
            "\"Goudy Old Style\", Garamond, \"Big Caslon\", \"Times New Roman\", serif",
            "\"Hoefler Text\", \"Baskerville old face\", Garamond, \"Times New Roman\", serif",
            "\"Lucida Bright\", Georgia, serif",
            "Palatino, \"Palatino Linotype\", \"Palatino LT STD\", \"Book Antiqua\", Georgia, serif",
            "Perpetua, Baskerville, \"Big Caslon\", \"Palatino Linotype\", Palatino, \"URW Palladio L\", \"Nimbus Roman No9 L\", serif",
            "Rockwell, \"Courier Bold\", Courier, Georgia, Times, \"Times New Roman\", serif",
            "\"Rockwell Extra Bold\", \"Rockwell Bold\", monospace",
            "TimesNewRoman, \"Times New Roman\", Times, Baskerville, Georgia, serif",
            "\"Andale Mono\", AndaleMono, monospace",
            "Consolas, monaco, monospace",
            "\"Courier New\", Courier, \"Lucida Sans Typewriter\", \"Lucida Typewriter\", monospace",
            "\"Lucida Console\", \"Lucida Sans Typewriter\", Monaco, \"Bitstream Vera Sans Mono\", monospace",
            "\"Avant Garde\", Avantgarde, \"Century Gothic\", CenturyGothic, \"AppleGothic\", sans-serif",
            "Monaco, Consolas, \"Lucida Console\", monospace",
            "Papyrus, fantasy",
            "\"Brush Script MT\", cursive",
            "Copperplate, \"Copperplate Gothic Light\", fantasy"
        };

        private string _fontSelected;


        public ChooseFontWindow()
        {
            InitializeComponent();
            this.DataContext = this;
          
            Loaded += ChooseFontWindow_Loaded;
        }


        #region properties


        public string FontSelected
        {
            get { return _fontSelected; }
            set
            {
                if (value == _fontSelected) return;
                _fontSelected = value;
                OnPropertyChanged();
            }
        }

        

        //public string CssFontString
        //{
        //    get
        //    {
        //        string cssfont = string.Empty;
        //        cssfont += ".Mungles{" ;
        //        if (string.IsNullOrWhiteSpace(FontSelected) == false)
        //        {
        //            cssfont += string.Format("font-family:{0};\r\n", FontSelected);
        //        }
        //        if (string.IsNullOrWhiteSpace(CssFontSize) == false)
        //        {
        //            cssfont += string.Format("font-size:{0}%;\r\n", CssFontSize);
        //        }
        //        if (string.IsNullOrWhiteSpace(CssFontStyle) == false)
        //        {
        //            cssfont += string.Format("font-style:{0};\r\n", CssFontStyle);
        //        }
        //        if (string.IsNullOrWhiteSpace(CssFontWeight) == false)
        //        {
        //            cssfont += string.Format("font-weight:{0};\r\n", CssFontWeight);
        //        }
        //        if (string.IsNullOrWhiteSpace(CssFontVariant) == false)
        //        {
        //            cssfont += string.Format("font-variant:{0};\r\n", CssFontVariant);
        //        }
        //        cssfont+= "}\r\n";
        //        cssfont += "\r\n";
        //        return (cssfont);
        //    }
            
        //}

     

        #endregion

        #region events

        private void ChooseFontWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string st in _fontFamilyNames)
            {
                Button fontButton = new Button();
                TextBlock block = new TextBlock();
                block.Text = st;
                block.MaxWidth = 200;
                block.FontSize = 9;
                block.Margin = new Thickness(2.0);
                fontButton.Margin = new Thickness(2.0);
                fontButton.Content = block;
                
                fontButton.Click += FontButtonOnClick;
                WrapFonts.Children.Add(fontButton);
            }
        }

        private void FontButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Button fontButton = sender as Button;
            if (fontButton != null)
            {
                TextBlock block = fontButton.Content as TextBlock;
                if (block != null)
                {
                    FontSelected = block.Text;
                  //  ChosenFont.Text = block.Text;
                }
            }
        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            
            this.DialogResult = false;
            this.Close();
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

   
    }

   
}
