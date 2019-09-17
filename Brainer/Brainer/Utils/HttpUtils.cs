using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Brainer.Utils
{
  public  class HttpUtils
    {


        #region Generic gun for http get call
        public async static Task<T> GetMyRequest<T>(Uri uri)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                return default(T);
            }
        }
        #endregion

        #region Get Call Http Client Imp
        public static T Get<T>(string url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                return default(T);
            }
        }
        #endregion

    }
}
