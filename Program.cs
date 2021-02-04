using System;
using System.Collections.Generic;
using System.Linq;
using CollectionsAndLinq.LinqExamples;

namespace CollectionsAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //anything with angle brackets after the type name is a generic type
            //List<T> Generic List
            //Pronounced List of T
            //T is a Generic Type Parameter
            //string in this case closes the generic type
            var teachers = new List<string> { "Jameka", "Dylan", "Nathan" };

            var e13 = new List<string>();
            e13.Add("Rob");
            e13.Add("Ryan");
            e13.Add("Hunter");
            e13.Add("Bailey");
            e13.Add("Wanda");

            //e13.Add(teachers[0]);
            //e13.Add(teachers[1]);
            //e13.Add(teachers[2]);

            //foreach (var teacher in teachers)
            //{
            //    e13.Add(teacher);
            //}

            //gets enumerator for a type
            foreach (var student in e13) // unsupported operation exception
            {
                if (student == "Hunter")
                {
                    //changes to the underlying collection do not allow for continued looping
                    //e13.Remove(student);
                }
            }

            e13.AddRange(teachers);

            e13.ForEach(name => { Console.WriteLine(name); });

            if (e13.Remove("Wanda"))
            {
                Console.WriteLine("Bye Wanda.");
            }
            if (e13.Remove("Wanda"))
            {
                Console.WriteLine("Bye again Wanda.");
            }


            //Dictionary<TKey,TValue>
            //Arity (`2) -> how many generic type parameters a type has. Dictionary`2
            //Very fast information retrieval
            //Slower information storage
            //Good for: infrequently updated but often read data
            //Good for: loading information at startup or in the background and fast retrieval on demand (caching)

            //the first parameter is the type for the key, the second is the type for the value
            var words = new Dictionary<string, string>
            { //collection initializer
                {"soup", "a thing i don't have right now, but want."}, //key value pair
                {"cake", "a thing i don't have right now, but don't need."}
            };

            words.Add("Arity", "how many generic type parameters a type has");

            words["Arity"] = "A thing Nathan made up"; //look up an item by key using the indexer

            //words.Add("Arity", "another definition");  //argument exception
            if (!words.TryAdd("Arity", "another definition"))
            {
                words["Arity"] = "another definition";
            }

            words.Remove("cake");

            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} means {word.Value}");
            }

            foreach (var (word, definition) in words)
            {
                Console.WriteLine($"{word} means {definition}");
            }

            var complicatedDictionary = new Dictionary<string, List<string>>();

            complicatedDictionary.Add("Soup", new List<string>());
            var soupDefinitions = complicatedDictionary["Soup"];
            soupDefinitions.Add("This is a definition of soup");

            complicatedDictionary.Add("Arity", new List<string> { "A definition of arity" });

            foreach (var (word, definitions) in complicatedDictionary)
            {
                Console.WriteLine(word);
                foreach (var definition in definitions)
                {
                    Console.WriteLine($"\t{definition}");
                }
            }

            //Hashset<T>
            //Really fast retrieval, no keys
            //Slow information storage
            //enforces uniqueness, but no errors
            //Good for: looping
            //Good for: when you only want at most one copy of a thing, deduplication

            var unique = new HashSet<string>(e13); //most collection constructors take in collections and convert them

            unique.Add("Nathan");  //only this one did something
            unique.Add("Nathan");
            unique.Add("Nathan");
            unique.Add("Nathan");
            unique.Add("Nathan");

            unique.Remove("Nathan");

            //Queue<T>
            //FIFO 
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(8);
            queue.Enqueue(12);
            queue.Enqueue(3);
            queue.Enqueue(1);

            while (queue.Count > 0)
            {
                Console.WriteLine($"currently dequeueing : {queue.Dequeue()}");
            }

            //Stack<T>
            //LIFO
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(12);
            stack.Push(3);
            stack.Push(1);

            while (stack.Count > 0)
            {
                Console.WriteLine($"currently dequeueing : {stack.Pop()}");
            }


            var examples = new Examples();
            examples.Run();





















            var a1 = new A<int>();
            var a2 = new A<string>();

            a1.DoStuff(123);
            a2.DoStuff("Other stuff");

            foreach (var VARIABLE in a2)
            {

            }

        }
    }

    class A<TypeOfThingToDo>
    {
        public void DoStuff(TypeOfThingToDo thingToDo)
        {
            Console.WriteLine($"stuff {thingToDo}");
        }

        public IEnumerator<int> GetEnumerator()
        {
            return Enumerable.Range(1, 100).GetEnumerator();
        }
    }
}