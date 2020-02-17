using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RecipeScraperApplication.Models
{
    public class ScraperModel
    {
        public string Title { get; set; }
        public List<string> Ingredients = new List<string>();

        public List<string> Instructions = new List<string>();
    }
   


    
}
