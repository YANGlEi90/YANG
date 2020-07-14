using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YANGBlog.Models;
namespace YANGBlog.Controllers
{
    public class MessageBoardController : Controller
    {
        YANGEntities db = new YANGEntities();
        // GET: MessageBoard
        public ActionResult Index()
        {
            int Userid = int.Parse(Session["UserID"].ToString());
           List<MessageBoard> list= db.MessageBoard.Where(p => p.UserToId == Userid).ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult AddMessageBoard(string MessageContent,int UserToId)
        {
            int Userid = int.Parse(Session["UserID"].ToString());
            MessageBoard messageBoard = new MessageBoard()
            {
                MessageContent = MessageContent,
                UserToId = UserToId,
                UserId = Userid,
                MessageTime = DateTime.Now
            };
            db.MessageBoard.Add(messageBoard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMessage(int id)
        {
           var message=db.MessageBoard.Find(id);
            if (message.MessageReply.Count==0)
            {
                db.MessageBoard.Remove(message);
                db.SaveChanges();
            }
            else
            {
                foreach (var item in message.MessageReply)
                {
                    db.MessageReply.Remove(item);
                    db.SaveChanges();
                }
                db.MessageBoard.Remove(message);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}