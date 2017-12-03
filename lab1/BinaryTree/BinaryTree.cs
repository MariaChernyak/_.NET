using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        private readonly IComparer<T> _comparer;

        public BinaryTree(IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));
            _comparer = comparer;
        }

        public BinaryTree(): this(Comparer<T>.Default) { }

        public BinaryTree(ICollection<T> list, IComparer<T> comparer)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }
            _comparer = comparer;
                
            foreach (var item in list)
            {
                Add(item);
            }
        }

        public BinaryTree(ICollection<T> list) : this(list, Comparer<T>.Default) {}

        private Node<T> Root { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Preorder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void AddRecursion(Node<T> currentNode, T item)
        {
            if (_comparer.Compare(item, currentNode.Data) > 0)
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

        public IEnumerable<T> Preorder()
        {
            foreach (var node in Preorder(Root))
                yield return node.Data;
        }

        private IEnumerable<Node<T>> Preorder(Node<T> node)
        {
            if (node != null)
            {
                yield return node;
                foreach (var n in Preorder(node.LeftNode))
                    yield return n;
                foreach (var n in Preorder(node.RightNode))
                    yield return n;
            }
        }

        public IEnumerable<T> Inorder()
        {
            foreach (var node in Inorder(Root))
                yield return node.Data;
        }

        private IEnumerable<Node<T>> Inorder(Node<T> node)
        {
            if (node != null)
            {
                foreach (var n in Inorder(node.LeftNode))
                    yield return n;
                yield return node;
                foreach (var n in Inorder(node.RightNode))
                    yield return n;
            }
        }

        public IEnumerable<T> Postorder()
        {
            foreach (var node in Postorder(Root))
                yield return node.Data;
        }

        private IEnumerable<Node<T>> Postorder(Node<T> node)
        {
            if (node != null)
            {
                foreach (var n in Postorder(node.LeftNode))
                    yield return n;
                foreach (var n in Postorder(node.RightNode))
                    yield return n;
                yield return node;
            }
        }

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (Root == null)
            {
                Root = new Node<T>(item);
                return;
            }
            AddRecursion(Root, item);
        }
    }
}