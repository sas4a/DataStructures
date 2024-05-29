using System;

class Program
{
    static void Main(string[] args)
    {
        // I wrote a data structure called a max-heap using recursion, where the maximum element is always stored at the root.
        // To demonstrate, I created a PrintHeapAndMaximumValue method so that it will print the entire heap and
        // the maximum element as long as there are elements there, removing the maximum element each time.
        // After removing an element, the heap will be rearranged.
        
        Heap heap = new Heap();
        
        heap.Add(5);
        heap.Add(3);
        heap.Add(25);
        heap.Add(17);
        heap.Add(7);
        heap.Add(1);
        heap.Add(19);
        heap.Add(2);
        
        heap.PrintHeapAndMaximumValue();
    }
}

public class Heap
{
    public int Count => _heapData.Count;
    private List<int> _heapData = new();

    public void Add(int value)
    {
        _heapData.Add(value);
        ShiftUp(_heapData.Count - 1);
    }
    
    private void ShiftUp(int index)
    {
        int parentIndex = (index - 1) / 2;
        int currentElement = _heapData[index];
        int parentElement = _heapData[parentIndex];
        if (currentElement > parentElement)
        {
            Swap(_heapData, index, parentIndex);
            ShiftUp(parentIndex);
        }
    }

    private void Swap(List<int> array, int leftIndex, int rightIndex)
    {
        (array[leftIndex], array[rightIndex]) = (array[rightIndex], array[leftIndex]);
    }

    public int ExtractMaximum()
    {
        var result = _heapData[0];
        _heapData[0] = _heapData[^1];
        _heapData.RemoveAt(_heapData.Count -1);
        ShiftDown(0);
        return result;

    }

    private void ShiftDown(int index)
    {
        var leftChildIndex = index * 2 + 1;
        var rightChildIndex = index * 2 + 2;

        if (leftChildIndex >= _heapData.Count)
        {
            return;
        }

        var maxChildIndex = leftChildIndex;
        if (rightChildIndex < _heapData.Count 
            && _heapData[leftChildIndex]<_heapData[rightChildIndex])
        {
            maxChildIndex = rightChildIndex;
        }

        if (_heapData[index] > _heapData[maxChildIndex])
        {
            return;
        }
        Swap(_heapData,index,maxChildIndex);
        ShiftDown(maxChildIndex);
    }

    private void Print()
    {
        for (int i = 0; i < _heapData.Count; i++)
        {
            Console.Write(_heapData[i] + " ");
        }
    }

    public void PrintHeapAndMaximumValue()
    {
        while (_heapData.Count>0)
        {
            Print();
            Console.WriteLine("\n--------------\nMax:" + ExtractMaximum() + "\n--------------"); 
        }
    }
}

