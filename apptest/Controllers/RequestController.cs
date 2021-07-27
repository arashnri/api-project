using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apptest.Models;

namespace apptest.Controllers
{
    public class RequestController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetRequest_Addkala1(string name,int price)
        {
            KalaController kala = new KalaController();
            kala.insertkal(name, price);
            return Ok(kala);
        }
        static List<User> users = new List<User>();
        [HttpPost]
        public IHttpActionResult GetRequest_AddUser1(string name,int shomare)
        {
            UserController user = new UserController();
            user.insertuser(name,shomare);
            return Ok(user);
        }
        [HttpPost]
        public IHttpActionResult GetRequest_AddUser2(User user)
        {
            users.Add(user);
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetRequest_Showuser()
        {
            List<User> user = new List<User>();
            user = UserController.show();
            return Ok(user);
        }
        [HttpGet]
        public IHttpActionResult GetRequest_sabad(string name)
        {
            List<Sabad> sabad = new List<Sabad>();
            sabad = SabadKalaController.show1(name);
            return Ok(sabad);
        }
        [HttpGet]
        public IHttpActionResult GetRequest_sabaduser(string name)
        {
            List<Sabad> sabad = new List<Sabad>();
            sabad = SabadKalaController.show2(name);
            return Ok(sabad);
        }
        [HttpPost]
        public IHttpActionResult addsabad(string name,string kala)
        {
            SabadKalaController sbd = new SabadKalaController();
            sbd.insertsabad(name, kala);
            return Ok(sbd);
        }
    }
}
