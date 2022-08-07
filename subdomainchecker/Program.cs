using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace subdomainchecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Atomo -> Subdomain Checker";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
███████╗██╗   ██╗██████╗ ██████╗  ██████╗ ███╗   ███╗ █████╗ ██╗███╗   ██╗
██╔════╝██║   ██║██╔══██╗██╔══██╗██╔═══██╗████╗ ████║██╔══██╗██║████╗  ██║
███████╗██║   ██║██████╔╝██║  ██║██║   ██║██╔████╔██║███████║██║██╔██╗ ██║
╚════██║██║   ██║██╔══██╗██║  ██║██║   ██║██║╚██╔╝██║██╔══██║██║██║╚██╗██║
███████║╚██████╔╝██████╔╝██████╔╝╚██████╔╝██║ ╚═╝ ██║██║  ██║██║██║ ╚████║
╚══════╝ ╚═════╝ ╚═════╝ ╚═════╝  ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝
                                                                          
         ██████╗██╗  ██╗███████╗ ██████╗██╗  ██╗███████╗██████╗           
        ██╔════╝██║  ██║██╔════╝██╔════╝██║ ██╔╝██╔════╝██╔══██╗          
        ██║     ███████║█████╗  ██║     █████╔╝ █████╗  ██████╔╝          
        ██║     ██╔══██║██╔══╝  ██║     ██╔═██╗ ██╔══╝  ██╔══██╗          
        ╚██████╗██║  ██║███████╗╚██████╗██║  ██╗███████╗██║  ██║          
         ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝          
                                                                          
Telegram: @Mahitozin
Github: https://github.com/Mahitozin

-=- Exemple-=-
Base url -> https://google.com/
WordList -> list.txt
");

            Console.ResetColor();

            string site = input("Base url -> ");
            string wordlist = input("WordList -> ");
           
            foreach(string x in File.ReadAllLines(wordlist))
            {
                check(site+x);
            }

            Console.ReadLine();
        }

        static void check(string url)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);


                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

                log($"[Url -> {url}] [Status -> {(int)httpResponse.StatusCode}]", ConsoleColor.DarkGreen);
            }
            catch (WebException ex)
            {
                log($"[Url -> {url}] [Status -> {(int)((HttpWebResponse)ex.Response).StatusCode}]", ConsoleColor.DarkRed);
            }
            catch(Exception ex)
            {
                log($"Invalid Url", ConsoleColor.DarkRed);
            }
        }

        static string input(string msg)
        {
            ConsoleColor cb = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"[{DateTime.Now.ToString("hh:mm:ss")}] ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(msg);
            Console.ForegroundColor = cb;

            return Console.ReadLine();
        }

        static void log(string msg, ConsoleColor cor)
        {
            ConsoleColor cb = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"[{DateTime.Now.ToString("hh:mm:ss")}] ");
            Console.ForegroundColor = cor;
            Console.WriteLine(msg);
            Console.ForegroundColor = cb;
        }
    }
}
