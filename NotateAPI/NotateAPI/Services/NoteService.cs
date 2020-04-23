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
        private string accessToken;
        private BaseUrl url;
        private WebRequest req;
        public NoteService(string AccessToken)
        {
            accessToken = AccessToken;
            url = new BaseUrl();
            req = new WebRequest(accessToken, url.Note);
            req.SetAccessToken(AccessToken);
        }

        public async Task<string> CreateNoteAsync(CreateNoteModel model)
        {
            var res = await req.PostAsync("Create", model);
            if (res.IsSuccess)
                return "OK";
            else
                throw new NoteException(res.Error);
        }

        public async Task<string> DeleteNoteAsync(long NoteId)
        {
            var res = await req.DeleteAsync("Delete", new DeleteNoteModel { NoteId = NoteId });
            if (res.IsSuccess)
                return "OK";
            else
                throw new NoteException(res.Error);
        }

        public async Task<string> EditNoteAsync(EditNoteModel model)
        {
            var res = await req.PutAsync("Edit", model);
            if (res.IsSuccess)
                return "OK";
            else
                throw new NoteException(res.Error);
        }

        public async Task<List<Note>> GetByHeaderAsync(string Header, int Offset = 0, int Count = 20)
        {
            var res = await req.GetAsync($"GetByHeader/{Header}?Offset={Offset}&Count={Count}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<List<Note>>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }

        public async Task<List<Note>> GetByTextAsync(string Text, int Offset = 0, int Count = 20)
        {
            var res = await req.GetAsync($"GetByText/{Text}?Offset={Offset}&Count={Count}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<List<Note>>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }

        public async Task<Note> GetByIdAsync(long Id)
        {
            var res = await req.GetAsync($"{Id}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<Note>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }

        public async Task<Note> GetPrivateAsync(long Id, string Key)
        {
            var res = await req.GetAsync($"GetPrivate/{Id}/{Key}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<Note>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }

        public async Task<List<Note>> GetUserNotesAsync(int UserId, int Offset = 0, int Count = 20)
        {
            var res = await req.GetAsync($"GetUserNotes/{UserId}?Offset={Offset}&Count={Count}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<List<Note>>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }

        public async Task<List<Note>> GetMyNotesAsync(bool All, int Offset = 0, int Count = 20)
        {
            var res = await req.GetAsync($"GetMy/{All}?Offset={Offset}&Count={Count}");
            if (res.IsSuccess)
                return JsonConvert.DeserializeObject<List<Note>>(res.Data.ToString());
            else
                throw new NoteException(res.Error);
        }
    }
}