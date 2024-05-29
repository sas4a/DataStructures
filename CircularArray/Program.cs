using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        CircularArray<int> circularArray = new CircularArray<int>(3);
        CircularArray<string> circularArray2 = new CircularArray<string>(2);
        
        circularArray.Add(1); circularArray.Add(2);
        circularArray.Add(3); circularArray.Add(4);
        circularArray.Add(5); circularArray.Add(6);
        circularArray.Add(7);
        
        circularArray.PrintArray(); //5 6 7
        
        Console.WriteLine(new string('-', 7)); 
        
        circularArray2.Add("hello"); circularArray2.Add("world");
        circularArray2.Add("its"); circularArray2.Add("me");
        circularArray2.Add("human");
        
        circularArray2.PrintArray(); //me human
    }
}
public class CircularArray<T>
{
    public int Count => _nextIndex > _elements.Length ? _elements.Length : _nextIndex;
    private T[] _elements;
    private int _nextIndex;
    
    public CircularArray(int count)
    {
        _elements = new T[count];
    }
    public void Add(T value)
    {
        var currentIndex = _nextIndex % _elements.Length;
        _elements[currentIndex] = value;
        ++_nextIndex;
    }
    public T Get(int index)
    {
        if (_nextIndex < _elements.Length)
        {
            return _elements[index];
        }

        return _elements[(_nextIndex + index) % _elements.Length];
    }

    public void PrintArray()
    {
        for (int i = 0; i < Count; i++)
        {
            Console.Write(Get(i) + " ");
        } 
        Console.WriteLine();
    }
}