using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.IO;
using System.Net;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Management;
using xNet;
using Newtonsoft.Json;

namespace AnoncitySniper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "AnoncitySniper - Anon.city file scraper - cracked.to/Zekh";
            var Zekh = new string[]
            {
@"
		██      ▄   ████▄    ▄   ▄█▄    ▄█    ▄▄▄▄▀ ▀▄    ▄  ▄▄▄▄▄    ▄   ▄█ █ ▄▄  ▄███▄   █▄▄▄▄ 
		█ █      █  █   █     █  █▀ ▀▄  ██ ▀▀▀ █      █  █  █     ▀▄   █  ██ █   █ █▀   ▀  █  ▄▀ 
		█▄▄█ ██   █ █   █ ██   █ █   ▀  ██     █       ▀█ ▄  ▀▀▀▀▄ ██   █ ██ █▀▀▀  ██▄▄    █▀▀▌  
		█  █ █ █  █ ▀████ █ █  █ █▄  ▄▀ ▐█    █        █   ▀▄▄▄▄▀  █ █  █ ▐█ █     █▄   ▄▀ █  █  
		   █ █  █ █       █  █ █ ▀███▀   ▐   ▀       ▄▀            █  █ █  ▐  █    ▀███▀     █   
		  █  █   ██       █   ██                                   █   ██      ▀            ▀    
		 ▀     
					           cracked.to/Zekh
",
            };
			foreach (string line in Zekh) { Console.WriteLine(line, Color.DarkSlateBlue); }
			Console.WriteLine();
            Console.WriteLine("> Enter your keyword :");
			string resp = Console.ReadLine();
			int count = 0;
			List<string> Links = new List<string>();
			using (WebClient wc = new WebClient())
			{
				string s = wc.DownloadString("https://www.google.com/search?q=site:anon.city+" + resp);
				Regex r = new Regex(@"https:\/\/anon.city\/\w+\/\w+");
				foreach (Match m in r.Matches(s))
				{
					count++;
					Links.Add(m.ToString());
				}
			}

			using (TextWriter tw = new StreamWriter(@"links.txt"))
			{
				foreach (string line in Links)
				{
					tw.WriteLine(line.ToString());
				}
			}

			Console.WriteLine();
			Console.WriteLine("Scraped " + count.ToString() + " links!");
			Console.ReadLine();
		}
    }
}
