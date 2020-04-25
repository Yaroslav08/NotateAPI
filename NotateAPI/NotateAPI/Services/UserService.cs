using Newtonsoft.Json;
using NotateAPI.Configure;
using NotateAPI.Exceptions;
using NotateAPI.Models.Entity;
using NotateAPI.Models.Helpers.UserService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotateAPI.Services
{
    public class UserService
    {
        private string accessToken;
        private BaseUrl url;
        private WebRequest req;
        public UserService(string AccessToken)
        {
            accessToken = AccessToken;
            url = new BaseUrl();
            req = new WebRequest(accessToken, url.User);
            req.SetAccessToken(AccessToken);
        }

        public async Task<string> DeleteMyAccountAsync()
        {
            var res = await req.DeleteAsync("Delete");
            if (res.IsSuccess)
                return "OK";
            else
                throw new UserException(res.Error);
        }

        public async Task<string> EditAsync(UserEditModel model)
        {
            var res = await req.PutAsync("Edit", model);
            if (res.IsSuccess)
                return "OK";
            else
                throw new UserException(res.Error);
        }

        public async Task<User> GetUserAsync(int Id)
        {
            var res = await req.GetAsync($"{Id}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<User>(res.Data.ToString());
            else
                throw new UserException(res.Error);
        }

        public async Task<User> GetUserAsync(string Username)
        {
            var res = await req.GetAsync($"@{Username}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<User>(res.Data.ToString());
            else
                throw new UserException(res.Error);
        }

        public async Task<string> EditUsernameAsync(string NewUsername)
        {
            var res = await req.PutAsync("EditUsername", new ChangeUsernameModel { Username = NewUsername });
            if (res.IsSuccess)
                return "OK";
            else
                throw new UserException(res.Error);
        }

        public async Task<List<UserShortModel>> SearchUsersAsync(string Name, int Offset = 0, int Count = 20)
        {
            var res = await req.GetAsync($"Search/{Name}?Offset={Offset}&Count={Count}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<List<UserShortModel>>(res.Data.ToString());
            else
                throw new UserException(res.Error);
        }

        public async Task<User> GetMe()
        {
            var res = await req.GetAsync("GetMe");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<User>(res.Data.ToString());
            
            else
                throw new UserException(res.Error);
        }
    }
}