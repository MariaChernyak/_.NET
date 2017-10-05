using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinaryTree<T>
        //where T : IComparable<T>
    {
        private Node<T> Root { get; set; }
        private IComparer<T> _comparer;

        public BinaryTree()
        {
            _comparer = Comparer<T>.Default;
        }

        public BinaryTree(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public void Add(T item)
        {
            if (Root == null)
            {
                Root = new Node<T>(item); ;
                return;
            }
            AddRecursion(Root, item);
        }

        private void AddRecursion(Node<T> currentNode, T item)
        {
            if (_comparer.Compare(item, currentNode.Data) > 0)//   item.CompareTo(currentNode.Data) > 0)
            {

                if (currentNode.RightNode == null)
                {
                    currentNode.RightNode = new Node<T>(item);
                    return;
                }
                AddRecursion(currentNode.RightNode, item);
            }
            else
            {
                if (currentNode.LeftNode == null)
                {
                    currentNode.LeftNode = new Node<T>(item);
                    return;
                }
                AddRecursion(currentNode.LeftNode, item);
            }
        }

        public IEnumerable<Node<T>> Preorder()
        {
            foreach (var node in Preorder(Root))
            {
                yield return node;
            }
        }
        private IEnumerable<Node<T>> Preorder(Node<T> node)
        {
            if (node != null)
            {
                yield return node;
                foreach (var n in Preorder(node.LeftNode))
                {
                    yield return n;
                }
                foreach (var n in Preorder(node.RightNode))
                {
                    yield return n;
                }
            }
        }
        public IEnumerable<Node<T>> Inorder()
        {
            foreach (var node in Inorder(Root))
            {
                yield return node;
            }
        }

        private IEnumerable<Node<T>> Inorder(Node<T> node)
        {
            if (node != null)
            {
                foreach (var n in Inorder(node.LeftNode))
                {
                    yield return n;
                }
                yield return node;
                foreach (var n in Inorder(node.RightNode))
                {
                    yield return n;
                }
            }
        }

        public IEnumerable<Node<T>> Postorder()
        {
            foreach (var node in Postorder(Root))
            {
                yield return node;
            }
        }

        private IEnumerable<Node<T>> Postorder(Node<T> node)
        {
            if (node != null)
            {
                foreach (var n in Postorder(node.LeftNode))
                {
                    yield return n;
                }
                foreach (var n in Postorder(node.RightNode))
                {
                    yield return n;
                }
                yield return node;
            }
        }
    }
}
