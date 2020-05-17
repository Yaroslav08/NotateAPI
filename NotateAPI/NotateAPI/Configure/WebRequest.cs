using Newtonsoft.Json;
using NotateAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NotateAPI.Configure
{
    public class WebRequest
    {
        private string accessToken;
        private HttpClient httpClient;

        public void SetAccessToken(string AccessToken)
        {
            accessToken = AccessToken;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
        }
        public WebRequest(string AccessToken, string BaseUrl)
        {
            accessToken = AccessToken;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<Response> GetAsync(string Url)
        {
            string Response = null;
            try
            {
                Response = await httpClient.GetAsync(Url).Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(Response);
            }
            catch (Exception ex)
            {
                throw new APIReadResponseException(ex.Message + "\n" + Response);
            }
        }

        public async Task<Response> PostAsync(string Url, object Data)
        {
            string Response = null;
            try
            {
                var con = JsonConvert.SerializeObject(Data);
                var content = new StringContent(con, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Response = await httpClient.PostAsync(Url, content).Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(Response);
            }
            catch(Exception ex) { throw new APIReadResponseException(ex.Message + "\n" + Response); }
        }

        public async Task<Response> PostAsync(string Url)
        {
            string Response = null;
            try
            {
                Response = await httpClient.PostAsync(Url, null).Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(Response);
            }
            catch (Exception ex) { throw new APIReadResponseException(ex.Message + "\n" + Response); }
        }

        public async Task<Response> PutAsync(string Url, object Data)
        {
            string Response = null;
            try
            {
                var con = JsonConvert.SerializeObject(Data);
                var content = new StringContent(con, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Response = await httpClient.PutAsync(Url, content).Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(Response);
            }
            catch (Exception ex)
            {
                throw new APIReadResponseException(ex.Message + "\n" + Response);
            }
        }

        public async Task<Response> DeleteAsync(string Url)
        {
            string Response = null;
            try
            {
                Response = await httpClient.DeleteAsync(Url).Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(Response);
            }
            catch (Exception ex)
            {
                throw new APIReadResponseException(ex.Message + "\n" + Response);
            }
        }

        public async Task<Response> DeleteAsync(string Url, object Data)
        {
            string Response = null;
            try
            {
                var con = JsonConvert.SerializeObject(Data);
                var content = new StringContent(con, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Response = await httpClient.PutAsync(Url, content).Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response>(Response);
            }
            catch(Exception ex)
            {
                throw new APIReadResponseException(ex.Message + "\n" + Response);
            }
        }
    }
}