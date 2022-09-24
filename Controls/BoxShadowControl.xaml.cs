using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;


namespace WpfCssControlLibrary.Controls
{
    /// <summary>
    /// Interaction logic for BoxShadowControl.xaml
    /// </summary>
    public partial class BoxShadowControl : UserControl, INotifyPropertyChanged
    {

        #region fields
        private string _boxShadowHorizontalValue;
        private string _boxShadowVerticalValue;
        private string _boxShadowBlurDistanceValue;
        private string _boxShadowSpreadDistanceValue;
        private bool _boxShadowInsetValue;
        private System.Windows.Media.Color _boxShadowColor;
        private string _shadowLabel;
        private string _shadowString;

        #endregion
        public BoxShadowControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }   

        #region properties

        public string ShadowLabel
        {
            get { return _shadowLabel; }
            set
            {
                _shadowLabel = value;
                OnPropertyChanged();
            }
        }

        public string ShadowString
        {
            get
            {

                return _shadowString;
            }
            set
            {
                _shadowString = value;
                BoxShadowParse();
            }
        }

        public bool BoxShadowInsetValue
        {
            get { return _boxShadowInsetValue; }
            set
            {
                _boxShadowInsetValue = value;
                ComposeBoxShadowElement();
                OnPropertyChanged();
            }
        }

        public string BoxShadowHorizontalValue
        {
            get { return _boxShadowHorizontalValue; }
            set
            {
                int res;
                if (int.TryParse(value, out res))
                {

                    _boxShadowHorizontalValue = value;
                }
                else
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(BoxShadowVerticalValue))
                {
                    _boxShadowVerticalValue = "0";
                }
                ComposeBoxShadowElement();

                OnPropertyChanged();
                OnPropertyChanged(nameof(BoxShadowVerticalValue));
            }
        }

        public string BoxShadowVerticalValue
        {
            get { return _boxShadowVerticalValue; }
            set
            {
                int res;
                if (int.TryParse(value, out res))
                {

                    _boxShadowVerticalValue = value;
                }
                else
                {
                    return;
                }


                ComposeBoxShadowElement();
                OnPropertyChanged();
            }
        }

        public string BoxShadowBlurDistanceValue
        {
            get { return _boxShadowBlurDistanceValue; }
            set
            {
                int res;
                if (int.TryParse(value, out res))
                {

                    _boxShadowBlurDistanceValue = value;
                }
                else
                {
                    return;
                }

                OnPropertyChanged(nameof(BoxShadowBlurDistanceValue));
                ComposeBoxShadowElement();
            }
        }

        public string BoxShadowSpreadDistanceValue
        {
            get { return _boxShadowSpreadDistanceValue; }
            set
            {
                int res;
                if (int.TryParse(value, out res))
                {

                    _boxShadowSpreadDistanceValue = value;
                }
                else
                {
                    return;
                }

                OnPropertyChanged(nameof(BoxShadowSpreadDistanceValue));
                ComposeBoxShadowElement();
            }

        }

        public Color BoxShadowColor
        {
            get { return _boxShadowColor; }
            set { _boxShadowColor = value; }
        }

        #endregion

        #region methods
        public string ComposeBoxShadowElement()
        {
            try
            {
                string BoxShadowData = string.Empty;
                if (!string.IsNullOrWhiteSpace(BoxShadowHorizontalValue))
                {

                    if (BoxShadowInsetValue == true)
                    {
                        BoxShadowData += "inset ";
                    }

                    BoxShadowData = BoxShadowData + BoxShadowHorizontalValue + "px ";


                    if (string.IsNullOrWhiteSpace(BoxShadowVerticalValue) == true)
                    {
                        _boxShadowVerticalValue = "0";
                    }

                    BoxShadowData = BoxShadowData + BoxShadowVerticalValue + "px ";

                    if (!string.IsNullOrWhiteSpace(BoxShadowBlurDistanceValue))
                    {
                        BoxShadowData = BoxShadowData + BoxShadowBlurDistanceValue + "px ";
                    }
                    if (!string.IsNullOrWhiteSpace(BoxShadowSpreadDistanceValue))
                    {
                        BoxShadowData = BoxShadowData + BoxShadowSpreadDistanceValue + "px ";
                    }

                    BoxShadowData +=
                        (string.Format("rgba({0},{1},{2},{3,2:F})", BoxShadowColor.R, BoxShadowColor.G, BoxShadowColor.B,
                            ((double)BoxShadowColor.A)));

                    _shadowString = BoxShadowData;

                    OnPropertyChanged();
                    return (BoxShadowData);
                }
            }
            catch (Exception ee)
            {
                string kk = ee.Message;
                if (ee.InnerException != null)
                {
                    string jj = ee.InnerException.Message;
                }
            }


          
            return (string.Empty);
        }

        public void BoxShadowParse()
        {
          

            try
            {
                char[] delimiter = { ' ' };

                if (string.IsNullOrWhiteSpace(_shadowString))
                {
                    return;
                }

                _shadowString = ShadowString.Trim();
                string[] strs = ShadowString.Split(delimiter);
                int pos = 0;
                int cnt = 0;

                if (strs[pos] == "inset")
                {
                    _boxShadowInsetValue = true;
                    pos++;
                    cnt++;
                }
                int zz = 0;
                zz = strs[pos].Length - 2;
                strs[pos] = strs[pos].Substring(0, zz);
                _boxShadowHorizontalValue = strs[pos];
                pos++;
                cnt++;
                zz = strs[pos].Length - 2;
                strs[pos] = strs[pos].Substring(0, zz);
                _boxShadowVerticalValue = strs[pos];
                pos++;
                cnt++;

                int rem = strs.Count() - cnt;

                switch (rem)
                {
                    case 0:
                        return;

                    case 1:
                        if (strs[pos].Contains("rgba"))
                        {
                            ParseBoxShadowColor(strs[pos]);
                        }
                        break;
                    case 2:
                        zz = strs[pos].Length - 2;
                        strs[pos] = strs[pos].Substring(0, zz);
                        _boxShadowBlurDistanceValue = strs[pos];
                        pos++;
                        if (strs[pos].Contains("rgba"))
                        {
                            ParseBoxShadowColor(strs[pos]);

                        }
                        break;

                    case 3:
                        zz = strs[pos].Length - 2;
                        strs[pos] = strs[pos].Substring(0, zz);
                        _boxShadowBlurDistanceValue = strs[pos];
                        pos++;

                        zz = strs[pos].Length - 2;
                        strs[pos] = strs[pos].Substring(0, zz);
                        _boxShadowSpreadDistanceValue = strs[pos];
                        pos++;

                        ParseBoxShadowColor(strs[pos]);
                        break;
                }
            }
            catch (Exception ee)
            {
                string kk = ee.Message;
                if (ee.InnerException != null)
                {
                    string jj = ee.InnerException.Message;
                }

            }
        }

      private  void ParseBoxShadowColor(string strcolor)
        {
            // rgba(0, 0, 0, 0.00);
            string rgbaz = strcolor.Substring(6);
            int pind = rgbaz.IndexOf(")");
            string rgba = rgbaz.Remove(pind);
            char[] commaonly = { ',' };
            string[] colvals = rgba.Split(commaonly);
            //  Color.FromArgb()
            int rr, gg, bb, aaa;
            double aa;
            if (int.TryParse(colvals[0], out rr) == false)
            {
                rr = 0;
            }
            if (int.TryParse(colvals[1], out gg) == false)
            {
                gg = 0;
            }
            if (int.TryParse(colvals[2], out bb) == false)
            {
                bb = 0;
            }
            if (double.TryParse(colvals[3], out aa) == false)
            {
                aa = 0;
            }
            aaa = (int)aa;
            _boxShadowColor = System.Windows.Media.Color.FromArgb((byte)aaa, (byte)rr, (byte)gg, (byte)bb);
        }
        #endregion

        #region events

        private void InsetCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BoxShadowHorizontalValue))
            {
                BoxShadowHorizontalValue = "0";
            }
            if (string.IsNullOrWhiteSpace(BoxShadowVerticalValue))
            {
                BoxShadowVerticalValue = "0";
            }
            BoxShadowInsetValue = true;
        }

        private void InsetCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            BoxShadowInsetValue = false;
        }

        private void DeleteItemClick(object sender, RoutedEventArgs e)
        {
            Button bb = sender as Button;
            if (bb != null)
            {
                string st = bb.Tag as string;
                if (string.IsNullOrWhiteSpace(st) == false)
                {
                    switch (st)
                    {
                        case "BoxShadowHorizontal":
                            BoxShadowHorizontalValue = string.Empty;
                            ShadowString = string.Empty;
                            break;
                        case "ShadowVertical":
                            BoxShadowVerticalValue = string.Empty;
                            ShadowString = string.Empty;
                            break;
                        case "BoxShadowBlurDistance":
                            BoxShadowBlurDistanceValue = string.Empty;
                            break;
                        case "BoxShadowSpreadDistance":
                            BoxShadowSpreadDistanceValue = string.Empty;
                            break;

                    }
                }

            }

        }

        public void ShadowColorSelected(object sender, EventArgs e)
        {
            var shadowPicker = sender as ColorPicker;
            BoxShadowColor = shadowPicker.SelectedColor;
            ComposeBoxShadowElement();
        }

       public Popup Boxshadowpopup;

        private void BoxShadowColorButton_OnClick(object sender, RoutedEventArgs e)
        {

            Boxshadowpopup = new Popup();
            ColorPicker picker = new ColorPicker();
            picker.RaiseSelection += ShadowColorSelected;

            picker.SelectedColor = BoxShadowColor;
            Boxshadowpopup.Child = picker;

            Boxshadowpopup.IsOpen = true;

        }

        public event PropertyChangedEventHandler PropertyChanged;

      //  [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

     
        #endregion
    }
}
