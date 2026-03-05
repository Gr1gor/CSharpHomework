namespace HomeworkLinkedList;

public class MyLinkedListNode<T>
{
    public T Value { get; set; }
    public MyLinkedListNode<T> Next { get; set; }

    public MyLinkedListNode(T value)
    {
        Value = value;
        Next = null;
    }

    public MyLinkedListNode(T value, MyLinkedListNode<T> next)
    {
        Value = value;
        Next = next;
    }

    public override string ToString()
    {
        return Value?.ToString() ?? "null";
    }
}