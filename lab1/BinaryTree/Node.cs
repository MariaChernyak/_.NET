
namespace BinaryTree
{
    public class Node<T>
    {
        public Node<T> RightNode { get; set; }
        public Node<T> LeftNode { get; set; }
        public T Data { get; set; }
        public Node(T data)
        {
            Data = data;     
        }
    }
}
