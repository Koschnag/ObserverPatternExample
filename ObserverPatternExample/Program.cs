using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RandomValueProvider randomValueProvider = new RandomValueProvider();
            RandomValueObserver randomValueObserver1 = new RandomValueObserver();
            RandomValueObserver randomValueObserver2 = new RandomValueObserver();

            randomValueProvider.Subscribe(randomValueObserver1);
            randomValueProvider.Subscribe(randomValueObserver2);

            randomValueProvider.Start();
            Console.ReadKey();
        }
    }
}
