﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoListApp.Data;

#nullable disable

namespace TodoListApp.Migrations
{
    [DbContext(typeof(TodoListDbContext))]
    [Migration("20230910165921_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("TodoListApp.Model.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Done")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EstimatedTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ListId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SpendTime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TodoListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TodoListId");

                    b.ToTable("TodoItem");
                });

            modelBuilder.Entity("TodoListApp.Model.TodoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Open")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TodoList");
                });

            modelBuilder.Entity("TodoListApp.Model.TodoItem", b =>
                {
                    b.HasOne("TodoListApp.Model.TodoList", "TodoList")
                        .WithMany("Tasks")
                        .HasForeignKey("TodoListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TodoList");
                });

            modelBuilder.Entity("TodoListApp.Model.TodoList", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
