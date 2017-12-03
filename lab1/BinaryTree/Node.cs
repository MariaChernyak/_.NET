namespace BinaryTree
{
    internal sealed class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public Node<T> RightNode { get; set; }
        public Node<T> LeftNode { get; set; }
        public T Data { get; set; }
    }
}