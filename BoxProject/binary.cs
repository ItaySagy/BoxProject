using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProject
{
    internal class BinaryTree<K,V> where K : IComparable<K>
    {
        class NodeTree
        {
            double _key;
            private K _value;

            public NodeTree(double key)
            {
                _key = key;
            }
            private NodeTree _right;
            private NodeTree _left;



            public NodeTree Right { get { return _right; } set { _right = value; } }
            public NodeTree Left { get { return _left; } set { _left = value; } }
            public double KeyNode { get { return _key; } set { _key = value; } }
            public K ValueNode { get { return _value; } set { _value = value; } }


        }


        NodeTree root;
        public BinaryTree()
        {
            root = null;
        }   

        public void addNode(double key)
        {
            if (root == null)
            {
                root = new NodeTree(key);
            }
            else
                addNode(key);
        }
        public bool isFound(Box box)
        {
            if(root!= null)
            {

            }
            else
            {
                return false;
            }
        }
        public bool isFound()
        

        private void addNode(double key, NodeTree node)
        {
            if (key < node.KeyNode)
            {
                if (node.Left == null)
                    node.Left = new NodeTree(key);
                else
                    addNode(key, node.Left);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new NodeTree(key);
                else
                    addNode(key, node.Right);
            }
        }
        private void removeNode(double key, NodeTree t) { }
        public void inOrder()
        {
            inOrder(root);
        }

        private void inOrder(NodeTree t)
        {
            if (t != null)
            {
                inOrder(t.Left);
                Console.Write(t.KeyNode + "  ");
                inOrder(t.Right);
            }
        }

        public T Get(double key)
        {
            return default(T);
        }
    }
}





