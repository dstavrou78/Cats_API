﻿// <auto-generated />
using System;
using Cats_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cats_API.Migrations
{
    [DbContext(typeof(CatsContext))]
    partial class CatsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BreedImage", b =>
                {
                    b.Property<string>("BreedsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImagesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BreedsId", "ImagesId");

                    b.HasIndex("ImagesId");

                    b.ToTable("BreedImage");
                });

            modelBuilder.Entity("CatTag", b =>
                {
                    b.Property<int>("CatsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("CatsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("CatTag");
                });

            modelBuilder.Entity("Cats_API.Models.Breed", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Adaptability")
                        .HasColumnType("int");

                    b.Property<int?>("Affection_level")
                        .HasColumnType("int");

                    b.Property<string>("Alt_names")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Child_friendly")
                        .HasColumnType("int");

                    b.Property<string>("Country_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country_codes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dog_friendly")
                        .HasColumnType("int");

                    b.Property<int?>("Energy_level")
                        .HasColumnType("int");

                    b.Property<int?>("Experimental")
                        .HasColumnType("int");

                    b.Property<int?>("Grooming")
                        .HasColumnType("int");

                    b.Property<int?>("Hairless")
                        .HasColumnType("int");

                    b.Property<int?>("Health_issues")
                        .HasColumnType("int");

                    b.Property<int?>("Hypoallergenic")
                        .HasColumnType("int");

                    b.Property<int?>("Indoor")
                        .HasColumnType("int");

                    b.Property<int?>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Life_span")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Natural")
                        .HasColumnType("int");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rare")
                        .HasColumnType("int");

                    b.Property<string>("Reference_image_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rex")
                        .HasColumnType("int");

                    b.Property<int?>("Shedding_level")
                        .HasColumnType("int");

                    b.Property<int?>("Short_legs")
                        .HasColumnType("int");

                    b.Property<int?>("Social_needs")
                        .HasColumnType("int");

                    b.Property<int?>("Stranger_friendly")
                        .HasColumnType("int");

                    b.Property<int?>("Suppressed_tail")
                        .HasColumnType("int");

                    b.Property<string>("Temperament")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vcahospitals_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vetstreet_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wikipedia_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("Cats_API.Models.Cat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CatId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("Cats_API.Models.Image", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CatId")
                        .HasColumnType("int");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatId")
                        .IsUnique();

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Cats_API.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Cats_API.Models.Weight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BreedId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Imperial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Metric")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BreedId")
                        .IsUnique()
                        .HasFilter("[BreedId] IS NOT NULL");

                    b.ToTable("Weight");
                });

            modelBuilder.Entity("BreedImage", b =>
                {
                    b.HasOne("Cats_API.Models.Breed", null)
                        .WithMany()
                        .HasForeignKey("BreedsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cats_API.Models.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CatTag", b =>
                {
                    b.HasOne("Cats_API.Models.Cat", null)
                        .WithMany()
                        .HasForeignKey("CatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cats_API.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cats_API.Models.Image", b =>
                {
                    b.HasOne("Cats_API.Models.Cat", "Cat")
                        .WithOne("Image")
                        .HasForeignKey("Cats_API.Models.Image", "CatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cat");
                });

            modelBuilder.Entity("Cats_API.Models.Weight", b =>
                {
                    b.HasOne("Cats_API.Models.Breed", "Breed")
                        .WithOne("Weight")
                        .HasForeignKey("Cats_API.Models.Weight", "BreedId");

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("Cats_API.Models.Breed", b =>
                {
                    b.Navigation("Weight");
                });

            modelBuilder.Entity("Cats_API.Models.Cat", b =>
                {
                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}
