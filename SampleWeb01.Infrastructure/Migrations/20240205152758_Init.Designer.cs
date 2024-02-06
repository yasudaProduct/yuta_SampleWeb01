﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SampleWeb01.Infrastructure.Data;

#nullable disable

namespace SampleWeb01.Infrastructure.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    [Migration("20240205152758_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SampleWeb01.Infrastructure.Data.Entity.TUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("CreatePgmId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("create_pgm_id");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("create_user_id");

                    b.Property<string>("DeletedFlg")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("deleted_flg");

                    b.Property<string>("MailAdress")
                        .IsRequired()
                        .HasMaxLength(319)
                        .HasColumnType("character varying(319)")
                        .HasColumnName("mail_address");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("password");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<string>("UpdatePgmId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("update_pgm_id");

                    b.Property<string>("UpdateUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("update_user_id");

                    b.HasKey("UserId");

                    b.ToTable("m_user");
                });

            modelBuilder.Entity("SampleWeb01.Infrastructure.Data.Entity.TUserCompany", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("company_name");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("CreatePgmId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("create_pgm_id");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("create_user_id");

                    b.Property<string>("DeletedFlg")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("deleted_flg");

                    b.Property<string>("Remarks")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("remarks");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<string>("UpdatePgmId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("update_pgm_id");

                    b.Property<string>("UpdateUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("update_user_id");

                    b.HasKey("UserId");

                    b.ToTable("m_user_company");
                });

            modelBuilder.Entity("SampleWeb01.Infrastructure.Data.Entity.TUserCompany", b =>
                {
                    b.HasOne("SampleWeb01.Infrastructure.Data.Entity.TUser", "User")
                        .WithOne("UserCompany")
                        .HasForeignKey("SampleWeb01.Infrastructure.Data.Entity.TUserCompany", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SampleWeb01.Infrastructure.Data.Entity.TUser", b =>
                {
                    b.Navigation("UserCompany")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
