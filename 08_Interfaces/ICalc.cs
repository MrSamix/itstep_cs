using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Interfaces
{
    interface ICalc
    {
        int Less(int valueToCompare);
        int Greater(int valueToCompare);
    }
}
