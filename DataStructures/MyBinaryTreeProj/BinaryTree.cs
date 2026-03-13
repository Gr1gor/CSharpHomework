using System.Collections;

namespace MyBinaryTreeProj;

public class BinaryTree<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private BinaryTreeNode<T> _head;
    private int _count;

    public int Count => _count;

    // ADD
    public void Add(T value)
    {
        if (_head == null)
        {
            _head = new BinaryTreeNode<T>(value);
            _count++;
            return;
        }

        BinaryTreeNode<T> current = _head;

        while (true)
        {
            int result = value.CompareTo(current.Value);

            if (result < 0)
            {
                if (current.Left == null)
                {
                    current.Left = new BinaryTreeNode<T>(value);
                    break;
                }

                current = current.Left;
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = new BinaryTreeNode<T>(value);
                    break;
                }

                current = current.Right;
            }
        }

        _count++;
    }

    // CONTAINS
    public bool Contains(T value)
    {
        BinaryTreeNode<T> parent;
        return FindWithParent(value, out parent) != null;
    }

    // FIND WITH PARENT
    private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
    {
        BinaryTreeNode<T> current = _head;
        parent = null;

        while (current != null)
        {
            int result = current.Value.CompareTo(value);

            if (result > 0)
            {
                parent = current;
                current = current.Left;
            }
            else if (result < 0)
            {
                parent = current;
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    // REMOVE
    public bool Remove(T value)
    {
        BinaryTreeNode<T> parent;
        BinaryTreeNode<T> current = FindWithParent(value, out parent);

        if (current == null)
            return false;

        _count--;

        if (current.Right == null)
        {
            if (parent == null)
                _head = current.Left;
            else
            {
                if (parent.Value.CompareTo(current.Value) > 0)
                    parent.Left = current.Left;
                else
                    parent.Right = current.Left;
            }
        }
        else if (current.Right.Left == null)
        {
            current.Right.Left = current.Left;

            if (parent == null)
                _head = current.Right;
            else
            {
                if (parent.Value.CompareTo(current.Value) > 0)
                    parent.Left = current.Right;
                else
                    parent.Right = current.Right;
            }
        }
        else
        {
            BinaryTreeNode<T> leftmost = current.Right.Left;
            BinaryTreeNode<T> leftmostParent = current.Right;

            while (leftmost.Left != null)
            {
                leftmostParent = leftmost;
                leftmost = leftmost.Left;
            }

            leftmostParent.Left = leftmost.Right;

            leftmost.Left = current.Left;
            leftmost.Right = current.Right;

            if (parent == null)
                _head = leftmost;
            else
            {
                if (parent.Value.CompareTo(current.Value) > 0)
                    parent.Left = leftmost;
                else
                    parent.Right = leftmost;
            }
        }

        return true;
    }

    // CLEAR
    public void Clear()
    {
        _head = null;
        _count = 0;
    }

    // PREORDER
    public IEnumerable<T> PreOrderTraversal()
    {
        return PreOrder(_head);
    }

    private IEnumerable<T> PreOrder(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            yield return node.Value;

            foreach (var left in PreOrder(node.Left))
                yield return left;

            foreach (var right in PreOrder(node.Right))
                yield return right;
        }
    }

    // POSTORDER
    public IEnumerable<T> PostOrderTraversal()
    {
        return PostOrder(_head);
    }

    private IEnumerable<T> PostOrder(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            foreach (var left in PostOrder(node.Left))
                yield return left;

            foreach (var right in PostOrder(node.Right))
                yield return right;

            yield return node.Value;
        }
    }

    // INORDER (for foreach)
    private IEnumerable<T> InOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            foreach (var left in InOrderTraversal(node.Left))
                yield return left;

            yield return node.Value;

            foreach (var right in InOrderTraversal(node.Right))
                yield return right;
        }
    }

    // ENUMERATOR
    public IEnumerator<T> GetEnumerator()
    {
        return InOrderTraversal(_head).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}