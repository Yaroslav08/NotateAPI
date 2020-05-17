using System;
using System.Collections.Generic;
using System.Text;
namespace NotateAPI.Configure
{
    public class BaseUrl
    {
        private const string LocalHost = "https://localhost:5001/api";
        private const string Server = "https://api.notate.com/api";

        private string UserUrl;
        private string NoteUrl;
        private string CommentUrl;
        private string SpreadUrl;

        public BaseUrl()
        {
            UserUrl = $"{LocalHost}/user/";
            NoteUrl = $"{LocalHost}/note/";
            CommentUrl = $"{LocalHost}/comment/";
            SpreadUrl = $"{LocalHost}/spread/";
        }

        public string User => UserUrl;
        public string Note => NoteUrl;
        public string Comment => CommentUrl;
        public string Spread => SpreadUrl;
    }
}