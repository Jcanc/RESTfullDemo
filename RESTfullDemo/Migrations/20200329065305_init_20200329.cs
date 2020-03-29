using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RESTfullDemo.Migrations
{
    public partial class init_20200329 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("12ec899b-66f0-4e84-8f78-66ccc211712c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("8240bee0-e0eb-44ea-b1d1-fc078702bd73"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("e88a1bc9-3920-46e1-a258-bda3b558342d"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("ea7063d7-fbf9-4aa1-87fe-19b0339bc397"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("114f910b-6de9-4d37-8cd8-786eddfaf02e"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("bd7652e1-57d0-4bf8-8c5e-9f17dd57c90b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("e4281234-aa39-432e-9117-707c9d74be92"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("eb183823-dc3a-4425-84e9-e106ade1b0f6"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("3aceb6c1-edec-4a0a-ab4e-2b23a19b3da3"), "阿里巴巴(中国)有限公司成立于2007年03月26日，注册地位于杭州市西湖区西斗门路3号天堂软件园A幢10楼G座，法人代表为张勇。", "阿里巴巴" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("1721aa41-aad6-4e6b-be2e-fd3e7d0f7129"), "深圳市腾讯计算机系统有限公司成立于1998年11月11日，注册地位于深圳市南山区粤海街道麻岭社区科技中一路腾讯大厦35层，法人代表为马化腾。", "腾讯" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("1bccb001-9b51-45eb-8e3f-7b9ea54a3d35"), "北京字节跳动科技有限公司成立于2012年，是最早将人工智能应用于移动互联网场景的科技企业之一，是中国北京的一家信息科技公司，地址位于北京市海淀区知春路甲48号。", "字节跳动" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("c04a8a8a-bab3-48d6-b6c9-24dddc9210e5"), "北京百度网讯科技有限公司成立于2001年06月05日，注册地位于北京市海淀区上地十街10号百度大厦2层，法人代表为梁志祥。", "百度" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("1328bf95-f6d3-4b1d-ad67-ca3c7b8203d6"), "京东（股票代码：JD），中国自营式电商企业，创始人刘强东担任京东集团董事局主席兼首席执行官。", "京东" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[] { new Guid("03ecefd0-2892-468d-b94f-41e2b61b1d56"), new Guid("3aceb6c1-edec-4a0a-ab4e-2b23a19b3da3"), new DateTime(1983, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "001", "张", 1, "勇" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[] { new Guid("14a3592a-96eb-401c-a3f1-f9d257704e68"), new Guid("3aceb6c1-edec-4a0a-ab4e-2b23a19b3da3"), new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002", "蒋", 2, "芳" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[] { new Guid("2e31d15d-0503-463c-b97a-429953872df9"), new Guid("3aceb6c1-edec-4a0a-ab4e-2b23a19b3da3"), new DateTime(1983, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "003", "郑", 2, "俊芳" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("1328bf95-f6d3-4b1d-ad67-ca3c7b8203d6"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("1721aa41-aad6-4e6b-be2e-fd3e7d0f7129"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("1bccb001-9b51-45eb-8e3f-7b9ea54a3d35"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("c04a8a8a-bab3-48d6-b6c9-24dddc9210e5"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("03ecefd0-2892-468d-b94f-41e2b61b1d56"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("14a3592a-96eb-401c-a3f1-f9d257704e68"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("2e31d15d-0503-463c-b97a-429953872df9"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("3aceb6c1-edec-4a0a-ab4e-2b23a19b3da3"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("eb183823-dc3a-4425-84e9-e106ade1b0f6"), "阿里巴巴(中国)有限公司成立于2007年03月26日，注册地位于杭州市西湖区西斗门路3号天堂软件园A幢10楼G座，法人代表为张勇。", "阿里巴巴" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("12ec899b-66f0-4e84-8f78-66ccc211712c"), "深圳市腾讯计算机系统有限公司成立于1998年11月11日，注册地位于深圳市南山区粤海街道麻岭社区科技中一路腾讯大厦35层，法人代表为马化腾。", "腾讯" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("ea7063d7-fbf9-4aa1-87fe-19b0339bc397"), "北京字节跳动科技有限公司成立于2012年，是最早将人工智能应用于移动互联网场景的科技企业之一，是中国北京的一家信息科技公司，地址位于北京市海淀区知春路甲48号。", "字节跳动" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("e88a1bc9-3920-46e1-a258-bda3b558342d"), "北京百度网讯科技有限公司成立于2001年06月05日，注册地位于北京市海淀区上地十街10号百度大厦2层，法人代表为梁志祥。", "百度" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("8240bee0-e0eb-44ea-b1d1-fc078702bd73"), "京东（股票代码：JD），中国自营式电商企业，创始人刘强东担任京东集团董事局主席兼首席执行官。", "京东" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[] { new Guid("114f910b-6de9-4d37-8cd8-786eddfaf02e"), new Guid("eb183823-dc3a-4425-84e9-e106ade1b0f6"), new DateTime(1983, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "001", "张", 1, "勇" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[] { new Guid("e4281234-aa39-432e-9117-707c9d74be92"), new Guid("eb183823-dc3a-4425-84e9-e106ade1b0f6"), new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002", "蒋", 2, "芳" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[] { new Guid("bd7652e1-57d0-4bf8-8c5e-9f17dd57c90b"), new Guid("eb183823-dc3a-4425-84e9-e106ade1b0f6"), new DateTime(1983, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "003", "郑", 2, "俊芳" });
        }
    }
}
