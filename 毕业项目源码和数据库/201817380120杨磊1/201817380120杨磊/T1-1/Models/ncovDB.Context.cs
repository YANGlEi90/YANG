﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace T1_1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    /// <summary>
    /// 数据库上下文类
    /// </summary>
    public partial class ncovDBEntities : DbContext
    {
        public ncovDBEntities()
            : base("name=ncovDBEntities")//继承父类有参构造方法
        {
        }
    /// <summary>
    /// 用于追踪识别业务实体的变更，是数据库访问操作的入口，没有该类，EF没有办法运行
    /// 这个方法用于上下文对象初始化后执行的配置场所
    /// </summary>
    /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    

        //业务实体集合类集合
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbDetail> tbDetail { get; set; }
        public virtual DbSet<tbStu> tbStu { get; set; }
        public virtual DbSet<tbTea> tbTea { get; set; }
    }
}
