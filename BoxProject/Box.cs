using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProject
{
    internal class Box : IComparable<Box>
    {
        int amountOfBoxs = 0;
        DateTime _expierDate;
        double _x, _y;

        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }


        public Box(double x, double y)
        {
            this._x = x;
            this._y = y;
            this._expierDate = DateTime.Now;


        }

        public int CompareTo(Box other)
        {
            throw new NotImplementedException();
        }
    }
}
