﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211002115958_mig_writer_blog_realtion_and_writer_city")]
    partial class mig_writer_blog_realtion_and_writer_city
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("EntityLayer.Concrete.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AboutDetails1")
                        .HasColumnType("longtext");

                    b.Property<string>("AboutDetails2")
                        .HasColumnType("longtext");

                    b.Property<string>("AboutImage1")
                        .HasColumnType("longtext");

                    b.Property<string>("AboutImage2")
                        .HasColumnType("longtext");

                    b.Property<string>("AboutMapLocation")
                        .HasColumnType("longtext");

                    b.Property<bool>("AboutStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BlogContent")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BlogCreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BlogImage")
                        .HasColumnType("longtext");

                    b.Property<bool>("BlogStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("BlogThumbnailImage")
                        .HasColumnType("longtext");

                    b.Property<string>("BlogTitle")
                        .HasColumnType("longtext");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("WriterID")
                        .HasColumnType("int");

                    b.HasKey("BlogID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("WriterID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("CategoryName")
                        .HasColumnType("longtext");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BlogID")
                        .HasColumnType("int");

                    b.Property<string>("CommentContent")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("CommentStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CommentTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("CommentUserName")
                        .HasColumnType("longtext");

                    b.HasKey("CommentID");

                    b.HasIndex("BlogID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CommentMail")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ContactDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ContactMessage")
                        .HasColumnType("longtext");

                    b.Property<bool>("ContactStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ContactSubject")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactUserName")
                        .HasColumnType("longtext");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Writer", b =>
                {
                    b.Property<int>("WriterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("WriterAbout")
                        .HasColumnType("longtext");

                    b.Property<string>("WriterCity")
                        .HasColumnType("longtext");

                    b.Property<string>("WriterEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("WriterImage")
                        .HasColumnType("longtext");

                    b.Property<string>("WriterName")
                        .HasColumnType("longtext");

                    b.Property<string>("WriterPassword")
                        .HasColumnType("longtext");

                    b.Property<bool>("WriterStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("WriterID");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Blog", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Writer", "Writer")
                        .WithMany("Blogs")
                        .HasForeignKey("WriterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Blog", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Writer", b =>
                {
                    b.Navigation("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}
