using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using MoreLinq;

using static System.Console;

namespace Singleton
{
    public sealed class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static readonly object obj = new object();
        private SingletonDatabase()
        {
            WriteLine("Initializing database");

            capitals = File.ReadAllLines(
              Path.Combine(
                new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt")
              )
              .Batch(2)
              .ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1)));
        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private static SingletonDatabase _instance = null;
        public static IDatabase Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (obj)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonDatabase();
                        }
                    }
                }

                return _instance;
            }
        }

        //// laziness + thread safety
        //private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() =>
        //{
        //    return new SingletonDatabase();
        //});

        //public static IDatabase Instance => instance.Value;
    }
}
