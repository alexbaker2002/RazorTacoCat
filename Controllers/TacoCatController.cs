using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorTacoCat.Models;

namespace RazorTacoCat.Controllers
{
    public class TacoCatController : Controller
    {
        [HttpPost]
        public IActionResult Index(TacoCatModel tcmodel)
        {
            
            string rev = "";
            string usr = Regex.Replace(tcmodel.UserInput.ToLower(), "[^0-9a-zA-Z]+", "") ;
            if(usr.Length < 2)
            {
                tcmodel.Result = "You must type in more than two characters";
                tcmodel.IsPalindrome = false;
                return View(tcmodel);
            }

            foreach (var c in usr)
            {
                rev += c;
            }

            tcmodel.Result = rev;
            if (String.Equals(rev,usr))
            {
                tcmodel.IsPalindrome = true;
            }

            return View(tcmodel);

        }
        
        public IActionResult Index()
        {
            TacoCatModel model = new();

            

            return View(model);
        }
    }
}