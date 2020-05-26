using Account.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class AnswerController : Controller
    {
        AccountDBEntities db = new AccountDBEntities();

        // GET: Answer
        //---》》》第二步：
        public ActionResult Index(int PaperID,int StuID)
        {
            //根据学生的ID和试卷的ID获得答题卡信息
            Answer answer = db.Answer.FirstOrDefault(a => a.PaperID == PaperID && a.StuID == StuID);
            return View(answer);
        }
        [HttpPost]
        public void Index(int AnswerID, int TopicID, string DetailAnswer)
        {
            //根据AnswerID和topicID 查询学生在答题卡中的记录
            var result = db.Detail.FirstOrDefault(d => d.TopicID == TopicID && d.AnswerID == AnswerID);
            //修改成最新提交的答案
            result.DetailAnswer = DetailAnswer;
            db.SaveChanges();
        }
        /// <summary>
        /// 我的考试
        /// </summary>
        /// <returns></returns>
        public ActionResult MyAnswer(int ? page)
        {
            Student stu = Session["stu"] as Student;
            //获取学生对应的  Answer 表
            List<Answer> answer = db.Answer.Where(p=>p.StuID== stu.StuID).ToList();
            ViewBag.answer = answer;

            return View();

        }
        /// <summary>
        ///  我的考试详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult MyAnswerDetail(int ID)
        {

            Student stu = Session["stu"] as Student;
            //获取对应的试卷
            Paper paper = db.Paper.Find(ID);
            //获取对应的试题
            List<Topic> topic = db.Topic.Where(p => p.PaperID == ID).ToList();

            ViewBag.paper = paper;
            ViewBag.topic = topic;

            return View();

        }
        /// <summary>
        /// ---》》》第一步：在线考试-》开始考试
        /// </summary>
        /// <returns></returns>
        public ActionResult AnswerDetail(int PaperID, int StuID)
        {
            
            //第一步：填写答题卡信息
            //当点击“开始开始时”，旺考试信息登记表中，添加学生对应试卷的考试信息
            Answer an = new Answer()
            {
                //对象初始化
                PaperID = PaperID,  //试卷ID
                StuID = StuID,      //学生ID
                TeacherID = 1,      //老师ID。默认主键为1 的老师
                AnswerScore = 0,    //考试成绩，默认是0，老师审完卷才修改
                AnswerTime = DateTime.Now,  //开始答题时间
                SubmitTime = null,           //学生点击交卷的时间
                BatchTime = null,         //老师点击批改试卷的时间
                AnswerState = 0,   //0考试中，1未审批，2已审批
            };
            db.Answer.Add(an);
            db.SaveChanges();

            //第二步：准备答题卡
            List<Topic> topic = db.Topic.Where(p => p.PaperID == PaperID).ToList();

            foreach (var item in topic)
            {
                //每一道题都在detail的答卷中进行初始化（准备空白答题卡）
                Detail detail = new Detail()
                {
                    AnswerID = an.AnswerID,
                    TopicID = item.TopicID,
                    DetailAnswer = ""       //初始化空答案，当点击提交时
                    //修改对应的题，答案即可，便无需做添加，这样省去了做题状态的判断
                };
                db.Detail.Add(detail);
            }
            db.SaveChanges();
            return RedirectToAction("Index","Answer",new { PaperID= PaperID,  StuID= StuID });
        }

        /// <summary>
        /// ---》》》第三步：最后提交试卷
        /// </summary>
        /// <param name="PaperID"></param>
        /// <param name="StuID"></param>
        /// <returns></returns>
        public ActionResult SubmitPaper(int AnswerID)
        {
            Answer answer = db.Answer.Find(AnswerID);
            answer.SubmitTime = DateTime.Now;
            answer.AnswerState = 1;   //0考试中，1未审批，2已审批
            db.SaveChanges();
            return RedirectToAction("IndexStu","Papers");
        }


        /// <summary>
        /// 审卷--全部查询
        /// </summary>
        /// <returns></returns>
        public ActionResult TeAnswer(int ? page)
        {
             Teacher tea = Session["teacher"] as Teacher;
            //获取对应的Answer
            List<Answer> answers = db.Answer.Where(p => p.TeacherID == tea.TeacherID).ToList();
            ViewBag.answer = answers;
            //当前页,合并运算符，
            int pageNumber = page??1;
            //每页显示的行数
            int pageSize = 8;
            //将我们的集合转成分页 的集合，
            IPagedList<Answer> answersList = answers.ToPagedList(pageNumber,pageSize);
            ViewBag.answersList = answersList;

            return View();
        }
        /// <summary>
        /// 审卷与详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult TeAnswerDetail(int id)
        {
            Answer answers = db.Answer.Find(id);
            
            ViewBag.answers = answers;
            return View();
        }
        /// <summary>
        /// 提交审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Verify(int AnswerID, int sumScore)
        {
            Answer answer = db.Answer.Find(AnswerID);
            answer.BatchTime = DateTime.Now;
            answer.AnswerState = 2;   //0考试中，1未审批，2已审批
            answer.AnswerScore = sumScore;
            db.SaveChanges();
            return RedirectToAction("TeAnswer");
        }
    }
}