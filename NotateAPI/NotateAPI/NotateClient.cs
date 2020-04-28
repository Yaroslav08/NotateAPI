using Newtonsoft.Json;
using NotateAPI.Configure;
using NotateAPI.Exceptions;
using NotateAPI.Models.Entity;
using NotateAPI.Models.Helpers.UserService;
using NotateAPI.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
        private int id;

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
        public int Id => id;

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
        public NotateClient(string AccessToken)
        {
            isAuthorize = true;
            accessToken = AccessToken;
            url = new BaseUrl();
            req = new WebRequest(null, url.User);
            userService = new UserService(accessToken);
            noteService = new NoteService(accessToken);
            commentService = new CommentService(accessToken);
        }

        public async Task AuthAsync(string Login, string Password)
        {
            await AuthAsync(new LoginModel(Login, Password));
        }

        public async Task AuthAsync(LoginModel model)
        {
            if (!await IsAvailable())
                throw new UserException("Server isn`t available");
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

        public async Task<bool> RegisterAsync(string Fullname, string Login, string Password)
        {
            return await RegisterAsync(new RegisterModel(Fullname, Login, Password));
        }

        public async Task<bool> RegisterAsync(RegisterModel model)
        {
            var res = await req.PostAsync("Register", model);
            if (res.IsSuccess)
                return res.IsSuccess;
            else
                throw new APIAuthException(res.Error);
        }

        public async Task<bool> ConfirmAsync(ConfirmModel model)
        {
            var res = await req.PostAsync("Confirm", model);
            if (res.IsSuccess)
                return true;
            else
                throw new APIAuthException(res.Error);
        }

        public async Task<User> LoadProfile()
        {
            var res = await req.GetAsync("GetMe");
            if (res.IsSuccess)
            {
                user = JsonConvert.DeserializeObject<User>(res.Data.ToString());
                return user;
            }
            else
                throw new UserException(res.Error);
        }

        private async Task<bool> IsAvailable()
        {
            try
            {
                var client = new HttpClient();
                var res = await client.GetAsync($"{url.User}Test");
                if (await res.Content.ReadAsStringAsync() == "Connection completed successfully!")
                    return true;
                else
                    return false;
            } catch(Exception ex)
            {
                if (ex.Message == "No connection could be made because the target machine actively refused it.") return false;
                return false;
            }
        }
    }
}