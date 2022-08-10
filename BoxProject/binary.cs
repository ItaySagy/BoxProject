using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProject
{
   public class Node<K, V>
    {
        K _key;
        V _value;
        Node<K, V> left, right;

        public Node(K key, V value)
        {
            _key = key;
            _value = value;
            left = right = null;
        }


        public Node<K, V> Right { get { return right; } set { right = value; } }
        public Node<K, V> Left { get { return left; } set { left = value; } }
        public K Key { get { return _key; } set { _key = value; } }
        public V Value { get { return _value; } set { _value = value; } }
    }


    public class Tree<K, V> where K : IComparable<K>
    {
        

        
        public Tree()
        {
            root = null;
        }

        private Node<K,V> root;
        public Node<K,V> Root { get { return root; } set { root = value; } }
        public void addNode(K key, V value)
        {
            if (root == null)
            {
                root = new Node<K,V>(key, value);
            }
            else
                addNode(key, value, root);
        }

        private void addNode(K key, V value, Node<K,V> node)
        {
            if (key.CompareTo(node.Key) < 0)
            {
                if (node.Left == null)
                    node.Left = new Node<K,V>(key, value);
                else
                    addNode(key, value, node.Left);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new Node<K,V>(key, value);
                else
                    addNode(key, value, node.Right);
            }
        }

        public void inOrder()
        {
            inOrder(root);
        }

        private void inOrder(Node<K,V> t)
        {
            if (t != null)
            {
                inOrder(t.Left);
                Console.Write(t.Key + "  ");
                inOrder(t.Right);
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
        private V TryFind(K k, Node<K,V> node)
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
        private Node<K,V> RemoveNode(Node<K,V> root,K key)
        {
            if (root == null)
                return root;
             if (root.Key.CompareTo(key) > 0)
                root.Left = RemoveNode(root.Left, key);
            else if(root.Key.CompareTo(key) < 0)
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
      
        private Node<K,V> FindMax(Node<K,V> root)
        {
            while (root.Left != null)
            {
                root = root.Left;
            }
            return root;
        }
    }
}





