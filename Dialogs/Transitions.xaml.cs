using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using WpfCssControlLibrary.Controls;
using WpfCssControlLibrary.Model;


namespace WpfCssControlLibrary.Dialogs
{
    /// <summary>
    ///     Interaction logic for Transitions.xaml
    /// </summary>
    public partial class Transitions : Window, INotifyPropertyChanged
    {
        private int _nextCssTransitionId = 1;
        private CssStyle _nowCssStyle;

        public Transitions()
        {
            InitializeComponent();
            Transitionsdata = new ObservableCollection<TransitionWraper>();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void LoadTransitions()
        {
            var trans = from tr in CssClassesToolControl.Context.CssTransitions
                where tr.CssStyleId == NowCssStyle.Id
                select tr;

            Transitionsdata.Clear();
            foreach (var tran in trans)
            {
                Transitionsdata.Add(new TransitionWraper(tran));
            }
            ResetShow();
            ShowTransitionsGrid.ItemsSource = Transitionsdata;
            ShowTransitionsGrid.HeadersVisibility = DataGridHeadersVisibility.All;
            ShowTransitionsGrid.InvalidateMeasure();
        }

        public int FindNextCssTransitionId()
        {
            var items = from tut in CssClassesToolControl.Context.CssTransitions
                select tut;

            foreach (var item in items)
            {
                if (item.Id >= _nextCssTransitionId)
                {
                    _nextCssTransitionId = item.Id + 1;
                }
            }
            return (_nextCssTransitionId);
        }

        private CssTransition TransitionExists(string name)
        {
            foreach (var tran in Transitionsdata)
            {
                if (tran.Name == name)
                {
                    return (tran.GetTransition());
                }
            }
            return (null);
        }

        private void ResetShow()
        {
            PropertyBox.SelectedIndex = -1;
            DurationBox.Text = string.Empty;
            DelayBox.Text = string.Empty;
            TimingFunctionBox.SelectedIndex = -1;
        }

        private void AddTransitionButton_OnClick(object sender, RoutedEventArgs e)
        {
            //  TransitionWraper transitionWraper = new TransitionWraper();

            var aname = string.Empty;
            var adelay = string.Empty;
            var atiming = string.Empty;
            var aduration = string.Empty;

            if (PropertyBox.SelectedIndex >= 0)
            {
                aname = (PropertyBox.SelectedItem as TextBlock).Text;
                int duration;
                if (int.TryParse(DurationBox.Text, out duration))
                {
                    aduration = duration.ToString();
                    if (TimingFunctionBox.SelectedIndex >= 0)
                    {
                        atiming = (TimingFunctionBox.SelectedItem as TextBlock).Text;
                        int delay;
                        if (int.TryParse(DelayBox.Text, out delay))
                        {
                            adelay = delay.ToString();
                            // all there now was one there already
                            var atran = TransitionExists(aname);
                            if (atran == null)
                            {
                               // atran = CssClassesToolControl.Context.CssTransitions.Create();
                                atran = new CssTransition();
                                atran.Id = FindNextCssTransitionId();
                                atran.CssStyleId = NowCssStyle.Id;
                                atran.PropertyName = aname;
                                atran.Delay = adelay;
                                atran.Duration = aduration;
                                atran.TimingFunction = atiming;
                                CssClassesToolControl.Context.CssTransitions.Add(atran);
                                CssClassesToolControl.Context.SaveChanges();
                            }
                            else
                            {
                                atran.Delay = adelay;
                                atran.Duration = aduration;
                                atran.TimingFunction = atiming;
                                CssClassesToolControl.Context.SaveChanges();
                            }
                        }
                    }
                }
            }
            LoadTransitions();
            InvalidateVisual();
        }

        private void RemoveTransitionButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (PropertyBox.SelectedIndex >= 0)
            {
                var name = (PropertyBox.SelectedItem as TextBlock).Text;
                var atran = TransitionExists(name);
                if (atran != null)
                {
                    CssClassesToolControl.Context.CssTransitions.Remove(atran);
                    CssClassesToolControl.Context.SaveChanges();
                }
            }
            LoadTransitions();
            InvalidateVisual();
        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

      
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ShowTransitionsGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShowTransitionsGrid.SelectedItem != null)
            {
                var tranwrap = ShowTransitionsGrid.SelectedItem as TransitionWraper;
                if (tranwrap != null)
                {
                    foreach (var vv in PropertyBox.Items)
                    {
                        var st = (vv as TextBlock).Text;
                        if (st == tranwrap.Name)
                        {
                            PropertyBox.SelectedItem = vv;
                        }
                    }
                    DurationBox.Text = tranwrap.Duration;
                    DelayBox.Text = tranwrap.Delay;
                    foreach (var rr in TimingFunctionBox.Items)
                    {
                        var st = (rr as TextBlock).Text;
                        if (st == tranwrap.Timing)
                        {
                            TimingFunctionBox.SelectedItem = rr;
                        }
                    }
                }
            }
        }

        #region properties

        public ObservableCollection<TransitionWraper> Transitionsdata { get; set; }

        public CssStyle NowCssStyle
        {
            get { return _nowCssStyle; }
            set
            {
                _nowCssStyle = value;
                if (_nowCssStyle != null)
                {
                    LoadTransitions();
                }
            }
        }

        #endregion
    }

    public class TransitionWraper : INotifyPropertyChanged
    {
        public TransitionWraper(CssTransition tran)
        {
            Tran = tran;
        }

        private CssTransition Tran { get; set; }

        public string Name
        {
            get { return Tran.PropertyName; }
            set
            {
                if (value == Tran.PropertyName) return;
                Tran.PropertyName = value;
                OnPropertyChanged1();
            }
        }

        public string Delay
        {
            get { return Tran.Delay; }
            set
            {
                if (value == Tran.Delay) return;
                Tran.Delay = value;
                OnPropertyChanged1();
            }
        }

        public string Duration
        {
            get { return Tran.Duration; }
            set
            {
                if (value == Tran.Duration) return;
                Tran.Duration = value;
                OnPropertyChanged1();
            }
        }

        public string Timing
        {
            get { return Tran.TimingFunction; }
            set
            {
                if (value == Tran.TimingFunction) return;
                Tran.TimingFunction = value;
                OnPropertyChanged1();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CssTransition GetTransition()
        {
            return (Tran);
        }


        protected virtual void OnPropertyChanged1([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}