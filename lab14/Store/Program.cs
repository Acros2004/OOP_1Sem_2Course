using System.Collections;
using System.Data;

namespace Store
{
    public class Car
    {
        public int maxSizeItem;
        public List<string> listItem = new List<string>();
        int number;
        public static int counterItem = 0;
        public Car(int size, int number)
        {
            this.number = number;
            maxSizeItem = size;
        }


        public void ShowItem()
        {
            Console.WriteLine($"{number} машина загрузила следующие элементы:");
            foreach (var item in listItem)
            {
                Console.WriteLine(item);
                counterItem++;
            }
        }
    }

    public class Store
    {
        Car[] cars;
        string[] store;
        Mutex mutex = new Mutex();

        int counter = 0;

        private readonly string fileItem;

        public Store(string fileItem, Car[] cars)
        {
            this.fileItem = fileItem;
            this.cars = cars;
            store = File.ReadAllLines(fileItem);
        }

        public void UnloadStore(object obj)
        {
            Car car = obj as Car;

            mutex.WaitOne();

            for (int i = 0; i < car.maxSizeItem; i++)
            {
                if (store.Length == 0) return;
                car.listItem.Add(store[store.Length - 1]);
                Array.Resize(ref store, store.Length - 1);
            }

            mutex.ReleaseMutex();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car_01 = new Car(10, 1);
            Car car_02 = new Car(15, 2);
            Car car_03 = new Car(20, 3);

            Car[] cars = { car_01, car_02, car_03 };

            Store store = new Store("", cars);

            Thread thread_01 = new Thread(store.UnloadStore);
            Thread thread_02 = new Thread(store.UnloadStore);
            Thread thread_03 = new Thread(store.UnloadStore);

            thread_01.Start(car_01);
            thread_02.Start(car_02);
            thread_03.Start(car_03);
            thread_03.Join();

            car_01.ShowItem();
            car_02.ShowItem();
            car_03.ShowItem();

            Console.WriteLine($"Всего товаров = {Car.counterItem}");
        }
    }
}