using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Part_3_Lesson_1
{
  public   class Cofee
    {
        private static readonly CancellationTokenSource cts = new CancellationTokenSource();
        private static readonly HttpClient client = new HttpClient();
        





        public static async Task MakeCall()
        {
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1", cts.Token);
            var content = await response.Content.ReadAsStringAsync(cts.Token);
         

            Console.WriteLine(content);

            var filePath = @"D:\visual Project\КУРСЫ GEKK BRAINS\Part 3 Lesson 1\newFile.txt";
            File.AppendAllText(filePath, content);
            File.AppendAllText(filePath, Environment.NewLine);
        

        }
      
        public static async Task ForChecking()
        {
            try
            {
                Cofee.cts.CancelAfter(1000);
                await Cofee.MakeCall();
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("some go wrong");
            }
            finally
            {
                cts.Dispose();
            }
        }
        public static async Task<int> Pizza()
        {
            Console.WriteLine("pizza is going to be prepared");
            await Task.Delay(1000);
            Console.WriteLine("pizza redy");
            return 1;
        }
        public  static async Task<Cofee> MaheCofe(int ammountOfGroundCofee)
        {
            if (0 > ammountOfGroundCofee)
            {
                throw new ArgumentException($"Parametre{nameof(ammountOfGroundCofee)} cannot be less then zero");
            }
            Console.WriteLine("start to make");
            Console.WriteLine("coming for another dusines");
            await Task.Delay(3000);
            Console.WriteLine("cose is reddy");
            return new Cofee();
        }

    }
}
