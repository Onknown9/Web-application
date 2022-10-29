using Microsoft.AspNetCore.Mvc;
using project.Models;
using System.Diagnostics;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        DBWork storage = new DBWork();
        NewProductForDB product = new NewProductForDB();

        public IActionResult Index()
        {
            List newList = storage.GetInfo();
            int hour = DateTime.Now.Hour;
            if (hour > 12)
            {
                ViewBag.Greeting = "Добрый вечер";
            }
            else
            {
                ViewBag.Greetings = "Добрый день";
            }
            return View(newList);
        }
        [HttpPost]
        public ViewResult NewProduct(NewProductForDB response)
        {
            Console.WriteLine(response.Answer);
            if (response.Answer == 1)
            {
                if (response != null)
                    {
                        try
                        {
                            ViewBag.Greeting = "Товар удален";
                            response.RemoveFromDB();
                            return View("Succes");

                        }
                        catch
                    {
                        response.RemoveFromDB();
                        return View("Succes");

                        }
                    }
                    else
                    {
                        return View();
                    }
            }
            if (response.Answer == 2)
            {
                if(response != null)
                {
                    try
                    {
                        ViewBag.Greeting = "Цена изменена";
                        response.Update();
                        return View("Succes");
                    }
                    catch
                    {
                        return View();
                    }

                }
                else
                {
                    return View();
                }
            }
            else
            {
                if (response == null)
                {
                    return View();
                }
                else
                {
                    try
                    {
                        ViewBag.Greeting = "Товар добавлен";
                        response.addToDB();
                        return View("Succes");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
        }
    }
}