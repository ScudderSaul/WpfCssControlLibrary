using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfCssControlLibrary.Model;


namespace WpfCssControlLibrary.Dialogs
{
    /// <summary>
    ///     Interaction logic for ChooseStyle.xaml
    /// </summary>
    public partial class ChooseStyle : Window
    {
        private ObservableCollection<CssStyle> _cssStyleObservableCollection;

        public ChooseStyle()
        {
            InitializeComponent();
        }

        public CssStyle ChosenStyle { get; set; }

        public ObservableCollection<CssStyle> CssStyleObservableCollection
        {
            get { return _cssStyleObservableCollection; }
            set
            {
                if (Equals(value, _cssStyleObservableCollection)) return;
                _cssStyleObservableCollection = value;
                foreach (var cssStyle in _cssStyleObservableCollection)
                {
                    if (cssStyle.Id == ChosenStyle.Id)
                    {
                        var bb = new Button
                        {
                            Width = 100.0,
                            Height = 30.0,
                            Margin = new Thickness(2.0),
                            Content = cssStyle.StyleName,
                            BorderBrush = new SolidColorBrush(Colors.Green),
                            BorderThickness = new Thickness(3.0),
                            Tag = cssStyle
                        };
                        bb.Click += ChooseStyleButton_OnClick;
                        ChooseWrapPanel.Children.Add(bb);
                    }
                    else
                    {
                        var bb = new Button();
                        bb.Width = 100.0;
                        bb.Height = 30.0;
                        bb.Margin = new Thickness(2.0);
                        bb.Content = cssStyle.StyleName;
                        bb.BorderBrush = new SolidColorBrush(Colors.Blue);
                        bb.BorderThickness = new Thickness(1.0);
                        bb.Tag = cssStyle;
                        bb.Click += ChooseStyleButton_OnClick;
                        ChooseWrapPanel.Children.Add(bb);
                    }
                }
            }
        }

        private void ChooseStyleButton_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                ChosenStyle = button.Tag as CssStyle;
                foreach (var ob in ChooseWrapPanel.Children)
                {
                    var bt = ob as Button;
                    bt.BorderBrush = new SolidColorBrush(Colors.Blue);
                    bt.BorderThickness = new Thickness(1.0);
                }
                button.BorderBrush = new SolidColorBrush(Colors.Green);
                button.BorderThickness = new Thickness(3.0);
            }
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}