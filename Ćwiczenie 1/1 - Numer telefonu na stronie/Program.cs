using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1___Numer_telefonu_na_stronie
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string website;
            Console.WriteLine("Podaj adres strony internetowej, lub zostaw domyślny aby wyszukać numery na stronie uczelni.");
            website = Console.ReadLine();
            if(string.IsNullOrEmpty(website))
            {
                website = @"https://pja.edu.pl/";
            }

            Console.WriteLine("Wybrano stronę: " + website);

            HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(website);
                string pageContent = await response.Content.ReadAsStringAsync();

                /*
                 * 
                 */
                string RegEx = @"\+48\s[0-9]{2}\s[0-9]{2}\s[0-9]{2}\s[0-9]{3}|" +
                                   @"\+48\s[0-9]{3}\s[0-9]{3}\s[0-9]{3}|\+48\s[0-9]{9}|" +
                                    @"[0-9]{2}\s[0-9]{3}\s[0-9]{2}\s[0-9]{2}|" +
                                    @"[0-9]{2}\s[0-9]{2}\s[0-9]{3}\s[0-9]{2}";

                MatchCollection phoneNumbersInPage = Regex.Matches(pageContent, RegEx);

                Console.WriteLine("Znalezione numery: ");

                foreach (var phoneNumber in phoneNumbersInPage)
                {
                    Console.WriteLine(phoneNumber);
                }


            } catch (Exception)
            {
                Console.WriteLine("Podana strona jest nieprawidłowa!");
            }
        }
    }
}
