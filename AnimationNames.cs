using System.Collections.Generic;

namespace WpfCssControlLibrary
{
  public static class AnimationNames
    {
        private static List<string> _animatableNames = new List<string>
        {
    "background",
    "background-color",
    "background-position",
    "background-size",
    "border",
    "border-bottom",
    "border-bottom-color",
    "border-bottom-left-radius",
    "border-bottom-right-radius",
    "border-bottom-width",
    "border-color",
    "border-left",
    "border-left-color",
    "border-left-width",
    "border-right",
    "border-right-color",
    "border-right-width",
    "border-spacing",
    "border-top",
    "border-top-color",
    "border-top-left-radius",
    "border-top-right-radius",
    "border-top-width",
    "border-width",
    "border-radius",
    "bottom",
    "box-shadow",
    "clip",
    "color",
    "column-count",
    "column-gap",
    "column-rule",
    "column-rule-color",
    "column-rule-width",
    "column-width",
    "columns",
    "flex",
    "flex-basis",
    "flex-grow",
    "flex-shrink",
    "font",
    "font-size",
    "font-size-adjust",
    "font-stretch",
    "font-weight",
    "height",
    "left",
    "letter-spacing",
    "line-height",
    "margin",
    "margin-bottom",
    "margin-left",
    "margin-right",
    "margin-top",
    "max-height",
    "max-width",
    "min-height",
    "min-width",
    "opacity",
    "order",
    "outline",
    "outline-color",
    "outline-offset",
    "outline-width",
    "padding",
    "padding-bottom",
    "padding-left",
    "padding-right",
    "padding-top",
    "perspective",
    "perspective-origin",
    "right",
    "text-decoration-color",
    "text-indent",
    "text-shadow",
    "top",
    "transform",
    "transform-origin",
    "vertical-align",
    "visibility",
    "width",
    "word-spacing",
    "z-index",
        };

        public static List<string> AnimatableNames
        {
            get { return _animatableNames; }
            set { _animatableNames = value; }
        }

        public static bool IsAnimatable(string name)
        {
            if (AnimatableNames.Contains(name) == true)
            {
                return (true);
            }
            return (false);
        }
    }
}
