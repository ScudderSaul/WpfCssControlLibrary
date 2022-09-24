using System.Collections.Generic;
using System.IO;

namespace WpfCssControlLibrary
{

    public class StringCompare01 : Comparer<string>
    {
        // Compares by Length, Height, and Width. 
        public override int Compare(string x, string y)
        {
            double xval;
            double yval;

            bool boomx = double.TryParse(x, out xval);
            bool boomy = double.TryParse(y, out yval);

            if (boomx == true && boomy == true)
            {
                if (xval < yval)
                {
                    return (-1);
                }
                else
                {
                    if (xval > yval)
                    {
                        return (1);
                    }
                }
                return (0);
            }
            else
            {
                throw (new InvalidDataException());
            }
        }

    }

}
