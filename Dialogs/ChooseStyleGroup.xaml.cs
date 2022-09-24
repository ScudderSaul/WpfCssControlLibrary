using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfCssControlLibrary.Model;


namespace WpfCssControlLibrary.Dialogs
{
    /// <summary>
    /// Interaction logic for ChooseStyleGroup.xaml
    /// </summary>
    public partial class ChooseStyleGroup : Window
    {

        private ObservableCollection<CssStyle> _cssStyleObservableCollection;
        private List<CssStyle> _chosenStyleGroup = new List<CssStyle>();


        public ChooseStyleGroup()
        {
            InitializeComponent();
            ChosenStyleGroup = new List<CssStyle>();
        }


        public List<CssStyle> ChosenStyleGroup
        {
            get { return _chosenStyleGroup; }
            set { _chosenStyleGroup = value; }
        }

        public ObservableCollection<CssStyle> CssStyleObservableCollection
        {
            get { return _cssStyleObservableCollection; }
            set
            {
                if (Equals(value, _cssStyleObservableCollection)) return;
                _cssStyleObservableCollection = value;
                foreach (var cssStyle in _cssStyleObservableCollection)
                {
                        var bb = new CheckBox()
                        {
                            Width = 100.0,
                            Height = 30.0,
                            Margin = new Thickness(2.0),
                            Content = cssStyle.StyleName,
                            BorderBrush = new SolidColorBrush(Colors.Blue),
                            BorderThickness = new Thickness(1.0),
                            Tag = cssStyle
                        };
                    bb.Checked += CheckStyle;
                    bb.Unchecked += UnCheckStyle;
                    ChooseWrapPanel.Children.Add(bb);
                   
                }
            }
        }

        private void CheckStyle(object sender, RoutedEventArgs e)
        {
            var check = sender as CheckBox;
            if (check != null)
            {

                ChosenStyleGroup.Add(check.Tag as CssStyle);
            }
        }

        private void UnCheckStyle(object sender, RoutedEventArgs e)
        {
            var check = sender as CheckBox;
            if (check != null)
            {

                ChosenStyleGroup.Remove(check.Tag as CssStyle);
            }
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
