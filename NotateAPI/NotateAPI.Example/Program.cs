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
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
