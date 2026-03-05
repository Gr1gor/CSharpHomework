using MyStack;

MyStack<int> stack = new MyStack<int>();


stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);
stack.Push(5);

Console.WriteLine($"Peek: {stack.Peek()}");
Console.WriteLine($"Pop: {stack.Pop()}");
Console.WriteLine($"Pop: {stack.Pop()}");
Console.WriteLine($"Pop: {stack.Pop()}");
Console.WriteLine($"Peek: {stack.Peek()}");
Console.WriteLine($"Pop: {stack.Pop()}");
