using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace UraxBPCPNO34Api.Tests.MockData
{
    class ConvertJsonData
    {
        public T GetMockJsonData<T>(string filename)
        {
            string json= string.Empty;
            try
            {   // Open the text file using a stream reader.
                var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var path1 = string.Format("{0}\\{1}\\{2}", directory, "MockData", filename);
                using (StreamReader r = new StreamReader(path1))
                    {
                    json = r.ReadToEnd();
                    }
            }
            catch (Exception e)
            {
            }
            return JsonConvert.DeserializeObject<T>(json);
        }
        public List<T> GetMockJsonListData<T>(string filename)
        {

            string json = string.Empty;
            try
            {  
                var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var path1 = string.Format("{0}\\{1}\\{2}", directory, "MockData", filename);

                using (StreamReader r = new StreamReader(path1))
                {
                    json = r.ReadToEnd();
                    
                }
            }
            catch (Exception e)
            {
            }
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

    }
}
