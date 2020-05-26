using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace T2_1.Models
{
    public class nCovDBContextL : DbContext
    {

        /// <summary>
        /// 手动配置数据
        /// </summary>
        public nCovDBContextL():base("name=aaa")
        {
            //初始化设值
            Database.SetInitializer(new InitDatabase());
        }
        /// <summary>
        /// 数据库模型重建
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //这句是不要将EF生成的sql表名不要被复数 就是表名后面不要多加个S
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //做显示加载时 要将其关闭
            Configuration.LazyLoadingEnabled = true;
        }
        public virtual DbSet<dbDetail> dbDetail { get; set; }
        public virtual DbSet<dbStudent> dbStudent { get; set; }
        public virtual DbSet<dbTeacher> dbTeacher { get; set; }
    }
}
