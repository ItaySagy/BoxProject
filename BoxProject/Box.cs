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
        double _x, _y;//x - is size  y - is hight

        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }
        public int AmountOfBoxs { get { return amountOfBoxs; } set { amountOfBoxs = value; } }
        public DateTime ExpierDate { get { return _expierDate; } set { _expierDate = value;} }


        public Box(double x, double y, int q = 1)
        {
            this._x = x;
            this._y = y;
            this._expierDate = DateTime.Now.AddMonths(1);
            this.amountOfBoxs = q;
        }

        public int CompareTo(Box other)
        {
            throw new NotImplementedException();
        }
        public void AddBoxQ(int num)
        {
            this.amountOfBoxs = amountOfBoxs + num;
            ExpireDateReset();
            Console.WriteLine($" you added {num} boxes \ncurrently have : {amountOfBoxs} boxes ");
        }
        public override string ToString()
        {
            return $"box size : {X} \nbox hight: {Y}\n boxes amount {amountOfBoxs}\n box expiredate: {_expierDate:d}";
        }
        public void ExpireDateReset()
        {
            this._expierDate = DateTime.Now.AddMonths(1);
        }

    }
}
