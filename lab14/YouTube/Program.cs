namespace YouTube
{
    public class User
    {
        Thread thread;
        public User(int i)
        {
            thread = new Thread(PullVideoChannel.Using);
            {
                thread.Name = $"User {i}";
                thread.Start();
            }
        }
    }

    public static class PullVideoChannel
    {
        static Semaphore semaphore = new Semaphore(3, 20);
        public static void Using()
        {
            if (!semaphore.WaitOne(5000))
            {
                Console.Write("Я устал!!!");
                Console.WriteLine("Я УХОЖУУУ");
            }

            Console.WriteLine($"Это мой поток!!!! Зис ис {Thread.CurrentThread.Name}");
            Thread.Sleep(1500);

            semaphore.Release();
        }
    }


    class Program
    {
        static void Main()
        {
            try
            {
                User[] users = new User[20];

                for (int i = 0; i < 20; i++)
                {
                    users[i] = new User(i);
                }
            }
            catch { }
        }
    }
}