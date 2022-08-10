using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxProject
{
    internal class BoxManeger
    {
        public Tree<double, Tree<double, Box>> MainTree { get; set; }


        public BoxManeger()
        {
            MainTree = new Tree<double, Tree<double, Box>>();
        }

        public void AddBox(double x, double y, int q)
        {

            var innerTree = MainTree.TryFind(x);
            if (innerTree is Tree<double, Box> treey)//we have the x exist
            {
                var innerBox = innerTree.TryFind(y);
                if (innerBox is Box)// we have the y exist
                {
                    innerBox.AddBoxQ(q);
                    Console.WriteLine(innerBox);

                }
                else // we dont have the y exist
                {
                    Box box = new Box(x, y, q);
                    innerTree.addNode(y, box);
                    Console.WriteLine("\n " + box);

                }
            }
            else// creat everything new
            {
                var NewTree = new Tree<double, Box>();
                MainTree.addNode(x, NewTree);
                var box = new Box(x, y, q);
                NewTree.addNode(y, box);
                Console.WriteLine(box);

            }
        }

        public void CheckDate()
        {

        }
        public void CheckQuantity()
        {

        }

        public bool isBoxOk(Box box)
        {
            return (box.AmountOfBoxs > 0 && box.ExpierDate > DateTime.Now);
        }

        public void BuyBox(double k, double v, int q, Action<object> action)
        {
            var innerTree = MainTree.TryFind(k);
            if (innerTree is Tree<double, Box> treey)//we have the x exist
            {

                var innerBox = innerTree.TryFind(v);
                if (innerBox is Box)// we have the y exist
                {
                    if (isBoxOk(innerBox))
                    {
                        if (innerBox.AmountOfBoxs >= q)
                        {
                            innerBox.AmountOfBoxs = innerBox.AmountOfBoxs - q;
                            Console.WriteLine(innerBox);
                            innerBox.ExpireDateReset();
                            action.Invoke(innerBox.ToString());

                        }
                        else
                        {
                            string s = "\nnot enoth boxes";
                            action.Invoke(s);

                        }
                    }


                }
                else
                {
                    string s = "\nproblom with box";
                    action.Invoke(s);
                }
            }
            else
            {
                string s = "\nbox not found: we will creat one for you next time :)";
                action.Invoke(s);
                AddBox(k,v,q);
            }


        }


    }
}
        //purches box - remove n from boxes + restart expire date

        // if not enouth + not found correct box - search other compatible boxes from list (bigger boxes)


        //add box - add n boxes to the binary tree + restart expire date

        // expire date  - remove expired boxes from the tree

        // box amount alarm - nodify you about low amount of boxes
        //to string - found +not found
        // modify box - add amount and restart expire date
        // to string  - all boxes

