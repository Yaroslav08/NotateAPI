using Newtonsoft.Json;
using NotateAPI.Configure;
using NotateAPI.Exceptions;
using NotateAPI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotateAPI.Services
{
    public class SpreadService
    {
        private string accessToken;
        private BaseUrl url;
        private WebRequest req;
        public SpreadService(string AccessToken)
        {
            accessToken = AccessToken;
            url = new BaseUrl();
            req = new WebRequest(accessToken, url.Note);
            req.SetAccessToken(AccessToken);
        }

        public async Task<List<Spread>> GetMySpreads()
        {
            var res = await req.GetAsync("GetMy");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<List<Spread>>(res.Data.ToString());
            else
                throw new SpreadException(res.Error);
        }
        public async Task<List<Spread>> GetSentSpreads()
        {
            var res = await req.GetAsync("GetSent");
            if(res.IsSuccess)
                return JsonConvert.DeserializeObject<List<Spread>>(res.Data.ToString());
            else
                throw new SpreadException(res.Error);
        }
    }
}