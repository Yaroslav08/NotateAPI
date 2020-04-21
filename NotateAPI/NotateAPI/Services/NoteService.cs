using Newtonsoft.Json;
using NotateAPI.Configure;
using NotateAPI.Exceptions;
using NotateAPI.Models.Entity;
using NotateAPI.Models.Helpers.NoteService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotateAPI.Services
{
    public class NoteService
    {
        public string accessToken;
        private BaseUrl url;
        private WebRequest req;
        public NoteService(string AccessToken)
        {
            accessToken = AccessToken;
            url = new BaseUrl();
            req = new WebRequest(accessToken, url.Note);
            req.SetAccessToken(AccessToken);
        }

        public async Task<string> CreateNote(CreateNoteModel model)
        {
            var res = await req.PostAsync("Create", model);
            if (res.IsSuccess)
                return "OK";
            else
                throw new NoteException(res.Error);
        }

        public async Task<string> DeleteNote(CreateNoteModel model)
        {
            var res = await req.DeleteAsync("Delete", model);
            if (res.IsSuccess)
                return "OK";
            else
                throw new NoteException(res.Error);
        }

        public async Task<string> EditNote(EditNoteModel model)
        {
            var res = await req.PutAsync("Edit", model);
            if (res.IsSuccess)
                return "OK";
            else
                throw new NoteException(res.Error);
        }

        public async Task<List<Note>> GetByHeader(string Header, int Offset = 0, int Count = 20)
        {
            var res = await req.GetAsync($"GetByHeader/{Header}?Offset={Offset}&Count={Count}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<List<Note>>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }

        public async Task<List<Note>> GetByText(string Text, int Offset = 0, int Count = 20)
        {
            var res = await req.GetAsync($"GetByText/{Text}?Offset={Offset}&Count={Count}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<List<Note>>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }

        public async Task<Note> GetById(long Id)
        {
            var res = await req.GetAsync($"{Id}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<Note>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }

        public async Task<Note> GetPrivate(long Id, string Key)
        {
            var res = await req.GetAsync($"GetPrivate/{Id}/{Key}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<Note>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }

        public async Task<List<Note>> GetUserNotes(int UserId, int Offset = 0, int Count = 20)
        {
            var res = await req.GetAsync($"GetUserNotes/{UserId}?Offset={Offset}&Count={Count}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<List<Note>>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }

        public async Task<List<Note>> GetMyNotes(bool All, int Offset = 0, int Count = 20)
        {
            var res = await req.GetAsync($"GetMy/{All}?Offset={Offset}&Count={Count}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<List<Note>>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }
    }
}