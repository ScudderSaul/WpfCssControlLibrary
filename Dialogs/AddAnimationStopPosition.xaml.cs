using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;


namespace WpfCssControlLibrary.Dialogs
{
    /// <summary>
    ///     Interaction logic for AddAnimationStopPosition.xaml
    /// </summary>
    public partial class AddAnimationStopPosition : Window, INotifyPropertyChanged
    {
        private int _fromStop;
        private string _toStopText = string.Empty;

        public AddAnimationStopPosition()
        {
            InitializeComponent();
            DataContext = this;
            ToStopText = "1";
        }

        public List<int> CurrentStops { get; set; } = new List<int>();

        public int FromStop
        {
            get { return _fromStop; }
            set
            {
                _fromStop = value;
                FromStopText.Text = string.Format("{0} %", _fromStop);
            }
        }

        public int ToStop { get; set; }

        public string ToStopText
        {
            get { return _toStopText; }
            set
            {
                if (value == _toStopText) return;

                int tt;
                if (int.TryParse(value, out tt))
                {
                    if (tt >= 1 && tt <= 99 && CurrentStops.Contains(tt) == false)
                    {
                        _toStopText = value;
                        ToStop = tt;
                        OnPropertyChanged();
                    }
                    else
                    {
                        MessageBox.Show("The new Animation Stop must be between 1 and 99 and unique");
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

       
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}