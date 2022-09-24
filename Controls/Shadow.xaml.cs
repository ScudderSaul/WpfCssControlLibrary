using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using WpfCssControlLibrary.Model;

namespace WpfCssControlLibrary.Controls
{
    /// <summary>
    /// Interaction logic for Shadow.xaml
    /// </summary>
    public partial class Shadow : UserControl, INotifyPropertyChanged
    {

        #region fields
        private int _nextCssStyleItemId;
        private string _boxShadowData = string.Empty;
        private int? _cssStyleId;
        private CssStyle _currentCssStyle;

        #endregion

        public Shadow()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += Shadow_Loaded;
        }     

        public CssStyleItem BoxShadow { get; set; }

        public int? CssStyleId
        {
            get { return _cssStyleId; }
            set
            {
                _cssStyleId = value;
            }
        }

        public CssStyle CurrentCssStyle
        {
            get { return _currentCssStyle; }
            set
            {
                _currentCssStyle = value;
            }
        }
        public int? CssAnimationId { get; set; }

        public CssAnimation CurentCssAnimation { get; set; }

        public int? CurrentAnimationOrder { get; set; }


        private void AddShadow(string shadow)
        {
            if(string.IsNullOrEmpty(_boxShadowData))
            {
                _boxShadowData = shadow;
            }
        else
            {
                _boxShadowData += ", ";
                _boxShadowData += shadow;
            }
        }


        public int FindNextCssStyleItemId()
        {
            var items = from tut in CssClassesToolControl.Context.CssStyleItems
                        select tut;

            if (_nextCssStyleItemId <= 0)
            {
                _nextCssStyleItemId = 1;
            }

            foreach (var item in items)
            {
                if (item.Id >= _nextCssStyleItemId)
                {
                    _nextCssStyleItemId = item.Id + 1;
                }
            }
            return (_nextCssStyleItemId);
        }

        private void ComposeBoxShadows()
        {

            
            if (string.IsNullOrWhiteSpace(FirstShadowControl.ShadowString) == false)
            {
                AddShadow(FirstShadowControl.ShadowString);
                
            }
            if (string.IsNullOrWhiteSpace(SecondShadowControl.ShadowString) == false)
            {
                AddShadow(SecondShadowControl.ShadowString);

            }
            if (string.IsNullOrWhiteSpace(ThirdShadowControl.ShadowString) == false)
            {
                AddShadow(ThirdShadowControl.ShadowString);

            }
            if (string.IsNullOrWhiteSpace(FourthShadowControl.ShadowString) == false)
            {
                AddShadow(FourthShadowControl.ShadowString);

            }

            if (BoxShadow == null)
                {
                    BoxShadow = new CssStyleItem();

                    BoxShadow.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BoxShadow.CssStyleId = CssStyleId;
                        BoxShadow.ItemName = "box-shadow";
                        BoxShadow.ItemValue = _boxShadowData;
                        CssClassesToolControl.Context.CssStyleItems.Add(BoxShadow);
                    }
                    if (CssAnimationId != null)
                    {
                        BoxShadow.CssAnimationId = CssAnimationId;
                        BoxShadow.ItemName = "box-shadow";
                        BoxShadow.StyleOrder = CurrentAnimationOrder;
                        BoxShadow.ItemValue = _boxShadowData;
                        CssClassesToolControl.Context.CssStyleItems.Add(BoxShadow);
                    }
                }
                else
                {
                    BoxShadow.ItemValue = _boxShadowData;
                }
                CssClassesToolControl.Context.SaveChanges();

           
        }

        private void Shadow_Loaded(object sender, RoutedEventArgs e)
        {
            FirstShadowControl.ShadowLabel = "First Shadow";
            SecondShadowControl.ShadowLabel = "Second Shadow";
            ThirdShadowControl.ShadowLabel = "Third Shadow";
            FourthShadowControl.ShadowLabel = "Fourth Shadow";
        }

        public void FindShadows()
        {
            try
            {
                var boxshadows = from cc in CssClassesToolControl.Context.CssStyleItems
                                 where cc.ItemName == "box-shadow" && cc.CssStyleId == CssStyleId
                                 select cc;

                if (boxshadows.Count() > 0)
                {
                    BoxShadow = boxshadows.ToList().First();
                    ShadowParse();
                }
            }
            catch (Exception ee)
            {
                string qq = ee.Message;
                if (ee.InnerException != null)
                {
                    string jj = ee.InnerException.Message;
                }

            }
           
        }


      public  void ShadowParse()
        {
            

          try
          {
                char[] delimiter = { ',' };

                string[] shadows = BoxShadow.ItemValue.Split(delimiter);
              
              int nn = shadows.Length;
              if (nn > 0)
              {
                  FirstShadowControl.ShadowString = shadows[0];
              }
              if (nn > 1)
              {
                  SecondShadowControl.ShadowString = shadows[1];
              }
                if (nn > 2)
                {
                    ThirdShadowControl.ShadowString = shadows[2];
                }
                if (nn > 3)
                {
                    FourthShadowControl.ShadowString = shadows[3];
                }

            }
          catch (Exception ee)
          {
              string qq = ee.Message;
                if (ee.InnerException != null)
                {
                    string jj = ee.InnerException.Message;
                }
            }
        }

        private void DoneButton_OnClick(object sender, RoutedEventArgs e)
        {
            ComposeBoxShadows();
            if (FirstShadowControl.Boxshadowpopup != null)
            {
                FirstShadowControl.Boxshadowpopup.IsOpen = false;

            }
            if (SecondShadowControl.Boxshadowpopup != null)
            {
                SecondShadowControl.Boxshadowpopup.IsOpen = false;
            }
            if (ThirdShadowControl.Boxshadowpopup != null)
            {
                ThirdShadowControl.Boxshadowpopup.IsOpen = false;
            }
            if (FourthShadowControl.Boxshadowpopup != null)
            {
                FourthShadowControl.Boxshadowpopup.IsOpen = false;
            }
            (Parent as Popup).IsOpen = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

       // [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
