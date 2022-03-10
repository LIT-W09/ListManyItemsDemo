using ListManyFoodItems.Data;
using ListManyFoodItems.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ListManyFoodItems.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = "Data Source=.\\sqlexpress;Initial Catalog=SnackStore;Integrated Security=True";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(FoodItem item)
        {
            var db = new FoodItemDb(_connectionString);
            db.AddFoodItem(item);
            return Redirect("/");
        }

        public IActionResult ShowAddManyNumbers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostInts(List<int> numbers)
        {
            return Redirect("/home/showaddmanynumbers");
        }

        public IActionResult ShowAddManyFoodItems()
        {
            var vm = new ShowAddManyViewModel();
            string message = (string)TempData["Message"];
            if (!String.IsNullOrEmpty(message))
            {
                vm.Message = message;
            }
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddMultipleFoodItems(List<FoodItem> foodItems)
        {
            var db = new FoodItemDb(_connectionString);
            foreach (var item in foodItems)
            {
                db.AddFoodItem(item);
            }
            TempData["Message"] = $"{foodItems.Count} items added successfully!";
            return Redirect("/home/ShowAddManyFoodItems");
        }
    }

}

//create an mvc application that displays a list of people. On top of the list
//have a link that takes you to a page that allows the user to enter multiple
//people. When that page loads, there should be one row of textboxes (first name,
//lastname and age) with a button on top that says "Add". When Add is clicked,
//another row of textboxes should appear. Beneath those textboxes, there should
//be a submit button, that when clicked, adds all those people to the database
//and then redirects the user back to the home page.
