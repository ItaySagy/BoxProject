using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BoxManeger box = new BoxManeger();

            box.MainTree.addNode(5.0, null);
            box.MainTree.addNode(4.0, null);
            box.MainTree.addNode(8, null);
            box.MainTree.addNode(10, null);
            box.MainTree.addNode(3, null);
            box.MainTree.addNode(4.5, null);
            box.MainTree.addNode(4.3, null);
            box.MainTree.addNode(4.7, null);
            box.MainTree.addNode(4.8, null);
            box.MainTree.addNode(4.6, null);
            box.MainTree.addNode(4.2, null);
            box.MainTree.addNode(4.65, null);
            box.MainTree.inOrder(Format);
            box.AddBox(12, 4, 300);
            box.MainTree.RemoveNode(5.0);
            box.MainTree.inOrder(Format);
            Console.WriteLine("\n===========");
            box.BuyBox(12, 4, 250, Console.WriteLine);
            box.BuyBox(12, 4, 255, Console.WriteLine);
            box.BuyBox(12222,2112,123123, Console.WriteLine);
        }
        public static void Format(object obj)
        {
            Console.Write(obj + ", ");
        }
    }
}
