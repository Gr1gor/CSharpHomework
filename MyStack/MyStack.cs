using HomeworkLinkedList;

namespace MyStack;

public class MyStack<T>
{
    private MyLinkedList<T> items;

    public MyStack()
    {
        items = new MyLinkedList<T>();
    }

    public void Push(T item)
    {
        items.AddFirst(new MyLinkedListNode<T>(item));
    }

    public T Pop()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        T value = items.Head.Value;
        items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        return items.Head.Value;
    }
}
