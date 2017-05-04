using System.Linq;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class UserController : Controller
    {
        private readonly UsersContext _db = new UsersContext();

        [HttpGet]
        public ActionResult Get()
        {
            var users = _db.Users;
            if (!users.Any())
            {
                _db.Users.Add(new User { Name = "Саша", City = "Киев", Age = 18 });
                _db.Users.Add(new User { Name = "Аня", City = "Львів", Age = 25 });
                _db.Users.Add(new User { Name = "Віка", City = "Харьків", Age = 22 });
                _db.Users.Add(new User { Name = "Ігор", City = "Киев", Age = 40 });
                _db.Users.Add(new User { Name = "Ваня", City = "Львів", Age = 16 });
                _db.SaveChanges();
            }
            return View(users);
        }

        [HttpPost]
        public ActionResult Get(string searchParam, SortType sortType)
        {
            IQueryable<User> users = from s in _db.Users select s;

            if (!string.IsNullOrEmpty(searchParam))
            {
                users = users.Where(s => s.City.Equals(searchParam));
            }

            switch (sortType)
            {
                case SortType.Desk:
                    users = users.OrderByDescending(s => s.Age);
                    break;
                case SortType.Ask:
                    users = users.OrderBy(s => s.Age);
                    break;
            }

            return PartialView("User", users);
        }
    }

    public enum SortType
    {
        None = 0,
        Ask = 1,
        Desk = 2
    }
}
