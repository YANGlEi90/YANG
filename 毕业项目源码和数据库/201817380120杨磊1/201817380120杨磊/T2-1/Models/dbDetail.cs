using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//数据注解得支持包
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2_1.Models
{
    public class dbDetail
    {
        [Key]
        public int ID { get; set; }
        public string StuId { get; set; }
        public int TeaId { get; set; }
        public Nullable<System.DateTime> fillTime { get; set; }
        public string isCough { get; set; }
        public string isFever { get; set; }
        public  dbStudent dbStudent { get; set; }
        public  dbTeacher dbTeacher { get; set; }
    }
}
