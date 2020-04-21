using NotateAPI.Configure;
using NotateAPI.Exceptions;
using NotateAPI.Models.Entity;
using NotateAPI.Models.Helpers.UserService;
using NotateAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotateAPI
{
    public class NotateClient
    {
        private static NotateClient notateClient;
        private string accessToken;
        private bool isAuthorize;
        private UserService userService;
        private NoteService noteService;
        private CommentService commentService;
        private BaseUrl url;
        private WebRequest req;
        private User user;

        public UserService UserService
        {
            get
            {
                if (isAuthorize)
                    return userService;
                else
                    throw new APIAuthException("Need auth");
            }
        }
        public NoteService NoteService
        {
            get
            {
                if (isAuthorize)
                    return noteService;
                else
                    throw new APIAuthException("Need auth");
            }
        }
        public CommentService CommentService
        {
            get
            {
                if (isAuthorize)
                    return commentService;
                else
                    throw new APIAuthException("Need auth");
            }
        }

        public bool IsAuthorize => isAuthorize;
        public string AccessToken => accessToken;
        public User User => user;

        public static NotateClient Instance()
        {
            if (notateClient == null)
            {
                notateClient = new NotateClient();
            }
            return notateClient;
        }
        private NotateClient()
        {
            isAuthorize = false;
            accessToken = null;
            url = new BaseUrl();
            req = new WebRequest(null, url.User);
        }

        public async Task Auth(string Login, string Password)
        {
            await Auth(new LoginModel(Login, Password));
        }

        public async Task Auth(LoginModel model)
        {
            var res = await req.PostAsync("auth", model);
            if (res.IsSuccess)
            {
                accessToken = res.Message;
                req.SetAccessToken(accessToken);
                isAuthorize = true;
                userService = new UserService(accessToken);
                noteService = new NoteService(accessToken);
                commentService = new CommentService(accessToken);
            }
            else
                throw new APIAuthException(res.Error);
        }

        public void Auth(string AccessToken)
        {
            accessToken = AccessToken;
            req.SetAccessToken(accessToken);
            isAuthorize = true;
            userService = new UserService(accessToken);
            noteService = new NoteService(accessToken);
            commentService = new CommentService(accessToken);
        }

        public async Task<bool> Register(string Fullname, string Login, string Password)
        {
            return await Register(new RegisterModel(Fullname, Login, Password));
        }

        public async Task<bool> Register(RegisterModel model)
        {
            var res = await req.PostAsync("Register", model);
            if (res.IsSuccess)
                return res.IsSuccess;
            else
                throw new APIAuthException(res.Error);
        }
    }
}