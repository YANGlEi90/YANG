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
    public class dbTeacher
    {
        //实例化老师的时候初始化加载对应导航属性（报备表所对应得所有信息）
        public dbTeacher(){
            this.dbDetails = new HashSet<dbDetail>();
        }
        //老师编号
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeaId { get; set; }
        //老师姓名
        [Required]
        [StringLength(32)]
        public string TeaName { get; set; }
        //导航属性
        public ICollection<dbDetail> dbDetails { get; set; }
    }
}
