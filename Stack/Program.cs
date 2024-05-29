using System.Collections;
using MyNamespace;
class Program
{

    static void Main(string[] args)
    {
        // I basically wrote a stack based on my other project MyLinkedList,
        // making interaction between projects.
        Stack myStack = new Stack();
        
        myStack.Push(8);
        myStack.Push(5);
        myStack.Push(12);
        myStack.Push(26);
        myStack.Push(17);
        myStack.Push(4);
        myStack.Push(42);
        
        myStack.Print(); // 42 4 17 26 12 5 8 
        Console.WriteLine(myStack.Count);// 7
        Console.WriteLine(new string('-', 15));
        
        Console.WriteLine(myStack.Contains(26)); // true
        Console.WriteLine(myStack.Contains(28)); // false
        Console.WriteLine(new string('-', 15));
        
        Console.WriteLine(myStack.Peek()); // 42
        myStack.Print(); // 42 4 17 26 12 5 8
        Console.WriteLine(new string('-', 15));
        
        Console.WriteLine(myStack.Pop()); // 42
        Console.WriteLine(myStack.Count); // 6
        myStack.Print(); // 4 17 26 12 5 8
        Console.WriteLine(new string('-', 15));
        
        myStack.Clear();
        Console.WriteLine(myStack.Count); // 0
        myStack.Print(); //
    }
}

public class Stack
{
    private MyLinkedList<int> _list = new();
    public int Count => _list.Count;
    
    public void Clear()
    {
        //Based on the fact that I wrote a stack based on my written MyLinkedList,
        //to clear the entire list there is no point in deleting objects one by one.
        //Because the list stores one object with links to other objects,
        //by deleting them we simply remove the links, but the objects themselves will remain
        //in the heap to await the garbage collector. So it's easier to just create a new list.
        var clearLinkedList = new MyLinkedList<int>();
        _list = clearLinkedList;
    }

    public bool Contains(int element)
    {
        return _list.Contains(element);
    }

    public void Push(int element)
    {
        _list.AddFirst(element);
    }

    public int Pop()
    {
        if (_list.Count == 0)
        { 
            throw new InvalidOperationException("Stack is empty");
        }
        var firstNoda = _list.GetFirstNoda();
        _list.DeleteFirst();
        return firstNoda.Value;
    }

    public int Peek()
    {
        if (_list.Count == 0)
        { 
            throw new InvalidOperationException("Stack is empty");
        }
        var firstNoda = _list.GetFirstNoda();
        return firstNoda.Value;
    }

    public void Print()
    {
        foreach (var i in _list)
        {
           Console.Write(i + " "); 
        }
        Console.WriteLine();
    }
}