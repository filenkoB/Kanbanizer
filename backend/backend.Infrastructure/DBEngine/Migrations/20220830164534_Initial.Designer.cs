// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.DBEngine;

#nullable disable

namespace backend.Infrastructure.DBEngine.Migrations
{
    [DbContext(typeof(CanbanDbContext))]
    [Migration("20220830164534_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("backend.Domain.Model.Board", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("backend.Domain.Model.Column", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaxTasks")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Column");
                });

            modelBuilder.Entity("backend.Domain.Model.Credential", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Credential");
                });

            modelBuilder.Entity("backend.Domain.Model.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("UserId");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("backend.Domain.Model.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColumnId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParticipantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ColumnId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("backend.Domain.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("backend.Domain.Model.Column", b =>
                {
                    b.HasOne("backend.Domain.Model.Board", "Board")
                        .WithMany()
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("backend.Domain.Model.Credential", b =>
                {
                    b.HasOne("backend.Domain.Model.User", "User")
                        .WithOne("Credential")
                        .HasForeignKey("backend.Domain.Model.Credential", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Domain.Model.Participant", b =>
                {
                    b.HasOne("backend.Domain.Model.Board", "Board")
                        .WithMany("Participants")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Domain.Model.User", "User")
                        .WithMany("Participants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Domain.Model.Task", b =>
                {
                    b.HasOne("backend.Domain.Model.Column", "Column")
                        .WithMany("Tasks")
                        .HasForeignKey("ColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Domain.Model.Participant", null)
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Participant_Tasks");

                    b.HasOne("backend.Domain.Model.Participant", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ParticipantId");

                    b.Navigation("Column");
                });

            modelBuilder.Entity("backend.Domain.Model.Board", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("backend.Domain.Model.Column", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("backend.Domain.Model.Participant", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("backend.Domain.Model.User", b =>
                {
                    b.Navigation("Credential")
                        .IsRequired();

                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
