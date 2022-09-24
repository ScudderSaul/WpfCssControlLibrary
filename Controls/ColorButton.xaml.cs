using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using WpfCssControlLibrary.Model;


namespace WpfCssControlLibrary.Controls
{
    /// <summary>
    ///     Interaction logic for ColorButton.xaml
    /// </summary>
    public partial class ColorButton : UserControl, INotifyPropertyChanged
    {
        #region ctor

        public ColorButton()
        {
            InitializeComponent();
            DataContext = this;
        }

        #endregion

        #region Dependency Properties

        public static readonly DependencyProperty IsChosenColorProperty =
            DependencyProperty.Register(
                "IsChosenColor",
                typeof (Color),
                typeof (ColorButton), new FrameworkPropertyMetadata(Colors.Black,
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null)
                );


        public Color ChosenColor
        {
            get { return (Color) GetValue(IsChosenColorProperty); }
            set
            {
                SetValue(IsChosenColorProperty, value);
                var abrush = new SolidColorBrush(value);
                ColorRectangle.Fill = abrush;
                OnPropertyChanged("ChosenColor");
            }
        }

        public static readonly DependencyProperty IsButtonTextProperty =
            DependencyProperty.Register(
                "IsButtonText",
                typeof (string),
                typeof (ColorButton), new FrameworkPropertyMetadata("none",
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null)
                );

        public string ButtonText
        {
            get { return (string) GetValue(IsButtonTextProperty); }
            set
            {
                SetValue(IsButtonTextProperty, value);
                TextShown.Text = value;
                OnPropertyChanged("ButtonText");
            }
        }

        public CssColor InCssColor { get; set; }

        #endregion

        #region events

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ColorSelected(object sender, EventArgs e)
        {
            var colorPicker = sender as ColorPicker;
            ChosenColor = colorPicker.SelectedColor;

            InCssColor.ColorValue = ChosenColor.ToString();
            CssClassesToolControl.Context.SaveChanges();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var colorpopup = new Popup();
            var colorPicker = new ColorPicker();
            colorPicker.SelectedColor = ChosenColor;
            colorPicker.RaiseSelection += ColorSelected;
            colorpopup.Child = colorPicker;

            colorpopup.VerticalOffset = 300;

            colorpopup.IsOpen = true;
        }

        #endregion
    }
}