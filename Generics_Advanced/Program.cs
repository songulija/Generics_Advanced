using System;
using System.Collections.Generic;

namespace Generics_Advanced
{
    /// <summary>
    /// Generic class. When creating object provide type for this class.
    /// Then properties could use that provided type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyList<T>
    {
        //Generic property of T type. 
        private List<T> values { get; set; }
        public MyList()
        {
            values = new List<T>();
        }
        public void AddValue(T value)
        {
            values.Add(value);
        }
        public T GetValueByIndex(int index)
        {
            return values[index];
        }
        public T GetFirstOrDefault(Func<T,bool> func) 
        {
            foreach(T value in values)
            {
                if(func(value) == true)
                {
                    return value;
                }
            }
            return default(T);
        }
    }

    public class ApiWebResponse<T>
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        //response could be status code or just message
        public T Response { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var mg = new MyList<int>();
            mg.AddValue(1);
            mg.AddValue(2);
            mg.AddValue(3);
            mg.AddValue(4);
            mg.AddValue(5);
            mg.AddValue(6);
            Func<int, bool> funcDelegate = (int value) => value == 5;
            var result = mg.GetFirstOrDefault(funcDelegate);
            Console.WriteLine(result);

            //Gets my friend number. Response depends on what type is passed to generic class. api can return anything basically
            var response = new ApiWebResponse<int> { Success = true, Response = 2 };
            //Gets my username
            var response2 = new ApiWebResponse<string> { Success = true, Response = "test123" };

            Console.ReadLine();
        }
    }
}
