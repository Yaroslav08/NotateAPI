using NotateAPI.Configure;
using System;
using System.Collections.Generic;
using System.Text;
namespace NotateAPI.Services
{
    public class CommentService
    {
        public string accessToken;
        private BaseUrl url;
        private WebRequest req;
        public CommentService(string AccessToken)
        {
            accessToken = AccessToken;
            url = new BaseUrl();
            req = new WebRequest(accessToken, url.Note);
            req.SetAccessToken(AccessToken);
        }
    }
}