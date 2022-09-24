using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using WpfCssControlLibrary.Dialogs;
using WpfCssControlLibrary.Model;
using Css_Classes2019;

namespace WpfCssControlLibrary.Controls
{
    /// <summary>
    ///     Interaction logic for CssItem.xaml
    /// </summary>
    public partial class CssItem : UserControl, INotifyPropertyChanged
    {
        public CssItem()
        {
            InitializeComponent();
            DataContext = this;
           

            Loaded += CssItem_Loaded;
        }

        #region fields

        private string _borderRadiusValue;
        private string _borderWidthValue;
        private string _columnCountValue;
        private string _columnGapValue;
        private string _columnWidthValue;
        private string _contentsBottomValue;
        private string _contentsHeightValue;
        private string _contentsLeftValue;
        private string _contentsMaxHeightValue;
        private string _contentsMaxWidthValue;
        private string _contentsMinHeightValue;
        private string _contentsMinWidthValue;
        private string _contentsRightValue;
        private string _contentsTopValue;
        private string _contentsWidthValue;
        private string _flexBasisValue;
        private string _flexGrowValue;
        private string _flexShrinkValue;
        private string _fontSizeItemValue;
        private bool _isLoaded;
        private string _itemHead;
        private string _lineHeightValue;
        private int _nextCssStyleItemId;
        private string _outlineWidthValue;
        private string _perspectiveOriginXValue = string.Empty;
        private string _perspectiveOriginYValue = string.Empty;
        private string _perspectiveValue;
        private string _rotateXValue;
        private string _rotateYValue;
        private string _rotateZValue;
        private string _scaleXValue;
        private string _scaleYValue;
        private string _scaleZValue;
        private string _styleMarginValue;
        private string _textIndentValue;
        private string _transformOriginXValue = string.Empty;
        private string _transformOriginYValue = string.Empty;
        private string _translateXValue;
        private string _translateYValue;
        private string _translateZValue;
        private string _zIndexValue;
        private string _clipTopValue;
        private string _clipRightValue;
        private string _clipBottomValue;
        private string _clipLeftValue;
        private string _backgroundImageValue;
        private string _backgroundPositionXValue;
        private string _backgroundPositionYValue;
        private string _backgroundSizeXValue;
        private string _backgroundSizeYValue;
        private string _contentsOpacityValue;
        private string _letterSpacingValue;
        private string _borderSpacingXValue;
        private string _borderSpacingYValue;
        private string _orderValue;
        private string _stylePaddingValue;
        private string _paddingTopValue;
        private string _paddingRightValue;
        private string _paddingBottomValue;
        private string _paddingLeftValue;
        private string _marginTopValue;
        private string _marginRightValue;
        private string _marginBottomValue;
        private string _marginLeftValue;
        private string _borderTopWidthValue;
        private string _borderRightWidthValue;
        private string _borderBottomWidthValue;
        private string _borderLeftWidthValue;
        private string _borderTopLeftRadiusValue;
        private string _borderTopRightRadiusValue;
        private string _borderBottomLeftRadiusValue;
        private string _borderBottomRightRadiusValue;
        private int? _cssStyleId;
        private CssStyle _currentCssStyle;
        private string _boxShadowHorizontalValue;
        private string _boxShadowVerticalValue;
        private string _boxShadowBlurDistanceValue;
        private string _boxShadowSpreadDistanceValue;
        private bool _boxShadowInsetValue;
        private System.Windows.Media.Color _boxShadowColor;

        private string _textShadowHorizontalValue;
        private string _textShadowVerticalValue;
        private string _textShadowBlurDistanceValue;
        private string _textShadowSpreadDistanceValue;
        private System.Windows.Media.Color _textShadowColor;

        #endregion fields

        #region LayoutConstants

        private double _boxSettingsLabelWidth = 41;
        private double _moreBoxSettingsLabelWidth = 50;
        private double _flexableBoxSettingsLabelWidth = 50;
        private double _fontSettingsLabelWidth = 50;
        private double _textSettingsLabelWidth = 50;
        private double _backgroundSettingsLabelWidth = 73;
        private double _listSettingsLabelWidth = 65;
        private double _tableSettingsLabelWidth = 60;
        private double _columnSettingsLabelWidth = 60;
        private double _transformSettingsLabelWidth = 60;
        private double _shadowSettingsLabelWidth = 70;

        public double BoxSettingsLabelWidth
        {
            get { return _boxSettingsLabelWidth; }
            set
            {
                _boxSettingsLabelWidth = value;
                OnPropertyChanged();
            }
        }

        public double MoreBoxSettingsLabelWidth
        {
            get { return _moreBoxSettingsLabelWidth; }
            set
            {
                _moreBoxSettingsLabelWidth = value;
                OnPropertyChanged();
            }
        }

        public double FlexableBoxSettingsLabelWidth
        {
            get { return _flexableBoxSettingsLabelWidth; }
            set
            {
                _flexableBoxSettingsLabelWidth = value;
                OnPropertyChanged();
            }
        }

        public double FontSettingsLabelWidth
        {
            get { return _fontSettingsLabelWidth; }
            set
            {
                _fontSettingsLabelWidth = value;
                OnPropertyChanged();
            }
        }

        public double TextSettingsLabelWidth
        {
            get { return _textSettingsLabelWidth; }
            set
            {
                _textSettingsLabelWidth = value;
                OnPropertyChanged();
            }
        }

        public double BackgroundSettingsLabelWidth
        {
            get { return _backgroundSettingsLabelWidth; }
            set
            {
                _backgroundSettingsLabelWidth = value;
                OnPropertyChanged();
            }
        }

        public double ListSettingsLabelWidth
        {
            get { return _listSettingsLabelWidth; }
            set
            {
                _listSettingsLabelWidth = value;
                OnPropertyChanged();
            }
        }

        public double TableSettingsLabelWidth
        {
            get { return _tableSettingsLabelWidth; }
            set
            {
                _tableSettingsLabelWidth = value;
                OnPropertyChanged();
            }
        }

        public double ColumnSettingsLabelWidth
        {
            get { return _columnSettingsLabelWidth; }
            set
            {
                _columnSettingsLabelWidth = value;
                OnPropertyChanged();
            }
        }

        public double TransformSettingsLabelWidth
        {
            get { return _transformSettingsLabelWidth; }
            set
            {
                _transformSettingsLabelWidth = value;
                OnPropertyChanged();
            }
        }

        public double ShadowSettingsLabelWidth
        {
            get { return _shadowSettingsLabelWidth; }
            set
            {
                _shadowSettingsLabelWidth = value;
                OnPropertyChanged();
            }
        }


        #endregion


        #region properties

        public int? CssStyleId
        {
            get { return _cssStyleId; }
            set
            {
                _cssStyleId = value;
            }
        }

        public string ItemHead
        {
            get { return _itemHead; }
            set
            {
                _itemHead = value;
                OnPropertyChanged(nameof(ItemHead));
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

        public string IsA
        {
            get
            {
                if (CssAnimationId != null)
                {
                    return (Colors.Gold.ToString());
                }
                else
                {
                    return (Colors.WhiteSmoke.ToString());
                }
            }
        }

        public int? CssAnimationId { get; set; }

        public CssAnimation CurentCssAnimation { get; set; }

        public int? CurrentAnimationOrder { get; set; }

        #region CssStyleItems

        public CssStyleItem ContentsWidth { get; set; }

        public CssStyleItem ContentsMaxWidth { get; set; }

        public CssStyleItem ContentsMinWidth { get; set; }

        public CssStyleItem ContentsHeight { get; set; }

        public CssStyleItem ContentsMaxHeight { get; set; }

        public CssStyleItem ContentsMinHeight { get; set; }

        public CssStyleItem ContentsLeft { get; set; }

        public CssStyleItem ContentsRight { get; set; }

        public CssStyleItem ContentsTop { get; set; }

        public CssStyleItem ContentsBottom { get; set; }

        public CssStyleItem ContentsClip { get; set; }

        public CssStyleItem OverflowX { get; set; }

        public CssStyleItem OverflowY { get; set; }

        public CssStyleItem Position { get; set; }

        public CssStyleItem Display { get; set; }

        public CssStyleItem BorderStyle { get; set; }

        public CssStyleItem BorderWidth { get; set; }

        public CssStyleItem BorderRadius { get; set; }

        public CssStyleItem BackgroundImage { get; set; }

        public CssStyleItem BackgroundPosition { get; set; }

        public CssStyleItem BackgroundClip { get; set; }

        public CssStyleItem BackgroundOrigin { get; set; }

        public CssStyleItem BackgroundRepeat { get; set; }

        public CssStyleItem BackgroundSize { get; set; }

        public CssStyleItem BackgroundAttachment { get; set; }

        public CssStyleItem OutlineStyle { get; set; }

        public CssStyleItem OutlineWidth { get; set; }

        public CssStyleItem StyleMargin { get; set; }

        public CssStyleItem MarginTop { get; set; }

        public CssStyleItem MarginRight { get; set; }

        public CssStyleItem MarginBottom { get; set; }

        public CssStyleItem MarginLeft { get; set; }

        public CssStyleItem BorderTopWidth { get; set; }

        public CssStyleItem BorderRightWidth { get; set; }

        public CssStyleItem BorderBottomWidth { get; set; }

        public CssStyleItem BorderLeftWidth { get; set; }

        public CssStyleItem BorderTopLeftRadius { get; set; }

        public CssStyleItem BorderTopRightRadius { get; set; }

        public CssStyleItem BorderBottomRightRadius { get; set; }

        public CssStyleItem BorderBottomLeftRadius { get; set; }

        public CssStyleItem BorderTopStyle { get; set; }

        public CssStyleItem BorderRightStyle { get; set; }

        public CssStyleItem BorderBottomStyle { get; set; }

        public CssStyleItem BorderLeftStyle { get; set; }

        public CssStyleItem StylePadding { get; set; }

        public CssStyleItem PaddingTop { get; set; }

        public CssStyleItem PaddingRight { get; set; }

        public CssStyleItem PaddingBottom { get; set; }

        public CssStyleItem PaddingLeft { get; set; }

        public CssStyleItem LineHeight { get; set; }

        public CssStyleItem LetterSpacing { get; set; }

        public CssStyleItem TextIndent { get; set; }

        public CssStyleItem WhiteSpace { get; set; }

        public CssStyleItem WordWrap { get; set; }

        public CssStyleItem TableLayout { get; set; }

        public CssStyleItem EmptyCells { get; set; }

        public CssStyleItem CaptionSide { get; set; }

        public CssStyleItem BorderCollapse { get; set; }

        public CssStyleItem BorderSpacing { get; set; }

        public CssStyleItem ColumnCount { get; set; }

        public CssStyleItem ColumnGap { get; set; }

        public CssStyleItem ColumnWidth { get; set; }

        public CssStyleItem ColumnSpan { get; set; }

        public CssStyleItem VisibilityItem { get; set; }

        public CssStyleItem AlignItems { get; set; }

        public CssStyleItem FloatItem { get; set; }

        public CssStyleItem TextAlign { get; set; }

        public CssStyleItem TextTransform { get; set; }

        public CssStyleItem FontWeightItem { get; set; }

        public CssStyleItem FontSizeItem { get; set; }

        public CssStyleItem FontVariantItem { get; set; }

        public CssStyleItem FontStyleItem { get; set; }

        public CssStyleItem FontFamilyItem { get; set; }

        public CssStyleItem FlexBasis { get; set; }

        public CssStyleItem FlexGrow { get; set; }

        public CssStyleItem FlexShrink { get; set; }

        public CssStyleItem FlexDirection { get; set; }

        public CssStyleItem FlexWrap { get; set; }

        public CssStyleItem Order { get; set; }

        public CssStyleItem AlignSelf { get; set; }

        public CssStyleItem JustifyContent { get; set; }

        public CssStyleItem AlignContent { get; set; }

        public CssStyleItem ContentsOpacity { get; set; }

        public CssStyleItem RotateX { get; set; }

        public CssStyleItem RotateY { get; set; }

        public CssStyleItem RotateZ { get; set; }

        public CssStyleItem TranslateX { get; set; }

        public CssStyleItem TranslateY { get; set; }

        public CssStyleItem TranslateZ { get; set; }

        public CssStyleItem ScaleX { get; set; }

        public CssStyleItem ScaleY { get; set; }

        public CssStyleItem ScaleZ { get; set; }

        public CssStyleItem Perspective { get; set; }

        public CssStyleItem PerspectiveOrigin { get; set; }

        public CssStyleItem BackfaceVisibility { get; set; }

        public CssStyleItem ListStyleType { get; set; }

        public CssStyleItem ListStylePosition { get; set; }

        public CssStyleItem ListTextAlign { get; set; }

        public CssStyleItem TransformOrigin { get; set; }

        public CssStyleItem BackgroundColor { get; set; }

        public CssStyleItem BorderColor { get; set; }

        public CssStyleItem OutlineColor { get; set; }

        public CssStyleItem FontColor { get; set; }

        public System.Windows.Media.Color BoxShadowColor
        {
            get { return _boxShadowColor; }
            set { _boxShadowColor = value; }
        }

        public System.Windows.Media.Color TextShadowColor
        {
            get { return _textShadowColor; }
            set { _textShadowColor = value; }
        }

        public CssStyleItem BoxShadow { get; set; }

        public CssStyleItem TextShadow { get; set; }

        public CssStyleItem ContentVerticalAlignment { get; set; }

        public CssStyleItem ZIndex { get; set; }

        #endregion

        public ColorSelector BackgroundColorSelector { get; set; }

        public ColorSelector BorderColorSelector { get; set; }

        public ColorSelector OutlineColorSelector { get; set; }

        public ColorSelector FontColorSelector { get; set; }

        //    public ColorSelector BoxShadowColorSelector { get; set; }

        #region style value properties

        public string ClipTopValue
        {
            get { return _clipTopValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                var tt = 0.0;
                if (double.TryParse(_clipRightValue, out tt) == false)
                {
                    _clipRightValue = "0";
                }

                var ss = 0.0;
                if (double.TryParse(_clipBottomValue, out ss) == false)
                {
                    _clipBottomValue = "0";
                }


                var ww = 0.0;
                if (double.TryParse(_clipLeftValue, out ww) == false)
                {
                    _clipLeftValue = "0";
                }
                _clipTopValue = value;

                if (ContentsClip == null)
                {
                    // ContentsClip = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsClip = new CssStyleItem();
                 //   ContentsClip.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsClip.CssStyleId = CssStyleId;
                        ContentsClip.ItemName = "clip";
                        ContentsClip.ItemValue =
                            $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsClip);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsClip.CssAnimationId = CssAnimationId;
                        ContentsClip.ItemName = "clip";
                        ContentsClip.StyleOrder = CurrentAnimationOrder;
                        ContentsClip.ItemValue =
                            $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsClip);
                    }
                }
                else
                {
                    ContentsClip.ItemValue =
                        $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ClipRightValue
        {
            get { return _clipRightValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                var ss = 0.0;
                if (double.TryParse(_clipBottomValue, out ss) == false)
                {
                    _clipBottomValue = "0";
                }
                var tt = 0.0;
                if (double.TryParse(_clipLeftValue, out tt) == false)
                {
                    _clipLeftValue = "0";
                }
                var ww = 0.0;
                if (double.TryParse(_clipTopValue, out ww) == false)
                {
                    _clipTopValue = "0";
                }


                _clipRightValue = value;
                if (ContentsClip == null)
                {
                    //  ContentsClip = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsClip = new CssStyleItem();
                 //   ContentsClip.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsClip.CssStyleId = CssStyleId;
                        ContentsClip.ItemName = "clip";
                        ContentsClip.ItemValue =
                            $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsClip);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsClip.CssAnimationId = CssAnimationId;
                        ContentsClip.ItemName = "clip";
                        ContentsClip.StyleOrder = CurrentAnimationOrder;
                        ContentsClip.ItemValue =
                            $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsClip);
                    }
                }
                else
                {
                    ContentsClip.ItemValue =
                        $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ClipBottomValue
        {
            get { return _clipBottomValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                var ss = 0.0;
                if (double.TryParse(_clipLeftValue, out ss) == false)
                {
                    _clipLeftValue = "0";
                }
                var tt = 0.0;
                if (double.TryParse(_clipRightValue, out tt) == false)
                {
                    _clipRightValue = "0";
                }
                var ww = 0.0;
                if (double.TryParse(_clipTopValue, out ww) == false)
                {
                    _clipTopValue = "0";
                }
                _clipBottomValue = value;
                if (ContentsClip == null)
                {
                    // ContentsClip = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsClip = new CssStyleItem();
                  //  ContentsClip.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsClip.CssStyleId = CssStyleId;
                        ContentsClip.ItemName = "clip";
                        ContentsClip.ItemValue =
                            $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsClip);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsClip.CssAnimationId = CssAnimationId;
                        ContentsClip.ItemName = "clip";
                        ContentsClip.StyleOrder = CurrentAnimationOrder;
                        ContentsClip.ItemValue =
                            $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsClip);
                    }
                }
                else
                {
                    ContentsClip.ItemValue =
                        $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ClipLeftValue
        {
            get { return _clipLeftValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                var ss = 0.0;
                if (double.TryParse(_clipBottomValue, out ss) == false)
                {
                    _clipBottomValue = "0";
                }
                var tt = 0.0;
                if (double.TryParse(_clipRightValue, out tt) == false)
                {
                    _clipRightValue = "0";
                }
                var ww = 0.0;
                if (double.TryParse(_clipTopValue, out ww) == false)
                {
                    _clipTopValue = "0";
                }

                _clipLeftValue = value;

                if (ContentsClip == null)
                {
                    //  ContentsClip = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsClip = new CssStyleItem();
                  //  ContentsClip.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsClip.CssStyleId = CssStyleId;
                        ContentsClip.ItemName = "clip";
                        ContentsClip.ItemValue =
                            $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsClip);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsClip.CssAnimationId = CssAnimationId;
                        ContentsClip.ItemName = "clip";
                        ContentsClip.StyleOrder = CurrentAnimationOrder;
                        ContentsClip.ItemValue =
                            $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsClip);
                    }
                }
                else
                {
                    ContentsClip.ItemValue =
                        $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";

                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ContentsWidthValue
        {
            get { return _contentsWidthValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _contentsWidthValue) return;
                _contentsWidthValue = value;

                if (ContentsWidth == null)
                {
                    //  ContentsWidth = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsWidth = new CssStyleItem();
                 //   ContentsWidth.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsWidth.CssStyleId = CssStyleId;
                        ContentsWidth.ItemName = "width";
                        ContentsWidth.ItemValue = _contentsWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsWidth);

                    }
                    if (CssAnimationId != null)
                    {
                        ContentsWidth.CssAnimationId = CssAnimationId;
                        ContentsWidth.ItemName = "width";
                        ContentsWidth.StyleOrder = CurrentAnimationOrder;
                        ContentsWidth.ItemValue = _contentsWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsWidth);
                    }
                }
                else
                {
                    ContentsWidth.ItemValue = _contentsWidthValue;


                }
                int res = CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();

            }
        }

        public string ContentsMaxWidthValue
        {
            get { return _contentsMaxWidthValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _contentsMaxWidthValue) return;
                _contentsMaxWidthValue = value;

                if (ContentsMaxWidth == null)
                {
                    // ContentsMaxWidth = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsMaxWidth = new CssStyleItem();
                //    ContentsMaxWidth.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsMaxWidth.CssStyleId = CssStyleId;
                        ContentsMaxWidth.ItemName = "max-width";
                        ContentsMaxWidth.ItemValue = _contentsMaxWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsMaxWidth);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsMaxWidth.CssAnimationId = CssAnimationId;
                        ContentsMaxWidth.ItemName = "max-width";
                        ContentsMaxWidth.StyleOrder = CurrentAnimationOrder;
                        ContentsMaxWidth.ItemValue = _contentsWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsMaxWidth);
                    }
                }
                else
                {
                    ContentsMaxWidth.ItemValue = _contentsMaxWidthValue;

                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ContentsMinWidthValue
        {
            get { return _contentsMinWidthValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _contentsMinWidthValue) return;
                _contentsMinWidthValue = value;

                if (ContentsMinWidth == null)
                {
                    //  ContentsMinWidth = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsMinWidth = new CssStyleItem();
               //     ContentsMinWidth.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsMinWidth.CssStyleId = CssStyleId;
                        ContentsMinWidth.ItemName = "min-width";
                        ContentsMinWidth.ItemValue = _contentsMinWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsMinWidth);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsMinWidth.CssAnimationId = CssAnimationId;
                        ContentsMinWidth.ItemName = "min-width";
                        ContentsMinWidth.StyleOrder = CurrentAnimationOrder;
                        ContentsMinWidth.ItemValue = _contentsWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsMinWidth);
                    }
                }
                else
                {
                    ContentsMinWidth.ItemValue = _contentsMinWidthValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ContentsHeightValue
        {
            get { return _contentsHeightValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _contentsHeightValue) return;
                _contentsHeightValue = value;

                if (ContentsHeight == null)
                {
                    // ContentsHeight = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsHeight = new CssStyleItem();
               //     ContentsHeight.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsHeight.CssStyleId = CssStyleId;
                        ContentsHeight.ItemName = "height";
                        ContentsHeight.ItemValue = _contentsHeightValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsHeight);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsHeight.CssAnimationId = CssAnimationId;
                        ContentsHeight.ItemName = "height";
                        ContentsHeight.StyleOrder = CurrentAnimationOrder;
                        ContentsHeight.ItemValue = _contentsHeightValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsHeight);
                    }
                }
                else
                {
                    ContentsHeight.ItemValue = _contentsHeightValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ContentsMaxHeightValue
        {
            get { return _contentsMaxHeightValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _contentsMaxHeightValue) return;
                _contentsMaxHeightValue = value;

                if (ContentsMaxHeight == null)
                {
                    // ContentsMaxHeight = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsMaxHeight = new CssStyleItem();
                //    ContentsMaxHeight.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsMaxHeight.CssStyleId = CssStyleId;
                        ContentsMaxHeight.ItemName = "max-height";
                        ContentsMaxHeight.ItemValue = _contentsMaxHeightValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsMaxHeight);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsMaxHeight.CssAnimationId = CssAnimationId;
                        ContentsMaxHeight.ItemName = "max-height";
                        ContentsMaxHeight.StyleOrder = CurrentAnimationOrder;
                        ContentsMaxHeight.ItemValue = _contentsMaxHeightValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsMaxHeight);
                    }
                }
                else
                {
                    ContentsMaxHeight.ItemValue = _contentsMaxHeightValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ContentsMinHeightValue
        {
            get { return _contentsMinHeightValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _contentsMinHeightValue) return;
                _contentsMinHeightValue = value;

                if (ContentsMinHeight == null)
                {
                    //   ContentsMinHeight = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsMinHeight = new CssStyleItem();
               //     ContentsMinHeight.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsMinHeight.CssStyleId = CssStyleId;
                        ContentsMinHeight.ItemName = "min-height";
                        ContentsMinHeight.ItemValue = _contentsMinHeightValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsMinHeight);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsMinHeight.CssAnimationId = CssAnimationId;
                        ContentsMinHeight.ItemName = "min-height";
                        ContentsMinHeight.StyleOrder = CurrentAnimationOrder;
                        ContentsMinHeight.ItemValue = _contentsMinHeightValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsMinHeight);
                    }
                }
                else
                {
                    ContentsMinHeight.ItemValue = _contentsMinHeightValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ContentsLeftValue
        {
            get { return _contentsLeftValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _contentsLeftValue) return;
                _contentsLeftValue = value;

                if (ContentsLeft == null)
                {
                    //  ContentsLeft = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsLeft = new CssStyleItem();
               //     ContentsLeft.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsLeft.CssStyleId = CssStyleId;
                        ContentsLeft.ItemName = "left";
                        ContentsLeft.ItemValue = _contentsLeftValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsLeft);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsLeft.CssAnimationId = CssAnimationId;
                        ContentsLeft.ItemName = "left";
                        ContentsLeft.StyleOrder = CurrentAnimationOrder;
                        ContentsLeft.ItemValue = _contentsLeftValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsLeft);
                    }
                }
                else
                {
                    ContentsLeft.ItemValue = _contentsLeftValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ContentsRightValue
        {
            get { return _contentsRightValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _contentsRightValue) return;
                _contentsRightValue = value;

                if (ContentsRight == null)
                {
                    //  ContentsRight = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsRight = new CssStyleItem();
              //      ContentsRight.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsRight.CssStyleId = CssStyleId;
                        ContentsRight.ItemName = "right";
                        ContentsRight.ItemValue = _contentsRightValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsRight);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsRight.CssAnimationId = CssAnimationId;
                        ContentsRight.ItemName = "right";
                        ContentsRight.StyleOrder = CurrentAnimationOrder;
                        ContentsRight.ItemValue = _contentsRightValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsRight);
                    }
                }
                else
                {
                    ContentsRight.ItemValue = _contentsRightValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ContentsTopValue
        {
            get { return _contentsTopValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _contentsTopValue) return;
                _contentsTopValue = value;

                if (ContentsTop == null)
                {
                    //  ContentsTop = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsTop = new CssStyleItem();
                  //  ContentsTop.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsTop.CssStyleId = CssStyleId;
                        ContentsTop.ItemName = "top";
                        ContentsTop.ItemValue = _contentsTopValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsTop);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsTop.CssAnimationId = CssAnimationId;
                        ContentsTop.ItemName = "top";
                        ContentsTop.StyleOrder = CurrentAnimationOrder;
                        ContentsTop.ItemValue = _contentsTopValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsTop);
                    }
                }
                else
                {
                    ContentsTop.ItemValue = _contentsTopValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ContentsBottomValue
        {
            get { return _contentsBottomValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _contentsBottomValue) return;
                _contentsBottomValue = value;

                if (ContentsBottom == null)
                {
                    //  ContentsBottom = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsBottom = new CssStyleItem();
               //     ContentsBottom.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsBottom.CssStyleId = CssStyleId;
                        ContentsBottom.ItemName = "height";
                        ContentsBottom.ItemValue = _contentsBottomValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsBottom);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsBottom.CssAnimationId = CssAnimationId;
                        ContentsBottom.ItemName = "height";
                        ContentsBottom.StyleOrder = CurrentAnimationOrder;
                        ContentsBottom.ItemValue = _contentsBottomValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsBottom);
                    }
                }
                else
                {
                    ContentsBottom.ItemValue = _contentsBottomValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string BorderWidthValue
        {
            get { return _borderWidthValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _borderWidthValue) return;
                _borderWidthValue = value;

                if (BorderTopWidth != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderTopWidth);
                    _borderTopWidthValue = string.Empty;
                    BorderTopWidth = null;
                }

                if (BorderRightWidth != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderRightWidth);
                    _borderRightWidthValue = string.Empty;
                    BorderRightWidth = null;
                }

                if (BorderBottomWidth != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderBottomWidth);
                    _borderBottomWidthValue = string.Empty;
                    BorderBottomWidth = null;
                }

                if (BorderLeftWidth != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderLeftWidth);
                    _borderLeftWidthValue = string.Empty;
                    BorderLeftWidth = null;
                }

                if (BorderWidth == null)
                {
                    //  BorderWidth = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderWidth = new CssStyleItem();
                 //   BorderWidth.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderWidth.CssStyleId = CssStyleId;
                        BorderWidth.ItemName = "border-width";
                        BorderWidth.ItemValue = _borderWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderWidth);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderWidth.CssAnimationId = CssAnimationId;
                        BorderWidth.ItemName = "border-width";
                        BorderWidth.ItemValue = _borderWidthValue;
                        BorderWidth.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderWidth);
                    }
                }
                else
                {
                    BorderWidth.ItemValue = _borderWidthValue;
                }
                CssClassesToolControl.Context.SaveChanges();

                OnPropertyChanged();
                OnPropertyChanged(nameof(BorderLeftWidthValue));
                OnPropertyChanged(nameof(BorderRightWidthValue));
                OnPropertyChanged(nameof(BorderTopWidthValue));
                OnPropertyChanged(nameof(BorderBottomWidthValue));
            }
        }

        public string BorderTopWidthValue
        {
            get { return _borderTopWidthValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _borderTopWidthValue) return;
                _borderTopWidthValue = value;

                if (BorderWidth != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderWidth);
                    _borderWidthValue = string.Empty;
                    BorderWidth = null;
                }

                if (BorderTopWidth == null)
                {
                    //  BorderTopWidth = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderTopWidth = new CssStyleItem();
               //    BorderTopWidth.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderTopWidth.CssStyleId = CssStyleId;
                        BorderTopWidth.ItemName = "border-top-width";
                        BorderTopWidth.ItemValue = _borderTopWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderTopWidth);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderTopWidth.CssAnimationId = CssAnimationId;
                        BorderTopWidth.ItemName = "border-top-width";
                        BorderTopWidth.ItemValue = _borderTopWidthValue;
                        BorderTopWidth.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderTopWidth);
                    }
                }
                else
                {
                    BorderTopWidth.ItemValue = _borderTopWidthValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(BorderWidthValue));
            }
        }

        public string BorderRightWidthValue
        {
            get { return _borderRightWidthValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _borderRightWidthValue) return;
                _borderRightWidthValue = value;

                if (BorderWidth != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderWidth);
                    _borderWidthValue = string.Empty;
                    BorderWidth = null;
                }

                if (BorderRightWidth == null)
                {
                    // BorderRightWidth = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderRightWidth = new CssStyleItem();
                  //  BorderRightWidth.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderRightWidth.CssStyleId = CssStyleId;
                        BorderRightWidth.ItemName = "border-right-width";
                        BorderRightWidth.ItemValue = _borderRightWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderRightWidth);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderRightWidth.CssAnimationId = CssAnimationId;
                        BorderRightWidth.ItemName = "border-right-width";
                        BorderRightWidth.ItemValue = _borderRightWidthValue;
                        BorderRightWidth.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderRightWidth);
                    }
                }
                else
                {
                    BorderRightWidth.ItemValue = _borderRightWidthValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(BorderWidthValue));
            }
        }

        public string BorderBottomWidthValue
        {
            get { return _borderBottomWidthValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _borderBottomWidthValue) return;
                _borderBottomWidthValue = value;

                if (BorderWidth != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderWidth);
                    _borderWidthValue = string.Empty;
                    BorderWidth = null;
                }

                if (BorderBottomWidth == null)
                {
                    //      BorderBottomWidth = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderBottomWidth = new CssStyleItem();
               //     BorderBottomWidth.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderBottomWidth.CssStyleId = CssStyleId;
                        BorderBottomWidth.ItemName = "border-bottom-width";
                        BorderBottomWidth.ItemValue = _borderBottomWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderBottomWidth);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderBottomWidth.CssAnimationId = CssAnimationId;
                        BorderBottomWidth.ItemName = "border-bottom-width";
                        BorderBottomWidth.ItemValue = _borderBottomWidthValue;
                        BorderBottomWidth.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderBottomWidth);
                    }
                }
                else
                {
                    BorderBottomWidth.ItemValue = _borderBottomWidthValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(BorderWidthValue));
            }
        }

        public string BorderLeftWidthValue
        {
            get { return _borderLeftWidthValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _borderLeftWidthValue) return;
                _borderLeftWidthValue = value;

                if (BorderWidth != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderWidth);
                    _borderWidthValue = string.Empty;
                    BorderWidth = null;
                }

                if (BorderLeftWidth == null)
                {
                    //     BorderLeftWidth = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderLeftWidth = new CssStyleItem();
                 //   BorderLeftWidth.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderLeftWidth.CssStyleId = CssStyleId;
                        BorderLeftWidth.ItemName = "border-left-width";
                        BorderLeftWidth.ItemValue = _borderLeftWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderLeftWidth);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderLeftWidth.CssAnimationId = CssAnimationId;
                        BorderLeftWidth.ItemName = "border-left-width";
                        BorderLeftWidth.ItemValue = _borderLeftWidthValue;
                        BorderLeftWidth.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderLeftWidth);
                    }
                }
                else
                {
                    BorderLeftWidth.ItemValue = _borderLeftWidthValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(BorderWidthValue));
            }
        }

        public string BorderTopLeftRadiusValue
        {
            get { return _borderTopLeftRadiusValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _borderTopLeftRadiusValue) return;
                _borderTopLeftRadiusValue = value;

                if (BorderRadius != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderRadius);
                    _borderRadiusValue = string.Empty;
                    BorderRadius = null;
                }

                if (BorderTopLeftRadius == null)
                {
                    //    BorderTopLeftRadius = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderTopLeftRadius = new CssStyleItem();
             //       BorderTopLeftRadius.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderTopLeftRadius.CssStyleId = CssStyleId;
                        BorderTopLeftRadius.ItemName = "border-top-left-radius";
                        BorderTopLeftRadius.ItemValue = _borderTopLeftRadiusValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderTopLeftRadius);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderTopLeftRadius.CssAnimationId = CssAnimationId;
                        BorderTopLeftRadius.ItemName = "border-top-left-radius";
                        BorderTopLeftRadius.ItemValue = _borderTopLeftRadiusValue;
                        BorderTopLeftRadius.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderTopLeftRadius);
                    }
                }
                else
                {
                    BorderTopLeftRadius.ItemValue = _borderTopLeftRadiusValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(BorderRadiusValue));
            }
        }

        public string BorderTopRightRadiusValue
        {
            get { return _borderTopRightRadiusValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _borderTopRightRadiusValue) return;
                _borderTopRightRadiusValue = value;

                if (BorderRadius != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderRadius);
                    _borderRadiusValue = string.Empty;
                    BorderRadius = null;
                }

                if (BorderTopRightRadius == null)
                {
                    //   BorderTopRightRadius = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderTopRightRadius = new CssStyleItem();
               //     BorderTopRightRadius.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderTopRightRadius.CssStyleId = CssStyleId;
                        BorderTopRightRadius.ItemName = "border-top-right-radius";
                        BorderTopRightRadius.ItemValue = _borderTopRightRadiusValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderTopRightRadius);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderTopRightRadius.CssAnimationId = CssAnimationId;
                        BorderTopRightRadius.ItemName = "border-top-right-radius";
                        BorderTopRightRadius.ItemValue = _borderTopRightRadiusValue;
                        BorderTopRightRadius.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderTopRightRadius);
                    }
                }
                else
                {
                    BorderTopRightRadius.ItemValue = _borderTopRightRadiusValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(BorderRadiusValue));
            }
        }

        public string BorderBottomRightRadiusValue
        {
            get { return _borderBottomRightRadiusValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _borderBottomRightRadiusValue) return;
                _borderBottomRightRadiusValue = value;

                if (BorderRadius != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderRadius);
                    _borderRadiusValue = string.Empty;
                    BorderRadius = null;
                }

                if (BorderBottomRightRadius == null)
                {
                    //   BorderBottomRightRadius = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderBottomRightRadius = new CssStyleItem();
                 //   BorderBottomRightRadius.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderBottomRightRadius.CssStyleId = CssStyleId;
                        BorderBottomRightRadius.ItemName = "border-bottom-right-radius";
                        BorderBottomRightRadius.ItemValue = _borderBottomRightRadiusValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderBottomRightRadius);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderBottomRightRadius.CssAnimationId = CssAnimationId;
                        BorderBottomRightRadius.ItemName = "border-bottom-right-radius";
                        BorderBottomRightRadius.ItemValue = _borderBottomRightRadiusValue;
                        BorderBottomRightRadius.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderBottomRightRadius);
                    }
                }
                else
                {
                    BorderBottomRightRadius.ItemValue = _borderBottomRightRadiusValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(BorderRadiusValue));
            }
        }

        public string BorderBottomLeftRadiusValue
        {
            get { return _borderBottomLeftRadiusValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _borderBottomLeftRadiusValue) return;
                _borderBottomLeftRadiusValue = value;

                if (BorderRadius != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderRadius);
                    _borderRadiusValue = string.Empty;
                    BorderRadius = null;
                }

                if (BorderBottomLeftRadius == null)
                {
                    //  BorderBottomLeftRadius = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderBottomLeftRadius = new CssStyleItem();
             //       BorderBottomLeftRadius.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderBottomLeftRadius.CssStyleId = CssStyleId;
                        BorderBottomLeftRadius.ItemName = "border-bottom-left-radius";
                        BorderBottomLeftRadius.ItemValue = _borderBottomLeftRadiusValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderBottomLeftRadius);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderBottomLeftRadius.CssAnimationId = CssAnimationId;
                        BorderBottomLeftRadius.ItemName = "border-bottom-left-radius";
                        BorderBottomLeftRadius.ItemValue = _borderBottomLeftRadiusValue;
                        BorderBottomLeftRadius.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderBottomLeftRadius);
                    }
                }
                else
                {
                    BorderBottomLeftRadius.ItemValue = _borderBottomLeftRadiusValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(BorderRadiusValue));
            }
        }

        public string BorderRadiusValue
        {
            get { return _borderRadiusValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _borderRadiusValue) return;
                _borderRadiusValue = value;

                if (BorderTopLeftRadius != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderTopLeftRadius);
                    _borderTopLeftRadiusValue = string.Empty;
                    BorderTopLeftRadius = null;
                }

                if (BorderTopRightRadius != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderTopRightRadius);
                    _borderTopRightRadiusValue = string.Empty;
                    BorderTopRightRadius = null;
                }

                if (BorderBottomRightRadius != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderBottomRightRadius);
                    _borderBottomRightRadiusValue = string.Empty;
                    BorderBottomRightRadius = null;
                }

                if (BorderBottomLeftRadius != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(BorderBottomLeftRadius);
                    _borderBottomLeftRadiusValue = string.Empty;
                    BorderBottomLeftRadius = null;
                }

                if (BorderRadius == null)
                {
                    //   BorderRadius = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderRadius = new CssStyleItem();
             //       BorderRadius.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderRadius.CssStyleId = CssStyleId;
                        BorderRadius.ItemName = "border-radius";
                        BorderRadius.ItemValue = _borderRadiusValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderRadius);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderRadius.CssAnimationId = CssAnimationId;
                        BorderRadius.ItemName = "border-radius";
                        BorderRadius.ItemValue = _borderRadiusValue;
                        BorderRadius.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderRadius);
                    }
                }
                else
                {
                    BorderRadius.ItemValue = _borderRadiusValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(BorderTopLeftRadiusValue));
                OnPropertyChanged(nameof(BorderTopRightRadiusValue));
                OnPropertyChanged(nameof(BorderBottomRightRadiusValue));
                OnPropertyChanged(nameof(BorderBottomLeftRadiusValue));
            }
        }

        public string BackgroundImageValue
        {
            get { return _backgroundImageValue; }
            set
            {
                if (value == _backgroundImageValue) return;
                _backgroundImageValue = value;

                if (BackgroundImage == null)
                {
                    //  BackgroundImage = CssClassesToolControl.Context.CssStyleItems.Create();
                    BackgroundImage = new CssStyleItem();
             //       BackgroundImage.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BackgroundImage.CssStyleId = CssStyleId;
                        BackgroundImage.ItemName = "background-image";
                        BackgroundImage.ItemValue = $"url(\"{_backgroundImageValue}\")";
                        CssClassesToolControl.Context.CssStyleItems.Add(BackgroundImage);
                    }
                    if (CssAnimationId != null)
                    {
                        BackgroundImage.CssAnimationId = CssAnimationId;
                        BackgroundImage.ItemName = "background-image";
                        BackgroundImage.ItemValue = $"url(\"{_backgroundImageValue}\")";
                        BackgroundImage.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BackgroundImage);
                    }
                }
                else
                {
                    BackgroundImage.ItemValue = $"url(\"{_backgroundImageValue}\")";
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string BackgroundPositionXValue
        {
            get { return _backgroundPositionXValue; }
            set
            {
                var rr = 0;
                if (int.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged(nameof(BackgroundPositionXValue));
                    return;
                }
                if (rr < 0 || rr > 100)
                {
                    OnPropertyChanged(nameof(BackgroundPositionXValue));
                    return;
                }

                rr = 0;
                if (int.TryParse(_backgroundPositionYValue, out rr) == false)
                {
                    _backgroundPositionYValue = "50";
                    OnPropertyChanged(nameof(BackgroundPositionYValue));
                    // return;
                }
                if (rr < 0 || rr > 100)
                {
                    _backgroundPositionYValue = "50";
                    OnPropertyChanged(nameof(BackgroundPositionYValue));
                    //  return;
                }

                if (value == _backgroundPositionXValue) return;
                _backgroundPositionXValue = value;

                if (BackgroundPosition == null)
                {
                    //   BackgroundPosition = CssClassesToolControl.Context.CssStyleItems.Create();
                    BackgroundPosition = new CssStyleItem();
               //     BackgroundPosition.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BackgroundPosition.CssStyleId = CssStyleId;
                        BackgroundPosition.ItemName = "background-position";
                        BackgroundPosition.ItemValue = $"{_backgroundPositionXValue}% {_backgroundPositionYValue}%";
                        CssClassesToolControl.Context.CssStyleItems.Add(BackgroundPosition);
                    }
                    if (CssAnimationId != null)
                    {
                        BackgroundPosition.CssAnimationId = CssAnimationId;
                        BackgroundPosition.ItemName = "background-position";
                        BackgroundPosition.ItemValue = $"{_backgroundPositionXValue}% {_backgroundPositionYValue}%";
                        BackgroundPosition.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BackgroundPosition);
                    }
                }
                else
                {
                    BackgroundPosition.ItemValue = $"{_backgroundPositionXValue}% {_backgroundPositionYValue}%";
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string BackgroundPositionYValue
        {
            get { return _backgroundPositionYValue; }
            set
            {
                var rr = 0;
                if (int.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged(nameof(BackgroundPositionYValue));
                    return;
                }
                if (rr < 0 || rr > 100)
                {
                    OnPropertyChanged(nameof(BackgroundPositionYValue));
                    return;
                }

                rr = 0;
                if (int.TryParse(_backgroundPositionXValue, out rr) == false)
                {
                    _backgroundPositionXValue = "50";
                    OnPropertyChanged(nameof(BackgroundPositionXValue));
                    //  return;
                }
                if (rr < 0 || rr > 100)
                {
                    _backgroundPositionXValue = "50";
                    OnPropertyChanged(nameof(BackgroundPositionXValue));
                    //   return;
                }

                if (value == _backgroundPositionYValue) return;
                _backgroundPositionYValue = value;

                if (BackgroundPosition == null)
                {
                    //  BackgroundPosition = CssClassesToolControl.Context.CssStyleItems.Create();
                    BackgroundPosition = new CssStyleItem();
           //         BackgroundPosition.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BackgroundPosition.CssStyleId = CssStyleId;
                        BackgroundPosition.ItemName = "background-position";
                        BackgroundPosition.ItemValue = $"{_backgroundPositionXValue}% {_backgroundPositionYValue}%";
                        CssClassesToolControl.Context.CssStyleItems.Add(BackgroundPosition);
                    }
                    if (CssAnimationId != null)
                    {
                        BackgroundPosition.CssAnimationId = CssAnimationId;
                        BackgroundPosition.ItemName = "background-position";
                        BackgroundPosition.ItemValue = $"{_backgroundPositionXValue}% {_backgroundPositionYValue}%";
                        BackgroundPosition.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BackgroundPosition);
                    }
                }
                else
                {
                    BackgroundPosition.ItemValue = $"{_backgroundPositionXValue}% {_backgroundPositionYValue}%";
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string BackgroundSizeXValue
        {
            get { return _backgroundSizeXValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged(nameof(BackgroundSizeXValue));
                    return;
                }

                rr = 0.0;
                if (double.TryParse(_backgroundSizeYValue, out rr) == false)
                {
                    _backgroundSizeYValue = "0.0";
                    OnPropertyChanged(nameof(BackgroundSizeYValue));
                    //      return;
                }

                if (value == _backgroundSizeXValue) return;
                _backgroundSizeXValue = value;

                if (BackgroundSize == null)
                {
                    // BackgroundSize = CssClassesToolControl.Context.CssStyleItems.Create();
                    BackgroundSize = new CssStyleItem();
              //      BackgroundSize.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BackgroundSize.CssStyleId = CssStyleId;
                        BackgroundSize.ItemName = "background-size";
                        BackgroundSize.ItemValue = $"{_backgroundSizeXValue}px {_backgroundSizeYValue}px";
                        CssClassesToolControl.Context.CssStyleItems.Add(BackgroundSize);
                    }
                    if (CssAnimationId != null)
                    {
                        BackgroundSize.CssAnimationId = CssAnimationId;
                        BackgroundSize.ItemName = "background-size";
                        BackgroundSize.ItemValue = $"{_backgroundSizeXValue}px {_backgroundSizeYValue}px";
                        BackgroundSize.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BackgroundSize);
                    }
                }
                else
                {
                    BackgroundSize.ItemValue = $"{_backgroundSizeXValue}px {_backgroundSizeYValue}px";
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string BackgroundSizeYValue
        {
            get { return _backgroundSizeYValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged(nameof(BackgroundSizeYValue));
                    return;
                }
                rr = 0.0;
                if (double.TryParse(_backgroundSizeXValue, out rr) == false)
                {
                    _backgroundSizeXValue = "0.0";
                    OnPropertyChanged(nameof(BackgroundSizeXValue));
                    // return;
                }

                if (value == _backgroundSizeYValue) return;
                _backgroundSizeYValue = value;

                if (BackgroundSize == null)
                {
                    //  BackgroundSize = CssClassesToolControl.Context.CssStyleItems.Create();
                    BackgroundSize = new CssStyleItem();
               //     BackgroundSize.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BackgroundSize.CssStyleId = CssStyleId;
                        BackgroundSize.ItemName = "background-size";
                        BackgroundSize.ItemValue = $"{_backgroundSizeXValue}px {_backgroundSizeYValue}px";
                        CssClassesToolControl.Context.CssStyleItems.Add(BackgroundSize);
                    }
                    if (CssAnimationId != null)
                    {
                        BackgroundSize.CssAnimationId = CssAnimationId;
                        BackgroundSize.ItemName = "background-size";
                        BackgroundSize.ItemValue = $"{_backgroundSizeXValue}px {_backgroundSizeYValue}px";
                        BackgroundSize.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BackgroundSize);
                    }
                }
                else
                {
                    BackgroundSize.ItemValue = $"{_backgroundSizeXValue}px {_backgroundSizeYValue}px";
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string BorderSpacingXValue
        {
            get { return _borderSpacingXValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged(nameof(BorderSpacingXValue));
                    return;
                }

                rr = 0.0;
                if (double.TryParse(_borderSpacingYValue, out rr) == false)
                {
                    _borderSpacingYValue = "0.0";
                    OnPropertyChanged(nameof(BackgroundSizeYValue));
                    //return;
                }

                if (value == _borderSpacingXValue) return;
                _borderSpacingXValue = value;

                if (BorderSpacing == null)
                {
                    // BorderSpacing = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderSpacing = new CssStyleItem();
          //          BorderSpacing.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderSpacing.CssStyleId = CssStyleId;
                        BorderSpacing.ItemName = "border-spacing";
                        BorderSpacing.ItemValue = $"{_borderSpacingXValue}px {_borderSpacingYValue}px";
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderSpacing);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderSpacing.CssAnimationId = CssAnimationId;
                        BorderSpacing.ItemName = "border-spacing";
                        BorderSpacing.ItemValue = $"{_borderSpacingXValue}px {_borderSpacingYValue}px";
                        BorderSpacing.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderSpacing);
                    }
                }
                else
                {
                    BorderSpacing.ItemValue = $"{_borderSpacingXValue}px {_borderSpacingYValue}px";
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string BorderSpacingYValue
        {
            get { return _borderSpacingYValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged(nameof(BorderSpacingYValue));
                    return;
                }

                rr = 0.0;
                if (double.TryParse(_borderSpacingXValue, out rr) == false)
                {
                    _borderSpacingXValue = "0.0";
                    OnPropertyChanged(nameof(BorderSpacingXValue));
                    // return;
                }

                if (value == _borderSpacingYValue) return;
                _borderSpacingYValue = value;

                if (BorderSpacing == null)
                {
                    //   BorderSpacing = CssClassesToolControl.Context.CssStyleItems.Create();
                    BorderSpacing = new CssStyleItem();
           //         BorderSpacing.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BorderSpacing.CssStyleId = CssStyleId;
                        BorderSpacing.ItemName = "background-size";
                        BorderSpacing.ItemValue = $"{_borderSpacingXValue}px {_borderSpacingYValue}px";
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderSpacing);
                    }
                    if (CssAnimationId != null)
                    {
                        BorderSpacing.CssAnimationId = CssAnimationId;
                        BorderSpacing.ItemName = "background-size";
                        BorderSpacing.ItemValue = $"{_borderSpacingXValue}px {_borderSpacingYValue}px";
                        BorderSpacing.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(BorderSpacing);
                    }
                }
                else
                {
                    BorderSpacing.ItemValue = $"{_borderSpacingXValue}px {_borderSpacingYValue}px";
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ContentsOpacityValue
        {
            get { return _contentsOpacityValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _contentsOpacityValue) return;
                _contentsOpacityValue = value;

                if (ContentsOpacity == null)
                {
                    // ContentsOpacity = CssClassesToolControl.Context.CssStyleItems.Create();
                    ContentsOpacity = new CssStyleItem();
               //     ContentsOpacity.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ContentsOpacity.CssStyleId = CssStyleId;
                        ContentsOpacity.ItemName = "opacity";
                        ContentsOpacity.ItemValue = _contentsOpacityValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsOpacity);
                    }
                    if (CssAnimationId != null)
                    {
                        ContentsOpacity.CssAnimationId = CssAnimationId;
                        ContentsOpacity.ItemName = "opacity";
                        ContentsOpacity.ItemValue = _contentsOpacityValue;
                        ContentsOpacity.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(ContentsOpacity);
                    }
                }
                else
                {
                    ContentsOpacity.ItemValue = _contentsOpacityValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string OutlineWidthValue
        {
            get { return _outlineWidthValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _outlineWidthValue) return;
                _outlineWidthValue = value;

                if (OutlineWidth == null)
                {
                    //  OutlineWidth = CssClassesToolControl.Context.CssStyleItems.Create();
                    OutlineWidth = new CssStyleItem();
               //     OutlineWidth.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        OutlineWidth.CssStyleId = CssStyleId;
                        OutlineWidth.ItemName = "outline-width";
                        OutlineWidth.ItemValue = _outlineWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(OutlineWidth);
                    }
                    if (CssAnimationId != null)
                    {
                        OutlineWidth.CssAnimationId = CssAnimationId;
                        OutlineWidth.ItemName = "outline-width";
                        OutlineWidth.ItemValue = _outlineWidthValue;
                        OutlineWidth.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(OutlineWidth);
                    }
                }
                else
                {
                    OutlineWidth.ItemValue = _outlineWidthValue;
                }

                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string StyleMarginValue
        {
            get { return _styleMarginValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _styleMarginValue) return;
                _styleMarginValue = value;

                if (MarginTop != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(MarginTop);
                    _marginTopValue = string.Empty;
                    MarginTop = null;
                }

                if (MarginRight != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(MarginRight);
                    _marginRightValue = string.Empty;
                    MarginRight = null;
                }

                if (MarginBottom != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(MarginBottom);
                    _marginBottomValue = string.Empty;
                    MarginBottom = null;
                }

                if (MarginLeft != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(MarginLeft);
                    _marginLeftValue = string.Empty;
                    MarginLeft = null;
                }

                if (StyleMargin == null)
                {
                    //     StyleMargin = CssClassesToolControl.Context.CssStyleItems.Create();
                    StyleMargin = new CssStyleItem();
               //     StyleMargin.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        StyleMargin.CssStyleId = CssStyleId;
                        StyleMargin.ItemName = "margin";
                        StyleMargin.ItemValue = _styleMarginValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(StyleMargin);
                    }
                    if (CssAnimationId != null)
                    {
                        StyleMargin.CssAnimationId = CssAnimationId;
                        StyleMargin.ItemName = "margin";
                        StyleMargin.ItemValue = _styleMarginValue;
                        StyleMargin.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(StyleMargin);
                    }
                }
                else
                {
                    StyleMargin.ItemValue = _styleMarginValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(MarginLeftValue));
                OnPropertyChanged(nameof(MarginRightValue));
                OnPropertyChanged(nameof(MarginTopValue));
                OnPropertyChanged(nameof(MarginBottomValue));
            }
        }

        public string MarginTopValue
        {
            get { return _marginTopValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _marginTopValue) return;
                _marginTopValue = value;

                if (StyleMargin != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(StyleMargin);
                    _styleMarginValue = string.Empty;
                    StyleMargin = null;
                }

                if (MarginTop == null)
                {
                    //   MarginTop = CssClassesToolControl.Context.CssStyleItems.Create();
                    MarginTop = new CssStyleItem();
             //       MarginTop.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        MarginTop.CssStyleId = CssStyleId;
                        MarginTop.ItemName = "margin-top";
                        MarginTop.ItemValue = _marginTopValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(MarginTop);
                    }
                    if (CssAnimationId != null)
                    {
                        MarginTop.CssAnimationId = CssAnimationId;
                        MarginTop.ItemName = "margin-top";
                        MarginTop.ItemValue = _marginTopValue;
                        MarginTop.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(MarginTop);
                    }
                }
                else
                {
                    MarginTop.ItemValue = _marginTopValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(StyleMarginValue));
            }
        }

        public string MarginRightValue
        {
            get { return _marginRightValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _marginRightValue) return;
                _marginRightValue = value;

                if (StyleMargin != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(StyleMargin);
                    _styleMarginValue = string.Empty;
                    StyleMargin = null;
                }

                if (MarginRight == null)
                {
                    //  MarginRight = CssClassesToolControl.Context.CssStyleItems.Create();
                    MarginRight = new CssStyleItem();
            //        MarginRight.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        MarginRight.CssStyleId = CssStyleId;
                        MarginRight.ItemName = "margin-right";
                        MarginRight.ItemValue = _marginRightValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(MarginRight);
                    }
                    if (CssAnimationId != null)
                    {
                        MarginRight.CssAnimationId = CssAnimationId;
                        MarginRight.ItemName = "margin-right";
                        MarginRight.ItemValue = _marginRightValue;
                        MarginRight.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(MarginRight);
                    }
                }
                else
                {
                    MarginRight.ItemValue = _marginRightValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(StyleMarginValue));
            }
        }

        public string MarginBottomValue
        {
            get { return _marginBottomValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _marginBottomValue) return;
                _marginBottomValue = value;

                if (StyleMargin != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(StyleMargin);
                    _styleMarginValue = string.Empty;
                    StyleMargin = null;
                }

                if (MarginBottom == null)
                {
                    //     MarginBottom = CssClassesToolControl.Context.CssStyleItems.Create();
                    MarginBottom = new CssStyleItem();
              //      MarginBottom.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        MarginBottom.CssStyleId = CssStyleId;
                        MarginBottom.ItemName = "margin-bottom";
                        MarginBottom.ItemValue = _marginBottomValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(MarginBottom);
                    }
                    if (CssAnimationId != null)
                    {
                        MarginBottom.CssAnimationId = CssAnimationId;
                        MarginBottom.ItemName = "margin-bottom";
                        MarginBottom.ItemValue = _marginBottomValue;
                        MarginBottom.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(MarginBottom);
                    }
                }
                else
                {
                    MarginBottom.ItemValue = _marginBottomValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(StyleMarginValue));
            }
        }

        public string MarginLeftValue
        {
            get { return _marginLeftValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _marginLeftValue) return;
                _marginLeftValue = value;

                if (StyleMargin != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(StyleMargin);
                    _styleMarginValue = string.Empty;
                    StyleMargin = null;
                }

                if (MarginLeft == null)
                {
                    //  MarginLeft = CssClassesToolControl.Context.CssStyleItems.Create();
                    MarginLeft = new CssStyleItem();
              //      MarginLeft.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        MarginLeft.CssStyleId = CssStyleId;
                        MarginLeft.ItemName = "margin-left";
                        MarginLeft.ItemValue = _marginLeftValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(MarginLeft);
                    }
                    if (CssAnimationId != null)
                    {
                        MarginLeft.CssAnimationId = CssAnimationId;
                        MarginLeft.ItemName = "margin-left";
                        MarginLeft.ItemValue = _marginLeftValue;
                        MarginLeft.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(MarginLeft);
                    }
                }
                else
                {
                    MarginLeft.ItemValue = _marginLeftValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(StyleMarginValue));
            }
        }

        public string StylePaddingValue
        {
            get { return _stylePaddingValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _stylePaddingValue) return;
                _stylePaddingValue = value;

                if (PaddingTop != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(PaddingTop);
                    _paddingTopValue = string.Empty;
                    PaddingTop = null;
                }

                if (PaddingRight != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(PaddingRight);
                    _paddingRightValue = string.Empty;
                    PaddingRight = null;
                }

                if (PaddingBottom != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(PaddingBottom);
                    _paddingBottomValue = string.Empty;
                    PaddingBottom = null;
                }

                if (PaddingLeft != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(PaddingLeft);
                    _paddingLeftValue = string.Empty;
                    PaddingLeft = null;
                }

                if (StylePadding == null)
                {
                    //  StylePadding = CssClassesToolControl.Context.CssStyleItems.Create();
                    StylePadding = new CssStyleItem();
               //     StylePadding.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        StylePadding.CssStyleId = CssStyleId;
                        StylePadding.ItemName = "padding";
                        StylePadding.ItemValue = _stylePaddingValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(StylePadding);
                    }
                    if (CssAnimationId != null)
                    {
                        StylePadding.CssAnimationId = CssAnimationId;
                        StylePadding.ItemName = "padding";
                        StylePadding.ItemValue = _stylePaddingValue;
                        StylePadding.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(StylePadding);
                    }
                }
                else
                {
                    StylePadding.ItemValue = _stylePaddingValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(PaddingLeftValue));
                OnPropertyChanged(nameof(PaddingRightValue));
                OnPropertyChanged(nameof(PaddingTopValue));
                OnPropertyChanged(nameof(PaddingBottomValue));
            }
        }

        public string PaddingTopValue
        {
            get { return _paddingTopValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _paddingTopValue) return;
                _paddingTopValue = value;

                if (StylePadding != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(StylePadding);
                    _stylePaddingValue = string.Empty;
                    StylePadding = null;
                }

                if (PaddingTop == null)
                {
                    //   PaddingTop = CssClassesToolControl.Context.CssStyleItems.Create();
                    PaddingTop = new CssStyleItem();
              //      PaddingTop.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        PaddingTop.CssStyleId = CssStyleId;
                        PaddingTop.ItemName = "padding-top";
                        PaddingTop.ItemValue = _paddingTopValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(PaddingTop);
                    }
                    if (CssAnimationId != null)
                    {
                        PaddingTop.CssAnimationId = CssAnimationId;
                        PaddingTop.ItemName = "padding-top";
                        PaddingTop.ItemValue = _paddingTopValue;
                        PaddingTop.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(PaddingTop);
                    }
                }
                else
                {
                    PaddingTop.ItemValue = _paddingTopValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(StylePaddingValue));
            }
        }

        public string PaddingRightValue
        {
            get { return _paddingRightValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _paddingRightValue) return;
                _paddingRightValue = value;

                if (StylePadding != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(StylePadding);
                    _stylePaddingValue = string.Empty;
                    StylePadding = null;
                }

                if (PaddingRight == null)
                {
                    //    PaddingRight = CssClassesToolControl.Context.CssStyleItems.Create();
                    PaddingRight = new CssStyleItem();
          //          PaddingRight.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        PaddingRight.CssStyleId = CssStyleId;
                        PaddingRight.ItemName = "padding-right";
                        PaddingRight.ItemValue = _paddingRightValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(PaddingRight);
                    }
                    if (CssAnimationId != null)
                    {
                        PaddingRight.CssAnimationId = CssAnimationId;
                        PaddingRight.ItemName = "padding-right";
                        PaddingRight.ItemValue = _paddingRightValue;
                        PaddingRight.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(PaddingRight);
                    }
                }
                else
                {
                    PaddingRight.ItemValue = _paddingRightValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(StylePaddingValue));
            }
        }

        public string PaddingBottomValue
        {
            get { return _paddingBottomValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _paddingBottomValue) return;
                _paddingBottomValue = value;

                if (StylePadding != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(StylePadding);
                    _stylePaddingValue = string.Empty;
                    StylePadding = null;
                }

                if (PaddingBottom == null)
                {
                    //      PaddingBottom = CssClassesToolControl.Context.CssStyleItems.Create();
                    PaddingBottom = new CssStyleItem();
              //      PaddingBottom.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        PaddingBottom.CssStyleId = CssStyleId;
                        PaddingBottom.ItemName = "padding-bottom";
                        PaddingBottom.ItemValue = _paddingBottomValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(PaddingBottom);
                    }
                    if (CssAnimationId != null)
                    {
                        PaddingBottom.CssAnimationId = CssAnimationId;
                        PaddingBottom.ItemName = "padding-bottom";
                        PaddingBottom.ItemValue = _paddingBottomValue;
                        PaddingBottom.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(PaddingBottom);
                    }
                }
                else
                {
                    PaddingBottom.ItemValue = _paddingBottomValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(StylePaddingValue));
            }
        }

        public string PaddingLeftValue
        {
            get { return _paddingLeftValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _paddingLeftValue) return;
                _paddingLeftValue = value;

                if (StylePadding != null)
                {
                    CssClassesToolControl.Context.CssStyleItems.Remove(StylePadding);
                    _stylePaddingValue = string.Empty;
                    StylePadding = null;
                }

                if (PaddingLeft == null)
                {
                    //  PaddingLeft = CssClassesToolControl.Context.CssStyleItems.Create();
                    PaddingLeft = new CssStyleItem();
               //     PaddingLeft.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        PaddingLeft.CssStyleId = CssStyleId;
                        PaddingLeft.ItemName = "padding-left";
                        PaddingLeft.ItemValue = _paddingLeftValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(PaddingLeft);
                    }
                    if (CssAnimationId != null)
                    {
                        PaddingLeft.CssAnimationId = CssAnimationId;
                        PaddingLeft.ItemName = "padding-left";
                        PaddingLeft.ItemValue = _paddingLeftValue;
                        PaddingLeft.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(PaddingLeft);
                    }
                }
                else
                {
                    PaddingLeft.ItemValue = _paddingLeftValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                OnPropertyChanged(nameof(StylePaddingValue));
            }
        }

        public string TextIndentValue
        {
            get { return _textIndentValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _textIndentValue) return;
                _textIndentValue = value;

                if (TextIndent == null)
                {
                    //  TextIndent = CssClassesToolControl.Context.CssStyleItems.Create();
                    TextIndent = new CssStyleItem();
                //    TextIndent.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        TextIndent.CssStyleId = CssStyleId;
                        TextIndent.ItemName = "text-indent";
                        TextIndent.ItemValue = _textIndentValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(TextIndent);
                    }
                    if (CssAnimationId != null)
                    {
                        TextIndent.CssAnimationId = CssAnimationId;
                        TextIndent.ItemName = "text-indent";
                        TextIndent.ItemValue = _textIndentValue;
                        TextIndent.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(TextIndent);
                    }
                }
                else
                {
                    TextIndent.ItemValue = _textIndentValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string LineHeightValue
        {
            get { return _lineHeightValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _lineHeightValue) return;
                _lineHeightValue = value;

                if (LineHeight == null)
                {
                    //  LineHeight = CssClassesToolControl.Context.CssStyleItems.Create();
                    LineHeight = new CssStyleItem();
                //    LineHeight.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        LineHeight.CssStyleId = CssStyleId;
                        LineHeight.ItemName = "line-height";
                        LineHeight.ItemValue = _lineHeightValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(LineHeight);
                    }
                    if (CssAnimationId != null)
                    {
                        LineHeight.CssAnimationId = CssAnimationId;
                        LineHeight.ItemName = "line-height";
                        LineHeight.ItemValue = _lineHeightValue;
                        LineHeight.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(LineHeight);
                    }
                }
                else
                {
                    LineHeight.ItemValue = _lineHeightValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string LetterSpacingValue
        {
            get { return _letterSpacingValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _letterSpacingValue) return;
                _letterSpacingValue = value;

                if (LetterSpacing == null)
                {
                    //     LetterSpacing = CssClassesToolControl.Context.CssStyleItems.Create();
                    LetterSpacing = new CssStyleItem();
             //       LetterSpacing.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        LetterSpacing.CssStyleId = CssStyleId;
                        LetterSpacing.ItemName = "letter-spacing";
                        LetterSpacing.ItemValue = _letterSpacingValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(LetterSpacing);
                    }
                    if (CssAnimationId != null)
                    {
                        LetterSpacing.CssAnimationId = CssAnimationId;
                        LetterSpacing.ItemName = "letter-spacing";
                        LetterSpacing.ItemValue = _letterSpacingValue;
                        LetterSpacing.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(LetterSpacing);
                    }
                }
                else
                {
                    LetterSpacing.ItemValue = _letterSpacingValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ColumnCountValue
        {
            get { return _columnCountValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _columnCountValue) return;
                _columnCountValue = value;

                if (ColumnCount == null)
                {
                    // ColumnCount = CssClassesToolControl.Context.CssStyleItems.Create();
                    ColumnCount = new CssStyleItem();
               //     ColumnCount.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ColumnCount.CssStyleId = CssStyleId;
                        ColumnCount.ItemName = "column-count";
                        ColumnCount.ItemValue = _columnCountValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ColumnCount);
                    }
                    if (CssAnimationId != null)
                    {
                        ColumnCount.CssAnimationId = CssAnimationId;
                        ColumnCount.ItemName = "column-count";
                        ColumnCount.ItemValue = _columnCountValue;
                        ColumnCount.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(ColumnCount);
                    }
                }
                else
                {
                    ColumnCount.ItemValue = _columnCountValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ColumnGapValue
        {
            get { return _columnGapValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _columnGapValue) return;
                _columnGapValue = value;

                if (ColumnGap == null)
                {
                    //  ColumnGap = CssClassesToolControl.Context.CssStyleItems.Create();
                    ColumnGap = new CssStyleItem();
              //      ColumnGap.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ColumnGap.CssStyleId = CssStyleId;
                        ColumnGap.ItemName = "column-gap";
                        ColumnGap.ItemValue = _columnGapValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ColumnGap);
                    }
                    if (CssAnimationId != null)
                    {
                        ColumnGap.CssAnimationId = CssAnimationId;
                        ColumnGap.ItemName = "column-gap";
                        ColumnGap.ItemValue = _columnGapValue;
                        ColumnGap.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(ColumnGap);
                    }
                }
                else
                {
                    ColumnGap.ItemValue = _columnGapValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ColumnWidthValue
        {
            get { return _columnWidthValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _columnWidthValue) return;
                _columnWidthValue = value;

                if (ColumnWidth == null)
                {
                    //   ColumnWidth = CssClassesToolControl.Context.CssStyleItems.Create();
                    ColumnWidth = new CssStyleItem();
               //     ColumnWidth.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ColumnWidth.CssStyleId = CssStyleId;
                        ColumnWidth.ItemName = "column-width";
                        ColumnWidth.ItemValue = _columnWidthValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ColumnWidth);
                    }
                    if (CssAnimationId != null)
                    {
                        ColumnWidth.CssAnimationId = CssAnimationId;
                        ColumnWidth.ItemName = "column-width";
                        ColumnWidth.ItemValue = _columnWidthValue;
                        ColumnWidth.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(ColumnWidth);
                    }
                }
                else
                {
                    ColumnWidth.ItemValue = _columnWidthValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string FontSizeItemValue
        {
            get { return _fontSizeItemValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _fontSizeItemValue) return;
                _fontSizeItemValue = value;

                if (FontSizeItem == null)
                {
                    //     FontSizeItem = CssClassesToolControl.Context.CssStyleItems.Create();
                    FontSizeItem = new CssStyleItem();
                  //  FontSizeItem.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        FontSizeItem.CssStyleId = CssStyleId;
                        FontSizeItem.ItemName = "font-size";
                        FontSizeItem.ItemValue = _fontSizeItemValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(FontSizeItem);
                    }
                    if (CssAnimationId != null)
                    {
                        FontSizeItem.CssAnimationId = CssAnimationId;
                        FontSizeItem.ItemName = "font-size";
                        FontSizeItem.ItemValue = _fontSizeItemValue;
                        FontSizeItem.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(FontSizeItem);
                    }
                }
                else
                {
                    FontSizeItem.ItemValue = _fontSizeItemValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string RotateXValue
        {
            get { return _rotateXValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _rotateXValue) return;
                _rotateXValue = value;

                if (RotateX == null)
                {
                    //     RotateX = CssClassesToolControl.Context.CssStyleItems.Create();
                    RotateX = new CssStyleItem();
          //          RotateX.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        RotateX.CssStyleId = CssStyleId;
                        RotateX.ItemName = "rotateX";
                        RotateX.ItemValue = _rotateXValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(RotateX);
                    }
                    if (CssAnimationId != null)
                    {
                        RotateX.CssAnimationId = CssAnimationId;
                        RotateX.ItemName = "rotateX";
                        RotateX.ItemValue = _rotateXValue;
                        RotateX.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(RotateX);
                    }
                }
                else
                {
                    RotateX.ItemValue = _rotateXValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string RotateYValue
        {
            get { return _rotateYValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _rotateYValue) return;
                _rotateYValue = value;

                if (RotateY == null)
                {
                    // RotateY = CssClassesToolControl.Context.CssStyleItems.Create();
                    RotateY = new CssStyleItem();
               //     RotateY.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        RotateY.CssStyleId = CssStyleId;
                        RotateY.ItemName = "rotateY";
                        RotateY.ItemValue = _rotateYValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(RotateY);
                    }
                    if (CssAnimationId != null)
                    {
                        RotateY.CssAnimationId = CssAnimationId;
                        RotateY.ItemName = "rotateY";
                        RotateY.ItemValue = _rotateYValue;
                        RotateY.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(RotateY);
                    }
                }
                else
                {
                    RotateY.ItemValue = _rotateYValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string RotateZValue
        {
            get { return _rotateZValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _rotateZValue) return;
                _rotateZValue = value;

                if (RotateZ == null)
                {
                    //     RotateZ = CssClassesToolControl.Context.CssStyleItems.Create();
                    RotateZ = new CssStyleItem();
              //      RotateZ.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        RotateZ.CssStyleId = CssStyleId;
                        RotateZ.ItemName = "rotateZ";
                        RotateZ.ItemValue = _rotateZValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(RotateZ);
                    }
                    if (CssAnimationId != null)
                    {
                        RotateZ.CssAnimationId = CssAnimationId;
                        RotateZ.ItemName = "rotateZ";
                        RotateZ.ItemValue = _rotateZValue;
                        RotateZ.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(RotateZ);
                    }
                }
                else
                {
                    RotateZ.ItemValue = _rotateZValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string TranslateXValue
        {
            get { return _translateXValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _translateXValue) return;
                _translateXValue = value;

                if (TranslateX == null)
                {
                    //    TranslateX = CssClassesToolControl.Context.CssStyleItems.Create();
                    TranslateX = new CssStyleItem();
                //    TranslateX.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        TranslateX.CssStyleId = CssStyleId;
                        TranslateX.ItemName = "translateX";
                        TranslateX.ItemValue = _translateXValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(TranslateX);
                    }
                    if (CssAnimationId != null)
                    {
                        TranslateX.CssAnimationId = CssAnimationId;
                        TranslateX.ItemName = "translateX";
                        TranslateX.ItemValue = _translateXValue;
                        TranslateX.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(TranslateX);
                    }
                }
                else
                {
                    TranslateX.ItemValue = _translateXValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string TranslateYValue
        {
            get { return _translateYValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _translateYValue) return;
                _translateYValue = value;

                if (TranslateY == null)
                {
                    // TranslateY = CssClassesToolControl.Context.CssStyleItems.Create();
                    TranslateY = new CssStyleItem();
                //    TranslateY.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        TranslateY.CssStyleId = CssStyleId;
                        TranslateY.ItemName = "translateY";
                        TranslateY.ItemValue = _translateYValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(TranslateY);
                    }
                    if (CssAnimationId != null)
                    {
                        TranslateY.CssAnimationId = CssAnimationId;
                        TranslateY.ItemName = "translateY";
                        TranslateY.ItemValue = _translateYValue;
                        TranslateY.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(TranslateY);
                    }
                }
                else
                {
                    TranslateY.ItemValue = _translateYValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string TranslateZValue
        {
            get { return _translateZValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _translateZValue) return;
                _translateZValue = value;

                if (TranslateZ == null)
                {
                    //  TranslateZ = CssClassesToolControl.Context.CssStyleItems.Create();
                    TranslateZ = new CssStyleItem();
                //    TranslateZ.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        TranslateZ.CssStyleId = CssStyleId;
                        TranslateZ.ItemName = "translateZ";
                        TranslateZ.ItemValue = _translateZValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(TranslateZ);
                    }
                    if (CssAnimationId != null)
                    {
                        TranslateZ.CssAnimationId = CssAnimationId;
                        TranslateZ.ItemName = "translateZ";
                        TranslateZ.ItemValue = _translateZValue;
                        TranslateZ.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(TranslateZ);
                    }
                }
                else
                {
                    TranslateZ.ItemValue = _translateZValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ScaleXValue
        {
            get { return _scaleXValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _scaleXValue) return;
                _scaleXValue = value;

                if (ScaleX == null)
                {
                    //   ScaleX = CssClassesToolControl.Context.CssStyleItems.Create();
                    ScaleX = new CssStyleItem();
               //     ScaleX.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ScaleX.CssStyleId = CssStyleId;
                        ScaleX.ItemName = "scaleX";
                        ScaleX.ItemValue = _scaleXValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ScaleX);
                    }
                    if (CssAnimationId != null)
                    {
                        ScaleX.CssAnimationId = CssAnimationId;
                        ScaleX.ItemName = "scaleX";
                        ScaleX.ItemValue = _scaleXValue;
                        ScaleX.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(ScaleX);
                    }
                }
                else
                {
                    ScaleX.ItemValue = _scaleXValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ScaleYValue
        {
            get { return _scaleYValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _scaleYValue) return;
                _scaleYValue = value;

                if (ScaleY == null)
                {
                    //   ScaleY = CssClassesToolControl.Context.CssStyleItems.Create();
                    ScaleY = new CssStyleItem();
               //     ScaleY.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ScaleY.CssStyleId = CssStyleId;
                        ScaleY.ItemName = "scaleY";
                        ScaleY.ItemValue = _scaleYValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ScaleY);
                    }
                    if (CssAnimationId != null)
                    {
                        ScaleY.CssAnimationId = CssAnimationId;
                        ScaleY.ItemName = "scaleY";
                        ScaleY.ItemValue = _scaleYValue;
                        ScaleY.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(ScaleY);
                    }
                }
                else
                {
                    ScaleY.ItemValue = _scaleYValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ScaleZValue
        {
            get { return _scaleZValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _scaleZValue) return;
                _scaleZValue = value;

                if (ScaleZ == null)
                {
                    //    ScaleZ = CssClassesToolControl.Context.CssStyleItems.Create();
                    ScaleZ = new CssStyleItem();
              //      ScaleZ.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ScaleZ.CssStyleId = CssStyleId;
                        ScaleZ.ItemName = "scaleZ";
                        ScaleZ.ItemValue = _scaleZValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ScaleZ);
                    }
                    if (CssAnimationId != null)
                    {
                        ScaleZ.CssAnimationId = CssAnimationId;
                        ScaleZ.ItemName = "scaleZ";
                        ScaleZ.ItemValue = _scaleZValue;
                        ScaleZ.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(ScaleZ);
                    }
                }
                else
                {
                    ScaleZ.ItemValue = _scaleZValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string PerspectiveValue
        {
            get { return _perspectiveValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _perspectiveValue) return;
                _perspectiveValue = value;

                if (Perspective == null)
                {
                    //    Perspective = CssClassesToolControl.Context.CssStyleItems.Create();
                    Perspective = new CssStyleItem();
                //    Perspective.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        Perspective.CssStyleId = CssStyleId;
                        Perspective.ItemName = "perspective";
                        Perspective.ItemValue = _perspectiveValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(Perspective);
                    }
                    if (CssAnimationId != null)
                    {
                        Perspective.CssAnimationId = CssAnimationId;
                        Perspective.ItemName = "perspective";
                        Perspective.ItemValue = _perspectiveValue;
                        Perspective.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(Perspective);
                    }
                }
                else
                {
                    Perspective.ItemValue = _perspectiveValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string PerspectiveOriginXValue
        {
            get { return _perspectiveOriginXValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _perspectiveOriginXValue) return;
                _perspectiveOriginXValue = value;

                if (PerspectiveOrigin == null)
                {
                    //  PerspectiveOrigin = CssClassesToolControl.Context.CssStyleItems.Create();
                    PerspectiveOrigin = new CssStyleItem();
                 //   PerspectiveOrigin.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        PerspectiveOrigin.CssStyleId = CssStyleId;
                        PerspectiveOrigin.ItemName = "perspective-origin";
                        PerspectiveOrigin.ItemValue = _perspectiveOriginXValue + ", " +
                                                      _perspectiveOriginYValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(PerspectiveOrigin);
                    }
                    if (CssAnimationId != null)
                    {
                        PerspectiveOrigin.CssAnimationId = CssAnimationId;
                        PerspectiveOrigin.ItemName = "perspective-origin";
                        PerspectiveOrigin.ItemValue = _perspectiveOriginXValue + ", " +
                                                      _perspectiveOriginYValue;
                        PerspectiveOrigin.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(PerspectiveOrigin);
                    }
                }
                else
                {
                    PerspectiveOrigin.ItemValue = _perspectiveOriginXValue + ", " +
                                                  _perspectiveOriginYValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string PerspectiveOriginYValue
        {
            get { return _perspectiveOriginYValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _perspectiveOriginYValue) return;
                _perspectiveOriginYValue = value;

                if (PerspectiveOrigin == null)
                {
                    //  PerspectiveOrigin = CssClassesToolControl.Context.CssStyleItems.Create();
                    PerspectiveOrigin = new CssStyleItem();
               //     PerspectiveOrigin.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        PerspectiveOrigin.CssStyleId = CssStyleId;
                        PerspectiveOrigin.ItemName = "perspective-origin";
                        PerspectiveOrigin.ItemValue = _perspectiveOriginXValue + ", " +
                                                      _perspectiveOriginYValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(PerspectiveOrigin);
                    }
                    if (CssAnimationId != null)
                    {
                        PerspectiveOrigin.CssAnimationId = CssAnimationId;
                        PerspectiveOrigin.ItemName = "perspective-origin";
                        PerspectiveOrigin.ItemValue = _perspectiveOriginXValue + ", " +
                                                      _perspectiveOriginYValue;
                        PerspectiveOrigin.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(PerspectiveOrigin);
                    }
                }
                else
                {
                    PerspectiveOrigin.ItemValue = _perspectiveOriginXValue + ", " +
                                                  _perspectiveOriginYValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string TransformOriginXValue
        {
            get { return _transformOriginXValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _transformOriginXValue) return;
                _transformOriginXValue = value;

                if (TransformOrigin == null)
                {
                    //   TransformOrigin = CssClassesToolControl.Context.CssStyleItems.Create();
                    TransformOrigin = new CssStyleItem();
               //     TransformOrigin.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        TransformOrigin.CssStyleId = CssStyleId;
                        TransformOrigin.ItemName = "transform-origin";
                        TransformOrigin.ItemValue = _transformOriginXValue + ", " +
                                                    _transformOriginYValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(TransformOrigin);
                    }
                    if (CssAnimationId != null)
                    {
                        TransformOrigin.CssAnimationId = CssAnimationId;
                        TransformOrigin.ItemName = "transform-origin";
                        TransformOrigin.ItemValue = _transformOriginXValue + ", " +
                                                    _transformOriginYValue;
                        TransformOrigin.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(TransformOrigin);
                    }
                }
                else
                {
                    TransformOrigin.ItemValue = _transformOriginXValue + ", " +
                                                _transformOriginYValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string TransformOriginYValue
        {
            get { return _transformOriginYValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }
                if (value == _transformOriginYValue) return;
                _transformOriginYValue = value;

                if (TransformOrigin == null)
                {
                    //  TransformOrigin = CssClassesToolControl.Context.CssStyleItems.Create();
                    TransformOrigin = new CssStyleItem();
              //      TransformOrigin.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        TransformOrigin.CssStyleId = CssStyleId;
                        TransformOrigin.ItemName = "transform-origin";
                        TransformOrigin.ItemValue = _transformOriginXValue + ", " +
                                                    _transformOriginYValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(TransformOrigin);
                    }
                    if (CssAnimationId != null)
                    {
                        TransformOrigin.CssAnimationId = CssAnimationId;
                        TransformOrigin.ItemName = "transform-origin";
                        TransformOrigin.ItemValue = _transformOriginXValue + ", " +
                                                    _transformOriginYValue;
                        TransformOrigin.StyleOrder = CurrentAnimationOrder;
                        CssClassesToolControl.Context.CssStyleItems.Add(TransformOrigin);
                    }
                }
                else
                {
                    TransformOrigin.ItemValue = _transformOriginXValue + ", " +
                                                _transformOriginYValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string ZindexValue
        {
            get { return _zIndexValue; }
            set
            {
                var rr = 0;
                if (int.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _zIndexValue) return;
                _zIndexValue = value;

                if (ZIndex == null)
                {
                    // ZIndex = CssClassesToolControl.Context.CssStyleItems.Create();
                    ZIndex = new CssStyleItem();
              //      ZIndex.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        ZIndex.CssStyleId = CssStyleId;
                        ZIndex.ItemName = "z-index";
                        ZIndex.ItemValue = _zIndexValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ZIndex);
                    }
                    if (CssAnimationId != null)
                    {
                        ZIndex.CssAnimationId = CssAnimationId;
                        ZIndex.ItemName = "z-index";
                        ZIndex.StyleOrder = CurrentAnimationOrder;
                        ZIndex.ItemValue = _zIndexValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(ZIndex);
                    }
                }
                else
                {
                    ZIndex.ItemValue = _zIndexValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string FlexBasisValue
        {
            get { return _flexBasisValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _flexBasisValue) return;
                _flexBasisValue = value;

                if (FlexBasis == null)
                {
                    //   FlexBasis = CssClassesToolControl.Context.CssStyleItems.Create();
                    FlexBasis = new CssStyleItem();
              //      FlexBasis.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        FlexBasis.CssStyleId = CssStyleId;
                        FlexBasis.ItemName = "flex-basis";
                        FlexBasis.ItemValue = _flexBasisValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(FlexBasis);
                    }
                    if (CssAnimationId != null)
                    {
                        FlexBasis.CssAnimationId = CssAnimationId;
                        FlexBasis.ItemName = "flex-basis";
                        FlexBasis.StyleOrder = CurrentAnimationOrder;
                        FlexBasis.ItemValue = _flexBasisValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(FlexBasis);
                    }
                }
                else
                {
                    FlexBasis.ItemValue = _flexBasisValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string FlexGrowValue
        {
            get { return _flexGrowValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _flexGrowValue) return;
                _flexGrowValue = value;

                if (FlexGrow == null)
                {
                    // FlexGrow = CssClassesToolControl.Context.CssStyleItems.Create();
                    FlexGrow = new CssStyleItem();
              //      FlexGrow.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        FlexGrow.CssStyleId = CssStyleId;
                        FlexGrow.ItemName = "flex-grow";
                        FlexGrow.ItemValue = _flexGrowValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(FlexGrow);
                    }
                    if (CssAnimationId != null)
                    {
                        FlexGrow.CssAnimationId = CssAnimationId;
                        FlexGrow.ItemName = "flex-grow";
                        FlexGrow.StyleOrder = CurrentAnimationOrder;
                        FlexGrow.ItemValue = _flexGrowValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(FlexGrow);
                    }
                }
                else
                {
                    FlexGrow.ItemValue = _flexGrowValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string FlexShrinkValue
        {
            get { return _flexShrinkValue; }
            set
            {
                var rr = 0.0;
                if (double.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _flexShrinkValue) return;
                _flexShrinkValue = value;

                if (FlexShrink == null)
                {
                    // FlexShrink = CssClassesToolControl.Context.CssStyleItems.Create();
                    FlexShrink = new CssStyleItem();
                //    FlexShrink.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        FlexShrink.CssStyleId = CssStyleId;
                        FlexShrink.ItemName = "height";
                        FlexShrink.ItemValue = _flexShrinkValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(FlexShrink);
                    }
                    if (CssAnimationId != null)
                    {
                        FlexShrink.CssAnimationId = CssAnimationId;
                        FlexShrink.ItemName = "height";
                        FlexShrink.StyleOrder = CurrentAnimationOrder;
                        FlexShrink.ItemValue = _flexShrinkValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(FlexShrink);
                    }
                }
                else
                {
                    FlexShrink.ItemValue = _flexShrinkValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string OrderValue
        {
            get { return _flexShrinkValue; }
            set
            {
                var rr = 0;
                if (int.TryParse(value, out rr) == false)
                {
                    OnPropertyChanged();
                    return;
                }

                if (value == _orderValue) return;
                _orderValue = value;

                if (Order == null)
                {
                    //  Order = CssClassesToolControl.Context.CssStyleItems.Create();
                    Order = new CssStyleItem();
             //       Order.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        Order.CssStyleId = CssStyleId;
                        Order.ItemName = "order";
                        Order.ItemValue = _orderValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(Order);
                    }
                    if (CssAnimationId != null)
                    {
                        Order.CssAnimationId = CssAnimationId;
                        Order.ItemName = "order";
                        Order.StyleOrder = CurrentAnimationOrder;
                        Order.ItemValue = _orderValue;
                        CssClassesToolControl.Context.CssStyleItems.Add(Order);
                    }
                }
                else
                {
                    Order.ItemValue = _orderValue;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
            }
        }

        #endregion

        #endregion

        #region methods

        public void ParseClipRect(string rect)
        {
            //  $"rect({_clipTopValue}px,{_clipRightValue}px,{ClipBottomValue}px,{ClipLeftValue}px)";
            try
            {
                var pst = rect.IndexOf("(", 0, StringComparison.Ordinal);
                pst++;
                var pfi = rect.IndexOf("px,", pst, StringComparison.Ordinal);
                var top = rect.Substring(pst, pfi - pst);
                pst = pfi + 3;
                pfi = rect.IndexOf("px,", pst, StringComparison.Ordinal);
                var right = rect.Substring(pst, pfi - pst);
                pst = pfi + 3;
                pfi = rect.IndexOf("px,", pst, StringComparison.Ordinal);
                var bottom = rect.Substring(pst, pfi - pst);
                pst = pfi + 3;
                pfi = rect.IndexOf("px", pst, StringComparison.Ordinal);
                var left = rect.Substring(pst, pfi - pst);
                ClipTopValue = top;
                ClipRightValue = right;
                ClipBottomValue = bottom;
                ClipLeftValue = left;
            }
            catch (Exception ee)
            {
                string tt = ee.Message;
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

        private bool ParseBothPercent(string val, out string first, out string second)
        {
            try
            {
                var fp = val.IndexOf("%", 0, StringComparison.CurrentCulture);
                first = val.Substring(0, fp);
                fp++;
                var np = val.IndexOf("%", 0, StringComparison.CurrentCulture);
                second = val.Substring(fp, np);
                return (true);
            }
            catch (Exception)
            {
                first = "0";
                second = "0";
            }
            return (false);
        }

        private bool ParseBothPx(string val, out string first, out string second)
        {
            try
            {
                var fp = val.IndexOf("px", 0, StringComparison.CurrentCulture);
                first = val.Substring(0, fp);
                fp += 3;
                var np = val.IndexOf("px", 0, StringComparison.CurrentCulture);
                second = val.Substring(fp, np);
                return (true);
            }
            catch (Exception)
            {
                first = "0";
                second = "0";
            }
            return (false);
        }

        private void ParseBetweenQuotes(string input, out string output)
        {
            try
            {
                var forparse = input;
                var initialpos = forparse.IndexOf("\"", 0);
                initialpos++;
                var finalpos = forparse.IndexOf("\"", initialpos);
                output = forparse.Substring(initialpos, finalpos - initialpos + 1);
            }
            catch (Exception)
            {
                output = string.Empty;
            }
        }

        #region load style items

        public void LoadStyleItems()
        {
            Font.Visibility = Visibility.Visible;
            TransitionsButton.Visibility = Visibility.Visible;

            var cc = from vv in CssClassesToolControl.Context.CssStyleItems
                     where vv.CssStyleId == CssStyleId && vv.CssAnimationId == null
                     select vv;

            foreach (var it in cc.ToList())
            {
                string first;
                string second;
                switch (it.ItemName)
                {
                    case "border-style":
                        BorderStyle = it;
                        foreach (TextBlock bl in BorderStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "border-top-style":
                        BorderTopStyle = it;
                        foreach (TextBlock bl in BorderTopStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderTopStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-right-style":
                        BorderRightStyle = it;
                        foreach (TextBlock bl in BorderRightStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderRightStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-bottom-style":
                        BorderBottomStyle = it;
                        foreach (TextBlock bl in BorderBottomStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderBottomStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-left-style":
                        BorderLeftStyle = it;
                        foreach (TextBlock bl in BorderLeftStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderLeftStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "height":
                        ContentsHeight = it;
                        _contentsHeightValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsHeightValue));
                        break;

                    case "max-height":
                        ContentsMaxHeight = it;
                        _contentsMaxHeightValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsMaxHeightValue));
                        break;

                    case "min-height":
                        ContentsMinHeight = it;
                        _contentsMinHeightValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsMinHeightValue));
                        break;

                    case "width":
                        ContentsWidth = it;
                        _contentsWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsWidthValue));
                        break;

                    case "max-width":
                        ContentsMaxWidth = it;
                        _contentsMaxWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsMaxWidthValue));
                        break;

                    case "min-width":
                        ContentsMinWidth = it;
                        _contentsMinWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsMinWidthValue));
                        break;

                    case "left":
                        ContentsLeft = it;
                        _contentsLeftValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsLeftValue));
                        break;

                    case "right":
                        ContentsRight = it;
                        _contentsRightValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsRightValue));
                        break;

                    case "opacity":
                        ContentsOpacity = it;
                        _contentsOpacityValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsOpacityValue));
                        break;

                    case "top":
                        ContentsTop = it;
                        _contentsTopValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsTopValue));
                        break;

                    case "bottom":
                        ContentsBottom = it;
                        _contentsBottomValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsBottomValue));
                        break;

                    case "clip":
                        ContentsClip = it;
                        ParseClipRect(it.ItemValue);

                        break;

                    case "border-width":
                        BorderWidth = it;
                        _borderWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderWidthValue));
                        break;

                    case "border-top-width":
                        BorderTopWidth = it;
                        _borderTopWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderTopWidthValue));
                        break;

                    case "border-right-width":
                        BorderRightWidth = it;
                        _borderRightWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderRightWidthValue));
                        break;

                    case "border-bottom-width":
                        BorderBottomWidth = it;
                        _borderBottomWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderBottomWidthValue));
                        break;

                    case "border-left-width":
                        BorderLeftWidth = it;
                        _borderLeftWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderLeftWidthValue));
                        break;

                    case "border-radius":
                        BorderRadius = it;
                        _borderRadiusValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderRadiusValue));
                        break;

                    case "border-top-left-radius":
                        BorderTopLeftRadius = it;
                        _borderTopLeftRadiusValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderTopLeftRadiusValue));
                        break;

                    case "border-top-right-radius":
                        BorderTopRightRadius = it;
                        _borderTopRightRadiusValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderTopRightRadiusValue));
                        break;

                    case "border-bottom-right-radius":
                        BorderBottomRightRadius = it;
                        _borderBottomRightRadiusValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderBottomRightRadiusValue));
                        break;

                    case "border-bottom-left-radius":
                        BorderBottomLeftRadius = it;
                        _borderBottomLeftRadiusValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderBottomLeftRadiusValue));
                        break;

                    case "background-image": // Not Animatable:
                        ParseBetweenQuotes(it.ItemValue, out first);
                        if (string.IsNullOrEmpty(first) == false)
                        {
                            BackgroundImage = it;
                            _backgroundImageValue = first;
                            OnPropertyChanged(nameof(BackgroundImageValue));
                        }
                        break;

                    case "background-clip": // Not Animatable:
                        BackgroundClip = it;
                        foreach (TextBlock bl in BackgroundClipBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BackgroundClipBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "background-origin": // Not Animatable:
                        BackgroundOrigin = it;
                        foreach (TextBlock bl in BackgroundOriginBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BackgroundOriginBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "background-position":
                        if (ParseBothPercent(it.ItemValue, out first, out second))
                        {
                            BackgroundPosition = it;
                            BackgroundPositionXValue = first;
                            BackgroundPositionYValue = second;
                        }
                        break;

                    case "background-attachment":
                        BackgroundAttachment = it;
                        foreach (TextBlock bl in BackgroundAttachmentBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BackgroundAttachmentBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "background-repeat": // Not Animatable
                        BackgroundRepeat = it;
                        foreach (TextBlock bl in BackgroundRepeatBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BackgroundRepeatBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "background-size":
                        if (ParseBothPx(it.ItemValue, out first, out second))
                        {
                            BackgroundSize = it;
                            BackgroundSizeXValue = first;
                            BackgroundSizeYValue = second;
                        }
                        break;

                    case "outline-style":
                        OutlineStyle = it;
                        foreach (TextBlock bl in OutlineStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                OutlineStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "overflow-x":
                        OverflowX = it;
                        foreach (TextBlock bl in OverflowXBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                OverflowXBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "overflow-y":
                        OverflowY = it;
                        foreach (TextBlock bl in OverflowYBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                OverflowYBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "border-collapse":
                        BorderCollapse = it;
                        foreach (TextBlock bl in BorderCollapseBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderCollapseBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-spacing":
                        if (ParseBothPx(it.ItemValue, out first, out second))
                        {
                            BorderSpacing = it;
                            BorderSpacingXValue = first;
                            BorderSpacingYValue = second;
                        }
                        break;

                    case "caption-side":
                        CaptionSide = it;
                        foreach (TextBlock bl in CaptionSideBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                CaptionSideBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "empty-cells":
                        EmptyCells = it;
                        foreach (TextBlock bl in EmptyCellsBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                EmptyCellsBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "table-layout":
                        TableLayout = it;
                        foreach (TextBlock bl in TableLayoutBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                TableLayoutBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "position":
                        Position = it;
                        foreach (TextBlock bl in PositionBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                PositionBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "display":
                        Display = it;
                        foreach (TextBlock bl in DisplayBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                DisplayBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "visibility":
                        VisibilityItem = it;
                        foreach (TextBlock bl in VisibilityBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                VisibilityBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "outline-width":
                        OutlineWidth = it;
                        _outlineWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(OutlineWidthValue));
                        break;

                    case "margin":
                        StyleMargin = it;
                        _styleMarginValue = it.ItemValue;
                        OnPropertyChanged(nameof(StyleMarginValue));
                        break;

                    case "margin-top":
                        MarginLeft = it;
                        _marginLeftValue = it.ItemValue;
                        OnPropertyChanged(nameof(MarginLeftValue));
                        break;

                    case "margin-right":
                        MarginRight = it;
                        _marginRightValue = it.ItemValue;
                        OnPropertyChanged(nameof(MarginRightValue));
                        break;

                    case "margin-bottom":
                        MarginBottom = it;
                        _marginBottomValue = it.ItemValue;
                        OnPropertyChanged(nameof(MarginBottomValue));
                        break;

                    case "margin-left":
                        MarginLeft = it;
                        _marginLeftValue = it.ItemValue;
                        OnPropertyChanged(nameof(MarginLeftValue));
                        break;

                    case "padding":
                        StylePadding = it;
                        _stylePaddingValue = it.ItemValue;
                        OnPropertyChanged(nameof(StylePaddingValue));
                        break;

                    case "padding-top":
                        PaddingLeft = it;
                        _paddingLeftValue = it.ItemValue;
                        OnPropertyChanged(nameof(PaddingLeftValue));
                        break;

                    case "padding-right":
                        PaddingRight = it;
                        _paddingRightValue = it.ItemValue;
                        OnPropertyChanged(nameof(PaddingRightValue));
                        break;

                    case "padding-bottom":
                        PaddingBottom = it;
                        _paddingBottomValue = it.ItemValue;
                        OnPropertyChanged(nameof(PaddingBottomValue));
                        break;

                    case "padding-left":
                        PaddingLeft = it;
                        _paddingLeftValue = it.ItemValue;
                        OnPropertyChanged(nameof(PaddingLeftValue));
                        break;

                    case "line-height":
                        LineHeight = it;
                        _lineHeightValue = it.ItemValue;
                        OnPropertyChanged(nameof(LineHeightValue));
                        break;


                    case "letter-spacing":
                        LetterSpacing = it;
                        _letterSpacingValue = it.ItemValue;
                        OnPropertyChanged(nameof(LetterSpacingValue));
                        break;

                    case "text-indent":
                        TextIndent = it;
                        _textIndentValue = it.ItemValue;
                        OnPropertyChanged(nameof(TextIndentValue));
                        break;

                    case "column-count":
                        ColumnCount = it;
                        _columnCountValue = it.ItemValue;
                        OnPropertyChanged(nameof(ColumnCountValue));
                        break;

                    case "column-gap":
                        ColumnGap = it;
                        _columnGapValue = it.ItemValue;
                        OnPropertyChanged(nameof(ColumnGapValue));
                        break;

                    case "column-width":
                        ColumnWidth = it;
                        _columnWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(ColumnWidthValue));
                        break;

                    case "column-span":
                        ColumnSpan = it;
                        foreach (TextBlock bl in ColumnSpanBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                ColumnSpanBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "align-items":
                        AlignItems = it;
                        foreach (TextBlock bl in AlignItemsBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                AlignItemsBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "align-self":
                        AlignSelf = it;
                        foreach (TextBlock bl in AlignSelfBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                AlignSelfBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "align-content":
                        AlignSelf = it;
                        foreach (TextBlock bl in AlignContentBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                AlignContentBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "justify-content":
                        AlignSelf = it;
                        foreach (TextBlock bl in JustifyContentBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                JustifyContentBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "order":
                        Order = it;
                        OrderValue = it.ItemValue;
                        OnPropertyChanged(nameof(OrderValue));
                        break;

                    case "flex-wrap":
                        TextAlign = it;
                        foreach (TextBlock bl in FlexWrapBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FlexWrapBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "flex-direction":
                        TextAlign = it;
                        foreach (TextBlock bl in FlexDirectionBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FlexDirectionBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "flex-basis":
                        FlexBasis = it;
                        _flexBasisValue = it.ItemValue;
                        OnPropertyChanged(nameof(FlexBasisValue));
                        break;

                    case "flex-grow":
                        FlexGrow = it;
                        _flexGrowValue = it.ItemValue;
                        OnPropertyChanged(nameof(FlexGrowValue));
                        break;

                    case "flex-shrink":
                        FlexShrink = it;
                        _flexShrinkValue = it.ItemValue;
                        OnPropertyChanged(nameof(FlexShrinkValue));
                        break;

                    case "float":
                        FloatItem = it;
                        foreach (TextBlock bl in FloatItemBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FloatItemBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "text-transform":
                        TextTransform = it;
                        foreach (TextBlock bl in TextTransformBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                TextTransformBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "text-align":
                        TextAlign = it;
                        foreach (TextBlock bl in TextAlignBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                TextAlignBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "white-space":
                        WhiteSpace = it;
                        foreach (TextBlock bl in WhiteSpaceBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                WhiteSpaceBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "word-wrap":
                        WordWrap = it;
                        foreach (TextBlock bl in WordWrapBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                WordWrapBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "vertical-align":
                        ContentVerticalAlignment = it;
                        foreach (TextBlock bl in VerticalAlignBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                VerticalAlignBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "font-size":
                        FontSizeItem = it;
                        _fontSizeItemValue = it.ItemValue;
                        OnPropertyChanged(nameof(FontSizeItemValue));
                        break;

                    case "rotateX":
                        RotateX = it;
                        _rotateXValue = it.ItemValue;
                        OnPropertyChanged(nameof(RotateXValue));
                        break;

                    case "rotateY":
                        RotateY = it;
                        _rotateYValue = it.ItemValue;
                        OnPropertyChanged(nameof(RotateYValue));
                        break;

                    case "rotateZ":
                        RotateZ = it;
                        _rotateZValue = it.ItemValue;
                        OnPropertyChanged(nameof(RotateZValue));
                        break;

                    case "translateX":
                        TranslateX = it;
                        _translateXValue = it.ItemValue;
                        OnPropertyChanged(nameof(TranslateXValue));
                        break;

                    case "translateY":
                        TranslateY = it;
                        _translateYValue = it.ItemValue;
                        OnPropertyChanged(nameof(TranslateYValue));
                        break;

                    case "translateZ":
                        TranslateZ = it;
                        _translateZValue = it.ItemValue;
                        OnPropertyChanged(nameof(TranslateZValue));
                        break;

                    case "scaleX":
                        ScaleX = it;
                        _scaleXValue = it.ItemValue;
                        OnPropertyChanged(nameof(ScaleXValue));
                        break;

                    case "scaleY":
                        ScaleY = it;
                        _scaleYValue = it.ItemValue;
                        OnPropertyChanged(nameof(ScaleYValue));
                        break;

                    case "scaleZ":
                        ScaleZ = it;
                        _scaleZValue = it.ItemValue;
                        OnPropertyChanged(nameof(ScaleZValue));
                        break;

                    case "z-index":
                        ZIndex = it;
                        _zIndexValue = it.ItemValue;
                        OnPropertyChanged(nameof(ZindexValue));
                        break;

                    case "perspective":
                        Perspective = it;
                        _perspectiveValue = it.ItemValue;
                        OnPropertyChanged(nameof(PerspectiveValue));
                        break;

                    case "perspective-origin":
                        PerspectiveOrigin = it;
                        var ttstring = it.ItemValue;
                        char[] seperator = { ',' };
                        var sptt = ttstring.Split(seperator);
                        _perspectiveOriginXValue = sptt[0];
                        _perspectiveOriginYValue = sptt[1];
                        OnPropertyChanged(nameof(PerspectiveOriginXValue));
                        OnPropertyChanged(nameof(PerspectiveOriginYValue));

                        break;

                    case "transform-origin":
                        TransformOrigin = it;
                        var trstring = it.ItemValue;
                        char[] seperate = { ',' };
                        var stt = trstring.Split(seperate);
                        _transformOriginXValue = stt[0];
                        _transformOriginYValue = stt[1];
                        OnPropertyChanged(nameof(TransformOriginXValue));
                        OnPropertyChanged(nameof(TransformOriginYValue));
                        break;

                    case "font-weight":
                        FontWeightItem = it;
                        foreach (TextBlock bl in FontWeightItemBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FontWeightItemBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "font-variant":
                        FontVariantItem = it;
                        foreach (TextBlock bl in FontVariantItemBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FontVariantItemBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "font-style":
                        FontStyleItem = it;
                        foreach (TextBlock bl in FontStyleItemBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FontStyleItemBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "backface-visibility":
                        BackfaceVisibility = it;
                        foreach (TextBlock bl in BackfaceVisibilityBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BackfaceVisibilityBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "list-style-type":
                        ListStyleType = it;
                        foreach (TextBlock bl in ListStyleTypeBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                ListStyleTypeBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "list-style-position":
                        ListStylePosition = it;
                        foreach (TextBlock bl in ListStylePositionBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                ListStylePositionBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "list-text-align":
                        ListTextAlign = it;
                        foreach (TextBlock bl in ListTextAlignBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                ListTextAlignBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "box-shadow":
                        BoxShadow = it;
                        BoxShadowParse();
                        break;

                    case "text-shadow":
                        TextShadow = it;
                        TextShadowParse();
                        break;

                    case "font-family":
                        FontFamilyItem = it;
                        break;

                    case "background-color":
                        BackgroundColor = it;
                        BackgroundColorSelector = new ColorSelector();
                        BackgroundColorSelector.ColorName = it.ItemName;
                        BackgroundColorSelector.StyleItem = it;
                        BackgroundColorSelector.Load();
                        break;

                    case "border-color":
                        BorderColor = it;

                        BorderColorSelector = new ColorSelector();
                        BorderColorSelector.ColorName = it.ItemName;
                        BorderColorSelector.StyleItem = it;
                        BorderColorSelector.Load();
                        break;

                    case "outline-color":
                        OutlineColor = it;
                        OutlineColorSelector = new ColorSelector();
                        OutlineColorSelector.ColorName = it.ItemName;
                        OutlineColorSelector.StyleItem = it;
                        OutlineColorSelector.Load();
                        break;

                    case "color":
                        FontColor = it;
                        FontColorSelector = new ColorSelector();
                        FontColorSelector.ColorName = it.ItemName;
                        FontColorSelector.StyleItem = it;
                        FontColorSelector.Load();
                        break;

                        //case "boxshadow-color":
                        //    BoxShadowColor = it;
                        //    BoxShadowColorSelector = new ColorSelector();
                        //    BoxShadowColorSelector.ColorName = it.ItemName;
                        //    BoxShadowColorSelector.StyleItem = it;
                        //    BoxShadowColorSelector.SetFlatOnly();
                        //    BoxShadowColorSelector.Load();
                        //    break;
                }
            }
        }

        #endregion

        #region load animation items

        public void LoadAnimationItems()
        {
            Font.Visibility = Visibility.Collapsed;
            TransitionsButton.Visibility = Visibility.Collapsed;

            var cc = from vv in CssClassesToolControl.Context.CssStyleItems
                     where vv.CssAnimationId == CssAnimationId
                           && vv.CssStyleId == null
                           && vv.StyleOrder == CurrentAnimationOrder
                     select vv;

            foreach (var it in cc.ToList())
            {
                string first;
                string second;
                switch (it.ItemName)
                {
                    case "border-style":
                        BorderStyle = it;
                        foreach (TextBlock bl in BorderStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-top-style":
                        BorderTopStyle = it;
                        foreach (TextBlock bl in BorderTopStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderTopStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-right-style":
                        BorderRightStyle = it;
                        foreach (TextBlock bl in BorderRightStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderRightStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-bottom-style":
                        BorderBottomStyle = it;
                        foreach (TextBlock bl in BorderBottomStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderBottomStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-left-style":
                        BorderLeftStyle = it;
                        foreach (TextBlock bl in BorderLeftStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderLeftStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "height":
                        ContentsHeight = it;
                        _contentsHeightValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsHeightValue));
                        break;

                    case "max-height":
                        ContentsMaxHeight = it;
                        _contentsMaxHeightValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsMaxHeightValue));
                        break;

                    case "min-height":
                        ContentsMinHeight = it;
                        _contentsMinHeightValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsMinHeightValue));
                        break;

                    case "width":
                        ContentsWidth = it;
                        _contentsWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsWidthValue));
                        break;

                    case "max-width":
                        ContentsMaxWidth = it;
                        _contentsMaxWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsMaxWidthValue));
                        break;

                    case "min-width":
                        ContentsMinWidth = it;
                        _contentsMinWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsMinWidthValue));
                        break;

                    case "left":
                        ContentsLeft = it;
                        _contentsLeftValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsLeftValue));
                        break;

                    case "right":
                        ContentsRight = it;
                        _contentsRightValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsRightValue));
                        break;

                    case "top":
                        ContentsTop = it;
                        _contentsTopValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsTopValue));
                        break;

                    case "bottom":
                        ContentsBottom = it;
                        _contentsBottomValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsBottomValue));
                        break;

                    case "clip":
                        ContentsClip = it;
                        ParseClipRect(it.ItemValue);

                        break;

                    case "opacity":
                        ContentsOpacity = it;
                        _contentsOpacityValue = it.ItemValue;
                        OnPropertyChanged(nameof(ContentsOpacityValue));
                        break;

                    case "border-width":
                        BorderWidth = it;
                        _borderWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderWidthValue));
                        break;


                    case "border-top-width":
                        BorderTopWidth = it;
                        _borderTopWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderTopWidthValue));
                        break;

                    case "border-right-width":
                        BorderRightWidth = it;
                        _borderRightWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderRightWidthValue));
                        break;

                    case "border-bottom-width":
                        BorderBottomWidth = it;
                        _borderBottomWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderBottomWidthValue));
                        break;

                    case "border-left-width":
                        BorderLeftWidth = it;
                        _borderLeftWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderLeftWidthValue));
                        break;

                    case "border-radius":
                        BorderRadius = it;
                        _borderRadiusValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderRadiusValue));
                        break;

                    case "border-top-left-radius":
                        BorderTopLeftRadius = it;
                        _borderTopLeftRadiusValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderTopLeftRadiusValue));
                        break;

                    case "border-top-right-radius":
                        BorderTopRightRadius = it;
                        _borderTopRightRadiusValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderTopRightRadiusValue));
                        break;

                    case "border-bottom-right-radius":
                        BorderBottomRightRadius = it;
                        _borderBottomRightRadiusValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderBottomRightRadiusValue));
                        break;

                    case "border-bottom-left-radius":
                        BorderBottomLeftRadius = it;
                        _borderBottomLeftRadiusValue = it.ItemValue;
                        OnPropertyChanged(nameof(BorderBottomLeftRadiusValue));
                        break;

                    case "background-image": // Not Animatable:
                        ParseBetweenQuotes(it.ItemValue, out first);
                        if (string.IsNullOrEmpty(first) == false)
                        {
                            BackgroundImage = it;
                            _backgroundImageValue = first;
                            OnPropertyChanged(nameof(BackgroundImageValue));
                        }
                        break;


                    case "background-clip": // Not Animatable:
                        BackgroundClip = it;
                        foreach (TextBlock bl in BackgroundClipBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BackgroundClipBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "background-origin": // Not Animatable:
                        BackgroundOrigin = it;
                        foreach (TextBlock bl in BackgroundOriginBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BackgroundOriginBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "background-position":
                        if (ParseBothPercent(it.ItemValue, out first, out second))
                        {
                            BackgroundPosition = it;
                            BackgroundPositionXValue = first;
                            BackgroundPositionYValue = second;
                        }
                        break;

                    case "background-repeat": // Not Animatable
                        BackgroundRepeat = it;
                        foreach (TextBlock bl in BackgroundRepeatBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BackgroundRepeatBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "background-attachment":
                        BackgroundAttachment = it;
                        foreach (TextBlock bl in BackgroundAttachmentBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BackgroundAttachmentBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "background-size":

                        if (ParseBothPx(it.ItemValue, out first, out second))
                        {
                            BackgroundSize = it;
                            BackgroundSizeXValue = first;
                            BackgroundSizeYValue = second;
                        }
                        break;


                    case "outline-style":
                        OutlineStyle = it;
                        foreach (TextBlock bl in OutlineStyleBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                OutlineStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "overflow-x":
                        OverflowX = it;
                        foreach (TextBlock bl in OverflowXBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                OverflowXBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "overflow-y":
                        OverflowY = it;
                        foreach (TextBlock bl in OverflowYBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                OverflowYBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-collapse":
                        BorderCollapse = it;
                        foreach (TextBlock bl in BorderCollapseBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BorderCollapseBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-spacing":
                        if (ParseBothPx(it.ItemValue, out first, out second))
                        {
                            BorderSpacing = it;
                            BorderSpacingXValue = first;
                            BorderSpacingYValue = second;
                        }
                        break;

                    case "caption-side":
                        CaptionSide = it;
                        foreach (TextBlock bl in CaptionSideBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                CaptionSideBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "empty-cells":
                        EmptyCells = it;
                        foreach (TextBlock bl in EmptyCellsBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                EmptyCellsBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "table-layout":
                        TableLayout = it;
                        foreach (TextBlock bl in TableLayoutBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                TableLayoutBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "position":
                        Position = it;
                        foreach (TextBlock bl in PositionBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                PositionBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "display":
                        Display = it;
                        foreach (TextBlock bl in DisplayBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                DisplayBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "visibility":
                        VisibilityItem = it;
                        foreach (TextBlock bl in VisibilityBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                VisibilityBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "outline-width":
                        OutlineWidth = it;
                        _outlineWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(OutlineWidthValue));
                        break;

                    case "margin":
                        StyleMargin = it;
                        _styleMarginValue = it.ItemValue;
                        OnPropertyChanged(nameof(StyleMarginValue));
                        break;

                    case "margin-top":
                        MarginLeft = it;
                        _marginLeftValue = it.ItemValue;
                        OnPropertyChanged(nameof(MarginLeftValue));
                        break;

                    case "margin-right":
                        MarginRight = it;
                        _marginRightValue = it.ItemValue;
                        OnPropertyChanged(nameof(MarginRightValue));
                        break;

                    case "margin-bottom":
                        MarginBottom = it;
                        _marginBottomValue = it.ItemValue;
                        OnPropertyChanged(nameof(MarginBottomValue));
                        break;

                    case "margin-left":
                        MarginLeft = it;
                        _marginLeftValue = it.ItemValue;
                        OnPropertyChanged(nameof(MarginLeftValue));
                        break;

                    case "padding":
                        StylePadding = it;
                        _stylePaddingValue = it.ItemValue;
                        OnPropertyChanged(nameof(StylePaddingValue));
                        break;

                    case "padding-top":
                        PaddingLeft = it;
                        _paddingLeftValue = it.ItemValue;
                        OnPropertyChanged(nameof(PaddingLeftValue));
                        break;

                    case "padding-right":
                        PaddingRight = it;
                        _paddingRightValue = it.ItemValue;
                        OnPropertyChanged(nameof(PaddingRightValue));
                        break;

                    case "padding-bottom":
                        PaddingBottom = it;
                        _paddingBottomValue = it.ItemValue;
                        OnPropertyChanged(nameof(PaddingBottomValue));
                        break;

                    case "padding-left":
                        PaddingLeft = it;
                        _paddingLeftValue = it.ItemValue;
                        OnPropertyChanged(nameof(PaddingLeftValue));
                        break;

                    case "line-height":
                        LineHeight = it;
                        _lineHeightValue = it.ItemValue;
                        OnPropertyChanged(nameof(LineHeightValue));
                        break;

                    case "letter-spacing":
                        LetterSpacing = it;
                        _letterSpacingValue = it.ItemValue;
                        OnPropertyChanged(nameof(LetterSpacingValue));
                        break;

                    case "text-indent":
                        TextIndent = it;
                        _textIndentValue = it.ItemValue;
                        OnPropertyChanged(nameof(TextIndentValue));
                        break;

                    case "column-count":
                        ColumnCount = it;
                        _columnCountValue = it.ItemValue;
                        OnPropertyChanged(nameof(ColumnCountValue));
                        break;

                    case "column-gap":
                        ColumnGap = it;
                        _columnGapValue = it.ItemValue;
                        OnPropertyChanged(nameof(ColumnGapValue));
                        break;

                    case "column-width":
                        ColumnWidth = it;
                        _columnWidthValue = it.ItemValue;
                        OnPropertyChanged(nameof(ColumnWidthValue));
                        break;

                    case "column-span":
                        ColumnSpan = it;
                        foreach (TextBlock bl in ColumnSpanBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                ColumnSpanBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "align-items":
                        AlignItems = it;
                        foreach (TextBlock bl in AlignItemsBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                AlignItemsBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "align-self":
                        AlignSelf = it;
                        foreach (TextBlock bl in AlignSelfBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                AlignSelfBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "align-content":
                        AlignSelf = it;
                        foreach (TextBlock bl in AlignContentBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                AlignContentBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "justify-content":
                        AlignSelf = it;
                        foreach (TextBlock bl in JustifyContentBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                JustifyContentBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "order":
                        Order = it;
                        OrderValue = it.ItemValue;
                        OnPropertyChanged(nameof(OrderValue));
                        break;

                    case "flex-wrap":
                        TextAlign = it;
                        foreach (TextBlock bl in FlexWrapBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FlexWrapBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "flex-direction":
                        TextAlign = it;
                        foreach (TextBlock bl in FlexDirectionBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FlexDirectionBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "flex-basis":
                        FlexBasis = it;
                        _flexBasisValue = it.ItemValue;
                        OnPropertyChanged(nameof(FlexBasisValue));
                        break;

                    case "flex-grow":
                        FlexGrow = it;
                        _flexGrowValue = it.ItemValue;
                        OnPropertyChanged(nameof(FlexGrowValue));
                        break;

                    case "flex-shrink":
                        FlexShrink = it;
                        _flexShrinkValue = it.ItemValue;
                        OnPropertyChanged(nameof(FlexShrinkValue));
                        break;

                    case "float":
                        FloatItem = it;
                        foreach (TextBlock bl in FloatItemBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FloatItemBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "text-align":
                        TextAlign = it;
                        foreach (TextBlock bl in TextAlignBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                TextAlignBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "text-transform":
                        TextTransform = it;
                        foreach (TextBlock bl in TextTransformBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                TextTransformBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "white-space":
                        WhiteSpace = it;
                        foreach (TextBlock bl in WhiteSpaceBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                WhiteSpaceBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "word-wrap":
                        WordWrap = it;
                        foreach (TextBlock bl in WordWrapBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                WordWrapBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "font-size":
                        FontSizeItem = it;
                        _fontSizeItemValue = it.ItemValue;
                        OnPropertyChanged(nameof(FontSizeItemValue));
                        break;


                    case "rotateX":
                        RotateX = it;
                        _rotateXValue = it.ItemValue;
                        OnPropertyChanged(nameof(RotateXValue));
                        break;

                    case "rotateY":
                        RotateY = it;
                        _rotateYValue = it.ItemValue;
                        OnPropertyChanged(nameof(RotateYValue));
                        break;

                    case "rotateZ":
                        RotateZ = it;
                        _rotateZValue = it.ItemValue;
                        OnPropertyChanged(nameof(RotateZValue));
                        break;

                    case "translateX":
                        TranslateX = it;
                        _translateXValue = it.ItemValue;
                        OnPropertyChanged(nameof(TranslateXValue));
                        break;

                    case "translateY":
                        TranslateY = it;
                        _translateYValue = it.ItemValue;
                        OnPropertyChanged(nameof(TranslateYValue));
                        break;

                    case "translateZ":
                        TranslateZ = it;
                        _translateZValue = it.ItemValue;
                        OnPropertyChanged(nameof(TranslateZValue));
                        break;

                    case "scaleX":
                        ScaleX = it;
                        _scaleXValue = it.ItemValue;
                        OnPropertyChanged(nameof(ScaleXValue));
                        break;

                    case "scaleY":
                        ScaleY = it;
                        _scaleYValue = it.ItemValue;
                        OnPropertyChanged(nameof(ScaleYValue));
                        break;

                    case "scaleZ":
                        ScaleZ = it;
                        _scaleZValue = it.ItemValue;
                        OnPropertyChanged(nameof(ScaleZValue));
                        break;

                    case "perspective":
                        Perspective = it;
                        _perspectiveValue = it.ItemValue;
                        OnPropertyChanged(nameof(PerspectiveValue));
                        break;

                    case "perspective-origin":
                        PerspectiveOrigin = it;
                        var ttstring = it.ItemValue;
                        char[] seperator = { ',' };
                        var sptt = ttstring.Split(seperator);
                        _perspectiveOriginXValue = sptt[0];
                        _perspectiveOriginYValue = sptt[1];
                        OnPropertyChanged(nameof(PerspectiveOriginXValue));
                        OnPropertyChanged(nameof(PerspectiveOriginYValue));
                        break;

                    case "transform-origin":
                        TransformOrigin = it;
                        var trstring = it.ItemValue;
                        char[] seperate = { ',' };
                        var stt = trstring.Split(seperate);
                        _transformOriginXValue = stt[0];
                        _transformOriginYValue = stt[1];
                        OnPropertyChanged(nameof(TransformOriginXValue));
                        OnPropertyChanged(nameof(TransformOriginYValue));
                        break;


                    case "vertical-align":
                        ContentVerticalAlignment = it;
                        foreach (TextBlock bl in VerticalAlignBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                VerticalAlignBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "z-index":
                        ZIndex = it;
                        _zIndexValue = it.ItemValue;
                        OnPropertyChanged(nameof(ZindexValue));
                        break;

                    case "font-weight":
                        FontWeightItem = it;
                        foreach (TextBlock bl in FontWeightItemBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FontWeightItemBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "font-variant":
                        FontVariantItem = it;
                        foreach (TextBlock bl in FontVariantItemBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FontVariantItemBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "font-style":
                        FontStyleItem = it;
                        foreach (TextBlock bl in FontStyleItemBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                FontStyleItemBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "backface-visibility":
                        BackfaceVisibility = it;
                        foreach (TextBlock bl in BackfaceVisibilityBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                BackfaceVisibilityBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "list-style-type":
                        ListStyleType = it;
                        foreach (TextBlock bl in ListStyleTypeBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                ListStyleTypeBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "list-style-position":
                        ListStylePosition = it;
                        foreach (TextBlock bl in ListStylePositionBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                ListStylePositionBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "list-text-align":
                        ListTextAlign = it;
                        foreach (TextBlock bl in ListTextAlignBox.Items)
                        {
                            if (bl.Text == it.ItemValue)
                            {
                                ListTextAlignBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "box-shadow":
                        BoxShadow = it;
                        BoxShadowParse();
                        break;

                    case "text-shadow":
                        TextShadow = it;
                        TextShadowParse();
                        break;


                    case "font-family":
                        FontFamilyItem = it;
                        break;

                    case "background-color":
                        BackgroundColor = it;
                        BackgroundColorSelector = new ColorSelector();
                        BackgroundColorSelector.ColorName = it.ItemName;
                        BackgroundColorSelector.StyleItem = it;
                        BackgroundColorSelector.Load();
                        break;

                    case "border-color":
                        BorderColor = it;

                        BorderColorSelector = new ColorSelector();
                        BorderColorSelector.ColorName = it.ItemName;
                        BorderColorSelector.StyleItem = it;
                        BorderColorSelector.Load();
                        break;

                    case "outline-color":
                        OutlineColor = it;
                        OutlineColorSelector = new ColorSelector();
                        OutlineColorSelector.ColorName = it.ItemName;
                        OutlineColorSelector.StyleItem = it;
                        OutlineColorSelector.Load();
                        break;

                    case "color":
                        FontColor = it;
                        FontColorSelector = new ColorSelector();
                        FontColorSelector.ColorName = it.ItemName;
                        FontColorSelector.StyleItem = it;
                        FontColorSelector.Load();
                        break;

                        //case "boxshadow-color":
                        //    BoxShadowColor = it;
                        //    BoxShadowColorSelector = new ColorSelector();
                        //    BoxShadowColorSelector.ColorName = it.ItemName;
                        //    BoxShadowColorSelector.StyleItem = it;
                        //    BoxShadowColorSelector.Load();
                        //    break;
                }
            }
        }

        #endregion
        #endregion

        #region events

        private void CssItem_Loaded(object sender, RoutedEventArgs e)
        {
            _isLoaded = true;
        }

        #region OnSelectionChanged Events

        private void BackGroundClipBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (BackgroundClip == null)
            {
                //   BackgroundClip = CssClassesToolControl.Context.CssStyleItems.Create();
                BackgroundClip = new CssStyleItem();
           //     BackgroundClip.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BackgroundClip.CssStyleId = CssStyleId;
                    BackgroundClip.ItemName = "background-clip";
                    BackgroundClip.ItemValue = (BackgroundClipBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(BackgroundClip);
                }
                if (CssAnimationId != null)
                {
                    BackgroundClip.CssAnimationId = CssAnimationId;
                    BackgroundClip.ItemName = "background-clip";
                    BackgroundClip.ItemValue = (BackgroundClipBox.SelectedItem as TextBlock).Text;
                    BackgroundClip.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BackgroundClip);
                }
            }
            else
            {
                BackgroundClip.ItemValue = (BackgroundClipBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void BackGroundOriginBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (BackgroundOrigin == null)
            {
                //   BackgroundOrigin = CssClassesToolControl.Context.CssStyleItems.Create();
                BackgroundOrigin = new CssStyleItem();
             //   BackgroundOrigin.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BackgroundOrigin.CssStyleId = CssStyleId;
                    BackgroundOrigin.ItemName = "background-origin";
                    BackgroundOrigin.ItemValue = (BackgroundOriginBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(BackgroundOrigin);
                }
                if (CssAnimationId != null)
                {
                    BackgroundOrigin.CssAnimationId = CssAnimationId;
                    BackgroundOrigin.ItemName = "background-origin";
                    BackgroundOrigin.ItemValue = (BackgroundOriginBox.SelectedItem as TextBlock).Text;
                    BackgroundOrigin.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BackgroundOrigin);
                }
            }
            else
            {
                BackgroundOrigin.ItemValue = (BackgroundOriginBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void BackGroundRepeatBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (BackgroundRepeat == null)
            {
                // BackgroundRepeat = CssClassesToolControl.Context.CssStyleItems.Create();
                BackgroundRepeat = new CssStyleItem();
          //      BackgroundRepeat.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BackgroundRepeat.CssStyleId = CssStyleId;
                    BackgroundRepeat.ItemName = "background-repeat";
                    BackgroundRepeat.ItemValue = (BackgroundRepeatBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(BackgroundRepeat);
                }
                if (CssAnimationId != null)
                {
                    BackgroundRepeat.CssAnimationId = CssAnimationId;
                    BackgroundRepeat.ItemName = "background-repeat";
                    BackgroundRepeat.ItemValue = (BackgroundRepeatBox.SelectedItem as TextBlock).Text;
                    BackgroundRepeat.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BackgroundRepeat);
                }
            }
            else
            {
                BackgroundRepeat.ItemValue = (BackgroundRepeatBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void BackGroundAttachmentBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (BackgroundAttachment == null)
            {
                //  BackgroundAttachment = CssClassesToolControl.Context.CssStyleItems.Create();
                BackgroundAttachment = new CssStyleItem();
          //      BackgroundAttachment.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BackgroundAttachment.CssStyleId = CssStyleId;
                    BackgroundAttachment.ItemName = "background-attachment";
                    BackgroundAttachment.ItemValue = (BackgroundAttachmentBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(BackgroundAttachment);
                }
                if (CssAnimationId != null)
                {
                    BackgroundAttachment.CssAnimationId = CssAnimationId;
                    BackgroundAttachment.ItemName = "background-attachment";
                    BackgroundAttachment.ItemValue = (BackgroundAttachmentBox.SelectedItem as TextBlock).Text;
                    BackgroundAttachment.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BackgroundAttachment);
                }
            }
            else
            {
                BackgroundAttachment.ItemValue = (BackgroundAttachmentBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void BorderStyleBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }

            if (BorderTopStyle != null)
            {
                CssClassesToolControl.Context.CssStyleItems.Remove(BorderTopStyle);
                BorderTopStyle = null;
                foreach (TextBlock bl in BorderTopStyleBox.Items)
                {
                    if (bl.Text == "none")
                    {
                        BorderTopStyleBox.SelectedItem = bl;
                        break;
                    }
                }
            }

            if (BorderRightStyle != null)
            {
                CssClassesToolControl.Context.CssStyleItems.Remove(BorderRightStyle);
                BorderRightStyle = null;
                foreach (TextBlock bl in BorderRightStyleBox.Items)
                {
                    if (bl.Text == "none")
                    {
                        BorderRightStyleBox.SelectedItem = bl;
                        break;
                    }
                }
            }

            if (BorderBottomStyle != null)
            {
                CssClassesToolControl.Context.CssStyleItems.Remove(BorderBottomStyle);
                BorderBottomStyle = null;
                foreach (TextBlock bl in BorderBottomStyleBox.Items)
                {
                    if (bl.Text == "none")
                    {
                        BorderBottomStyleBox.SelectedItem = bl;
                        break;
                    }
                }
            }

            if (BorderLeftStyle != null)
            {
                CssClassesToolControl.Context.CssStyleItems.Remove(BorderLeftStyle);
                BorderLeftStyle = null;
                foreach (TextBlock bl in BorderLeftStyleBox.Items)
                {
                    if (bl.Text == "none")
                    {
                        BorderLeftStyleBox.SelectedItem = bl;
                        break;
                    }
                }
            }

            if (BorderStyle == null)
            {
                //BorderStyle = CssClassesToolControl.Context.CssStyleItems.Create();
                BorderStyle = new CssStyleItem();
            //    BorderStyle.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BorderStyle.CssStyleId = CssStyleId;
                    BorderStyle.ItemName = "border-style";
                    BorderStyle.ItemValue = (BorderStyleBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderStyle);
                }
                if (CssAnimationId != null)
                {
                    BorderStyle.CssAnimationId = CssAnimationId;
                    BorderStyle.ItemName = "border-style";
                    BorderStyle.ItemValue = (BorderStyleBox.SelectedItem as TextBlock).Text;
                    BorderStyle.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderStyle);
                }
            }
            else
            {
                BorderStyle.ItemValue = (BorderStyleBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
            
        }

        private void BorderTopStyleBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (BorderStyle != null)
            {
                CssClassesToolControl.Context.CssStyleItems.Remove(BorderStyle);
                BorderStyle = null;
                foreach (TextBlock bl in BorderStyleBox.Items)
                {
                    if (bl.Text == "none")
                    {
                        BorderStyleBox.SelectedItem = bl;
                        break;
                    }
                }
            }

            if (BorderTopStyle == null)
            {
                //     BorderTopStyle = CssClassesToolControl.Context.CssStyleItems.Create();
                BorderTopStyle = new CssStyleItem();
        //        BorderTopStyle.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BorderTopStyle.CssStyleId = CssStyleId;
                    BorderTopStyle.ItemName = "border-top-style";
                    BorderTopStyle.ItemValue = (BorderTopStyleBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderTopStyle);
                }
                if (CssAnimationId != null)
                {
                    BorderTopStyle.CssAnimationId = CssAnimationId;
                    BorderTopStyle.ItemName = "border-top-style";
                    BorderTopStyle.ItemValue = (BorderTopStyleBox.SelectedItem as TextBlock).Text;
                    BorderTopStyle.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderTopStyle);
                }
            }
            else
            {
                BorderTopStyle.ItemValue = (BorderTopStyleBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void BorderRightStyleBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }

            if (BorderStyle != null)
            {
                CssClassesToolControl.Context.CssStyleItems.Remove(BorderStyle);
                BorderStyle = null;
                foreach (TextBlock bl in BorderStyleBox.Items)
                {
                    if (bl.Text == "none")
                    {
                        BorderStyleBox.SelectedItem = bl;
                        break;
                    }
                }
            }

            if (BorderRightStyle == null)
            {
                //  BorderRightStyle = CssClassesToolControl.Context.CssStyleItems.Create();
                BorderRightStyle = new CssStyleItem();
             //   BorderRightStyle.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BorderRightStyle.CssStyleId = CssStyleId;
                    BorderRightStyle.ItemName = "border-right-style";
                    BorderRightStyle.ItemValue = (BorderRightStyleBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderRightStyle);
                }
                if (CssAnimationId != null)
                {
                    BorderRightStyle.CssAnimationId = CssAnimationId;
                    BorderRightStyle.ItemName = "border-right-style";
                    BorderRightStyle.ItemValue = (BorderRightStyleBox.SelectedItem as TextBlock).Text;
                    BorderRightStyle.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderRightStyle);
                }
            }
            else
            {
                BorderRightStyle.ItemValue = (BorderRightStyleBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void BorderBottomStyleBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (BorderStyle != null)
            {
                CssClassesToolControl.Context.CssStyleItems.Remove(BorderStyle);
                BorderStyle = null;
                foreach (TextBlock bl in BorderStyleBox.Items)
                {
                    if (bl.Text == "none")
                    {
                        BorderStyleBox.SelectedItem = bl;
                        break;
                    }
                }
            }

            if (BorderBottomStyle == null)
            {
                //      BorderBottomStyle = CssClassesToolControl.Context.CssStyleItems.Create();
                BorderBottomStyle = new CssStyleItem();
            //    BorderBottomStyle.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BorderBottomStyle.CssStyleId = CssStyleId;
                    BorderBottomStyle.ItemName = "border-bottom-style";
                    BorderBottomStyle.ItemValue = (BorderBottomStyleBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderBottomStyle);
                }
                if (CssAnimationId != null)
                {
                    BorderBottomStyle.CssAnimationId = CssAnimationId;
                    BorderBottomStyle.ItemName = "border-bottom-style";
                    BorderBottomStyle.ItemValue = (BorderBottomStyleBox.SelectedItem as TextBlock).Text;
                    BorderBottomStyle.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderBottomStyle);
                }
            }
            else
            {
                BorderBottomStyle.ItemValue = (BorderBottomStyleBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void BorderLeftStyleBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (BorderStyle != null)
            {
                CssClassesToolControl.Context.CssStyleItems.Remove(BorderStyle);
                BorderStyle = null;
                foreach (TextBlock bl in BorderStyleBox.Items)
                {
                    if (bl.Text == "none")
                    {
                        BorderStyleBox.SelectedItem = bl;
                        break;
                    }
                }
            }
            if (BorderLeftStyle == null)
            {
                //   BorderLeftStyle = CssClassesToolControl.Context.CssStyleItems.Create();
                BorderLeftStyle = new CssStyleItem();
             //   BorderLeftStyle.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BorderLeftStyle.CssStyleId = CssStyleId;
                    BorderLeftStyle.ItemName = "border-left-style";
                    BorderLeftStyle.ItemValue = (BorderLeftStyleBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderLeftStyle);
                }
                if (CssAnimationId != null)
                {
                    BorderLeftStyle.CssAnimationId = CssAnimationId;
                    BorderLeftStyle.ItemName = "border-left-style";
                    BorderLeftStyle.ItemValue = (BorderLeftStyleBox.SelectedItem as TextBlock).Text;
                    BorderLeftStyle.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderLeftStyle);
                }
            }
            else
            {
                BorderLeftStyle.ItemValue = (BorderLeftStyleBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void OutlineStyleBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (OutlineStyle == null)
            {
                //  OutlineStyle = CssClassesToolControl.Context.CssStyleItems.Create();
                OutlineStyle = new CssStyleItem();
           //     OutlineStyle.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    OutlineStyle.CssStyleId = CssStyleId;
                    OutlineStyle.ItemName = "outline-style";
                    OutlineStyle.ItemValue = (OutlineStyleBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(OutlineStyle);
                }
                if (CssAnimationId != null)
                {
                    OutlineStyle.CssAnimationId = CssAnimationId;
                    OutlineStyle.ItemName = "outline-style";
                    OutlineStyle.ItemValue = (OutlineStyleBox.SelectedItem as TextBlock).Text;
                    OutlineStyle.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(OutlineStyle);
                }
            }
            else
            {
                OutlineStyle.ItemValue = (OutlineStyleBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void PositionBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (Position == null)
            {
                //        Position = CssClassesToolControl.Context.CssStyleItems.Create();
                Position = new CssStyleItem();
        //        Position.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    Position.CssStyleId = CssStyleId;
                    Position.ItemName = "position";
                    Position.ItemValue = (PositionBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(Position);
                }
                if (CssAnimationId != null)
                {
                    Position.CssAnimationId = CssAnimationId;
                    Position.ItemName = "position";
                    Position.ItemValue = (PositionBox.SelectedItem as TextBlock).Text;
                    Position.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(Position);
                }
            }
            else
            {
                Position.ItemValue = (PositionBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void DisplayBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (Display == null)
            {
                //       Display = CssClassesToolControl.Context.CssStyleItems.Create();
                Display = new CssStyleItem();
         //       Display.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    Display.CssStyleId = CssStyleId;
                    Display.ItemName = "display";
                    Display.ItemValue = (DisplayBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(Display);
                }
                if (CssAnimationId != null)
                {
                    Display.CssAnimationId = CssAnimationId;
                    Display.ItemName = "display";
                    Display.ItemValue = (DisplayBox.SelectedItem as TextBlock).Text;
                    Display.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(Display);
                }
            }
            else
            {
                Position.ItemValue = (DisplayBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void VisibilityBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (VisibilityItem == null)
            {
                //   VisibilityItem = CssClassesToolControl.Context.CssStyleItems.Create();
                VisibilityItem = new CssStyleItem();
         //       VisibilityItem.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    VisibilityItem.CssStyleId = CssStyleId;
                    VisibilityItem.ItemName = "visibility";
                    VisibilityItem.ItemValue = (VisibilityBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(VisibilityItem);
                }
                if (CssAnimationId != null)
                {
                    VisibilityItem.CssAnimationId = CssAnimationId;
                    VisibilityItem.ItemName = "visibility";
                    VisibilityItem.ItemValue = (VisibilityBox.SelectedItem as TextBlock).Text;
                    VisibilityItem.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(VisibilityItem);
                }
            }
            else
            {
                VisibilityItem.ItemValue = (VisibilityBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void ColumnSpanBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (ColumnSpan == null)
            {
                //      ColumnSpan = CssClassesToolControl.Context.CssStyleItems.Create();
                ColumnSpan = new CssStyleItem();
              //  ColumnSpan.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    ColumnSpan.CssStyleId = CssStyleId;
                    ColumnSpan.ItemName = "column-span";
                    ColumnSpan.ItemValue = (ColumnSpanBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(ColumnSpan);
                }
                if (CssAnimationId != null)
                {
                    ColumnSpan.CssAnimationId = CssAnimationId;
                    ColumnSpan.ItemName = "column-span";
                    ColumnSpan.ItemValue = (ColumnSpanBox.SelectedItem as TextBlock).Text;
                    ColumnSpan.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(ColumnSpan);
                }
            }
            else
            {
                ColumnSpan.ItemValue = (ColumnSpanBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void AlignItemsBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (AlignItems == null)
            {
                //      AlignItems = CssClassesToolControl.Context.CssStyleItems.Create();
                AlignItems = new CssStyleItem();
         //       AlignItems.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    AlignItems.CssStyleId = CssStyleId;
                    AlignItems.ItemName = "align-items";
                    AlignItems.ItemValue = (AlignItemsBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(AlignItems);
                }
                if (CssAnimationId != null)
                {
                    AlignItems.CssAnimationId = CssAnimationId;
                    AlignItems.ItemName = "align-items";
                    AlignItems.ItemValue = (AlignItemsBox.SelectedItem as TextBlock).Text;
                    AlignItems.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(AlignItems);
                }
            }
            else
            {
                AlignItems.ItemValue = (AlignItemsBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void JustifyContentBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (JustifyContent == null)
            {
                //    JustifyContent = CssClassesToolControl.Context.CssStyleItems.Create();
                JustifyContent = new CssStyleItem();
          //      JustifyContent.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    JustifyContent.CssStyleId = CssStyleId;
                    JustifyContent.ItemName = "justify-content";
                    JustifyContent.ItemValue = (JustifyContentBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(JustifyContent);
                }
                if (CssAnimationId != null)
                {
                    JustifyContent.CssAnimationId = CssAnimationId;
                    JustifyContent.ItemName = "justify-content";
                    JustifyContent.ItemValue = (JustifyContentBox.SelectedItem as TextBlock).Text;
                    JustifyContent.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(JustifyContent);
                }
            }
            else
            {
                JustifyContent.ItemValue = (JustifyContentBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void AlignSelfBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (AlignSelf == null)
            {
                //     AlignSelf = CssClassesToolControl.Context.CssStyleItems.Create();
                AlignSelf = new CssStyleItem();
         //       AlignSelf.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    AlignSelf.CssStyleId = CssStyleId;
                    AlignSelf.ItemName = "align-self";
                    AlignSelf.ItemValue = (AlignSelfBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(AlignSelf);
                }
                if (CssAnimationId != null)
                {
                    AlignSelf.CssAnimationId = CssAnimationId;
                    AlignSelf.ItemName = "align-self";
                    AlignSelf.ItemValue = (AlignSelfBox.SelectedItem as TextBlock).Text;
                    AlignSelf.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(AlignSelf);
                }
            }
            else
            {
                AlignSelf.ItemValue = (AlignSelfBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void AlignContentBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (AlignContent == null)
            {
                //     AlignContent = CssClassesToolControl.Context.CssStyleItems.Create();
                AlignContent = new CssStyleItem();
             //   AlignContent.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    AlignContent.CssStyleId = CssStyleId;
                    AlignContent.ItemName = "align-content";
                    AlignContent.ItemValue = (AlignContentBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(AlignContent);
                }
                if (CssAnimationId != null)
                {
                    AlignContent.CssAnimationId = CssAnimationId;
                    AlignContent.ItemName = "align-content";
                    AlignContent.ItemValue = (AlignContentBox.SelectedItem as TextBlock).Text;
                    AlignContent.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(AlignContent);
                }
            }
            else
            {
                AlignContent.ItemValue = (AlignContentBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void FloatItemBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (FloatItem == null)
            {
                //     FloatItem = CssClassesToolControl.Context.CssStyleItems.Create();
                FloatItem = new CssStyleItem();
           //     FloatItem.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    FloatItem.CssStyleId = CssStyleId;
                    FloatItem.ItemName = "float";
                    FloatItem.ItemValue = (FloatItemBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(FloatItem);
                }
                if (CssAnimationId != null)
                {
                    FloatItem.CssAnimationId = CssAnimationId;
                    FloatItem.ItemName = "float";
                    FloatItem.ItemValue = (FloatItemBox.SelectedItem as TextBlock).Text;
                    FloatItem.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(FloatItem);
                }
            }
            else
            {
                FloatItem.ItemValue = (FloatItemBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void TextAlignBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (TextAlign == null)
            {
                // TextAlign = CssClassesToolControl.Context.CssStyleItems.Create();
                TextAlign = new CssStyleItem();
           //     TextAlign.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    TextAlign.CssStyleId = CssStyleId;
                    TextAlign.ItemName = "text-align";
                    TextAlign.ItemValue = (TextAlignBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(TextAlign);
                }
                if (CssAnimationId != null)
                {
                    TextAlign.CssAnimationId = CssAnimationId;
                    TextAlign.ItemName = "text-align";
                    TextAlign.ItemValue = (TextAlignBox.SelectedItem as TextBlock).Text;
                    TextAlign.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(TextAlign);
                }
            }
            else
            {
                TextAlign.ItemValue = (TextAlignBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void TextTransformBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (TextTransform == null)
            {
                //  TextTransform = CssClassesToolControl.Context.CssStyleItems.Create();
                TextTransform = new CssStyleItem();
             //   TextTransform.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    TextTransform.CssStyleId = CssStyleId;
                    TextTransform.ItemName = "text-transform";
                    TextTransform.ItemValue = (TextTransformBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(TextTransform);
                }
                if (CssAnimationId != null)
                {
                    TextTransform.CssAnimationId = CssAnimationId;
                    TextTransform.ItemName = "text-transform";
                    TextTransform.ItemValue = (TextTransformBox.SelectedItem as TextBlock).Text;
                    TextTransform.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(TextTransform);
                }
            }
            else
            {
                TextTransform.ItemValue = (TextTransformBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void WhiteSpaceBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (WhiteSpace == null)
            {
                //  WhiteSpace = CssClassesToolControl.Context.CssStyleItems.Create();
                WhiteSpace = new CssStyleItem();
             //   WhiteSpace.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    WhiteSpace.CssStyleId = CssStyleId;
                    WhiteSpace.ItemName = "white-space";
                    WhiteSpace.ItemValue = (WhiteSpaceBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(WhiteSpace);
                }
                if (CssAnimationId != null)
                {
                    WhiteSpace.CssAnimationId = CssAnimationId;
                    WhiteSpace.ItemName = "white-space";
                    WhiteSpace.ItemValue = (WhiteSpaceBox.SelectedItem as TextBlock).Text;
                    WhiteSpace.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(WhiteSpace);
                }
            }
            else
            {
                WhiteSpace.ItemValue = (WhiteSpaceBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void WordWrapBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (WordWrap == null)
            {
                //    WordWrap = CssClassesToolControl.Context.CssStyleItems.Create();
                WordWrap = new CssStyleItem();
            //    WordWrap.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    WordWrap.CssStyleId = CssStyleId;
                    WordWrap.ItemName = "word-wrap";
                    WordWrap.ItemValue = (WordWrapBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(WordWrap);
                }
                if (CssAnimationId != null)
                {
                    WordWrap.CssAnimationId = CssAnimationId;
                    WordWrap.ItemName = "word-wrap";
                    WordWrap.ItemValue = (WordWrapBox.SelectedItem as TextBlock).Text;
                    WordWrap.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(WordWrap);
                }
            }
            else
            {
                WordWrap.ItemValue = (WordWrapBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void FontWeightItemBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (FontWeightItem == null)
            {
                //     FontWeightItem = CssClassesToolControl.Context.CssStyleItems.Create();
                FontWeightItem = new CssStyleItem();
               // FontWeightItem.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    FontWeightItem.CssStyleId = CssStyleId;
                    FontWeightItem.ItemName = "font-weight";
                    FontWeightItem.ItemValue = (FontWeightItemBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(FontWeightItem);
                }
                if (CssAnimationId != null)
                {
                    FontWeightItem.CssAnimationId = CssAnimationId;
                    FontWeightItem.ItemName = "font-weight";
                    FontWeightItem.ItemValue = (FontWeightItemBox.SelectedItem as TextBlock).Text;
                    FontWeightItem.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(FontWeightItem);
                }
            }
            else
            {
                FontWeightItem.ItemValue = (FontWeightItemBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void FontVariantItemBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (FontVariantItem == null)
            {
                //   FontVariantItem = CssClassesToolControl.Context.CssStyleItems.Create();
                FontVariantItem = new CssStyleItem();
            //    FontVariantItem.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    FontVariantItem.CssStyleId = CssStyleId;
                    FontVariantItem.ItemName = "font-variant";
                    FontVariantItem.ItemValue = (FontVariantItemBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(FontVariantItem);
                }
                if (CssAnimationId != null)
                {
                    FontVariantItem.CssAnimationId = CssAnimationId;
                    FontVariantItem.ItemName = "font-variant";
                    FontVariantItem.ItemValue = (FontVariantItemBox.SelectedItem as TextBlock).Text;
                    FontVariantItem.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(FontVariantItem);
                }
            }
            else
            {
                FontVariantItem.ItemValue = (FontVariantItemBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void FontStyleItemBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (FontStyleItem == null)
            {
                // FontStyleItem = CssClassesToolControl.Context.CssStyleItems.Create();
                FontStyleItem = new CssStyleItem();
            //    FontStyleItem.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    FontStyleItem.CssStyleId = CssStyleId;
                    FontStyleItem.ItemName = "font-style";
                    FontStyleItem.ItemValue = (FontStyleItemBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(FontStyleItem);
                }
                if (CssAnimationId != null)
                {
                    FontStyleItem.CssAnimationId = CssAnimationId;
                    FontStyleItem.ItemName = "font-style";
                    FontStyleItem.ItemValue = (FontStyleItemBox.SelectedItem as TextBlock).Text;
                    FontStyleItem.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(FontStyleItem);
                }
            }
            else
            {
                FontStyleItem.ItemValue = (FontStyleItemBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void BackfaceVisibilityBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (BackfaceVisibility == null)
            {
                //    BackfaceVisibility = CssClassesToolControl.Context.CssStyleItems.Create();
                BackfaceVisibility = new CssStyleItem();
             //   BackfaceVisibility.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BackfaceVisibility.CssStyleId = CssStyleId;
                    BackfaceVisibility.ItemName = "backface-visibility";
                    BackfaceVisibility.ItemValue = (BackfaceVisibilityBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(BackfaceVisibility);
                }
                if (CssAnimationId != null)
                {
                    BackfaceVisibility.CssAnimationId = CssAnimationId;
                    BackfaceVisibility.ItemName = "backface-visibility";
                    BackfaceVisibility.ItemValue = (BackfaceVisibilityBox.SelectedItem as TextBlock).Text;
                    BackfaceVisibility.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BackfaceVisibility);
                }
            }
            else
            {
                BackfaceVisibility.ItemValue = (BackfaceVisibilityBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void ListStyleTypeBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (ListStyleType == null)
            {
                //     ListStyleType = CssClassesToolControl.Context.CssStyleItems.Create();
                ListStyleType = new CssStyleItem();
           //     ListStyleType.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    ListStyleType.CssStyleId = CssStyleId;
                    ListStyleType.ItemName = "list-style-type";
                    ListStyleType.ItemValue = (ListStyleTypeBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(ListStyleType);
                }
                if (CssAnimationId != null)
                {
                    ListStyleType.CssAnimationId = CssAnimationId;
                    ListStyleType.ItemName = "list-style-type";
                    ListStyleType.ItemValue = (ListStyleTypeBox.SelectedItem as TextBlock).Text;
                    ListStyleType.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(ListStyleType);
                }
            }
            else
            {
                ListStyleType.ItemValue = (ListStyleTypeBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void ListStylePositionBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (ListStylePosition == null)
            {
                //    ListStylePosition = CssClassesToolControl.Context.CssStyleItems.Create();
                ListStylePosition = new CssStyleItem();
            //    ListStylePosition.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    ListStylePosition.CssStyleId = CssStyleId;
                    ListStylePosition.ItemName = "list-style-position";
                    ListStylePosition.ItemValue = (ListStylePositionBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(ListStylePosition);
                }
                if (CssAnimationId != null)
                {
                    ListStylePosition.CssAnimationId = CssAnimationId;
                    ListStylePosition.ItemName = "list-style-position";
                    ListStylePosition.ItemValue = (ListStylePositionBox.SelectedItem as TextBlock).Text;
                    ListStylePosition.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(ListStylePosition);
                }
            }
            else
            {
                ListStylePosition.ItemValue = (ListStylePositionBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void ListTextAlignBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (ListTextAlign == null)
            {
                //      ListTextAlign = CssClassesToolControl.Context.CssStyleItems.Create();
                ListTextAlign = new CssStyleItem();
            //    ListTextAlign.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    ListTextAlign.CssStyleId = CssStyleId;
                    ListTextAlign.ItemName = "list-text-align";
                    ListTextAlign.ItemValue = (ListTextAlignBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(ListTextAlign);
                }
                if (CssAnimationId != null)
                {
                    ListTextAlign.CssAnimationId = CssAnimationId;
                    ListTextAlign.ItemName = "list-text-align";
                    ListTextAlign.ItemValue = (ListTextAlignBox.SelectedItem as TextBlock).Text;
                    ListTextAlign.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(ListTextAlign);
                }
            }
            else
            {
                ListTextAlign.ItemValue = (ListTextAlignBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void VerticalAlignBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (ContentVerticalAlignment == null)
            {
                //    ContentVerticalAlignment = CssClassesToolControl.Context.CssStyleItems.Create();
                ContentVerticalAlignment = new CssStyleItem();
           //     ContentVerticalAlignment.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    ContentVerticalAlignment.CssStyleId = CssStyleId;
                    ContentVerticalAlignment.ItemName = "vertical-align";
                    ContentVerticalAlignment.ItemValue = (VerticalAlignBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(ContentVerticalAlignment);
                }
                if (CssAnimationId != null)
                {
                    ContentVerticalAlignment.CssAnimationId = CssAnimationId;
                    ContentVerticalAlignment.ItemName = "vertical-align";
                    ContentVerticalAlignment.ItemValue = (VerticalAlignBox.SelectedItem as TextBlock).Text;
                    ContentVerticalAlignment.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(ContentVerticalAlignment);
                }
            }
            else
            {
                ContentVerticalAlignment.ItemValue = (VerticalAlignBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void OverflowXBox__OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (ContentVerticalAlignment == null)
            {
                //    OverflowX = CssClassesToolControl.Context.CssStyleItems.Create();
                OverflowX = new CssStyleItem();
           //     OverflowX.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    OverflowX.CssStyleId = CssStyleId;
                    OverflowX.ItemName = "overflow-x";
                    OverflowX.ItemValue = (OverflowXBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(OverflowX);
                }
                if (CssAnimationId != null)
                {
                    OverflowX.CssAnimationId = CssAnimationId;
                    OverflowX.ItemName = "overflow-x";
                    OverflowX.ItemValue = (OverflowXBox.SelectedItem as TextBlock).Text;
                    OverflowX.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(OverflowX);
                }
            }
            else
            {
                OverflowX.ItemValue = (OverflowXBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void OverflowYBox__OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (ContentVerticalAlignment == null)
            {
                //    OverflowY = CssClassesToolControl.Context.CssStyleItems.Create();
                OverflowY = new CssStyleItem();
          //      OverflowY.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    OverflowY.CssStyleId = CssStyleId;
                    OverflowY.ItemName = "overflow-y";
                    OverflowY.ItemValue = (OverflowYBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(OverflowY);
                }
                if (CssAnimationId != null)
                {
                    OverflowY.CssAnimationId = CssAnimationId;
                    OverflowY.ItemName = "overflow-y";
                    OverflowY.ItemValue = (OverflowYBox.SelectedItem as TextBlock).Text;
                    OverflowY.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(OverflowY);
                }
            }
            else
            {
                OverflowY.ItemValue = (OverflowYBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void TableLayoutBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (TableLayout == null)
            {
                //  TableLayout = CssClassesToolControl.Context.CssStyleItems.Create();
                TableLayout = new CssStyleItem();
           //     TableLayout.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    TableLayout.CssStyleId = CssStyleId;
                    TableLayout.ItemName = "table-layout";
                    TableLayout.ItemValue = (TableLayoutBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(TableLayout);
                }
                if (CssAnimationId != null)
                {
                    TableLayout.CssAnimationId = CssAnimationId;
                    TableLayout.ItemName = "table-layout";
                    TableLayout.ItemValue = (TableLayoutBox.SelectedItem as TextBlock).Text;
                    TableLayout.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(TableLayout);
                }
            }
            else
            {
                TableLayout.ItemValue = (TableLayoutBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void EmptyCellsBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (EmptyCells == null)
            {
                //    EmptyCells = CssClassesToolControl.Context.CssStyleItems.Create();
                EmptyCells = new CssStyleItem();
            //    EmptyCells.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    EmptyCells.CssStyleId = CssStyleId;
                    EmptyCells.ItemName = "empty-cells";
                    EmptyCells.ItemValue = (EmptyCellsBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(EmptyCells);
                }
                if (CssAnimationId != null)
                {
                    EmptyCells.CssAnimationId = CssAnimationId;
                    EmptyCells.ItemName = "empty-cells";
                    EmptyCells.ItemValue = (EmptyCellsBox.SelectedItem as TextBlock).Text;
                    EmptyCells.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(EmptyCells);
                }
            }
            else
            {
                EmptyCells.ItemValue = (EmptyCellsBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void CaptionSideBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (CaptionSide == null)
            {
                // CaptionSide = CssClassesToolControl.Context.CssStyleItems.Create();
                CaptionSide = new CssStyleItem();
          //      CaptionSide.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    CaptionSide.CssStyleId = CssStyleId;
                    CaptionSide.ItemName = "caption-side";
                    CaptionSide.ItemValue = (CaptionSideBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(CaptionSide);
                }
                if (CssAnimationId != null)
                {
                    CaptionSide.CssAnimationId = CssAnimationId;
                    CaptionSide.ItemName = "caption-side";
                    CaptionSide.ItemValue = (CaptionSideBox.SelectedItem as TextBlock).Text;
                    CaptionSide.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(CaptionSide);
                }
            }
            else
            {
                CaptionSide.ItemValue = (CaptionSideBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        private void BorderCollapseBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isLoaded == false)
            {
                return;
            }
            if (BorderCollapse == null)
            {
                //       BorderCollapse = CssClassesToolControl.Context.CssStyleItems.Create();
                BorderCollapse = new CssStyleItem();
           //     BorderCollapse.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BorderCollapse.CssStyleId = CssStyleId;
                    BorderCollapse.ItemName = "border-collapse";
                    BorderCollapse.ItemValue = (BorderCollapseBox.SelectedItem as TextBlock).Text;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderCollapse);
                }
                if (CssAnimationId != null)
                {
                    BorderCollapse.CssAnimationId = CssAnimationId;
                    BorderCollapse.ItemName = "border-collapse";
                    BorderCollapse.ItemValue = (BorderCollapseBox.SelectedItem as TextBlock).Text;
                    BorderCollapse.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderCollapse);
                }
            }
            else
            {
                BorderCollapse.ItemValue = (BorderCollapseBox.SelectedItem as TextBlock).Text;
            }
            CssClassesToolControl.Context.SaveChanges();
        }

        #endregion OnSelectionChanged

        private void BackgroundColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (BackgroundColor == null)
            {
                //   BackgroundColor = CssClassesToolControl.Context.CssStyleItems.Create();
                BackgroundColor = new CssStyleItem();
              //  BackgroundColor.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BackgroundColor.CssStyleId = CssStyleId;
                    BackgroundColor.ItemName = "background-color";
                    BackgroundColor.ItemValue = "Flat";
                    CssClassesToolControl.Context.CssStyleItems.Add(BackgroundColor);
                    CssClassesToolControl.Context.SaveChanges();
                }
                if (CssAnimationId != null)
                {
                    BackgroundColor.CssAnimationId = CssAnimationId;
                    BackgroundColor.ItemName = "background-color";
                    BackgroundColor.ItemValue = "Flat";
                    BackgroundColor.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BackgroundColor);
                    CssClassesToolControl.Context.SaveChanges();
                }
            }
            BackgroundColorSelector = new ColorSelector();
            BackgroundColorSelector.ColorName = BackgroundColor.ItemName;
            BackgroundColorSelector.StyleItem = BackgroundColor;
            BackgroundColorSelector.Load();
            var nc = CurrentCssStyle;


            BackgroundColorSelector.ShowDialog();
            ShowCurrentStyle();
            //Popup bkpop = new Popup();
            //bkpop.VerticalOffset = 30;
            //bkpop.HorizontalOffset = 30;

            //bkpop.Child = BackgroundColorSelector;

            //bkpop.IsOpen = true;
            //var wind = CssClassesToolControl.MainToolControl;
            //if (wind != null)
            //{
            //    wind.ToColorPage(BackgroundColorSelector);
            //}
        }

        private void BorderColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (BorderColor == null)
            {
                //     BorderColor = CssClassesToolControl.Context.CssStyleItems.Create();
                BorderColor = new CssStyleItem();
              //  BorderColor.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    BorderColor.CssStyleId = CssStyleId;
                    BorderColor.ItemName = "border-color";
                    BorderColor.ItemValue = "Flat";
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderColor);
                    CssClassesToolControl.Context.SaveChanges();
                }
                if (CssAnimationId != null)
                {
                    BorderColor.CssAnimationId = CssAnimationId;
                    BorderColor.ItemName = "border-color";
                    BorderColor.ItemValue = "Flat";
                    BorderColor.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(BorderColor);
                    CssClassesToolControl.Context.SaveChanges();
                }
            }
            BorderColorSelector = new ColorSelector();
            BorderColorSelector.ColorName = BorderColor.ItemName;
            BorderColorSelector.StyleItem = BorderColor;
            BorderColorSelector.Load();

            BorderColorSelector.ShowDialog();
            ShowCurrentStyle();
            //Popup bkpop = new Popup();
            //bkpop.VerticalOffset = 30;
            //bkpop.HorizontalOffset = 30;

            //bkpop.Child = BorderColorSelector;

            //bkpop.IsOpen = true;
            //var wind = CssClassesToolControl.MainToolControl;
            //if (wind != null)
            //{
            //    wind.ToColorPage(BorderColorSelector);
            //}
        }

        private void OutlineColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (OutlineColor == null)
            {
                //   OutlineColor = CssClassesToolControl.Context.CssStyleItems.Create();
                OutlineColor = new CssStyleItem();
             //   OutlineColor.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    OutlineColor.CssStyleId = CssStyleId;
                    OutlineColor.ItemName = "outline-color";
                    OutlineColor.ItemValue = "Flat";
                    CssClassesToolControl.Context.CssStyleItems.Add(OutlineColor);
                    CssClassesToolControl.Context.SaveChanges();
                }
                if (CssAnimationId != null)
                {
                    OutlineColor.CssAnimationId = CssAnimationId;
                    OutlineColor.ItemName = "outline-color";
                    OutlineColor.ItemValue = "Flat";
                    OutlineColor.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(OutlineColor);
                    CssClassesToolControl.Context.SaveChanges();
                }
            }
            OutlineColorSelector = new ColorSelector();
            OutlineColorSelector.ColorName = OutlineColor.ItemName;
            OutlineColorSelector.StyleItem = OutlineColor;
            OutlineColorSelector.Load();
            OutlineColorSelector.Title = "Outline Color";
            OutlineColorSelector.ShowDialog();
            ShowCurrentStyle();
            //Popup bkpop = new Popup();
            //bkpop.VerticalOffset = 30;
            //bkpop.HorizontalOffset = 30;

            //bkpop.Child = OutlineColorSelector;

            //bkpop.IsOpen = true;
            //var wind = CssClassesToolControl.MainToolControl;
            //if (wind != null)
            //{
            //    wind.ToColorPage(OutlineColorSelector);
            //}
        }

        private void FontColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (FontColor == null)
            {
                //  FontColor = CssClassesToolControl.Context.CssStyleItems.Create();
                FontColor = new CssStyleItem();
           //     FontColor.Id = FindNextCssStyleItemId();
                if (CssStyleId != null)
                {
                    FontColor.CssStyleId = CssStyleId;
                    FontColor.ItemName = "color";
                    FontColor.ItemValue = "Flat";
                    CssClassesToolControl.Context.CssStyleItems.Add(FontColor);
                    CssClassesToolControl.Context.SaveChanges();
                }
                if (CssAnimationId != null)
                {
                    FontColor.CssAnimationId = CssAnimationId;
                    FontColor.ItemName = "color";
                    FontColor.ItemValue = "Flat";
                    FontColor.StyleOrder = CurrentAnimationOrder;
                    CssClassesToolControl.Context.CssStyleItems.Add(FontColor);
                    CssClassesToolControl.Context.SaveChanges();
                }
            }
            FontColorSelector = new ColorSelector();
            FontColorSelector.ColorName = FontColor.ItemName;
            FontColorSelector.StyleItem = FontColor;
            FontColorSelector.Load();

            FontColorSelector.ShowDialog();
            ShowCurrentStyle();
            //Popup bkpop = new Popup();
            //bkpop.VerticalOffset = 30;
            //bkpop.HorizontalOffset = 30;

            //bkpop.Child = FontColorSelector;

            //bkpop.IsOpen = true;
            //var wind = CssClassesToolControl.MainToolControl;
            //if (wind != null)
            //{
            //    wind.ToColorPage(FontColorSelector);
            //}
        }

        #region text shadow

        public void TextShadowColorSelected(object sender, EventArgs e)
        {
            var shadowPicker = sender as ColorPicker;
            TextShadowColor = shadowPicker.SelectedColor;
            ComposeTextShadowElement();
        }

        private void TextShadowColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            Popup textshadowpopup = new Popup();
            ColorPicker picker = new ColorPicker();
            picker.RaiseSelection += TextShadowColorSelected;

            picker.SelectedColor = TextShadowColor;
            textshadowpopup.Child = picker;

            textshadowpopup.IsOpen = true;

        }

        public string TextShadowHorizontalValue
        {
            get { return _textShadowHorizontalValue; }
            set
            {
                int res;
                if (int.TryParse(value, out res))
                {

                    _textShadowHorizontalValue = value;
                }
                else
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(TextShadowVerticalValue))
                {
                    TextShadowVerticalValue = "0";
                }
                ComposeTextShadowElement();
                OnPropertyChanged();
                OnPropertyChanged("TextShadowVerticalValue");
            }
        }

        public string TextShadowVerticalValue
        {
            get { return _textShadowVerticalValue; }
            set
            {
                int res;
                if (int.TryParse(value, out res))
                {

                    _textShadowVerticalValue = value;
                }
                else
                {
                    return;
                }


                ComposeTextShadowElement();
                OnPropertyChanged();
            }
        }

        public string TextShadowBlurDistanceValue
        {
            get { return _textShadowBlurDistanceValue; }
            set
            {
                int res;
                if (int.TryParse(value, out res))
                {

                    _textShadowBlurDistanceValue = value;
                }
                else
                {
                    return;
                }

                OnPropertyChanged(nameof(TextShadowBlurDistanceValue));
                ComposeTextShadowElement();
            }
        }

        public string TextShadowSpreadDistanceValue
        {
            get { return _textShadowSpreadDistanceValue; }
            set
            {
                int res;
                if (int.TryParse(value, out res))
                {

                    _textShadowSpreadDistanceValue = value;
                }
                else
                {
                    return;
                }

                OnPropertyChanged(nameof(TextShadowSpreadDistanceValue));
                ComposeTextShadowElement();
            }

        }

        private string ComposeTextShadowElement()
        {
            if (!string.IsNullOrWhiteSpace(TextShadowHorizontalValue))
            {
                string TextShadowData = string.Empty;
                

                TextShadowData = TextShadowHorizontalValue + "px ";


                if (TextShadowVerticalValue == null)
                {
                    TextShadowVerticalValue = "0";
                }

                TextShadowData = TextShadowData + TextShadowVerticalValue + "px ";

                if (!string.IsNullOrWhiteSpace(TextShadowBlurDistanceValue))
                {
                    TextShadowData = TextShadowData + TextShadowBlurDistanceValue + "px ";
                }
                if (!string.IsNullOrWhiteSpace(TextShadowSpreadDistanceValue))
                {
                    TextShadowData = TextShadowData + TextShadowSpreadDistanceValue + "px ";
                }

                TextShadowData +=
                    (string.Format("rgba({0},{1},{2},{3,2:F})", TextShadowColor.R, TextShadowColor.G, TextShadowColor.B,
                        ((double)TextShadowColor.A)));
                if (TextShadow == null)
                {
                    TextShadow = new CssStyleItem();

                 //   TextShadow.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        TextShadow.CssStyleId = CssStyleId;
                        TextShadow.ItemName = "text-shadow";
                        TextShadow.ItemValue = TextShadowData;
                        CssClassesToolControl.Context.CssStyleItems.Add(TextShadow);
                    }
                    if (CssAnimationId != null)
                    {
                        TextShadow.CssAnimationId = CssAnimationId;
                        TextShadow.ItemName = "text-shadow";
                        TextShadow.StyleOrder = CurrentAnimationOrder;
                        TextShadow.ItemValue = TextShadowData;
                        CssClassesToolControl.Context.CssStyleItems.Add(TextShadow);
                    }
                }
                else
                {
                    TextShadow.ItemValue = TextShadowData;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                return (TextShadowData);
            }
            return (string.Empty);
        }

        private void TextShadowParse()
        {
            char[] delimiter = { ' ' };

            try
            {

                string[] strs = TextShadow.ItemValue.Split(delimiter);
                int pos = 0;
                int cnt = 0;

  
                int zz = 0;
                zz = strs[pos].Length - 2;
                strs[pos] = strs[pos].Substring(0, zz);
                _textShadowHorizontalValue = strs[pos];
                pos++;
                cnt++;
                zz = strs[pos].Length - 2;
                strs[pos] = strs[pos].Substring(0, zz);
                _textShadowVerticalValue = strs[pos];
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
                            ParseTextShadowColor(strs[pos]);
                        }
                        break;
                    case 2:
                        zz = strs[pos].Length - 2;
                        strs[pos] = strs[pos].Substring(0, zz);
                        _textShadowBlurDistanceValue = strs[pos];
                        pos++;
                        if (strs[pos].Contains("rgba"))
                        {
                            ParseTextShadowColor(strs[pos]);

                        }
                        break;

                    case 3:
                        zz = strs[pos].Length - 2;
                        strs[pos] = strs[pos].Substring(0, zz);
                        _textShadowBlurDistanceValue = strs[pos];
                        pos++;

                        zz = strs[pos].Length - 2;
                        strs[pos] = strs[pos].Substring(0, zz);
                        _textShadowSpreadDistanceValue = strs[pos];
                        pos++;

                        ParseTextShadowColor(strs[pos]);
                        break;
                }
            }
            catch (Exception ee)
            {
                string tt = ee.Message;

            }


        }

        void ParseTextShadowColor(string strcolor)
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
            _textShadowColor = System.Windows.Media.Color.FromArgb((byte)aaa, (byte)rr, (byte)gg, (byte)bb);
        }

      
        #endregion

        #region box shadow

        public void ShadowColorSelected(object sender, EventArgs e)
        {
            var shadowPicker = sender as ColorPicker;
            BoxShadowColor = shadowPicker.SelectedColor;
            ComposeBoxShadowElement();
        }

        private void BoxShadowColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            Popup boxshadowpopup = new Popup();
            ColorPicker picker = new ColorPicker();
            picker.RaiseSelection += ShadowColorSelected;

            picker.SelectedColor = BoxShadowColor;
            boxshadowpopup.Child = picker;

            boxshadowpopup.IsOpen = true;

        }

        //private void BoxShadowButton_OnClick(object sender, RoutedEventArgs e)
        //{

        //    ShadowInputControl.CssStyleId = CssStyleId;
        //    ShadowInputControl.CurrentCssStyle = CurrentCssStyle;
        //    ShadowInputControl.FindShadows();

        //    ShadowPopup.IsOpen = true;

        //}


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
                    BoxShadowVerticalValue = "0";
                }
                ComposeBoxShadowElement();
                OnPropertyChanged();
                OnPropertyChanged("BoxShadowVerticalValue");
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

     

        private string ComposeBoxShadowElement()
        {
            if (!string.IsNullOrWhiteSpace(BoxShadowHorizontalValue))
            {
                string BoxShadowData = string.Empty;
                if (BoxShadowInsetValue == true)
                {
                    BoxShadowData += "inset ";
                }

                BoxShadowData = BoxShadowData + BoxShadowHorizontalValue + "px ";


                if (BoxShadowVerticalValue == null)
                {
                    BoxShadowVerticalValue = "0";
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
                if (BoxShadow == null)
                {
                    BoxShadow = new CssStyleItem();

                  //  BoxShadow.Id = FindNextCssStyleItemId();
                    if (CssStyleId != null)
                    {
                        BoxShadow.CssStyleId = CssStyleId;
                        BoxShadow.ItemName = "box-shadow";
                        BoxShadow.ItemValue = BoxShadowData;
                        CssClassesToolControl.Context.CssStyleItems.Add(BoxShadow);
                    }
                    if (CssAnimationId != null)
                    {
                        BoxShadow.CssAnimationId = CssAnimationId;
                        BoxShadow.ItemName = "box-shadow";
                        BoxShadow.StyleOrder = CurrentAnimationOrder;
                        BoxShadow.ItemValue = BoxShadowData;
                        CssClassesToolControl.Context.CssStyleItems.Add(BoxShadow);
                    }
                }
                else
                {
                    BoxShadow.ItemValue = BoxShadowData;
                }
                CssClassesToolControl.Context.SaveChanges();
                OnPropertyChanged();
                return (BoxShadowData);
            }
            return (string.Empty);
        }

        private void BoxShadowParse()
        {
            char[] delimiter = { ' ' };

            try
            {

                string[] strs = BoxShadow.ItemValue.Split(delimiter);
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

                string tt = ee.Message;
            }


        }

        void ParseBoxShadowColor(string strcolor)
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
        #endregion

        private void Font_OnClick(object sender, RoutedEventArgs e)
        {
            var chooseFont = new Dialogs.ChooseFontWindow();

            if (FontFamilyItem != null)
            {
                chooseFont.FontSelected = FontFamilyItem.ItemValue;
            }

            if (chooseFont.ShowDialog() == true)
            {
                if (string.IsNullOrWhiteSpace(chooseFont.FontSelected) == false)
                {
                    if (FontFamilyItem == null)
                    {
                        //   FontFamilyItem = CssClassesToolControl.Context.CssStyleItems.Create();
                        FontFamilyItem = new CssStyleItem();
                    //    FontFamilyItem.Id = FindNextCssStyleItemId();
                        if (CssStyleId != null)
                        {
                            FontFamilyItem.CssStyleId = CssStyleId;
                            FontFamilyItem.ItemName = "font-family";
                            FontFamilyItem.ItemValue = chooseFont.FontSelected;
                            CssClassesToolControl.Context.CssStyleItems.Add(FontFamilyItem);
                        }
                        if (CssAnimationId != null)
                        {
                            FontFamilyItem.CssAnimationId = CssAnimationId;
                            FontFamilyItem.ItemName = "font-family";
                            FontFamilyItem.ItemValue = chooseFont.FontSelected;
                            FontFamilyItem.StyleOrder = CurrentAnimationOrder;
                            CssClassesToolControl.Context.CssStyleItems.Add(FontFamilyItem);
                        }
                    }
                    else
                    {
                        FontFamilyItem.ItemValue = chooseFont.FontSelected;
                    }
                    CssClassesToolControl.Context.SaveChanges();
                    ShowCurrentStyle();
                }
            }
        }

        #region delete item

        private void DeleteItemClick(object sender, RoutedEventArgs e)
        {
            var bb = sender as Button;
            if (bb != null)
            {
                var st = (string)bb.Tag;

                var instyle = from vv in CssClassesToolControl.Context.CssStyleItems
                              where vv.CssStyleId == CssStyleId
                                    && vv.CssAnimationId == null
                                    && vv.ItemName == st
                              select vv;

                if (instyle.Any())
                {
                    var it = instyle.ToList().First();
                    if (it != null)
                    {
                        CssClassesToolControl.Context.CssStyleItems.Remove(it);
                        CssClassesToolControl.Context.SaveChanges();
                    }
                }

                var inanim = from vv in CssClassesToolControl.Context.CssStyleItems
                             where vv.CssAnimationId == CssAnimationId
                                   && vv.CssStyleId == null
                                   && vv.StyleOrder == CurrentAnimationOrder
                                   && vv.ItemName == st
                             select vv;

                if (inanim.Any())
                {
                    var mit = inanim.ToList().First();
                    if (mit != null)
                    {
                        CssClassesToolControl.Context.CssStyleItems.Remove(mit);
                        CssClassesToolControl.Context.SaveChanges();
                    }
                }

                switch (st)
                {
                    case "border-style":
                        BorderStyle = null;
                        foreach (TextBlock bl in BorderStyleBox.Items)
                        {
                            if (bl.Text == "none")
                            {
                                BorderStyleBox.SelectedItem = bl;
                                break;
                            }
                        }

                        break;

                    case "border-top-style":
                        BorderTopStyle = null;
                        foreach (TextBlock bl in BorderTopStyleBox.Items)
                        {
                            if (bl.Text == "none")
                            {
                                BorderTopStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-right-style":
                        BorderRightStyle = null;
                        foreach (TextBlock bl in BorderRightStyleBox.Items)
                        {
                            if (bl.Text == "none")
                            {
                                BorderRightStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-bottom-style":
                        BorderBottomStyle = null;
                        foreach (TextBlock bl in BorderBottomStyleBox.Items)
                        {
                            if (bl.Text == "none")
                            {
                                BorderBottomStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-left-style":
                        BorderLeftStyle = null;
                        foreach (TextBlock bl in BorderLeftStyleBox.Items)
                        {
                            if (bl.Text == "none")
                            {
                                BorderLeftStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "boxshadowhorizontal":
                        _boxShadowHorizontalValue = string.Empty;
                        if (BoxShadow != null)
                        {
                            CssClassesToolControl.Context.CssStyleItems.Remove(BoxShadow);
                            CssClassesToolControl.Context.SaveChanges();
                            BoxShadow = null;
                        }
                        OnPropertyChanged(nameof(BoxShadowHorizontalValue));
                        break;

                    case "boxshadowvertical":
                        _boxShadowVerticalValue = string.Empty;
                        if (BoxShadow != null)
                        {
                            CssClassesToolControl.Context.CssStyleItems.Remove(BoxShadow);
                            CssClassesToolControl.Context.SaveChanges();
                            BoxShadow = null;
                        }
                        OnPropertyChanged(nameof(BoxShadowVerticalValue));
                        break;

                    case "boxshadowblurdistance":
                        _boxShadowBlurDistanceValue = string.Empty;
                        OnPropertyChanged(nameof(BoxShadowBlurDistanceValue));
                        break;

                    case "boxshadowspreaddistance":
                        _boxShadowSpreadDistanceValue = string.Empty;
                        OnPropertyChanged(nameof(BoxShadowSpreadDistanceValue));
                        break;

                    case "textshadowhorizontal":
                        _textShadowHorizontalValue = string.Empty;
                        if (TextShadow != null)
                        {
                            CssClassesToolControl.Context.CssStyleItems.Remove(TextShadow);
                            CssClassesToolControl.Context.SaveChanges();
                            TextShadow = null;
                        }
                        OnPropertyChanged(nameof(TextShadowHorizontalValue));
                        break;

                    case "textshadowvertical":
                        _textShadowVerticalValue = string.Empty;
                        if (TextShadow != null)
                        {
                            CssClassesToolControl.Context.CssStyleItems.Remove(TextShadow);
                            CssClassesToolControl.Context.SaveChanges();
                            TextShadow = null;
                        }
                        OnPropertyChanged(nameof(TextShadowVerticalValue));
                        break;

                    case "textshadowblurdistance":
                        _textShadowBlurDistanceValue = string.Empty;
                        OnPropertyChanged(nameof(TextShadowBlurDistanceValue));
                        break;

                    case "textshadowspreaddistance":
                        _textShadowSpreadDistanceValue = string.Empty;
                        OnPropertyChanged(nameof(TextShadowSpreadDistanceValue));
                        break;

                    case "clip":
                        ContentsClip = null;
                        _clipTopValue = string.Empty;
                        _clipRightValue = string.Empty;
                        _clipBottomValue = string.Empty;
                        _clipLeftValue = string.Empty;
                        OnPropertyChanged(nameof(ClipTopValue));
                        OnPropertyChanged(nameof(ClipRightValue));
                        OnPropertyChanged(nameof(ClipBottomValue));
                        OnPropertyChanged(nameof(ClipLeftValue));
                        break;

                    case "height":
                        ContentsHeight = null;
                        _contentsHeightValue = string.Empty;
                        OnPropertyChanged(nameof(ContentsHeightValue));
                        break;

                    case "max-height":
                        ContentsMaxHeight = null;
                        _contentsMaxHeightValue = string.Empty;
                        OnPropertyChanged(nameof(ContentsMaxHeightValue));
                        break;

                    case "min-height":
                        ContentsMinHeight = null;
                        _contentsMinHeightValue = string.Empty;
                        OnPropertyChanged(nameof(ContentsMinHeightValue));
                        break;

                    case "width":
                        ContentsWidth = null;
                        _contentsWidthValue = string.Empty;
                        OnPropertyChanged(nameof(ContentsWidthValue));
                        break;

                    case "max-width":
                        ContentsMaxWidth = null;
                        _contentsMaxWidthValue = string.Empty;
                        OnPropertyChanged(nameof(ContentsMaxWidthValue));
                        break;

                    case "min-width":
                        ContentsMinWidth = null;
                        _contentsMinWidthValue = string.Empty;
                        OnPropertyChanged(nameof(ContentsMinWidthValue));
                        break;

                    case "left":
                        ContentsLeft = null;
                        _contentsLeftValue = string.Empty;
                        OnPropertyChanged(nameof(ContentsLeftValue));
                        break;

                    case "right":
                        ContentsRight = null;
                        _contentsRightValue = string.Empty;
                        OnPropertyChanged(nameof(ContentsRightValue));
                        break;

                    case "top":
                        ContentsTop = null;
                        _contentsTopValue = string.Empty;
                        OnPropertyChanged(nameof(ContentsTopValue));
                        break;

                    case "bottom":
                        ContentsBottom = null;
                        _contentsBottomValue = string.Empty;
                        OnPropertyChanged(nameof(ContentsBottomValue));
                        break;

                    case "border-width":
                        BorderWidth = null;
                        _borderWidthValue = string.Empty;
                        OnPropertyChanged(nameof(BorderWidthValue));
                        break;

                    case "border-top-width":
                        BorderTopWidth = null;
                        _borderTopWidthValue = string.Empty;
                        OnPropertyChanged(nameof(BorderTopWidthValue));
                        break;

                    case "border-right-width":
                        BorderRightWidth = null;
                        _borderRightWidthValue = string.Empty;
                        OnPropertyChanged(nameof(BorderRightWidthValue));
                        break;

                    case "border-bottom-width":
                        BorderBottomWidth = null;
                        _borderBottomWidthValue = string.Empty;
                        OnPropertyChanged(nameof(BorderBottomWidthValue));
                        break;

                    case "border-left-width":
                        BorderLeftWidth = null;
                        _borderLeftWidthValue = string.Empty;
                        OnPropertyChanged(nameof(BorderLeftWidthValue));
                        break;

                    case "border-radius":
                        BorderRadius = null;
                        _borderRadiusValue = string.Empty;
                        OnPropertyChanged(nameof(BorderRadiusValue));
                        break;

                    case "border-top-left-radius":
                        BorderTopLeftRadius = null;
                        _borderTopLeftRadiusValue = string.Empty;
                        OnPropertyChanged(nameof(BorderTopLeftRadiusValue));
                        break;

                    case "border-top-right-radius":
                        BorderTopRightRadius = null;
                        _borderTopRightRadiusValue = string.Empty;
                        OnPropertyChanged(nameof(BorderTopRightRadiusValue));
                        break;

                    case "border-bottom-right-radius":
                        BorderBottomRightRadius = null;
                        _borderBottomRightRadiusValue = string.Empty;
                        OnPropertyChanged(nameof(BorderBottomRightRadiusValue));
                        break;

                    case "border-bottom-left-radius":
                        BorderBottomLeftRadius = null;
                        _borderBottomLeftRadiusValue = string.Empty;
                        OnPropertyChanged(nameof(BorderBottomLeftRadiusValue));
                        break;

                    case "background-image":
                        BackgroundImage = null;
                        _backgroundImageValue = string.Empty;
                        OnPropertyChanged(nameof(BackgroundImageValue));
                        break;

                    case "background-clip":
                        BackgroundClip = null;
                        foreach (TextBlock bl in BackgroundClipBox.Items)
                        {
                            if (bl.Text == "border-box")
                            {
                                BackgroundClipBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "background-origin":
                        BackgroundOrigin = null;
                        foreach (TextBlock bl in BackgroundOriginBox.Items)
                        {
                            if (bl.Text == "padding-box")
                            {
                                BackgroundOriginBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "background-repeat":
                        BackgroundRepeat = null;
                        foreach (TextBlock bl in BackgroundRepeatBox.Items)
                        {
                            if (bl.Text == "repeat")
                            {
                                BackgroundRepeatBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "background-attachment":
                        BackgroundAttachment = null;
                        foreach (TextBlock bl in BackgroundAttachmentBox.Items)
                        {
                            if (bl.Text == "scroll")
                            {
                                BackgroundAttachmentBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "background-size":
                        BackgroundSize = null;
                        _backgroundSizeXValue = string.Empty;
                        _backgroundSizeYValue = string.Empty;
                        OnPropertyChanged(nameof(BackgroundSizeXValue));
                        OnPropertyChanged(nameof(BackgroundSizeYValue));
                        break;

                    case "background-position":
                        BackgroundPosition = null;
                        _backgroundPositionXValue = string.Empty;
                        _backgroundPositionYValue = string.Empty;
                        OnPropertyChanged(nameof(BackgroundPositionXValue));
                        OnPropertyChanged(nameof(BackgroundPositionYValue));
                        break;

                    case "outline-style":
                        OutlineStyle = null;
                        foreach (TextBlock bl in OutlineStyleBox.Items)
                        {
                            if (bl.Text == "none")
                            {
                                OutlineStyleBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "overflow-x":
                        OverflowX = null;
                        foreach (TextBlock bl in OverflowXBox.Items)
                        {
                            if (bl.Text == "visible")
                            {
                                OverflowXBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "overflow-y":
                        OverflowX = null;
                        foreach (TextBlock bl in OverflowYBox.Items)
                        {
                            if (bl.Text == "visible")
                            {
                                OverflowYBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-collapse":
                        BorderCollapse = null;
                        foreach (TextBlock bl in BorderCollapseBox.Items)
                        {
                            if (bl.Text == "seperate")
                            {
                                BorderCollapseBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "caption-side":
                        CaptionSide = null;
                        foreach (TextBlock bl in CaptionSideBox.Items)
                        {
                            if (bl.Text == "top")
                            {
                                CaptionSideBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "empty-cells":
                        EmptyCells = null;
                        foreach (TextBlock bl in EmptyCellsBox.Items)
                        {
                            if (bl.Text == "show")
                            {
                                EmptyCellsBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "table-layout":
                        TableLayout = null;
                        foreach (TextBlock bl in TableLayoutBox.Items)
                        {
                            if (bl.Text == "auto")
                            {
                                TableLayoutBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "border-spacing":
                        BorderSpacing = null;
                        _borderSpacingXValue = string.Empty;
                        _borderSpacingYValue = string.Empty;
                        OnPropertyChanged(nameof(BorderSpacingXValue));
                        OnPropertyChanged(nameof(BorderSpacingYValue));
                        break;

                    case "position":
                        Position = null;
                        foreach (TextBlock bl in PositionBox.Items)
                        {
                            if (bl.Text == "static")
                            {
                                PositionBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "display":
                        Display = null;
                        foreach (TextBlock bl in DisplayBox.Items)
                        {
                            if (bl.Text == "inline")
                            {
                                DisplayBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "visibility":
                        VisibilityItem = null;
                        foreach (TextBlock bl in VisibilityBox.Items)
                        {
                            if (bl.Text == "visible")
                            {
                                VisibilityBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "outline-width":
                        OutlineWidth = null;
                        _outlineWidthValue = string.Empty;
                        OnPropertyChanged(nameof(OutlineWidthValue));
                        break;

                    case "margin":
                        StyleMargin = null;
                        _styleMarginValue = string.Empty;
                        OnPropertyChanged(nameof(StyleMarginValue));
                        break;

                    case "margin-top":
                        MarginLeft = null;
                        _marginLeftValue = string.Empty;
                        OnPropertyChanged(nameof(MarginLeftValue));
                        break;

                    case "margin-right":
                        MarginRight = null;
                        _marginRightValue = string.Empty;
                        OnPropertyChanged(nameof(MarginRightValue));
                        break;

                    case "margin-bottom":
                        MarginBottom = null;
                        _marginBottomValue = string.Empty;
                        OnPropertyChanged(nameof(MarginBottomValue));
                        break;

                    case "margin-left":
                        MarginLeft = null;
                        _marginLeftValue = string.Empty;
                        OnPropertyChanged(nameof(MarginLeftValue));
                        break;

                    case "padding":
                        StylePadding = null;
                        _stylePaddingValue = string.Empty;
                        OnPropertyChanged(nameof(StylePaddingValue));
                        break;


                    case "padding-top":
                        PaddingLeft = null;
                        _paddingLeftValue = string.Empty;
                        OnPropertyChanged(nameof(PaddingLeftValue));
                        break;

                    case "padding-right":
                        PaddingRight = null;
                        _paddingRightValue = string.Empty;
                        OnPropertyChanged(nameof(PaddingRightValue));
                        break;

                    case "padding-bottom":
                        PaddingBottom = null;
                        _paddingBottomValue = string.Empty;
                        OnPropertyChanged(nameof(PaddingBottomValue));
                        break;

                    case "padding-left":
                        PaddingLeft = null;
                        _paddingLeftValue = string.Empty;
                        OnPropertyChanged(nameof(PaddingLeftValue));
                        break;

                    case "line-height":
                        LineHeight = null;
                        _lineHeightValue = string.Empty;
                        OnPropertyChanged(nameof(LineHeightValue));
                        break;

                    case "letter-spacing":
                        LetterSpacing = null;
                        _letterSpacingValue = string.Empty;
                        OnPropertyChanged(nameof(LetterSpacingValue));
                        break;

                    case "text-indent":
                        TextIndent = null;
                        _textIndentValue = string.Empty;
                        OnPropertyChanged(nameof(TextIndentValue));
                        break;

                    case "column-count":
                        ColumnCount = null;
                        _columnCountValue = string.Empty;
                        OnPropertyChanged(nameof(ColumnCountValue));
                        break;

                    case "column-gap":
                        ColumnGap = null;
                        _columnGapValue = string.Empty;
                        OnPropertyChanged(nameof(ColumnGapValue));
                        break;

                    case "column-width":
                        ColumnWidth = null;
                        _columnWidthValue = string.Empty;
                        OnPropertyChanged(nameof(ColumnWidthValue));
                        break;

                    case "opacity":
                        ContentsOpacity = null;
                        _contentsOpacityValue = string.Empty;
                        OnPropertyChanged(nameof(ContentsOpacityValue));
                        break;

                    case "rotateX":
                        RotateX = null;
                        _rotateXValue = string.Empty;
                        OnPropertyChanged(nameof(RotateXValue));
                        break;

                    case "rotateY":
                        RotateY = null;
                        _rotateYValue = string.Empty;
                        OnPropertyChanged(nameof(RotateYValue));
                        break;

                    case "rotateZ":
                        RotateZ = null;
                        _rotateZValue = string.Empty;
                        OnPropertyChanged(nameof(RotateZValue));
                        break;

                    case "translateX":
                        TranslateX = null;
                        _translateXValue = string.Empty;
                        OnPropertyChanged(nameof(TranslateXValue));
                        break;

                    case "translateY":
                        TranslateY = null;
                        _translateYValue = string.Empty;
                        OnPropertyChanged(nameof(TranslateYValue));
                        break;

                    case "translateZ":
                        TranslateZ = null;
                        _translateZValue = string.Empty;
                        OnPropertyChanged(nameof(TranslateZValue));
                        break;

                    case "scaleX":
                        ScaleX = null;
                        _scaleXValue = string.Empty;
                        OnPropertyChanged(nameof(ScaleXValue));
                        break;

                    case "scaleY":
                        ScaleY = null;
                        _scaleYValue = string.Empty;
                        OnPropertyChanged(nameof(ScaleYValue));
                        break;

                    case "scaleZ":
                        ScaleZ = null;
                        _scaleZValue = string.Empty;
                        OnPropertyChanged(nameof(ScaleZValue));
                        break;

                    case "perspective":
                        Perspective = null;
                        _perspectiveValue = string.Empty;
                        OnPropertyChanged(nameof(PerspectiveValue));
                        break;

                    case "perspective-origin":
                        PerspectiveOrigin = null;
                        _perspectiveOriginXValue = string.Empty;
                        _perspectiveOriginYValue = string.Empty;
                        OnPropertyChanged(nameof(PerspectiveOriginXValue));
                        OnPropertyChanged(nameof(PerspectiveOriginYValue));
                        break;

                    case "transform-origin":
                        TransformOrigin = null;
                        _transformOriginXValue = string.Empty;
                        _transformOriginYValue = string.Empty;
                        OnPropertyChanged(nameof(TransformOriginXValue));
                        OnPropertyChanged(nameof(TransformOriginYValue));
                        break;

                    case "column-span":
                        ColumnSpan = null;
                        foreach (TextBlock bl in ColumnSpanBox.Items)
                        {
                            if (bl.Text == "1")
                            {
                                ColumnSpanBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "align-items":
                        AlignItems = null;
                        foreach (TextBlock bl in AlignItemsBox.Items)
                        {
                            if (bl.Text == "stretch")
                            {
                                AlignItemsBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "flex-wrap":
                        FlexWrap = null;
                        foreach (TextBlock bl in FlexWrapBox.Items)
                        {
                            if (bl.Text == "nowrap")
                            {
                                FlexWrapBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "flex-direction":
                        FlexDirection = null;
                        foreach (TextBlock bl in FlexDirectionBox.Items)
                        {
                            if (bl.Text == "row")
                            {
                                FlexDirectionBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "flex-basis":
                        FlexBasis = null;
                        _flexBasisValue = string.Empty;
                        OnPropertyChanged(nameof(FlexBasisValue));
                        break;

                    case "flex-grow":
                        FlexGrow = null;
                        _flexGrowValue = string.Empty;
                        OnPropertyChanged(nameof(FlexGrowValue));
                        break;

                    case "flex-shrink":
                        FlexShrink = null;
                        _flexShrinkValue = string.Empty;
                        OnPropertyChanged(nameof(FlexShrinkValue));
                        break;

                    case "align-self":
                        AlignSelf = null;
                        foreach (TextBlock bl in AlignSelfBox.Items)
                        {
                            if (bl.Text == "auto")
                            {
                                AlignSelfBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "align-content":
                        AlignSelf = null;
                        foreach (TextBlock bl in AlignContentBox.Items)
                        {
                            if (bl.Text == "stretch")
                            {
                                AlignContentBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "justify-content":
                        AlignSelf = null;
                        foreach (TextBlock bl in JustifyContentBox.Items)
                        {
                            if (bl.Text == "flex-start")
                            {
                                JustifyContentBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "order":
                        Order = null;
                        _orderValue = string.Empty;
                        OnPropertyChanged(nameof(OrderValue));
                        break;

                    case "float":
                        FloatItem = null;
                        foreach (TextBlock bl in FloatItemBox.Items)
                        {
                            if (bl.Text == "none")
                            {
                                FloatItemBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "text-align":
                        TextAlign = null;
                        foreach (TextBlock bl in TextAlignBox.Items)
                        {
                            if (bl.Text == "left")
                            {
                                TextAlignBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;


                    case "text-transform":
                        TextTransform = null;
                        foreach (TextBlock bl in TextTransformBox.Items)
                        {
                            if (bl.Text == "none")
                            {
                                TextTransformBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "white-space":
                        WhiteSpace = null;
                        foreach (TextBlock bl in WhiteSpaceBox.Items)
                        {
                            if (bl.Text == "normal")
                            {
                                WhiteSpaceBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "word-wrap":
                        WordWrap = null;
                        foreach (TextBlock bl in WordWrapBox.Items)
                        {
                            if (bl.Text == "normal")
                            {
                                WordWrapBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "vertical-align":
                        OverflowX = null;
                        foreach (TextBlock bl in VerticalAlignBox.Items)
                        {
                            if (bl.Text == "baseline")
                            {
                                VerticalAlignBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "z-index":
                        ZIndex = null;
                        _zIndexValue = string.Empty;
                        OnPropertyChanged(nameof(ZindexValue));
                        break;

                    case "font-size":
                        FontSizeItem = null;
                        _fontSizeItemValue = string.Empty;
                        OnPropertyChanged(nameof(FontSizeItemValue));
                        break;

                    case "font-weight":
                        FontWeightItem = null;
                        foreach (TextBlock bl in FontWeightItemBox.Items)
                        {
                            if (bl.Text == "normal")
                            {
                                FontWeightItemBox.SelectedItem = bl;
                                break;
                            }
                        }

                        break;

                    case "font-variant":
                        FontVariantItem = null;
                        foreach (TextBlock bl in FontVariantItemBox.Items)
                        {
                            if (bl.Text == "normal")
                            {
                                FontVariantItemBox.SelectedItem = bl;
                                break;
                            }
                        }

                        break;

                    case "font-style":
                        FontStyleItem = null;
                        foreach (TextBlock bl in FontStyleItemBox.Items)
                        {
                            if (bl.Text == "normal")
                            {
                                FontStyleItemBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "backface-visibility":
                        BackfaceVisibility = null;
                        foreach (TextBlock bl in BackfaceVisibilityBox.Items)
                        {
                            if (bl.Text == "visible")
                            {
                                BackfaceVisibilityBox.SelectedItem = bl;
                                break;
                            }
                        }

                        break;

                    case "list-style-type":
                        ListStyleType = null;
                        foreach (TextBlock bl in ListStyleTypeBox.Items)
                        {
                            if (bl.Text == "disk")
                            {
                                ListStyleTypeBox.SelectedItem = bl;
                                break;
                            }
                        }
                        break;

                    case "list-text-align":
                        ListTextAlign = null;
                        foreach (TextBlock bl in ListTextAlignBox.Items)
                        {
                            if (bl.Text == "left")
                            {
                                ListTextAlignBox.SelectedItem = bl;
                                break;
                            }
                        }

                        break;

                    case "list-style-position":
                        ListStylePosition = null;
                        foreach (TextBlock bl in ListStylePositionBox.Items)
                        {
                            if (bl.Text == "inside")
                            {
                                ListStylePositionBox.SelectedItem = bl;
                                break;
                            }
                        }

                        break;

                    case "font-family":
                        FontFamilyItem = null;
                        break;
                }
                if (CssStyleId == null && CssAnimationId != null)
                {
                    LoadAnimationItems();
                }
                else
                {
                    LoadStyleItems();
                }
                InvalidateVisual();
            }
        }

        #endregion

        private void TransitionsButton_OnClick(object sender, RoutedEventArgs e)
        {
            var transitions = new Dialogs.Transitions();

            transitions.NowCssStyle = CurrentCssStyle;

            if (transitions.ShowDialog() == true)
            {
            }
        }

       

        public void ShowCurrentStyle()
        {
            try
            {
                CssClassesToolControl.MainToolControl.UseCssControl.ShowStyleText();
            }
            catch (Exception ee)
            {
                string tt = ee.Message;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            ShowCurrentStyle();
        }

        

        #endregion


        private void Expander_OnCollapsed(object sender, RoutedEventArgs e)
        {
            ShowCurrentStyle();
            this.InvalidateVisual();
        }

        private void Expander_OnExpanded(object sender, RoutedEventArgs e)
        {
            ShowCurrentStyle();
            this.InvalidateVisual();
        }
    }
}