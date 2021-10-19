using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System;

namespace webapp
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://en.wikipedia.org/wiki/The_Beatles");

            var HeaderNames = doc.DocumentNode.SelectNodes("//span[@class='toctext']");

            var titles = new List<Row>();
            foreach (var item in HeaderNames)
            {
                titles.Add(new Row { Title = item.InnerText });
            }
            using (var writer = new StreamWriter("C:/Users/hanna/OneDrive/Desktop/Code/example.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(titles);
            }
        }

        public class Row
        {
            public string Title { get; set; }
        }
    }
}
