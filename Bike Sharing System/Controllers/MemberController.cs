using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bike_Sharing_System.Models;
using Bike_Sharing_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bike_Sharing_System.Controllers
{
    public class MemberController: Controller
    {
        private readonly MemberService _memberService;

        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }

        public IActionResult SignIn() => View();

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            var member = _memberService.GetMemberByEmail(email);
            if (member != null && member.Password == password)
            {
                HttpContext.Session.SetString("UserId", member.Id);
                return RedirectToAction("Dashboard");
            }
            ViewBag.Error = "Invalid credentials";
            return View();
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(Member member)
        {
            _memberService.Register(member);
            return RedirectToAction("SignIn");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }
    }
}