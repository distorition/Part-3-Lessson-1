using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Part_3_Lesson_1
{
    class ClassForHttp<T> where T:UserId
    {
      
        private  async Task<T> Getid(string docker)
        {
             HttpClient httpClient = new HttpClient();
            
            HttpResponseMessage message = await httpClient.GetAsync(docker);
            message.EnsureSuccessStatusCode();
            if(message.IsSuccessStatusCode)
            {
                string response = await message.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(response);
            }
            else
            {
                return null;
            }
            //try
            //{
            //    HttpResponseMessage httpResponse = await httpClient.GetAsync(docker);
            //    httpResponse.EnsureSuccessStatusCode();
            //    string tareAnswer = await httpResponse.Content.ReadAsStringAsync();
            //    return JsonSerializer.Deserialize<T>(tareAnswer);
            //}
            //catch (HttpRequestException EXZ)
            //{
            //    Console.WriteLine(EXZ.Message);
            //    return null;
            //}
            

        }
        private async Task<T> GetWithId(string docker, int id)
        {
           return await Getid(docker + $"{id}");
        }

        public  List<T> HetList(string url)
        {
            List<Task<T>> listFoDocker = new List<Task<T>>();
            List<T> reuslt = new List<T>();
            for(int i = 4; i <= 13; i++)
            {
                listFoDocker.Add(GetWithId(url, i));
            }
            Task.WaitAll(listFoDocker.ToArray());
            listFoDocker.ForEach(t => reuslt.Add(t.Result));
            return reuslt;
        }
  
       public void Save(string pathToFiles)
        {
            using (StreamWriter sw = File.AppendText(pathToFiles));
        }
    }
}
