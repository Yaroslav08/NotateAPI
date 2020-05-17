using NotateAPI.Configure;
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
    }
}