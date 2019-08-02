using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using entityFramevorkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace entityFramevorkCore.Controllers
{
    public class HomeController : Controller
    {
        UserContext db = new UserContext();
        public ActionResult Index(SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<User> users = db.Users;
            @ViewBag.NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            @ViewBag.SurnameSort = sortOrder == SortState.SurnameAsc ? SortState.SurnameDesc : SortState.SurnameAsc;

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    users = users.OrderByDescending(s => s.Name);
                    break;
                case SortState.SurnameAsc:
                    users = users.OrderBy(s => s.Surname);
                    break;
                case SortState.SurnameDesc:
                    users = users.OrderByDescending(s => s.Surname);
                    break;
                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }
            ViewBag.user = users.Include(c => c.Pages).ThenInclude(sc => sc.Page).ToList();

            ViewBag.page = db.Pages.ToList();
         
            return View();
         
        }

        [HttpGet]
        public ActionResult DbInsert()
        {
            ViewBag.Pages = db.Pages.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult DbInsert(string post, string cancel, User purchase, int[] selectPages)
        {
            if (post != null)
            {
                ViewBag.Pages = db.Pages.ToList();
                List<UserPage> uslist = new List<UserPage>();
                // добавляем информацию в базу данных
                foreach (var c in db.Pages.Where(co => selectPages.Contains(co.Id)))
                { UserPage userpage = new UserPage();
                    userpage.UserId = purchase.Id;
                    userpage.PageId = c.Id;
                    userpage.Page = c;
                    userpage.User = purchase;
                    uslist.Add(userpage);
                }
                purchase.Pages = uslist;
                purchase.Phone = "+7" + purchase.Phone;
                db.Users.Add(purchase);
                // сохраняем в бд все изменения
                db.SaveChanges();

            }
            if (cancel != null)

            {
                User newUser = new User();
                newUser.Name = "Cehutq";
                newUser.Surname = "gtnhjd";
                newUser.Email = "treyy@mail.ru";
                newUser.Pages.Clear();

                //получаем выбранные курсы
                //foreach (var c in db.Pages)
                //{
                //    newUser.Pages.Add(c);
                //}
                db.Users.Add(newUser);
                //db.Entry(newUser).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.user = db.Users.ToList();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Dbredact(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            User book = db.Users.Find(id);
            if (book != null)
            {
                ViewBag.Pages = db.Pages.Include(c=>c.Users).ThenInclude(sc => sc.User).ToList();
                
                List<int> t = new List<int>();
                foreach (var f in db.Users.Include(c => c.Pages).ThenInclude(sc => sc.Page).Where(x=>x.Id == id).ToList())
                {
                    foreach (var c in f.Pages)
                    {
                       t.Add(c.PageId);
                    }
                }
                ViewBag.User = t;

                return View(book);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Dbredact(User user, int[] selectPages)
        {
            List<UserPage> uslist = new List<UserPage>();
            var userihg = db.Users.Include(c => c.Pages).ThenInclude(sc => sc.Page).FirstOrDefault(x => x.Id == user.Id);
            userihg.Pages.Clear();
       
            db.SaveChanges();
            User newUser = db.Users.Find(user.Id);
            newUser.Name = user.Name;
            newUser.Surname = user.Surname;
            newUser.Email = user.Email;
            newUser.Phone = user.Phone;
            newUser.Pages.Clear();
            if (selectPages != null)
            {
        
                foreach (var c in db.Pages.Where(co => selectPages.Contains(co.Id)))
                {
                    UserPage userpage = new UserPage();
                    userpage.UserId = newUser.Id;
                    userpage.PageId = c.Id;
                    userpage.Page = c;
                    userpage.User = newUser;
                    uslist.Add(userpage);
                    
                }
                newUser.Pages= uslist;
                
            }
            //db.Entry(newUser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            User b = db.Users.Find(id);
            if (b != null)
            {
                db.Users.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
