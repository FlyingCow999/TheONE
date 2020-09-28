﻿// <auto-generated />
using System;
using Flying_Cow_TMSAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flying_Cow_TMSAPI.Migrations
{
    [DbContext(typeof(TMSDBContext))]
    [Migration("20200917092544_DB002")]
    partial class DB002
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Abnormal", b =>
                {
                    b.Property<int>("a_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("a_Abnormal")
                        .HasColumnType("int");

                    b.Property<string>("a_Explain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("a_Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("a_Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("a_Signer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("a_Signing")
                        .HasColumnType("datetime2");

                    b.Property<string>("a_Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ifid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("receiptid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("a_Id");

                    b.ToTable("Abnormal");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Address", b =>
                {
                    b.Property<int>("a_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("a_Site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("a_Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("ifid")
                        .HasColumnType("int");

                    b.HasKey("a_Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Anomaly", b =>
                {
                    b.Property<int>("ano_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("aid")
                        .HasColumnType("int");

                    b.Property<string>("ano_processing")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ano_Id");

                    b.ToTable("Anomaly");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Carrier_Profit", b =>
                {
                    b.Property<int>("cp_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ciid")
                        .HasColumnType("int");

                    b.Property<float>("cp_Aggregate")
                        .HasColumnType("real");

                    b.Property<float>("cp_ElseCost")
                        .HasColumnType("real");

                    b.Property<DateTime>("cp_EndTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("cp_Profit")
                        .HasColumnType("real");

                    b.HasKey("cp_Id");

                    b.ToTable("Carrier_Profit");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Consignee", b =>
                {
                    b.Property<int>("co_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("co_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("co_Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("co_Person")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("co_Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("co_State")
                        .HasColumnType("int");

                    b.Property<int>("eid")
                        .HasColumnType("int");

                    b.HasKey("co_Id");

                    b.ToTable("Consignee");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Dispatch", b =>
                {
                    b.Property<int>("dis_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("dis_State")
                        .HasColumnType("int");

                    b.Property<int>("orderid")
                        .HasColumnType("int");

                    b.Property<int>("transportid")
                        .HasColumnType("int");

                    b.HasKey("dis_Id");

                    b.ToTable("Dispatch");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Driver_Quotation", b =>
                {
                    b.Property<int>("dq_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ifid")
                        .HasColumnType("int");

                    b.Property<int>("oid")
                        .HasColumnType("int");

                    b.HasKey("dq_Id");

                    b.ToTable("Driver_Quotation");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Entrust", b =>
                {
                    b.Property<int>("e_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("e_AddPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("e_AddPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("e_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("e_Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("e_Person")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("e_Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ifid")
                        .HasColumnType("int");

                    b.HasKey("e_Id");

                    b.ToTable("Entrust");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Inquiry", b =>
                {
                    b.Property<int>("if_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("if_AllWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("if_BCarTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("if_BeginPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("if_EndPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("if_Goods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("if_Num")
                        .HasColumnType("int");

                    b.Property<string>("if_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("if_OrderTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("if_PlanArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("if_PlanBCarTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("if_Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("if_Specification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("if_State")
                        .HasColumnType("int");

                    b.Property<string>("if_TotalPackage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("if_Id");

                    b.ToTable("Inquiry");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Jurisdiction", b =>
                {
                    b.Property<int>("juris_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("juris_MenuName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("juris_Pid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("juris_Id");

                    b.ToTable("Jurisdiction");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Offer", b =>
                {
                    b.Property<int>("o_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ciid")
                        .HasColumnType("int");

                    b.Property<string>("o_Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("o_CarSpec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("o_Driver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("o_Freight")
                        .HasColumnType("real");

                    b.Property<string>("o_Nature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("o_Other")
                        .HasColumnType("real");

                    b.Property<float>("o_Price")
                        .HasColumnType("real");

                    b.Property<int>("o_Rated")
                        .HasColumnType("int");

                    b.Property<string>("o_Row")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("o_Starting")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("o_State")
                        .HasColumnType("int");

                    b.Property<string>("o_Station")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("o_TotalPrice")
                        .HasColumnType("real");

                    b.Property<string>("o_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("o_Id");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Receipt", b =>
                {
                    b.Property<int>("r_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("r_Article")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("r_Number")
                        .HasColumnType("int");

                    b.Property<string>("r_Order")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("r_Spec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("r_Weight")
                        .HasColumnType("int");

                    b.HasKey("r_Id");

                    b.ToTable("Receipt");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Role", b =>
                {
                    b.Property<int>("role_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("role_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role_Remark")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("role_Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.RoleJurisdiction", b =>
                {
                    b.Property<int>("role_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("jurisid")
                        .HasColumnType("int");

                    b.Property<int>("roleid")
                        .HasColumnType("int");

                    b.HasKey("role_Id");

                    b.ToTable("RoleJurisdiction");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Route", b =>
                {
                    b.Property<int>("r_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ifid")
                        .HasColumnType("int");

                    b.Property<string>("r_EndPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("r_Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("r_StratPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("r_Time")
                        .HasColumnType("datetime2");

                    b.HasKey("r_Id");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.Takegoods", b =>
                {
                    b.Property<int>("t_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("oid")
                        .HasColumnType("int");

                    b.Property<string>("t_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("t_Article")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("t_Number")
                        .HasColumnType("int");

                    b.Property<string>("t_Order")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("t_Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("t_Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("t_Signing")
                        .HasColumnType("datetime2");

                    b.Property<string>("t_Spec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("t_Starting")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("t_Station")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("t_Volume")
                        .HasColumnType("int");

                    b.Property<float>("t_Weight")
                        .HasColumnType("real");

                    b.HasKey("t_Id");

                    b.ToTable("Takegoods");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.UserInfo", b =>
                {
                    b.Property<int>("user_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("user_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("Flying_Cow_TMSAPI.Model.UserRole", b =>
                {
                    b.Property<int>("usro_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("roleid")
                        .HasColumnType("int");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("usro_Id");

                    b.ToTable("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
