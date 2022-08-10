using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProject
{


    public class Tree<K, V> where K : IComparable<K>
    {
        class Node
        {
            public Node(K key, V value)
            {
                Key = key;
                Value = value;
                Left = Right = null;
            }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public K Key { get; set; }
            public V Value { get; set; }
        }

        public Tree()
        {
            root = null;
        }

        private Node root;
        Node Root { get { return root; } set { root = value; } }
        public void addNode(K key, V value)
        {
            if (root == null)
            {
                root = new Node(key, value);
            }
            else
                addNode(key, value, root);
        }

        private void addNode(K key, V value, Node node)
        {
            if (key.CompareTo(node.Key) < 0)
            {
                if (node.Left == null)
                    node.Left = new Node(key, value);
                else
                    addNode(key, value, node.Left);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new Node(key, value);
                else
                    addNode(key, value, node.Right);
            }
        }

        public void inOrder(Action<object> action)
        {
            inOrder(root, action);
        }

        private void inOrder(Node t, Action<object> action)
        {
            if (t != null)
            {
                inOrder(t.Left, action);
                action.Invoke(t.Key);
                inOrder(t.Right, action);
            }
        }

        public K Get(K key)
        {
            return default(K);
        }

        public V TryFind(K k)
        {
            return TryFind(k, root);
        }
        private V TryFind(K k, Node node)
        {
            if (node == null)
                return default;
            else if (node.Key.Equals(k))
                return node.Value;
            else if (k.CompareTo(node.Key) > 0)
                return TryFind(k, node.Right);
            else
                return TryFind(k, node.Left);
        }

        public void RemoveNode(K key)
        {
            RemoveNode(root, key);
        }
        private Node RemoveNode(Node root, K key)
        {
            if (root == null)
                return root;
            if (root.Key.CompareTo(key) > 0)
                root.Left = RemoveNode(root.Left, key);
            else if (root.Key.CompareTo(key) < 0)
                root.Right = RemoveNode(root.Right, key);
            else
            {
                if (root.Left == null && root.Right == null)
                    root = null;
                else if (root.Left != null && root.Right != null)
                {
                    var maxNode = FindMax(root.Right);
                    root.Key = maxNode.Key;
                    root.Value = maxNode.Value;
                    root.Right = RemoveNode(root.Right, maxNode.Key);
                }
                else
                {
                    var child = root.Left != null ? root.Left : root.Right;
                    root = child;
                }

            }
            return root;

        }

        private Node FindMax(Node root)
        {
            while (root.Left != null)
            {
                root = root.Left;
            }
            return root;
        }
    }
}





