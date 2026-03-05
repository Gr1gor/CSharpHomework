using System.Collections;

namespace HomeworkLinkedList;

public class MyLinkedList<T> : ICollection<T>
{

    public MyLinkedListNode<T> Head { get; set; }
    public MyLinkedListNode<T> Tail { get; set; }

    #region ICollection


    public IEnumerator<T> GetEnumerator()
    {
        MyLinkedListNode<T> current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }





    public void Add(T item)
    {
        var newNode = new MyLinkedListNode<T>(item);
        if (Head == null)
        {
            AddFirst(newNode);
        }
        else
        {
            AddLast(newNode);
        }
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        MyLinkedListNode<T> current = Head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        if (array.Length - arrayIndex < Count)
            throw new ArgumentException();

        int index = arrayIndex;
        MyLinkedListNode<T> current = Head;
        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Next;
        }
    }

    public bool Remove(T item)
    {
        if (Head == null)
            return false;

        if (EqualityComparer<T>.Default.Equals(Head.Value, item))
        {
            RemoveFirst();
            if (Count == 0)
                Tail = null;
            return true;
        }

        MyLinkedListNode<T> current = Head;
        while (current.Next != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Next.Value, item))
            {
                current.Next = current.Next.Next;
                if (current.Next == null)
                    Tail = current;
                Count--;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public int Count { get; private set; }
    public bool IsReadOnly => false;

    #endregion

    #region Add

    public void AddFirst(MyLinkedListNode<T> item)
    {
        MyLinkedListNode<T> tmp = Head;
        Head = item;
        Head.Next = tmp;
        Count++;

        if (Count == 1)
        {
            Tail = Head;
        }
    }

    public void AddLast(MyLinkedListNode<T> item)
    {
        if (Head == null)
        {
            AddFirst(item);
        }
        else
        {
            Tail.Next = item;
            Tail = item;
            Count++;
        }
    }
    #endregion Add

    #region MyRegion

    public void RemoveFirst()
    {
        if (Head == null)
            throw new InvalidOperationException("List is empty.");

        Head = Head.Next;
        Count--;
    }

    public void RemoveLast()
    {
        if (Head == null)
            throw new InvalidOperationException("List is empty.");

        if (Head == Tail)
        {
            Head = null;
            Tail = null;
            Count--;
            return;
        }

        MyLinkedListNode<T> tmp = Head;
        while (tmp.Next.Next != null)
        {
            tmp = tmp.Next;
        }

        Tail = tmp;
        tmp.Next = null;
        Count--;
    }

    #endregion
}
