using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Part_3_Lesson_1
{
    class Program
    {
     
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = (@"D:\visual Project\КУРСЫ GEKK BRAINS\Part 3 Lesson 1\newFile.txt");
            var url = @"https://jsonplaceholder.typicode.com/posts/1";
            ClassForHttp<UserId> classForHttp = new ClassForHttp<UserId>();
            classForHttp.HetList(url);
            var usUrl = classForHttp.HetList(url);
            usUrl.ForEach(t => classForHttp.Save(path));

        }
     
    }
}
