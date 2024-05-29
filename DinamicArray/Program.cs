class Program
{
    static void Main(string[] args)
    {
        // In Main, I specially duplicated the output code to the console
        // to clearly show line by line changes after the methods work

        DynamicArray<int> dynamicArray = new DynamicArray<int>();
        
        dynamicArray.Print();
        Console.WriteLine("Count:" + dynamicArray.Count); // 0
        Console.WriteLine("Capacity:" + dynamicArray.Capacity); // 4
        Console.WriteLine(new string('-', 20)); 
        
        dynamicArray.Add(4);
        dynamicArray.Add(6);
        dynamicArray.Add(9);
        dynamicArray.Add(2);
        dynamicArray.Add(1);
        dynamicArray.Add(13);
        
        dynamicArray.Print(); // 4 6 9 2 1 13 0 0 
        Console.WriteLine("Count:" + dynamicArray.Count); // 6
        Console.WriteLine("Capacity:" + dynamicArray.Capacity); // 8
        Console.WriteLine(new string('-', 20)); 
        
        dynamicArray.Delete(2);
        
        dynamicArray.Print(); // 4 6 2 1 13 0 0 0
        Console.WriteLine("Count:" + dynamicArray.Count); // 5
        Console.WriteLine("Capacity:" + dynamicArray.Capacity); // 8
        Console.WriteLine(new string('-', 20)); 
        
        Console.WriteLine(dynamicArray.Get(1));
        Console.WriteLine(dynamicArray.Get(4));
        Console.WriteLine(new string('-', 20));
        
        
        
        
        DynamicArray<string> dynamicArray2 = new DynamicArray<string>();
        
        dynamicArray2.Print(); // 
        Console.WriteLine("Count:" + dynamicArray2.Count); // 0
        Console.WriteLine("Capacity:" + dynamicArray2.Capacity); // 4
        Console.WriteLine(new string('-', 20));
        
        dynamicArray2.Add("pasha");
        dynamicArray2.Add("dasha");
        dynamicArray2.Add("dima");
        dynamicArray2.Add("polina");
        dynamicArray2.Add("mike");
        
        dynamicArray2.Print(); // pasha dasha dima polina mike
        Console.WriteLine("Count:" + dynamicArray2.Count); // 5
        Console.WriteLine("Capacity:" + dynamicArray2.Capacity); // 8
        Console.WriteLine(new string('-', 20));
        
        dynamicArray2.Delete(0);
        
        dynamicArray2.Print(); // dasha dima polina mike
        Console.WriteLine("Count:" + dynamicArray2.Count); // 4
        Console.WriteLine("Capacity:" + dynamicArray2.Capacity); // 8
        Console.WriteLine(new string('-', 20));
        
        Console.WriteLine(dynamicArray2.Get(0));
        Console.WriteLine(dynamicArray2.Get(3));
    }
}

public class DynamicArray<T>
{
    public int Capacity => _array.Length;
    public int Count;
    private T[] _array;
    private int _startCountElement = 4;

    public DynamicArray()
    {
        _array = new T[_startCountElement];
    }

    public void Add(T value)
    {
        if (_array == null || value == null) throw new InvalidOperationException("Array is null or Entrance value is null!");
        if (Count == _array.Length)
        {
            Array.Resize(ref _array, _array.Length * 2);
        }
        _array[Count] = value; 
        Count++;
    }

    public T Get(int index)
    {
        return _array[index];
    }

    public void Delete(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }
        Swap(index);
        _array[Count-1] = default;
        Count--;
    }

    private void Swap(int index)
    {
        for (int i = index; i < Count-1; i++)
        {
            _array[i] = _array[i + 1];
        }
    }

    public void Print()
    {
        foreach (var i in _array)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }

}