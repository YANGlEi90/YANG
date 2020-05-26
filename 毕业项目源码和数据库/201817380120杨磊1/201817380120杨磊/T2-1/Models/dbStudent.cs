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
    public class dbStudent
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbStudent()
        {
            this.dbDetail = new HashSet<dbDetail>();
        }

        [Key]
        public string StuId { get; set; }
        public string stuName { get; set; }
        public string stuAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<dbDetail> dbDetail { get; set; }
    }
}
