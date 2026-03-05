using HomeworkLinkedList;

MyLinkedListNode<int> first = new MyLinkedListNode<int>(1);
MyLinkedListNode<int> second = new MyLinkedListNode<int>(2);
MyLinkedListNode<int> third = new MyLinkedListNode<int>(3);
MyLinkedListNode<int> fourth = new MyLinkedListNode<int>(4);
MyLinkedListNode<int> fifth = new MyLinkedListNode<int>(5);


MyLinkedList<int> list = new MyLinkedList<int>();

list.AddFirst(first);
list.AddFirst(second);
list.AddFirst(fourth);
list.AddLast(third);
list.AddLast(fifth);
list.RemoveFirst();
list.RemoveLast();
Console.WriteLine(list.Tail.Value);
