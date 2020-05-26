using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace T2_1.Models
{
    /// <summary>
    /// 重写seed方法 种子 初始化数据
    /// seed种子，将初始化得实际数据添加到设定种子得上下文中。
    /// </summary>
    public class InitDatabase: DropCreateDatabaseIfModelChanges<nCovDBContextL>
    {
        protected override void Seed(nCovDBContextL db)
        {
            dbStudent stu = new dbStudent()
            {
                StuId = "201817380120",
                stuName = "杨磊",
                stuAddress = "湖南常德"

            };
            db.dbStudent.Add(stu);
            db.SaveChanges();
            dbTeacher tea = new dbTeacher()
            {
                TeaName = "胡瑶"
            };
            db.dbTeacher.Add(tea);
            db.SaveChanges();
            //初始化从表 报备信息
            dbDetail detail = new dbDetail()
            {
                fillTime = DateTime.Now,
                isCough = "否",
                isFever = "否",
                dbStudent = stu,
                dbTeacher=tea
            };
            db.dbDetail.Add(detail);
            db.SaveChanges();
        }
    }
}
