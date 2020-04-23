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
    public class CommentService
    {
        private string accessToken;
        private BaseUrl url;
        private WebRequest req;
        public CommentService(string AccessToken)
        {
            accessToken = AccessToken;
            url = new BaseUrl();
            req = new WebRequest(accessToken, url.Comment);
            req.SetAccessToken(AccessToken);
        }

        public async Task<List<Comment>> GetComments(long NoteId, int Offset = 0, int Count = 20)
        {
            var res = await req.GetAsync($"GetComments/{NoteId}?Offset={Offset}&Count={Count}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<List<Comment>>(res.Data.ToString());
            else
                throw new CommentException(res.Error);
        }


    }
}