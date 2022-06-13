﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using chatAppAPIForReal;

#nullable disable

namespace chatAppAPIForReal.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220613102224_changed_date_to_string")]
    partial class changed_date_to_string
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ChatAppMVC.Models.Chat", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Interlocuter1")
                        .HasColumnType("longtext");

                    b.Property<string>("Interlocuter2")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("chats");
                });

            modelBuilder.Entity("ChatAppMVC.Models.Contact", b =>
                {
                    b.Property<string>("ContactKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Id")
                        .HasColumnType("longtext");

                    b.Property<string>("LastMessageDate")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Server")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.HasKey("ContactKey");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ChatAppMVC.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ChatId")
                        .HasColumnType("longtext");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<string>("Created")
                        .HasColumnType("longtext");

                    b.Property<bool>("Sent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SentBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("ChatAppMVC.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Server")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
