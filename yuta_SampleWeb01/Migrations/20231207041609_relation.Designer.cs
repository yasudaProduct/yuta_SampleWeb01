﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using yuta_SampleWeb01.Data;

#nullable disable

namespace yuta_SampleWeb01.Migrations
{
    [DbContext(typeof(yuta_SampleWeb01Context))]
    [Migration("20231207041609_relation")]
    partial class relation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("yuta_SampleWeb01.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasMaxLength(30)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("yuta_SampleWeb01.Models.TDataA", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<string>("CreatePgmId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("create_pgm_id");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("create_user_id");

                    b.Property<string>("DeletedFlg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deleted_flg");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.Property<string>("UpdatePgmId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("update_pgm_id");

                    b.Property<string>("UpdateUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("update_user_id");

                    b.Property<int>("dataCls")
                        .HasColumnType("int")
                        .HasColumnName("data_cls");

                    b.Property<bool>("downloadFlg")
                        .HasColumnType("bit")
                        .HasColumnName("download_flg");

                    b.Property<DateTime>("periodDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("period_date");

                    b.Property<int>("status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_id");

                    b.HasKey("ID");

                    b.ToTable("t_data_a");
                });

            modelBuilder.Entity("yuta_SampleWeb01.Models.TDataADetail", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<string>("CreatePgmId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("create_pgm_id");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("create_user_id");

                    b.Property<int>("DataId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.Property<string>("UpdatePgmId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("update_pgm_id");

                    b.Property<string>("UpdateUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("update_user_id");

                    b.Property<string>("column1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("column1");

                    b.Property<string>("column2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("column2");

                    b.Property<string>("column3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("column3");

                    b.Property<string>("column4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("column4");

                    b.Property<string>("column5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("column5");

                    b.HasKey("ID");

                    b.HasIndex("DataId");

                    b.ToTable("t_data_a_detail");
                });

            modelBuilder.Entity("yuta_SampleWeb01.Models.TUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<string>("CreatePgmId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("create_pgm_id");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("create_user_id");

                    b.Property<string>("DeletedFlg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deleted_flg");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.Property<string>("UpdatePgmId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("update_pgm_id");

                    b.Property<string>("UpdateUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("update_user_id");

                    b.HasKey("UserId");

                    b.ToTable("t_user");
                });

            modelBuilder.Entity("yuta_SampleWeb01.Models.TUserCompany", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ccompany_name");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<string>("CreatePgmId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("create_pgm_id");

                    b.Property<string>("CreateUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("create_user_id");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("remarks");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.Property<string>("UpdatePgmId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("update_pgm_id");

                    b.Property<string>("UpdateUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("update_user_id");

                    b.HasKey("UserId");

                    b.ToTable("t_user_company");
                });

            modelBuilder.Entity("yuta_SampleWeb01.Models.TDataADetail", b =>
                {
                    b.HasOne("yuta_SampleWeb01.Models.TDataA", "DataA")
                        .WithMany("DataADetail")
                        .HasForeignKey("DataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataA");
                });

            modelBuilder.Entity("yuta_SampleWeb01.Models.TUserCompany", b =>
                {
                    b.HasOne("yuta_SampleWeb01.Models.TUser", "User")
                        .WithOne("UserCompany")
                        .HasForeignKey("yuta_SampleWeb01.Models.TUserCompany", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("yuta_SampleWeb01.Models.TDataA", b =>
                {
                    b.Navigation("DataADetail");
                });

            modelBuilder.Entity("yuta_SampleWeb01.Models.TUser", b =>
                {
                    b.Navigation("UserCompany")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
