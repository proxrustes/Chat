﻿// <auto-generated />
using System;
using Chat_Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chat_Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220901184217_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Chat_Database.Models.ChatEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("chatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Chat_Database.Models.ChatUser", b =>
                {
                    b.Property<int>("chatId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("chatId", "userId");

                    b.HasIndex("userId");

                    b.ToTable("ChatUsers");
                });

            modelBuilder.Entity("Chat_Database.Models.MessageEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("chatId")
                        .HasColumnType("int");

                    b.Property<bool>("deletedForSelf")
                        .HasColumnType("bit");

                    b.Property<string>("messageBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("messageDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Chat_Database.Models.UserEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Chat_Database.Models.ChatUser", b =>
                {
                    b.HasOne("Chat_Database.Models.ChatEntity", "Chat")
                        .WithMany("chatUsers")
                        .HasForeignKey("chatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chat_Database.Models.UserEntity", "User")
                        .WithMany("chatUsers")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Chat_Database.Models.ChatEntity", b =>
                {
                    b.Navigation("chatUsers");
                });

            modelBuilder.Entity("Chat_Database.Models.UserEntity", b =>
                {
                    b.Navigation("chatUsers");
                });
#pragma warning restore 612, 618
        }
    }
}