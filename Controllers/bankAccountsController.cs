using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bankAccounts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace bankAccounts.Controllers
{
    public class bankAccountsController : Controller
    {
       private bankAccountsContext _context;

public bankAccountsController(bankAccountsContext context)
{
 _context = context;

} 
[HttpGet]
[Route("")]
        public IActionResult Index()
        {
            return View();
        }
public IActionResult addUser(UserViewModel user){
            if(ModelState.IsValid){
            PasswordHasher<UserViewModel> Hasher = new PasswordHasher<UserViewModel>();
                user.password = Hasher.HashPassword(user, user.password);
                User newUser = new User{
                    firstName = user.firstName,
                    lastName = user.lastName,
                    email = user.email,
                    password = user.password,
                    balance = 0,
                };
                _context.Add(newUser);
                _context.SaveChanges();
                newUser = _context.users.SingleOrDefault(u => u.email == newUser.email);
                HttpContext.Session.SetInt32("id", newUser.userId);
                return RedirectToAction("viewAccount", new {id = HttpContext.Session.GetInt32("id")});
            }
            return View("Index");
        }
             public IActionResult Haveaccnt(){
                return View("login");
            }
            public IActionResult Login(loginViewModel user){
                if(ModelState.IsValid){
                    User oneUser = _context.users.SingleOrDefault(u => u.email == user.email);
                    if(user.email != null && user.password != null){
                        var Hasher = new PasswordHasher<loginViewModel>();
                        if(0 != Hasher.VerifyHashedPassword(user, oneUser.password, user.password)){
                        HttpContext.Session.SetInt32("id", oneUser.userId);
                        return RedirectToAction("viewAccount", new {id = HttpContext.Session.GetInt32("id")});
                        }
                    }
                }
                    return View("login");
            }
         
            public IActionResult viewAccount(int id){
                if(HttpContext.Session.GetInt32("id") == null){
                    return RedirectToAction("Index");
                }
                if(id != (int) HttpContext.Session.GetInt32("id")){
                    HttpContext.Session.Clear();
                    return RedirectToAction("Index");
                }
                User singleUser = _context.users.Include(u => u.Transactions).SingleOrDefault(u => u.userId == id);
                ViewBag.singleUser = singleUser;
                return View("account");
        }
        public IActionResult Transact(Transaction transaction){
          
            if(ModelState.IsValid){
            User user = _context.users.Include(u => u.Transactions).SingleOrDefault(u => u.userId == (int)HttpContext.Session.GetInt32("id"));
            if((user.balance + transaction.amount) >= 0){
                Transaction newTrans = new Transaction{
                    amount = transaction.amount,
                    userId = user.userId,
                    createdAt = DateTime.Now,

                };
                user.balance += newTrans.amount;
                _context.Transactions.Add(newTrans);
                _context.SaveChanges();
                return RedirectToAction("viewAccount", new {id = HttpContext.Session.GetInt32("id")});
                }
            }
            return RedirectToAction("viewAccount", new {id = HttpContext.Session.GetInt32("id")});
        }  
    }
}