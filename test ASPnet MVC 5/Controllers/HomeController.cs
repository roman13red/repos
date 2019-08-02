using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_ASPnet_MVC_5.Models;

namespace test_ASPnet_MVC_5.Controllers
{
    public class HomeController : Controller
    {
        UserContext db = new UserContext();

       
        public async Task<ActionResult> Index(SortState sortOrder = SortState.NameAsc)
        {IQueryable<User> users = db.Users;
            // получаем из бд все объекты Book
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
            @ViewBag.user = await users.AsNoTracking().ToListAsync();
   
            return View();
       
          
        }
        [HttpPost]
        public ActionResult Index()
        {
            User newUser = new User();
            newUser.Name = "Cehutq";
            newUser.Surname = "gtnhjd";
            newUser.email = "treyy@mail.ru";
            newUser.Pages.Clear();

            //получаем выбранные курсы
            foreach (var c in db.Pages)
            {
                newUser.Pages.Add(c);
            }
            db.Users.Add(newUser);
            //db.Entry(newUser).State = EntityState.Modified;
            db.SaveChanges();
            @ViewBag.user = db.Users.ToList();
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

                // добавляем информацию в базу данных
                foreach (var c in db.Pages.Where(co => selectPages.Contains(co.Id)))
                {
                    purchase.Pages.Add(c);
                }
                db.Users.Add(purchase);
                // сохраняем в бд все изменения
                db.SaveChanges();
               
            }
            if (cancel != null)

            {
                User newUser = new User();
                newUser.Name = "Cehutq";
                newUser.Surname = "gtnhjd";
                newUser.email = "treyy@mail.ru";
                newUser.Pages.Clear();

                //получаем выбранные курсы
                foreach (var c in db.Pages)
                {
                    newUser.Pages.Add(c);
                }
                db.Users.Add(newUser);
                //db.Entry(newUser).State = EntityState.Modified;
                db.SaveChanges();
                @ViewBag.user = db.Users.ToList();
            }
            return RedirectToAction("Index");
        }

 
     
        [HttpGet]
        public ActionResult Dbredact(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            User book = db.Users.Find(id);
            if (book != null)
            {
                ViewBag.Pages= db.Pages.ToList();
                return View(book);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Dbredact(User user,int[] selectPages)
        {
            User newUser = db.Users.Find(user.Id);
            newUser.Name = user.Name;
            newUser.Surname = user.Surname;
            newUser.email = user.email;
            newUser.Pages.Clear();
            if (selectPages != null)
            {
                //получаем выбранные курсы
                foreach (var c in db.Pages.Where(co => selectPages.Contains(co.Id)))
                {
                    newUser.Pages.Add(c);
                }
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