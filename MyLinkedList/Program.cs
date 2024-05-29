using System.Collections;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            //Our class implements Generic parameter and we can use int
            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();

            myLinkedList.AddFirst(5);
            myLinkedList.AddFirst(7);
            myLinkedList.AddFirst(2);
            myLinkedList.AddFirst(1);
            myLinkedList.AddFirst(4);
            
            myLinkedList.PrintAllNoda(); // 4 1 2 7 5
            Console.WriteLine(myLinkedList.Count); // 5
            Console.WriteLine(new string('-', 25));

            myLinkedList.AddLast(16);
            myLinkedList.PrintAllNoda(); // 4 1 2 7 5 16
            Console.WriteLine(myLinkedList.Count); // 6
            Console.WriteLine(new string('-', 25));

            var afterThisNoda = myLinkedList.Find(7);
            myLinkedList.AddAfter(afterThisNoda, 10);
            myLinkedList.PrintAllNoda(); // 4 1 2 7 10 5 16
            Console.WriteLine(new string('-', 25));

            var beforeThisNoda = myLinkedList.Find(1);
            myLinkedList.AddBefore(beforeThisNoda,8);
            myLinkedList.PrintAllNoda(); // 4 8 1 2 7 10 5 16
            Console.WriteLine(new string('-', 25));
            
            myLinkedList.Remove(4);
            myLinkedList.PrintAllNoda(); // 8 1 2 7 10 5 16
            Console.WriteLine(new string('-', 25));
            
            myLinkedList.Remove(16);
            myLinkedList.PrintAllNoda(); // 8 1 2 7 10 5
            Console.WriteLine(new string('-', 25));

            //Also i realized interface Inumerable and can use foreach
            foreach (var i in myLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 25));
           

            
            
            
            
            //Our class implements Generic parameter and we can use object
            MyLinkedList<Person> personList = new MyLinkedList<Person>();
            
            var person1 = new Person("Sasha", 26);
            var person2 = new Person("Dima", 30);
            var person3 = new Person("Katy", 35);
            
            personList.AddFirst(person1);
            personList.AddLast(person2);
            personList.PrintAllNoda(); // Name: Sasha, Age: 26 // Name: Dima, Age: 30 
            Console.WriteLine(new string('-', 25));

            var findPerson = personList.Find(person1);
            personList.AddAfter(findPerson, person3);
            personList.PrintAllNoda(); // Name: Sasha, Age: 26 // Name: Katy, Age: 35 // Name: Dima, Age: 30 
            Console.WriteLine(new string('-', 25));
            
            personList.Remove(person2);
            personList.PrintAllNoda(); // Name: Sasha, Age: 26 // Name: Katy, Age: 35
            Console.WriteLine(new string('-', 25));
            Console.WriteLine();
            

            
            
            
            //Our class implements Generic parameter and we can use string
            MyLinkedList<string> listOfString = new MyLinkedList<string>();

            listOfString.AddFirst("water");
            listOfString.AddFirst("grass");
            listOfString.AddFirst("tree");
            listOfString.AddFirst("sun");
            
            listOfString.PrintAllNoda(); // sun tree grass water
            Console.WriteLine(listOfString.Count); // 4
            Console.WriteLine(new string('-', 25));

            listOfString.AddLast("fire");
            listOfString.PrintAllNoda(); // sun tree grass water fire
            Console.WriteLine(listOfString.Count); // 5
            Console.WriteLine(new string('-', 25));

            var afterThisNoda1 = listOfString.Find("tree");
            listOfString.AddAfter(afterThisNoda1, "wind");
            listOfString.PrintAllNoda(); // sun tree wind grass water fire
            Console.WriteLine(new string('-', 25));

            var beforeThisNoda1 = listOfString.Find("fire");
            listOfString.AddBefore(beforeThisNoda1, "element");
            listOfString.PrintAllNoda(); // sun tree wind grass water element fire
            Console.WriteLine(new string('-', 25));
            
            listOfString.Remove("sun");
            listOfString.PrintAllNoda(); // tree wind grass water element fire
            Console.WriteLine(new string('-', 25));
            
            listOfString.Remove("fire");
            listOfString.PrintAllNoda(); // tree wind grass water element
            Console.WriteLine(listOfString.Count); // 5
            Console.WriteLine(new string('-', 25));
            
        }
    }

    public class Noda<T>
    {
        public Noda<T>? Next;
        public Noda<T>? Previous;
        public T Value;

        public Noda(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    public class MyLinkedList<T> : IEnumerable<T>, IEquatable<T>
    {
        private Noda<T>? _head;
        private Noda<T>? _tail;
        public int Count;

        public void AddFirst(T value)
        {
            Noda<T> currentNoda = new Noda<T>(value);
            if (_head == null && Count == 0)
            {
                _head = currentNoda;
                _tail = currentNoda;
            }
            else
            {
                currentNoda.Next = _head;
                _head.Previous = currentNoda;
                _head = currentNoda;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            Noda<T> currentNoda = new Noda<T>(value);
            if (_head == null && _tail == null && Count == 0)
            {
                _head = currentNoda;
                _tail = currentNoda;
            }
            else
            {
                currentNoda.Previous = _tail;
                _tail.Next = currentNoda;
                _tail = currentNoda;
            }

            Count++;
        }

        public void AddAfter(Noda<T> afterThisNoda, T value)
        {
            Noda<T> newNoda = new Noda<T>(value);

            if (afterThisNoda != null)
            {
                newNoda.Previous = afterThisNoda;
                newNoda.Next = afterThisNoda.Next;
                if (afterThisNoda.Next != null) afterThisNoda.Next.Previous = newNoda;
                afterThisNoda.Next = newNoda;
                Count++;
            }
        }

        public void AddBefore(Noda<T>? beforeThisNoda, T value)
        {
            Noda<T> newNoda = new Noda<T>(value);
            if (beforeThisNoda != null)
            {
                newNoda.Previous = beforeThisNoda.Previous;
                newNoda.Next = beforeThisNoda;
                if (beforeThisNoda.Previous != null) beforeThisNoda.Previous.Next = newNoda;
                beforeThisNoda.Previous = newNoda;
                Count++;
            }
        }

        public Noda<T>? GetFirstNoda()
        {
            return _head;
        }

        public void Remove(T value)
        {
            var nodaForRemove = Find(value);
            if (nodaForRemove != null)
            {
                if (nodaForRemove == _head && _head == _tail)
                {
                    _head = _tail = null;
                }

                else if (nodaForRemove == _head)
                {
                    _head = nodaForRemove.Next;
                    _head.Previous = null;
                }

                else if (nodaForRemove == _tail)
                {
                    _tail = nodaForRemove.Previous;
                    _tail.Next = null;
                }
                else
                {
                    nodaForRemove.Previous.Next = nodaForRemove.Next;
                    nodaForRemove.Next.Previous = nodaForRemove.Previous;
                }
                Count--;
            }
        }

        public void DeleteFirst()
        {
            if (_head == null && _tail == null && Count == 0)
            {
                throw new Exception("No nodes to delete were found");
            }

            var currentNoda = _head?.Next;
            currentNoda.Previous = null;
            _head = currentNoda;
            Count--;
        }

        public void DeleteLast()
        {
            if (_head == null && _tail == null && Count == 0)
            {
                throw new Exception("No nodes to delete were found");
            }

            var currentNoda = _tail?.Previous;
            currentNoda.Next = null;
            _tail = currentNoda;
            Count--;
        }

        public Noda<T>? Find(T value)
        {
            var currentNoda = _head;
            while (currentNoda != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNoda.Value, value)) return currentNoda;
                currentNoda = currentNoda.Next;
            }

            return null;
        }

        public void PrintAllNoda()
        {
            var currentNoda = _head;
            while (currentNoda != null)
            {
                Console.Write(currentNoda.Value + " ");
                currentNoda = currentNoda.Next;
            }

            Console.WriteLine();
        }

        public void PrintAllNodaReverse()
        {
            var currentNoda = _tail;
            while (currentNoda != null)
            {
                Console.Write(currentNoda.Value + " ");
                currentNoda = currentNoda.Previous;
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNoda = _head;
            while (currentNoda != null)
            {
                yield return currentNoda.Value;
                currentNoda = currentNoda.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Equals(T? other)
        {
            if (other == null)
                return false;

            if (typeof(T) == typeof(int) || typeof(T) == typeof(string))
            {
                return Object.Equals(this, other);
            }
            else if (typeof(T) == typeof(Person))
            {
                var thisPerson = this as Person;
                var otherPerson = other as Person;

                if (thisPerson != null && otherPerson != null)
                {
                    return thisPerson.Name == otherPerson.Name && thisPerson.Age == otherPerson.Age;
                }
            }

            return false;
        }
    }


    public class Person : IEquatable<Person>
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            Console.WriteLine();
            return $"Name: {Name}, Age: {Age}";
        }

        public bool Equals(Person? other)
        {
            return other != null &&
                   Name == other.Name &&
                   Age == other.Age;
        }
    }
}