using System;
using System.Threading.Tasks;

namespace NotateAPI.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            NotateClient client = NotateClient.Instance();
        }
    }
}
