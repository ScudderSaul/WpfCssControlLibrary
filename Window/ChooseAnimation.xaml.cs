using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfCssControlLibrary.Model;

namespace Css_Classes2019.Window
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ChooseAnimation : System.Windows.Window
    {
        private ObservableCollection<CssAnimation> _cssAnimationObservableCollection;

        public ChooseAnimation()
        {
            InitializeComponent();
        }

        public CssAnimation  ChosenAnimation { get; set; }

        public ObservableCollection<CssAnimation> CssAnimationObservableCollection
        {
            get { return _cssAnimationObservableCollection; }
            set
            {
                if (Equals(value, _cssAnimationObservableCollection)) return;
                _cssAnimationObservableCollection = value;
                foreach (var cssAnimation in _cssAnimationObservableCollection)
                {
                    if (cssAnimation.Id == ChosenAnimation.Id)
                    {
                        var bb = new Button
                        {
                            Width = 100.0,
                            Height = 30.0,
                            Margin = new Thickness(2.0),
                            Content = cssAnimation.AnimationName,
                            BorderBrush = new SolidColorBrush(Colors.Green),
                            BorderThickness = new Thickness(3.0),
                            Tag = cssAnimation
                        };
                        bb.Click += ChooseAnimationButton_OnClick;
                        ChooseWrapPanel.Children.Add(bb);
                    }
                    else
                    {
                        var bb = new Button();
                        bb.Width = 100.0;
                        bb.Height = 30.0;
                        bb.Margin = new Thickness(2.0);
                        bb.Content = cssAnimation.AnimationName;
                        bb.BorderBrush = new SolidColorBrush(Colors.Blue);
                        bb.BorderThickness = new Thickness(1.0);
                        bb.Tag = cssAnimation;
                        bb.Click += ChooseAnimationButton_OnClick;
                        ChooseWrapPanel.Children.Add(bb);
                    }
                }
            }
        }

    private void ChooseAnimationButton_OnClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            ChosenAnimation = button.Tag as CssAnimation;
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
