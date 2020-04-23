using Newtonsoft.Json;
using NotateAPI.Configure;
using NotateAPI.Exceptions;
using NotateAPI.Models.Entity;
using NotateAPI.Models.Helpers.CommentService;
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

        public async Task<string> CreateComment(string Text, long NoteId)
        {
            var res = await req.PostAsync("Create", new CreateCommentModel { NoteId = NoteId, Text = Text });
            if (res.IsSuccess)
                return "OK";
            else
                throw new CommentException(res.Error);
        }

        public async Task<string> EditComment(EditCommentModel model)
        {
            var res = await req.PutAsync("Edit", model);
            if (res.IsSuccess)
                return "OK";
            else
                throw new CommentException(res.Error);
        }

        public async Task<string> DeleteComment(DeleteCommentModel model)
        {
            var res = await req.DeleteAsync("Delete", model);
            if (res.IsSuccess)
                return "OK";
            else
                throw new CommentException(res.Error);
        }
    }
}