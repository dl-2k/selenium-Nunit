using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final.Helper
{
    public class JsonUtils
    {

        public static IEnumerable<T> LoadJsonData<T>(string fileLocation)
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string jsonFilePath = Path.Combine(projectDirectory, fileLocation);
            var jsonString = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonString);

        }
    }
    
  


}
