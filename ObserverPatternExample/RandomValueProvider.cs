using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPatternExample
{
    public class RandomValueProvider : RandomValueObserver
    {
        IList<IObserver<int>> _observers=new List<IObserver<int>>();
        bool shoudStop=true;
        Random rnd= new Random();

        public IDisposable Subscribe(RandomValueObserver observer)
        {
            _observers.Add(observer);
            return observer;
        }

        public void Start()
        {
            shoudStop = false;
            Task.Factory.StartNew(createValues);
        }

        void createValues()
        {
    
            while (shoudStop==false)
            {
                var nextValue = rnd.Next();
                Notify(nextValue);
                Thread.Sleep(500);
            }
        }

        public void Notify(int nextValue)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(nextValue);
            }
        }

        public void Stop()
        {
            shoudStop=true;
        }
    }

    public class RandomValueObserver : IObserver<int>, IDisposable
    {
        private static int counter=0;
        public RandomValueObserver()
        {
            this.Id = counter;
            counter++;
        }

        int Id { get; set; }
        public void Dispose()
        {
            this.Dispose();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(int value)
        {
            Console.WriteLine("Observer "+Id+" : " +value.ToString());
        }
    }
}
