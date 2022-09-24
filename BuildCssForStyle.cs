using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using WpfCssControlLibrary.Controls;
using WpfCssControlLibrary.Model;

namespace WpfCssControlLibrary
{
    internal class BuildCssForStyle
    {
        private List<CssColor> _currentCssColors;
        private CssColorType _currentCssColorType;
        private CssStyle _currentCssStyle;
        private CssStyleItem _currentCssStyleItem;

        public SortedDictionary<int, List<CssStyleItem>> AnimationItemLists =
            new SortedDictionary<int, List<CssStyleItem>>();

        //     private CssColor _fixedColor;

        public CssStyle CurrentCssStyle
        {
            set { _currentCssStyle = value; }
        }

        public string CssString { get; set; }
        public CssAnimation CurrentCssAnimation { get; set; }

        private string TransitionsString()
        {
            var csstransitions = string.Empty;
            var cssdurations = string.Empty;
            var cssdelays = string.Empty;
            var csstimings = string.Empty;

            var vtran = from tran in CssClassesToolControl.Context.CssTransitions
                        where tran.CssStyleId == _currentCssStyle.Id
                        select tran;

            var trlist = vtran.ToList();

            var cnt = 0;
            foreach (var ct in trlist)
            {
                if (cnt == 0)
                {
                    csstransitions += "transition-property:";
                    csstimings += "transition-timing-function:";
                    cssdelays += "transition-delay:";
                    cssdurations += "transition-duration:";
                }
                cnt++;
                if (cnt != trlist.Count)
                {
                    csstransitions += (ct.PropertyName + ", ");
                    csstimings += (ct.TimingFunction + ", ");
                    cssdelays += (ct.Delay + ", ");
                    cssdurations += (ct.Duration + ", ");
                }
                else
                {
                    csstransitions += (ct.PropertyName + ";\r\n");
                    csstimings += (ct.TimingFunction + ";\r\n");
                    cssdelays += (ct.Delay + ";\r\n");
                    cssdurations += (ct.Duration + ";\r\n");
                }
            }

            if (trlist.Count == 0)
            {
                return (string.Empty);
            }
            return (csstransitions + csstimings + cssdurations + cssdelays);
        }

        #region Build Style

        public string BuildStyle()
        {
            CssString = string.Empty;

            var transformstring = "transform: ";
            var usetransform = false;

            if(_currentCssStyle == null)
            {
                _currentCssStyle = new CssStyle();

            }



            CssString += string.Format(".{0}{{\r\n", _currentCssStyle.StyleName);
            foreach (var item in _currentCssStyle.CssStyleItems)
            {
                _currentCssStyleItem = item;

                if (item.ItemName.Contains("color"))
                {
                    switch (item.ItemName)
                    {
                        case "FontColor":
                            CssString += string.Format("{0}: ", "color");
                            break;

                        case "background-color":
                            if (item.CssColorTypes.First().ColorType == "Flat")
                            {
                                CssString += string.Format("{0}: ", item.ItemName);
                            }
                            else
                            {
                                CssString += string.Format("{0}: ", "background");
                            }
                            break;

                        

                        default:
                            CssString += string.Format("{0}: ", item.ItemName);
                            break;
                    }

                    foreach (var ctype in item.CssColorTypes)
                    {
                        _currentCssColorType = ctype;
                        _currentCssColors = _currentCssColorType.CssColors.ToList();
                        CssString += BuildColorCssString();
                        break;
                    }
                }
                else
                {
                    switch (item.ItemName)
                    {
                        case "width":
                        case "max-width":
                        case "min-width":
                        case "height":
                        case "max-height":
                        case "min-height":
                        case "top":
                        case "left":
                        case "right":
                        case "bottom":
                        case "border-width":
                        case "border-top-width":
                        case "border-right-width":
                        case "border-bottom-width":
                        case "border-left-width":
                        case "border-radius":
                        case "border-top-left-radius":
                        case "border-top-right-radius":
                        case "border-bottom-right-radius":
                        case "border-bottom-left-radius":
                        case "text-indent":
                        case "margin":
                        case "margin-top":
                        case "margin-right":
                        case "margin-bottom":
                        case "margin-left":
                        case "padding":
                        case "padding-top":
                        case "padding-right":
                        case "padding-bottom":
                        case "padding-left":
                        case "outline-width":
                        case "column-width":
                        case "column-gap":
                        case "z-index":
                        case "flex-basis":
                        case "letter-spacing":

                            CssString += string.Format("{0}: {1}px;\r\n", _currentCssStyleItem.ItemName,
                                _currentCssStyleItem.ItemValue);
                            break;
                        case "line-height":
                        case "font-size":
                            CssString += string.Format("{0}: {1}%;\r\n", _currentCssStyleItem.ItemName,
                                _currentCssStyleItem.ItemValue);
                            break;

                        case "transform-origin":
                        case "perspective-origin":
                            char[] cch = { ',' };
                            var both = item.ItemValue.Split(cch);
                            if (both.Length == 2)
                            {
                                CssString += string.Format("{0}:{1}% {2}%;\r\n",
                                    item.ItemName, both[0], both[1]);
                            }
                            break;

                        case "rotateX":
                        case "rotateY":
                        case "rotateZ":
                            usetransform = true;
                            transformstring += string.Format("{0}({1}deg) ",
                                item.ItemName, item.ItemValue);
                            break;
                        case "translateX":
                        case "translateY":
                        case "translateZ":
                        case "perspective":
                            usetransform = true;
                            transformstring += string.Format("{0}({1}px) ",
                                item.ItemName, item.ItemValue);
                            break;
                        case "scaleX":
                        case "scaleY":
                        case "scaleZ":
                            usetransform = true;
                            transformstring += string.Format("{0}({1}) ",
                                item.ItemName, item.ItemValue);
                            break;

                        default:
                            CssString += string.Format("{0}: {1};\r\n",
                                _currentCssStyleItem.ItemName,
                                _currentCssStyleItem.ItemValue);
                            break;
                    }
                }
            }

            if (usetransform)
            {
                CssString += (transformstring + ";\r\n");
            }

            CssString += TransitionsString();

            CssString += "}\r\n";
            CssString += "\r\n";
            return (CssString);
        }

        #endregion Build Style

        private string ColorFunction(string colortext)
        {
            var ret = "inherit";
            if (string.IsNullOrWhiteSpace(colortext) == false)
            {
               // var cnvrt = new ColorConverter();
                var color = (Color)ColorConverter.ConvertFromString(colortext);
                ret = string.Format("rgba({0},{1},{2},{3,2:F})", color.R, color.G, color.B, ((double)color.A));
            }

            return (ret);
        }

        public string BuildColorCssString()
        {
            var colorstring = string.Empty;

            if (_currentCssColorType.ColorType == "Flat")
            {
                var cv = string.Empty;
                foreach (var color in _currentCssColors)
                {
                    if (color.ColorOrder < 0)
                    {
                        cv = ColorFunction(color.ColorValue);
                    }
                }
                colorstring = string.Format(" {0};\r\n", cv);
            }
            if (_currentCssColorType.ColorType == "Linear")
            {
                colorstring += string.Format("linear-gradient({0}deg, ", _currentCssColorType.Angle);

                foreach (var color in _currentCssColors)
                {
                    if (color.ColorOrder >= 0)
                    {
                        colorstring += string.Format(" {0} {1}%", ColorFunction(color.ColorValue), color.Stop);

                        if (color != _currentCssColors.Last())
                        {
                            colorstring += ",";
                        }
                    }
                }
                colorstring += ");\r\n";
            }
            if (_currentCssColorType.ColorType == "Radial")
            {
                colorstring += string.Format("radial-gradient({0} {1} {2},",
                    _currentCssColorType.Shape, _currentCssColorType.Size, _currentCssColorType.Center);

                foreach (var color in _currentCssColors)
                {
                    if (color.ColorOrder >= 0)
                    {
                        colorstring += string.Format(" {0} {1}%", ColorFunction(color.ColorValue), color.Stop);
                        if (color != _currentCssColors.Last())
                        {
                            colorstring += ",";
                        }
                    }
                }
                colorstring += ")\r\n";
            }
            return (colorstring);
        }

        #region Build Animation Style

        public string BuildStyle(int animationid)
        {
           // CurrentCssAnimation = CssClassesToolControl.Context.CssAnimations.Find(animationid);

            CurrentCssAnimation = (from anim in CssClassesToolControl.Context.CssAnimations
                where anim.Id == animationid
                select anim).First();

            var transformstring = "transform: ";
            var usetransform = false;

            CssString = string.Empty;
            CssString += string.Format(".{0}{{\r\n", _currentCssStyle.StyleName);
            foreach (var item in _currentCssStyle.CssStyleItems)
            {
                _currentCssStyleItem = item;

                if (item.ItemName.Contains("color"))
                {
                    switch (item.ItemName)
                    {
                        case "FontColor":
                            CssString += string.Format("{0}: ", "color");
                            break;

                        case "background-color":
                            if (item.CssColorTypes.First().ColorType == "Flat")
                            {
                                CssString += string.Format("{0}: ", item.ItemName);
                            }
                            else
                            {
                                CssString += string.Format("{0}: ", "background");
                            }
                            break;

                        default:
                            CssString += string.Format("{0}: ", item.ItemName);
                            break;
                    }

                    foreach (var ctype in item.CssColorTypes)
                    {
                        _currentCssColorType = ctype;
                        _currentCssColors = _currentCssColorType.CssColors.ToList();
                        CssString += BuildColorCssString();
                        break;
                    }
                }
                else
                {
                    switch (item.ItemName)
                    {
                        case "width":
                        case "max-width":
                        case "min-width":
                        case "height":
                        case "max-height":
                        case "min-height":
                        case "top":
                        case "left":
                        case "right":
                        case "bottom":
                        case "border-width":
                        case "border-top-width":
                        case "border-right-width":
                        case "border-bottom-width":
                        case "border-left-width":
                        case "border-radius":
                        case "border-top-left-radius":
                        case "border-top-right-radius":
                        case "border-bottom-right-radius":
                        case "border-bottom-left-radius":
                        case "text-indent":
                        case "margin":
                        case "margin-top":
                        case "margin-right":
                        case "margin-bottom":
                        case "margin-left":
                        case "padding":
                        case "padding-top":
                        case "padding-right":
                        case "padding-bottom":
                        case "padding-left":
                        case "outline-width":
                        case "column-width":
                        case "column-gap":
                        case "z-index":
                        case "flex-basis":
                        case "letter-spacing":


                            CssString += string.Format("{0}: {1}px;\r\n", _currentCssStyleItem.ItemName,
                                _currentCssStyleItem.ItemValue);
                            break;
                        case "line-height":
                        case "font-size":
                            CssString += string.Format("{0}: {1}%;\r\n", _currentCssStyleItem.ItemName,
                                _currentCssStyleItem.ItemValue);
                            break;
                        case "transform-origin":
                        case "perspective-origin":
                            var both = item.ItemValue.Split(',');
                            CssString += string.Format("{0}:{1}% {2}%;\r\n",
                                item.ItemName, both[0], both[1]);
                            break;

                        case "rotateX":
                        case "rotateY":
                        case "rotateZ":
                            usetransform = true;
                            transformstring += string.Format("{0}({1}deg) ",
                                item.ItemName, item.ItemValue);
                            break;
                        case "translateX":
                        case "translateY":
                        case "translateZ":
                        case "perspective":
                            usetransform = true;
                            transformstring += string.Format("{0}({1}px) ",
                                item.ItemName, item.ItemValue);
                            break;
                        case "scaleX":
                        case "scaleY":
                        case "scaleZ":
                            usetransform = true;
                            transformstring += string.Format("{0}({1}) ",
                                item.ItemName, item.ItemValue);
                            break;

                        default:
                            CssString += string.Format("{0}: {1};\r\n", _currentCssStyleItem.ItemName,
                                _currentCssStyleItem.ItemValue);
                            break;
                    }
                }
            }

            if (usetransform)
            {
                CssString += (transformstring + ";\r\n");
            }

            CssString += string.Format("animation: {0};\r\n", CurrentCssAnimation.AnimationName);
            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationDuration) == false)
            {
                CssString += string.Format("animation-duration: {0}ms;\r\n",
                    CurrentCssAnimation.AnimationDuration);
            }

            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationTimingFunction) == false)
            {
                CssString += string.Format("animation-timing-function: {0};\r\n",
                    CurrentCssAnimation.AnimationTimingFunction);
            }
            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationDelay) == false)
            {
                CssString += string.Format("animation-delay: {0}ms;\r\n",
                    CurrentCssAnimation.AnimationDelay);
            }
            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationIterationCount) == false)
            {
                CssString += string.Format("animation-iteration-count: {0};\r\n",
                    CurrentCssAnimation.AnimationIterationCount);
            }
            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationDirection) == false)
            {
                CssString += string.Format("animation-direction: {0};\r\n",
                    CurrentCssAnimation.AnimationDirection);
            }
            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationPlayState) == false)
            {
                CssString += string.Format("animation-play-state: {0};\r\n",
                    CurrentCssAnimation.AnimationPlayState);
            }
            CssString += TransitionsString();
            CssString += "}\r\n";
            CssString += "\r\n";

            AnimationItemLists = new SortedDictionary<int, List<CssStyleItem>>();

            var vv = from items in CssClassesToolControl.Context.CssStyleItems
                     where items.CssAnimationId == CurrentCssAnimation.Id
                     select items;

            foreach (var item in vv.ToList())
            {
                var cc = item.StyleOrder.Value;
                if (AnimationItemLists.ContainsKey(cc))
                {
                    AnimationItemLists[cc].Add(item);
                }
                else
                {
                    AnimationItemLists.Add(cc, new List<CssStyleItem>());
                    AnimationItemLists[cc].Add(item);
                }
            }

            CssString += string.Format("@keyframes {0} {{\r\n", CurrentCssAnimation.AnimationName);
            foreach (var nn in AnimationItemLists.Keys)
            {
                transformstring = "transform: ";
                usetransform = false;
                CssString += string.Format(" {0}% {{\r\n", nn);
                var ItemsAtStop = AnimationItemLists[nn];
                foreach (var item in ItemsAtStop)
                {
                    _currentCssStyleItem = item;

                    if (AnimationNames.IsAnimatable(item.ItemName) == false)
                    {
                        continue;
                    }

                    if (item.ItemName.Contains("color"))
                    {
                        switch (item.ItemName)
                        {
                            case "FontColor":
                                CssString += string.Format("{0}: ", "color");
                                break;

                            case "background-color":
                                if (item.CssColorTypes.First().ColorType == "Flat")
                                {
                                    CssString += string.Format("{0}: ", item.ItemName);
                                }
                                else
                                {
                                    CssString += string.Format("{0}: ", "background");
                                }
                                break;

                            default:
                                CssString += string.Format("{0}: ", item.ItemName);
                                break;
                        }

                        foreach (var ctype in item.CssColorTypes)
                        {
                            _currentCssColorType = ctype;
                            _currentCssColors = _currentCssColorType.CssColors.ToList();
                            CssString += BuildColorCssString();
                            break;
                        }
                    }
                    else
                    {
                        switch (item.ItemName)
                        {
                            case "width":
                            case "max-width":
                            case "min-width":
                            case "height":
                            case "max-height":
                            case "min-height":
                            case "top":
                            case "left":
                            case "right":
                            case "bottom":
                            case "border-width":
                            case "border-top-width":
                            case "border-right-width":
                            case "border-bottom-width":
                            case "border-left-width":
                            case "border-radius":
                            case "border-top-left-radius":
                            case "border-top-right-radius":
                            case "border-bottom-right-radius":
                            case "border-bottom-left-radius":
                            case "text-indent":
                            case "margin":
                            case "margin-top":
                            case "margin-right":
                            case "margin-bottom":
                            case "margin-left":
                            case "padding":
                            case "padding-top":
                            case "padding-right":
                            case "padding-bottom":
                            case "padding-left":
                            case "outline-width":
                            case "column-width":
                            case "column-gap":
                            case "z-index":
                            case "flex-basis":
                            case "letter-spacing":
                                CssString += string.Format("{0}:{1}px;\r\n", _currentCssStyleItem.ItemName,
                                    _currentCssStyleItem.ItemValue);
                                break;
                            case "line-height":
                            case "font-size":
                                CssString += string.Format("{0}: {1}%;\r\n", _currentCssStyleItem.ItemName,
                                    _currentCssStyleItem.ItemValue);
                                break;
                            case "transform-origin":
                            case "perspective-origin":
                                var both = item.ItemValue.Split(',');
                                CssString += string.Format("{0}:{1}% {2}%;\r\n",
                                    item.ItemName, both[0], both[1]);
                                break;

                            case "rotateX":
                            case "rotateY":
                            case "rotateZ":
                                usetransform = true;
                                transformstring += string.Format("{0}({1}deg) ",
                                    item.ItemName, item.ItemValue);
                                break;
                            case "translateX":
                            case "translateY":
                            case "translateZ":
                            case "perspective":
                                usetransform = true;
                                transformstring += string.Format("{0}({1}px) ",
                                    item.ItemName, item.ItemValue);
                                break;
                            case "scaleX":
                            case "scaleY":
                            case "scaleZ":
                                usetransform = true;
                                transformstring += string.Format("{0}({1}) ",
                                    item.ItemName, item.ItemValue);
                                break;

                            case "column-span":
                            case "align-items":
                            case "flex-direction":
                            case "flex-wrap":
                            case "text-align":
                            case "float":
                            case "display":
                            case "position":
                            case "font-family":
                            case "font-style":
                            case "font-variant":
                            case "background-image":
                            case "background-clip":
                            case "background-origin":
                            case "background-repeat":
                            case "background-attachment":
                            case "table-layout":
                            case "empty-cells":
                            case "caption-side":
                            case "border-collapse":
                            case "border-style":
                            case "border-top-style":
                            case "border-right-style":
                            case "border-bottom-style":
                            case "border-left-style":
                            case "align-content":
                            case "align-self":
                            case "justify-content":
                            case "white-space":
                            case "word-wrap":
                            case "outline-style":
                            case "list-style-type":
                            case "list-text-align":
                            case "list-style-position":
                                // not supported in animation
                                break;
                            default:
                                CssString += string.Format("{0}: {1};\r\n", _currentCssStyleItem.ItemName,
                                    _currentCssStyleItem.ItemValue);
                                break;
                        }
                    }
                }
                if (usetransform)
                {
                    CssString += (transformstring + ";\r\n");
                }

                CssString += "}\r\n";
              
            }
            CssString += "}\r\n";
            return (CssString);
        }

        #endregion Build Animation Style

        #region Build Animation

        public string BuildAnimation()
        {
            CssString = string.Empty;
            CssString += string.Format(".Wrap{0}{{\r\n", CurrentCssAnimation.AnimationName);
            CssString += string.Format("animation: {0};\r\n", CurrentCssAnimation.AnimationName);
            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationDuration) == false)
            {
                CssString += string.Format("animation-duration: {0}ms;\r\n",
                    CurrentCssAnimation.AnimationDuration);
            }

            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationTimingFunction) == false)
            {
                CssString += string.Format("animation-timing-function: {0};\r\n",
                    CurrentCssAnimation.AnimationTimingFunction);
            }
            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationDelay) == false)
            {
                CssString += string.Format("animation-delay: {0}ms;\r\n",
                    CurrentCssAnimation.AnimationDelay);
            }
            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationIterationCount) == false)
            {
                CssString += string.Format("animation-iteration-count: {0};\r\n",
                    CurrentCssAnimation.AnimationIterationCount);
            }
            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationDirection) == false)
            {
                CssString += string.Format("animation-direction: {0};\r\n",
                    CurrentCssAnimation.AnimationDirection);
            }
            if (string.IsNullOrWhiteSpace(CurrentCssAnimation.AnimationPlayState) == false)
            {
                CssString += string.Format("animation-play-state: {0};\r\n",
                    CurrentCssAnimation.AnimationPlayState);
            }


            CssString += "}\r\n";
            CssString += "\r\n";

            AnimationItemLists = new SortedDictionary<int, List<CssStyleItem>>();

            var vv = from items in CssClassesToolControl.Context.CssStyleItems
                     where items.CssAnimationId == CurrentCssAnimation.Id
                     select items;


            //  foreach (CssStyleItem item in _currentCssAnimation.CssStyleItems)
            foreach (var item in vv.ToList())
            {
                var cc = item.StyleOrder.Value;
                if (AnimationItemLists.ContainsKey(cc))
                {
                    AnimationItemLists[cc].Add(item);
                }
                else
                {
                    AnimationItemLists.Add(cc, new List<CssStyleItem>());
                    AnimationItemLists[cc].Add(item);
                }
            }

            CssString += string.Format("@keyframes {0} {{\r\n", CurrentCssAnimation.AnimationName);
            foreach (var nn in AnimationItemLists.Keys)
            {
                var transformstring = "transform: ";
                var usetransform = false;

                CssString += string.Format(" {0}% {{\r\n", nn);
                var ItemsAtStop = AnimationItemLists[nn];
                foreach (var item in ItemsAtStop)
                {
                    _currentCssStyleItem = item;

                    if (AnimationNames.IsAnimatable(item.ItemName) == false)
                    {
                        continue;
                    }

                    if (item.ItemName.Contains("color"))
                    {
                        switch (item.ItemName)
                        {
                            case "FontColor":
                                CssString += string.Format("{0}: ", "color");
                                break;

                            case "background-color":
                                if (item.CssColorTypes.First().ColorType == "Flat")
                                {
                                    CssString += string.Format("{0}: ", item.ItemName);
                                }
                                else
                                {
                                    CssString += string.Format("{0}: ", "background");
                                }
                                break;

                            default:
                                CssString += string.Format("{0}: ", item.ItemName);
                                break;
                        }

                        foreach (var ctype in item.CssColorTypes)
                        {
                            _currentCssColorType = ctype;
                            _currentCssColors = _currentCssColorType.CssColors.ToList();
                            CssString += BuildColorCssString();
                            break;
                        }
                    }
                    else
                    {
                        switch (item.ItemName)
                        {
                            case "width":
                            case "max-width":
                            case "min-width":
                            case "height":
                            case "max-height":
                            case "min-height":
                            case "top":
                            case "left":
                            case "right":
                            case "bottom":
                            case "border-width":
                            case "border-top-width":
                            case "border-right-width":
                            case "border-bottom-width":
                            case "border-left-width":
                            case "border-radius":
                            case "border-top-left-radius":
                            case "border-top-right-radius":
                            case "border-bottom-right-radius":
                            case "border-bottom-left-radius":
                            case "text-indent":
                            case "margin":
                            case "margin-top":
                            case "margin-right":
                            case "margin-bottom":
                            case "margin-left":
                            case "padding":
                            case "padding-top":
                            case "padding-right":
                            case "padding-bottom":
                            case "padding-left":
                            case "outline-width":
                            case "column-width":
                            case "column-gap":
                            case "letter-spacing":
                            case "z-index":
                            case "flex-basis":
                                CssString += string.Format("{0}:{1}px;\r\n", _currentCssStyleItem.ItemName,
                                    _currentCssStyleItem.ItemValue);
                                break;
                            case "line-height":
                            case "font-size":
                                CssString += string.Format("{0}: {1}%;\r\n", _currentCssStyleItem.ItemName,
                                    _currentCssStyleItem.ItemValue);
                                break;

                            case "transform-origin":
                            case "perspective-origin":
                                var both = item.ItemValue.Split(',');
                                CssString += string.Format("{0}:{1}% {2}%;\r\n",
                                    item.ItemName, both[0], both[1]);
                                break;

                            case "rotateX":
                            case "rotateY":
                            case "rotateZ":
                                usetransform = true;
                                transformstring += string.Format("{0}({1}deg) ",
                                    item.ItemName, item.ItemValue);
                                break;
                            case "translateX":
                            case "translateY":
                            case "translateZ":
                            case "perspective":
                                usetransform = true;
                                transformstring += string.Format("{0}({1}px) ",
                                    item.ItemName, item.ItemValue);
                                break;
                            case "scaleX":
                            case "scaleY":
                            case "scaleZ":
                                usetransform = true;
                                transformstring += string.Format("{0}({1}) ",
                                    item.ItemName, item.ItemValue);
                                break;


                            case "column-span":
                            case "align-items":
                            case "flex-direction":
                            case "flex-wrap":
                            case "text-align":
                            case "float":
                            case "display":
                            case "position":
                            case "font-family":
                            case "font-style":
                            case "font-variant":
                            case "background-image":
                            case "background-clip":
                            case "background-origin":
                            case "background-repeat":
                            case "background-attachment":
                            case "table-layout":
                            case "empty-cells":
                            case "caption-side":
                            case "border-collapse":
                            case "border-style":
                            case "border-top-style":
                            case "border-right-style":
                            case "border-bottom-style":
                            case "border-left-style":
                            case "align-content":
                            case "align-self":
                            case "justify-content":
                            case "white-space":
                            case "word-wrap":
                            case "outline-style":
                            case "list-style-type":
                            case "list-text-align":
                            case "list-style-position":
                                // not supported in animation
                                break;
                            default:
                                CssString += string.Format("{0}: {1};\r\n", _currentCssStyleItem.ItemName,
                                    _currentCssStyleItem.ItemValue);
                                break;
                        }
                    }
                }
                if (usetransform)
                {
                    CssString += (transformstring + ";\r\n");
                }
                CssString += "}\r\n";
            }
            CssString += "}\r\n";
            CssString += "\r\n";
            return (CssString);
        }

        #endregion Build Animation
    }
}