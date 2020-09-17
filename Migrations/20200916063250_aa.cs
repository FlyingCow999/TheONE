using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flying_Cow_TMSAPI.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abnormal",
                columns: table => new
                {
                    a_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    a_Abnormal = table.Column<int>(nullable: false),
                    a_Explain = table.Column<string>(nullable: true),
                    a_Signer = table.Column<string>(nullable: true),
                    a_Signing = table.Column<DateTime>(nullable: false),
                    a_Status = table.Column<string>(nullable: true),
                    a_Picture = table.Column<string>(nullable: true),
                    a_Remarks = table.Column<string>(nullable: true),
                    receiptid = table.Column<string>(nullable: true),
                    ifid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abnormal", x => x.a_Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    a_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    a_Time = table.Column<DateTime>(nullable: false),
                    a_Site = table.Column<string>(nullable: true),
                    ifid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.a_Id);
                });

            migrationBuilder.CreateTable(
                name: "Anomaly",
                columns: table => new
                {
                    ano_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aid = table.Column<int>(nullable: false),
                    ano_processing = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anomaly", x => x.ano_Id);
                });

            migrationBuilder.CreateTable(
                name: "Carrier_Profit",
                columns: table => new
                {
                    cp_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cp_Profit = table.Column<float>(nullable: false),
                    cp_ElseCost = table.Column<float>(nullable: false),
                    cp_EndTime = table.Column<DateTime>(nullable: false),
                    cp_Aggregate = table.Column<float>(nullable: false),
                    ciid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrier_Profit", x => x.cp_Id);
                });

            migrationBuilder.CreateTable(
                name: "Consignee",
                columns: table => new
                {
                    co_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    co_Company = table.Column<string>(nullable: true),
                    co_Person = table.Column<string>(nullable: true),
                    co_Phone = table.Column<string>(nullable: true),
                    co_Address = table.Column<string>(nullable: true),
                    eid = table.Column<int>(nullable: false),
                    co_State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consignee", x => x.co_Id);
                });

            migrationBuilder.CreateTable(
                name: "Dispatch",
                columns: table => new
                {
                    dis_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    routeid = table.Column<int>(nullable: false),
                    transportid = table.Column<int>(nullable: false),
                    orderid = table.Column<int>(nullable: false),
                    dis_State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatch", x => x.dis_Id);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    d_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ifid = table.Column<int>(nullable: false),
                    oid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.d_Id);
                });

            migrationBuilder.CreateTable(
                name: "Driver_Quotation",
                columns: table => new
                {
                    dq_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ifid = table.Column<int>(nullable: false),
                    oid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver_Quotation", x => x.dq_Id);
                });

            migrationBuilder.CreateTable(
                name: "Entrust",
                columns: table => new
                {
                    e_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    e_Company = table.Column<string>(nullable: true),
                    e_Person = table.Column<string>(nullable: true),
                    e_Phone = table.Column<string>(nullable: true),
                    e_Address = table.Column<string>(nullable: true),
                    e_AddPerson = table.Column<string>(nullable: true),
                    e_AddPhone = table.Column<string>(nullable: true),
                    ifid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrust", x => x.e_Id);
                });

            migrationBuilder.CreateTable(
                name: "Inquiry",
                columns: table => new
                {
                    if_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    if_Number = table.Column<string>(nullable: true),
                    if_OrderTime = table.Column<DateTime>(nullable: false),
                    if_PlanBCarTime = table.Column<DateTime>(nullable: false),
                    if_PlanArrivalTime = table.Column<DateTime>(nullable: false),
                    if_BCarTime = table.Column<DateTime>(nullable: false),
                    if_BeginPlace = table.Column<string>(nullable: true),
                    if_EndPlace = table.Column<string>(nullable: true),
                    if_State = table.Column<int>(nullable: false),
                    if_Remark = table.Column<string>(nullable: true),
                    if_Specification = table.Column<string>(nullable: true),
                    if_TotalPackage = table.Column<string>(nullable: true),
                    if_Num = table.Column<int>(nullable: false),
                    if_AllWeight = table.Column<string>(nullable: true),
                    if_Goods = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiry", x => x.if_Id);
                });

            migrationBuilder.CreateTable(
                name: "Jurisdiction",
                columns: table => new
                {
                    juris_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    juris_MenuName = table.Column<string>(nullable: true),
                    juris_Pid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jurisdiction", x => x.juris_Id);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    o_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    o_Driver = table.Column<string>(nullable: true),
                    o_Nature = table.Column<string>(nullable: true),
                    o_Row = table.Column<string>(nullable: true),
                    o_Type = table.Column<string>(nullable: true),
                    o_CarSpec = table.Column<string>(nullable: true),
                    o_State = table.Column<int>(nullable: false),
                    o_Price = table.Column<float>(nullable: false),
                    o_Capacity = table.Column<string>(nullable: true),
                    o_Starting = table.Column<string>(nullable: true),
                    o_Station = table.Column<string>(nullable: true),
                    o_Rated = table.Column<int>(nullable: false),
                    o_Freight = table.Column<float>(nullable: false),
                    o_Other = table.Column<float>(nullable: false),
                    o_TotalPrice = table.Column<float>(nullable: false),
                    ciid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.o_Id);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    r_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    r_Order = table.Column<string>(nullable: true),
                    r_Article = table.Column<string>(nullable: true),
                    r_Spec = table.Column<string>(nullable: true),
                    r_Number = table.Column<int>(nullable: false),
                    r_Weight = table.Column<int>(nullable: false),
                    r_Volume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.r_Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    role_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_Name = table.Column<string>(nullable: true),
                    role_Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.role_Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleJurisdiction",
                columns: table => new
                {
                    role_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleid = table.Column<int>(nullable: false),
                    jurisid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleJurisdiction", x => x.role_Id);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    r_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    r_Pass = table.Column<string>(nullable: true),
                    ifid = table.Column<int>(nullable: false),
                    r_Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.r_Id);
                });

            migrationBuilder.CreateTable(
                name: "Takegoods",
                columns: table => new
                {
                    t_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    t_Order = table.Column<string>(nullable: true),
                    t_Article = table.Column<string>(nullable: true),
                    t_Spec = table.Column<string>(nullable: true),
                    t_Number = table.Column<int>(nullable: false),
                    t_Weight = table.Column<float>(nullable: false),
                    t_Volume = table.Column<int>(nullable: false),
                    t_Starting = table.Column<string>(nullable: true),
                    t_Origin = table.Column<string>(nullable: true),
                    t_Station = table.Column<string>(nullable: true),
                    t_Address = table.Column<string>(nullable: true),
                    t_Picture = table.Column<string>(nullable: true),
                    t_Signing = table.Column<DateTime>(nullable: false),
                    oid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takegoods", x => x.t_Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    user_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_Name = table.Column<string>(nullable: true),
                    user_Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.user_Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    usro_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(nullable: false),
                    roleid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.usro_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abnormal");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Anomaly");

            migrationBuilder.DropTable(
                name: "Carrier_Profit");

            migrationBuilder.DropTable(
                name: "Consignee");

            migrationBuilder.DropTable(
                name: "Dispatch");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Driver_Quotation");

            migrationBuilder.DropTable(
                name: "Entrust");

            migrationBuilder.DropTable(
                name: "Inquiry");

            migrationBuilder.DropTable(
                name: "Jurisdiction");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RoleJurisdiction");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Takegoods");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
