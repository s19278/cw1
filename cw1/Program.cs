using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int? tmp = 1;
            //string tmps = "aaa";
            //string tmps2 = "bbb";
            //var tmpv = 1;
            //Console.WriteLine(tmps + tmps2);
            //Console.WriteLine($"(tmps) (tmps2)");
            //var newPerson = new Person { FirstName = "Damian"};

            var httpClient = new HttpClient();
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";

            var reponse = await httpClient.GetAsync(url);

            if (reponse.IsSuccessStatusCode) {
                var htmlContent = await reponse.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches) {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}
