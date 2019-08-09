using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using books.Models;

namespace books.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        [HttpGet]
        public ActionResult Index(string oldSearcrButton,  string Search, int sorTest,int lastsortorder, int sortorder = 0,int min = 0,int max = 25, string OldSearch="0", string searcrButton = "0" )
        {
           
            IQueryable<Book> books = db.Books;
            if (searcrButton == "0")
            {
                Search = OldSearch;
                searcrButton = oldSearcrButton;
            }
            @ViewBag.Search = Search;
            @ViewBag.searcrButton = searcrButton;

            if (sortorder == 0)
            {
                @ViewBag.NameSort = sorTest;
                sortorder = lastsortorder;
            }
            else if (sorTest != sortorder)
            {
                @ViewBag.NameSort = sortorder;
            }
            else @ViewBag.NameSort = sorTest + sortorder;
            int x = (int)@ViewBag.NameSort % 2;
            @ViewBag.sortorder = sortorder;
            switch (sortorder)
            {
                case 1:
                    if (x == 0)
                    {
                         books = books.OrderBy(s => s.NameBook);
                    }
                    else books = books.OrderByDescending(s => s.NameBook);
                    break;
                case 3:
                    if (x == 0)
                    {
                        books = books.OrderBy(s => s.Date);
                    }
                    else books = books.OrderByDescending(s => s.Date);
                    break;
                case 5:
                    if (x == 0)
                    {
                        books = books.OrderBy(s => s.Blook);
                    }
                    else books = books.OrderByDescending(s => s.Blook);
                    break;
                case 7:
                    if (x == 0)
                    {
                        books = books.OrderBy(s => s.Count);
                    }
                    else books = books.OrderByDescending(s => s.Count);
                    break;
                case 9:
                    if (x == 0)
                    {
                        books = books.OrderBy(s => s.Price);
                    }
                    else books = books.OrderByDescending(s => s.Price);
                    break;
                case 11:
                    if (x == 0)
                    {
                        books = books.OrderBy(s => s.Ok);
                    }
                    else books = books.OrderByDescending(s => s.Ok);
                    break;
                case 13:
                    if (x == 0)
                    {
                        books = books.OrderBy(s => s.Id);
                    }
                    else books = books.OrderByDescending(s => s.Id);
                    break;
                default:
                    books = books.OrderBy(s => s.Id);
                    break;
                
            }

            
            Search = Search.ToLower();
            var searchMas= Search.Split(new char[] { ' ' });
           
            switch (searcrButton)
            {
                case "Id":
                    books = books.Where(s => s.Id.ToString() == Search);
                    break;
                case "NameBook":
                    books = books.Where(s => s.NameBook.ToLower().IndexOf(Search) == 0);
                    break;
                case "Date":
                    if (searchMas.Count() <= 1)
                    {
                        books = books.Where(s => s.Date == DateTime.Parse(Search));
                    }
                    else
                    {
                        books = books.Where(s => s.Date >= DateTime.Parse(searchMas[0])& s.Date <= DateTime.Parse(searchMas[1]));
                    }
                        break;
                case "Blook":
                    books = books.Where(s => s.Blook.ToString() == Search);
                    break;
                case "Count":
                    books = books.Where(s => s.Count == int.Parse(Search));
                    break;
                case "Price":
                    if (searchMas.Count() <= 1)
                    {
                        books = books.Where(s => s.Price.ToString().IndexOf(Search) == 0);
                    }
                    else
                    {
                        
                        books = books.Where(s => s.Price >= float.Parse(searchMas[0]) & s.Price <= float.Parse(searchMas[1]));
                    }
                    break;
                case "Ok":
                    books = books.Where(s => s.Ok == bool.Parse(Search));
                    break;
            }
           

            @ViewBag.min = min;
            @ViewBag.max = max;
           
            var countBook = books.Count();
            if (max < 25)
            {
                min = 0;
                max = 25;
            }
            else if(max> countBook)
            {
                max = countBook;
                

            }
            @ViewBag.Count = countBook / 25;
            if (countBook % 25 != 0)
            {
                @ViewBag.Count = @ViewBag.Count + 1;
            };
            books = books.Take(max).Skip(min);
            
            return View(books);
        }

        



    }
}
