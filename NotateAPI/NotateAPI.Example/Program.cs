using NotateAPI.Models.Entity;
using NotateAPI.Models.Helpers.NoteService;
using NotateAPI.Models.Helpers.UserService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotateAPI.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string Login = "yaroslav.mudryk@gmail.com", Pass = "TestPass1234", Fullname = "Yaroslav Mudryk";
                NotateClient client = NotateClient.Instance();
                //var res1 = await client.RegisterAsync(Fullname, Login, Pass);
                //var res2 = await client.ConfirmAsync(new Models.Helpers.UserService.ConfirmModel { Login = Login, Code = "12345" });
                await client.AuthAsync(Login, Pass);
                if (!client.IsAuthorize) return;
                await Test(client, Fullname);
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        static async Task Test(NotateClient client, string Name)
        {
            string UsernameToEdit = "Yaroslav_M";
            //User user = await client.UserService.GetUserAsync(1);
            //var res1 = await client.UserService.EditAsync(new UserEditModel { About = "Test about text", FullName = user.FullName });
            //var res2 = await client.UserService.EditUsernameAsync(UsernameToEdit);
            //User user1 = await client.UserService.GetUserAsync(UsernameToEdit);
            //List<UserShortModel> users = await client.UserService.SearchUsersAsync(Name);
            var res3 = await client.NoteService.CreateNoteAsync(new CreateNoteModel("Testing", "Notate"));
            var note = await client.NoteService.GetByIdAsync(1);
            var notH = await client.NoteService.GetByHeaderAsync("Testing");
            var notT = await client.NoteService.GetByTextAsync("Notate");
            var my = await client.NoteService.GetMyNotesAsync(true);
            var res4 = await client.NoteService.EditNoteAsync(new EditNoteModel { Header = "Notate", Text = "Testing", Id = note.Id });
            var res5 = await client.CommentService.CreateCommentAsync("Cool", note.Id);
            var comm = await client.CommentService.GetCommentsAsync(note.Id);
            var res6 = await client.CommentService.EditCommentAsync(new Models.Helpers.CommentService.EditCommentModel { CommentId = 1, Text = "Now" });
            var res7 = await client.CommentService.DeleteCommentAsync(new Models.Helpers.CommentService.DeleteCommentModel { CommentId = 1 });
            var res8 = await client.NoteService.DeleteNoteAsync(1);
            var res10 = await client.UserService.DeleteMyAccountAsync();
        }
    }
}
