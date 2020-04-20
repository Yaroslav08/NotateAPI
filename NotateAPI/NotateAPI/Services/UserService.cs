using Newtonsoft.Json;
using NotateAPI.Configure;
using NotateAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotateAPI.Services
{
    public class UserService
    {
        public string accessToken;
        private BaseUrl url;
        private WebRequest req;
        public UserService(string AccessToken)
        {
            accessToken = AccessToken;
            url = new BaseUrl();
            req = new WebRequest(accessToken, url.User);
            req.SetAccessToken(AccessToken);
        }

        public async Task<User> GetUserAsync(int Id)
        {
            var res = await req.GetAsync(url.User + $"{Id}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<User>(res.Data.ToString());
            else
                throw new GetUserException(res.Error);
        }

        public async Task<User> GetUserAsync(string Username)
        {
            var res = await req.GetAsync(url.User + $"@{Username}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<User>(res.Data.ToString());
            else
                throw new GetUserException(res.Error);
        }
    }
}