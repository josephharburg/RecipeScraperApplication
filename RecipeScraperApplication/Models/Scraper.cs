using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RecipeScraperApplication.Models
{
    public class Scraper
    {

        public ScraperModel scrapeData(string page)
        {
            ScraperModel s = new ScraperModel();
            var web = new HtmlWeb();
            var doc = web.Load(page);

            var inst_ul = doc.DocumentNode.SelectSingleNode("//div[contains(@*, 'instr')]/ul");
            var inst_ol = doc.DocumentNode.SelectSingleNode("//div[contains(@*, 'instr')]/ol");
            var ingredients = doc.DocumentNode.SelectNodes("//div[contains(@*, 'ingred') ]/ul/li");

            if(inst_ul != null)
            {
                HtmlNodeCollection instr = inst_ul.ChildNodes;
                foreach (var item in instr)
                {
                    var ins = HttpUtility.HtmlDecode(item.InnerText);
                    s.Instructions.Add(ins);
                }
            }
            else
            {
                HtmlNodeCollection instru = inst_ol.ChildNodes;
                foreach (var item in instru)
                {
                    var ins = HttpUtility.HtmlDecode(item.InnerText);
                    s.Instructions.Add(ins);
                }
            }
            
            foreach (var item in ingredients)
            {
                string ingredient = HttpUtility.HtmlDecode(item.InnerText);
                s.Ingredients.Add(ingredient);
            }
            


            return s;


        }
    }
}
