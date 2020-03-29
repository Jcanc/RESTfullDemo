using Microsoft.EntityFrameworkCore;
using RESTfullDemo.Entities;
using System;

namespace RESTfullDemo.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = Guid.Parse("3ACEB6C1-EDEC-4A0A-AB4E-2B23A19B3DA3"),
                    Name = "阿里巴巴",
                    Introduction = "阿里巴巴(中国)有限公司成立于2007年03月26日，注册地位于杭州市西湖区西斗门路3号天堂软件园A幢10楼G座，法人代表为张勇。"
                },
                new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "腾讯",
                    Introduction = "深圳市腾讯计算机系统有限公司成立于1998年11月11日，注册地位于深圳市南山区粤海街道麻岭社区科技中一路腾讯大厦35层，法人代表为马化腾。"
                },
                new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "字节跳动",
                    Introduction = "北京字节跳动科技有限公司成立于2012年，是最早将人工智能应用于移动互联网场景的科技企业之一，是中国北京的一家信息科技公司，地址位于北京市海淀区知春路甲48号。"
                },
                new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "百度",
                    Introduction = "北京百度网讯科技有限公司成立于2001年06月05日，注册地位于北京市海淀区上地十街10号百度大厦2层，法人代表为梁志祥。"
                },
                new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "京东",
                    Introduction = "京东（股票代码：JD），中国自营式电商企业，创始人刘强东担任京东集团董事局主席兼首席执行官。"
                }
            );

            modelBuilder.Entity<Employee>().HasData( 
                new Employee
                {
                    Id = Guid.NewGuid(),
                    CompanyId = Guid.Parse("3ACEB6C1-EDEC-4A0A-AB4E-2B23A19B3DA3"),
                    EmployeeNo = "001",
                    FirstName = "张",
                    LastName = "勇",
                    DateOfBirth = new DateTime(1983, 11, 1),
                    Gender = Gender.男
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    CompanyId = Guid.Parse("3ACEB6C1-EDEC-4A0A-AB4E-2B23A19B3DA3"),
                    EmployeeNo = "002",
                    FirstName = "蒋",
                    LastName = "芳",
                    DateOfBirth = new DateTime(1989, 10, 1),
                    Gender = Gender.女
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    CompanyId = Guid.Parse("3ACEB6C1-EDEC-4A0A-AB4E-2B23A19B3DA3"),
                    EmployeeNo = "003",
                    FirstName = "郑",
                    LastName = "俊芳",
                    DateOfBirth = new DateTime(1983, 5, 9),
                    Gender = Gender.女
                }
            );
        }
    }
}
