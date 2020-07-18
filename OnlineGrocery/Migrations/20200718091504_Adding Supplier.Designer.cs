﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineGrocery.Models;

namespace OnlineGrocery.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200718091504_Adding Supplier")]
    partial class AddingSupplier
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineGrocery.Models.CMSIndexPageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About_1_H3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_1_Img_Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_1_Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_2_H3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_2_Img_Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_2_Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_3_H3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_3_Img_Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("About_3_Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ContactFormToggler")
                        .HasColumnType("bit");

                    b.Property<string>("Contact_Address_City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Address_Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Address_Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Email_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Email_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_H3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_P")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Phone_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Phone_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header_H1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header_P1_Welcome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IndexPageModel");
                });

            modelBuilder.Entity("OnlineGrocery.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OnlineGrocery.Models.SuppliersModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("OnlineGrocery.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MoneySpent")
                        .HasColumnType("float");

                    b.Property<int>("OrdersAmmount")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
