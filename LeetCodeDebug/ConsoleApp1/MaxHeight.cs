using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MaxHeight
    {
        public int MaxHeightOfTriangle(int red, int blue)
        {
            if (red + blue == 0)
                return 0;
            if (red + blue < 3)
                return 1;
            int maxHeight1 = 0;
            int maxHeight2 = 0;
            int tempRed = red;
            int tempBlue = blue;
            int i = 1;
            while (tempRed > 0 || tempBlue > 0)
            {
                if (i % 2 == 1)
                {
                    if (tempRed > 0)
                    {
                        tempRed = tempRed - i;
                        if (tempRed >= 0)
                            maxHeight1++;
                    }
                    else
                        break;
                }
                else
                {
                    if (tempBlue > 0)
                    {
                        tempBlue = tempBlue - i;
                        if (tempBlue >= 0)
                            maxHeight1++;
                    }
                    else
                        break;
                }
                i++;
            }
            tempRed = red;
            tempBlue = blue;
            i = 1;
            while (tempRed > 0 || tempBlue > 0)
            {
                if (i % 2 == 1)
                {
                    if (tempBlue > 0)
                    {
                        tempBlue = tempBlue - i;
                        if (tempBlue >= 0)
                            maxHeight2++;
                    }
                    else
                        break;
                }
                else
                {
                    if (tempRed > 0)
                    {
                        tempRed = tempRed - i;
                        if (tempRed >= 0)
                            maxHeight2++;
                    }
                    else
                        break;
                }
                i++;
            }
            return (maxHeight1 > maxHeight2) ? maxHeight1 : maxHeight2;
        }
    }
}
