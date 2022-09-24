using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using WpfCssControlLibrary.Dialogs;
using WpfCssControlLibrary.Model;

using Microsoft.Win32;

//using GenerateFiles;

namespace WpfCssControlLibrary.Controls
{
    /// <summary>
    /// Interaction logic for CssAnimationBuildControl.xaml
    /// </summary>
    public partial class CssAnimationBuildControl : UserControl, INotifyPropertyChanged
    {
        private readonly BuildCssForStyle _buildCssForStyle = new BuildCssForStyle();
        private string _animationDelay;
        private string _animationDirection;
        private string _animationDuration;
        private string _animationFillMode;
        private string _animationIterationCount;
        private string _animationName;
        private string _animationPlayState;
        private string _animationTimingFunction;

        private ObservableCollection<CssAnimation> _cssAnimationsObservableCollection =
            new ObservableCollection<CssAnimation>();

        private CssKeyFrameItem _cssSettings;
        private int _currentPercent;
        private double _fromHeight = 800.0;
        private double _fromWidth = 800.0;
        private int _nextCssAnimationId = 1;
        private int _nextCssColorId = 1;
        private int _nextCssColorTypeId = 1;
        private int _nextCssStyleItemId = 1;


        public CssAnimationBuildControl()
        {
            InitializeComponent();
            DataContext = this;

            Loaded += AnimationPage_Loaded;
        }

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

        private void AnimationPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAnimations();
        }

        #region properties

        public string AnimationName
        {
            get { return _animationName; }
            set
            {
                if (value == _animationName) return;
                _animationName = value;
                if (CurrentAnimation == null)
                {
                    return;
                }
                if (BlockDataChange == false)
                {
                    CurrentAnimation.AnimationName = value;
                    CssClassesToolControl.Context.SaveChanges();
                }
                OnPropertyChanged();
            }
        }


        private ObservableCollection<CssAnimation> CssAnimationsObservableCollection
        {
            get { return _cssAnimationsObservableCollection; }
            set
            {
                if (Equals(value, _cssAnimationsObservableCollection)) return;
                _cssAnimationsObservableCollection = value;

                OnPropertyChanged();
            }
        }

        public CssAnimation CurrentAnimation { get; set; }


        public string AnimationDuration
        {
            get { return _animationDuration; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }

                if (value == _animationDuration) return;
                var numb = 0;
                if (int.TryParse(value, out numb) == false)
                {
                    return;
                }
                if (CurrentAnimation == null)
                {
                    return;
                }


                _animationDuration = value;
                if (BlockDataChange == false)
                {
                    CurrentAnimation.AnimationDuration = value;
                    CssClassesToolControl.Context.SaveChanges();
                }

                OnPropertyChanged();
            }
        }

        public string AnimationDelay
        {
            get { return _animationDelay; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                if (value == _animationDelay) return;
                var numb = 0;
                if (int.TryParse(value, out numb) == false)
                {
                    return;
                }
                if (CurrentAnimation == null)
                {
                    return;
                }
                _animationDelay = value;
                if (BlockDataChange == false)
                {
                    CurrentAnimation.AnimationDelay = value;
                    CssClassesToolControl.Context.SaveChanges();
                }
                OnPropertyChanged();
            }
        }

        public string AnimationTimingFunction
        {
            get { return _animationTimingFunction; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                if (CurrentAnimation == null)
                {
                    return;
                }
                foreach (TextBox item in TimingFunctionBox.Items)
                {
                    if (item.Text == value)
                    {
                        TimingFunctionBox.SelectedItem = item;
                    }
                }

                _animationTimingFunction = value;
            }
        }

        public string AnimationIterationCount
        {
            get { return _animationIterationCount; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                if (value == "infinite")
                {
                    // InfiniteCheck.IsChecked = true;
                }
                else
                {
                    var numb = 0;
                    if (int.TryParse(value, out numb) == false)
                    {
                        return;
                    }
                }
                if (CurrentAnimation == null)
                {
                    return;
                }
                _animationIterationCount = value;
                if (BlockDataChange == false)
                {
                    CurrentAnimation.AnimationIterationCount = value;
                    CssClassesToolControl.Context.SaveChanges();
                }

                OnPropertyChanged();
            }
        }

        public string AnimationDirection
        {
            get { return _animationDirection; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                if (CurrentAnimation == null)
                {
                    return;
                }
                foreach (TextBlock item in DirectionBox.Items)
                {
                    if (item.Text == value)
                    {
                        DirectionBox.SelectedItem = item;
                    }
                }
                _animationDirection = value;
            }
        }

        public string AnimationPlayState
        {
            get { return _animationPlayState; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                if (CurrentAnimation == null)
                {
                    return;
                }
                foreach (TextBox item in PlayStateBox.Items)
                {
                    if (item.Text == value)
                    {
                        PlayStateBox.SelectedItem = item;
                    }
                }
                _animationPlayState = value;
            }
        }

        public string AnimationFillMode
        {
            get { return _animationFillMode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                if (CurrentAnimation == null)
                {
                    return;
                }
                foreach (TextBox item in FillModeBox.Items)
                {
                    if (item.Text == value)
                    {
                        FillModeBox.SelectedItem = item;
                    }
                }

                _animationFillMode = value;
            }
        }

        public bool BlockDataChange { get; set; }

        public List<CssStyleItem> CurrentCssStyleItems { get; set; }

        public CssKeyFrameItem CssSettings
        {
            get { return _cssSettings; }
            set
            {
                if (Equals(value, _cssSettings))
                {
                    _cssSettings.ItemHead = string.Format("Animation {0} at {1} % Settings", AnimationName,
                        _currentPercent);
                }
                _cssSettings = value;
                _cssSettings.ItemHead = string.Format("Animation {0} at {1} % Settings", AnimationName, _currentPercent);
                OnPropertyChanged();
            }
        }

        private int CurrentPercent
        {
            get { return _currentPercent; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _currentPercent = value;
                    StopKeyPercent.Text = string.Format("Editing settings for position at {0} %", _currentPercent);

                    OnPropertyChanged();
                }
            }
        }

        public List<int> PercentList { get; set; } = new List<int>();

        #endregion

        #region methods

        public void Load()
        {
            BlockDataChange = true;

            AnimationDelay = CurrentAnimation.AnimationDelay;
            AnimationName = CurrentAnimation.AnimationName;
            AnimationDirection = CurrentAnimation.AnimationDirection;
            AnimationDuration = CurrentAnimation.AnimationDuration;
            AnimationFillMode = CurrentAnimation.AnimationFillMode;
            AnimationIterationCount = CurrentAnimation.AnimationIterationCount;
            AnimationTimingFunction = CurrentAnimation.AnimationTimingFunction;
            AnimationPlayState = CurrentAnimation.AnimationPlayState;
            LoadStops();
            BlockDataChange = false;
        }

        public void GetAnimationItems()
        {
            var cc = from vv in CssClassesToolControl.Context.CssStyleItems
                     where vv.CssAnimationId == CurrentAnimation.Id && vv.CssStyleId == null
                     select vv;

            CurrentCssStyleItems = cc.ToList();
        }

        public void InitialPercentList()
        {
            PercentList = new List<int>();
            PercentList.Add(0);
            PercentList.Add(100);

            foreach (var currentCssStyleItem in CurrentCssStyleItems)
            {
                if (currentCssStyleItem.StyleOrder.HasValue)
                {
                    var order = currentCssStyleItem.StyleOrder.Value;

                    if (PercentList.Contains<int>(order) == false)
                    {
                        PercentList.Add(order);
                    }
                }
            }

            ShowPercentList();
        }

        public void ShowPercentList()
        {
            AllStops.Items.Clear();
            TextBlock sv = null;
            foreach (var percent in PercentList)
            {
                var bl = new TextBlock();
                bl.Text = percent.ToString();
                AllStops.Items.Add(bl);
                if (percent == CurrentPercent)
                {
                    sv = bl;
                }
            }
            if (sv != null)
            {
                AllStops.SelectedItem = sv;
            }
            else
            {
                AllStops.SelectedIndex = 0;
            }
        }

        public void LoadStops()
        {
            GetAnimationItems();
            InitialPercentList();
            SetupStop();
        }

        public void SetupStop()
        {
            CssSettings = new CssKeyFrameItem();
            CssSettings.CssAnimationId = CurrentAnimation.Id;
            CssSettings.CurentCssAnimation = CurrentAnimation;
            CssSettings.CurrentAnimationOrder = CurrentPercent;
            CssSettings.LoadAnimationItems();
            CssSettings.Width = ActionBox.MaxWidth - 3.0;

            CssSettings.ItemHead = $"Animation {AnimationName} at {CurrentPercent} % Settings";

            CssClassesToolControl.Context.SaveChanges();
        }

        public int FindNextCssAnimationId()
        {
            var items = from tut in CssClassesToolControl.Context.CssAnimations
                        select tut;

            foreach (var item in items)
            {
                if (item.Id >= _nextCssAnimationId)
                {
                    _nextCssAnimationId = item.Id + 1;
                }
            }
            return (_nextCssAnimationId);
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

        public void CreateAnimation()
        {
            var rnd = new Random();
            var nam = "Animation" + rnd.Next(99999);
            CssAnimation ani = new CssAnimation();


           // var ani = CssClassesToolControl.Context.CssAnimations
       //     ani.Id = FindNextCssAnimationId();
            ani.AnimationName = nam;
            ani.AnimationDelay = "0";
            ani.AnimationDuration = "1000";
            CssClassesToolControl.Context.CssAnimations.Add(ani);
            CssClassesToolControl.Context.SaveChanges();
            CurrentAnimation = ani;
        }

        public void ShowAnimationText()
        {
            _buildCssForStyle.CurrentCssAnimation = CurrentAnimation;
            try
            {
                ShowCssText.Text = _buildCssForStyle.BuildAnimation();
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

        #endregion

        #region events

        private void AllStops_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllStops.SelectedItem != null)
            {
                var bl = AllStops.SelectedItem as TextBlock;
                var cnv = 0;
                if (int.TryParse(bl.Text, out cnv))
                {
                    if (PercentList.Contains(cnv))
                    {
                        CurrentPercent = cnv;
                        SetupStop();
                    }
                }
            }
        }

        private void ChangeOrderButton_OnClick(object sender, RoutedEventArgs e)
        {
            var addAnimationStopPosition = new AddAnimationStopPosition();
            addAnimationStopPosition.Title = "Change Animation Step's % Position";
            if (_currentPercent != 0 && _currentPercent != 100)
            {
                addAnimationStopPosition.CurrentStops = PercentList;
                addAnimationStopPosition.FromStop = _currentPercent;
                if (addAnimationStopPosition.ShowDialog() == true)
                {
                    var npercent = addAnimationStopPosition.ToStop;

                    foreach (var item in CurrentCssStyleItems)
                    {
                        if (item.StyleOrder == _currentPercent)
                        {
                            item.StyleOrder = npercent;
                        }
                    }
                    CssClassesToolControl.Context.SaveChanges();
                    _currentPercent = npercent;
                    LoadStops();
                }
            }
            else
            {
                MessageBox.Show(
                    "The animaton step % to be modified may not be the step at 0 % or at 100 % of the animation timeline");
            }
        }

        private void AddStopButton_OnClick(object sender, RoutedEventArgs e)
        {
            LoadStops();
            var rnd = new Random();
            var nstop = 50;
            while (PercentList.Contains(nstop))
            {
                nstop = rnd.Next(0, 100);
            }
            CurrentPercent = nstop;
            PercentList.Add(_currentPercent);
            ShowPercentList();
        }

        private void DeleteStopButton_OnClick(object sender, RoutedEventArgs e)
        {
            var styleitems = new List<CssStyleItem>();
            var colortypes = new List<CssColorType>();
            var colors = new List<CssColor>();

            if (_currentPercent != 0 && _currentPercent != 100)
            {
                foreach (var currentCssStyleItem in CurrentCssStyleItems)
                {
                    if (currentCssStyleItem.StyleOrder == _currentPercent)
                    {
                        styleitems.Add(currentCssStyleItem);
                        foreach (var colortype in currentCssStyleItem.CssColorTypes)
                        {
                            colortypes.Add(colortype);
                            colors.AddRange(colortype.CssColors);
                        }
                    }
                }

                foreach (var col in colors)
                {
                    CssClassesToolControl.Context.CssColors.Remove(col);
                }
                CssClassesToolControl.Context.SaveChanges();
                foreach (var colortype in colortypes)
                {
                    CssClassesToolControl.Context.CssColorTypes.Remove(colortype);
                }
                CssClassesToolControl.Context.SaveChanges();
                foreach (var item in styleitems)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(item);
                }
                CssClassesToolControl.Context.SaveChanges();
                _currentPercent = 0;
                LoadStops();
            }
            else
            {
                MessageBox.Show("The steps at 0 % and 100 % can not be deleted");
            }
        }

        #region Animation timing, fillmode etc

        private void InfiniteCheck_OnChecked(object sender, RoutedEventArgs e)
        {
            AnimationIterationCount = "infinite";
        }

        private void InfiniteCheck_OnUnchecked(object sender, RoutedEventArgs e)
        {
            AnimationIterationCount = "0";
        }

        private void DirectionBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                if (BlockDataChange == false)
                {
                    var st = (DirectionBox.SelectedItem as TextBlock).Text;
                    if (CurrentAnimation == null)
                    {
                        return;
                    }
                    CurrentAnimation.AnimationDirection = st;
                    CssClassesToolControl.Context.SaveChanges();
                }
            }
        }

        private void TimingFunctionBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                if (BlockDataChange == false)
                {
                    var st = (TimingFunctionBox.SelectedItem as TextBlock).Text;
                    if (CurrentAnimation == null)
                    {
                        return;
                    }
                    CurrentAnimation.AnimationDirection = st;
                    CssClassesToolControl.Context.SaveChanges();
                }
            }
        }

        private void PlayStateBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                if (BlockDataChange == false)
                {
                    var st = (PlayStateBox.SelectedItem as TextBlock).Text;
                    if (CurrentAnimation == null)
                    {
                        return;
                    }
                    CurrentAnimation.AnimationDirection = st;
                    CssClassesToolControl.Context.SaveChanges();
                }
            }
        }

        private void FillModeBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                if (BlockDataChange == false)
                {
                    var st = (FillModeBox.SelectedItem as TextBlock).Text;
                    if (CurrentAnimation == null)
                    {
                        return;
                    }
                    CurrentAnimation.AnimationDirection = st;
                    CssClassesToolControl.Context.SaveChanges();
                }
            }
        }

        #endregion

        #region Load/select all animation names

        public void LoadAnimations()
        {
            if (CssClassesToolControl.Context.CssAnimations.Any() == false)
            {
                CreateAnimation();
            }

            CssAnimationsObservableCollection = new ObservableCollection<CssAnimation>(CssClassesToolControl.Context.CssAnimations);
            CurrentAnimation = CssAnimationsObservableCollection.First();
            AnimationName = CurrentAnimation.AnimationName;
            Load();
            AnimationsComboBox.Items.Clear();
            foreach (var cssa in CssAnimationsObservableCollection)
            {
                AnimationsComboBox.Items.Add(cssa.AnimationName);
            }
            AnimationsComboBox.SelectedItem = AnimationName;
            InvalidateVisual();
            OnPropertyChanged(nameof(AnimationName));

            //AnimationNamesComboBox.Items.Clear();
            //foreach (CssAnimation it in CssClassesToolControl.Context.CssAnimations.ToList())
            //{
            //    TextBlock block = new TextBlock();

            //    block.Margin = new Thickness(2.0);
            //    block.Text = it.AnimationName;
            //    AnimationNamesComboBox.Items.Add(block);
            //}

            //foreach (TextBlock it in AnimationNamesComboBox.Items)
            //{
            //    if (it.Text == AnimationName)
            //    {
            //        AnimationNamesComboBox.SelectedItem = it;
            //        break;
            //    }
            //}
        }

        private void AnimationsComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                foreach (var it in CssClassesToolControl.Context.CssAnimations.ToList())
                {
                    var st = (AnimationsComboBox.SelectedItem as string);
                    if (it.AnimationName == st)
                    {
                        CurrentAnimation = it;
                        Load();
                        break;
                    }
                }
                _animationName = CurrentAnimation.AnimationName;
                OnPropertyChanged(nameof(AnimationName));
                Load();
            }
        }

        private void ChooseAnimationMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var chooseAnimation = new Css_Classes2019.Window.ChooseAnimation();
            chooseAnimation.ChosenAnimation = CurrentAnimation;
            chooseAnimation.CssAnimationObservableCollection = CssAnimationsObservableCollection;
            chooseAnimation.ShowDialog();
            if (chooseAnimation.ChosenAnimation != null)
            {
                CurrentAnimation = chooseAnimation.ChosenAnimation;
                _animationName = CurrentAnimation.AnimationName;
                OnPropertyChanged(nameof(AnimationName));
                Load(); 
            }
        }

        #endregion

        private void NewAnimationButton_OnClick(object sender, RoutedEventArgs e)
        {
            CreateAnimation();
        }

        private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            CssClassesToolControl.MainToolControl.ToCssPage();
        }

        private void BuildAnimationButton_OnClick(object sender, RoutedEventArgs e)
        {
            ShowAnimationText();
        }

        //private void ShowAnimationButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var fileGenerator = new FileGenerator();
        //    _buildCssForStyle.CurrentCssAnimation = CurrentAnimation;
        //    var style = _buildCssForStyle.BuildAnimation();
        //    var html = fileGenerator.GenerateStyleTestPage(style, "Wrap" + CurrentAnimation.AnimationName);
        //    CssClassesToolControl.OpenBrowserPage(html);
            
          


       // }

        private void DeleteAnimationButton_OnClick(object sender, RoutedEventArgs e)
        {
            var deletecolor = new List<CssColor>();
            var deletecolortype = new List<CssColorType>();
            var deletestyleitem = new List<CssStyleItem>();

            foreach (var item in CurrentAnimation.CssStyleItems)
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
            CssClassesToolControl.Context.CssAnimations.Remove(CurrentAnimation);
            CssClassesToolControl.Context.SaveChanges();
            LoadAnimations();
        }

        private void CopyAnimationButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (CurrentAnimation == null)
            {
                return;
            }

         //   var createdAnimation = CssClassesToolControl.Context.CssAnimations.Create();
            var createdAnimation = new CssAnimation();
        //    createdAnimation.Id = FindNextCssAnimationId();
            createdAnimation.AnimationDelay = CurrentAnimation.AnimationDelay;
            createdAnimation.AnimationDirection = CurrentAnimation.AnimationDirection;
            createdAnimation.AnimationDuration = CurrentAnimation.AnimationDuration;
            createdAnimation.AnimationFillMode = CurrentAnimation.AnimationFillMode;
            createdAnimation.AnimationIterationCount = CurrentAnimation.AnimationIterationCount;
            createdAnimation.AnimationName = "copyOf" + CurrentAnimation.AnimationName;
            createdAnimation.AnimationPlayState = CurrentAnimation.AnimationPlayState;
            createdAnimation.AnimationTimingFunction = CurrentAnimation.AnimationTimingFunction;

            CssClassesToolControl.Context.CssAnimations.Add(createdAnimation);
            CssClassesToolControl.Context.SaveChanges();

            foreach (var item in CurrentAnimation.CssStyleItems)
            {
              //  var createdItem = CssClassesToolControl.Context.CssStyleItems.Create();

                var createdItem = new CssStyleItem();
                createdItem.Id = FindNextCssStyleItemId();
                createdItem.CssAnimationId = createdAnimation.Id;
                createdItem.ItemName = item.ItemName;
                createdItem.ItemValue = item.ItemValue;
                createdItem.StyleOrder = item.StyleOrder;
                CssClassesToolControl.Context.CssStyleItems.Add(createdItem);
                CssClassesToolControl.Context.SaveChanges();

                foreach (var cty in item.CssColorTypes)
                {
                   // var createdColorType = CssClassesToolControl.Context.CssColorTypes.Create();

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
                        
                       // var createdColor = CssClassesToolControl.Context.CssColors.Create();
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


            LoadAnimations();
        }

        private void WriteFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            _buildCssForStyle.CurrentCssAnimation = CurrentAnimation;
            var style = _buildCssForStyle.BuildAnimation();
            var dialog = new SaveFileDialog();
            dialog.Filter = "Css documents (.css)|*.css|All Files (*.*)|*.*";
            dialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            dialog.FileName = CurrentAnimation.AnimationName + ".css";
            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, style);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

     
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            try
            {
                ShowAnimationText();
              //  CssClassesToolControl.MainToolControl.UseCssAnimationControl.ShowAnimationText(); 
            }
            catch (Exception ee)
            {
                string tt = ee.Message;

            }

            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
