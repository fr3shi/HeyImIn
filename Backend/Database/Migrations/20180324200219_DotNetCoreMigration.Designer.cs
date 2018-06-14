﻿// <auto-generated />
using HeyImIn.Database.Context.Impl;
using HeyImIn.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HeyImIn.Database.Migrations
{
    [DbContext(typeof(HeyImInDatabaseContext))]
    [Migration("20180324200219_DotNetCoreMigration")]
    partial class DotNetCoreMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HeyImIn.Database.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HeyImIn.Database.Models.AppointmentParticipation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppointmentId");

                    b.Property<int?>("AppointmentParticipationAnswer");

                    b.Property<int>("ParticipantId");

                    b.Property<bool>("SentReminder");

                    b.Property<bool>("SentSummary");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ParticipantId", "AppointmentId")
                        .IsUnique();

                    b.ToTable("AppointmentParticipations");
                });

            modelBuilder.Entity("HeyImIn.Database.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<bool>("IsPrivate");

                    b.Property<string>("MeetingPlace")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<int>("OrganizerId");

                    b.Property<int>("ReminderTimeWindowInHours");

                    b.Property<int>("SummaryTimeWindowInHours");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("HeyImIn.Database.Models.EventInvitation", b =>
                {
                    b.Property<Guid>("Token")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<DateTime>("Requested");

                    b.Property<bool>("Used");

                    b.HasKey("Token");

                    b.HasIndex("EventId");

                    b.ToTable("EventInvitations");
                });

            modelBuilder.Entity("HeyImIn.Database.Models.EventParticipation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<int>("ParticipantId");

                    b.Property<bool>("SendLastMinuteChangesEmail");

                    b.Property<bool>("SendReminderEmail");

                    b.Property<bool>("SendSummaryEmail");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("ParticipantId", "EventId")
                        .IsUnique();

                    b.ToTable("EventParticipations");
                });

            modelBuilder.Entity("HeyImIn.Database.Models.PasswordReset", b =>
                {
                    b.Property<Guid>("Token")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Requested");

                    b.Property<bool>("Used");

                    b.Property<int>("UserId");

                    b.HasKey("Token");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordResets");
                });

            modelBuilder.Entity("HeyImIn.Database.Models.Session", b =>
                {
                    b.Property<Guid>("Token")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("UserId");

                    b.Property<DateTime?>("ValidUntil");

                    b.HasKey("Token");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("HeyImIn.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HeyImIn.Database.Models.Appointment", b =>
                {
                    b.HasOne("HeyImIn.Database.Models.Event", "Event")
                        .WithMany("Appointments")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HeyImIn.Database.Models.AppointmentParticipation", b =>
                {
                    b.HasOne("HeyImIn.Database.Models.Appointment", "Appointment")
                        .WithMany("AppointmentParticipations")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HeyImIn.Database.Models.User", "Participant")
                        .WithMany("AppointmentParticipations")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HeyImIn.Database.Models.Event", b =>
                {
                    b.HasOne("HeyImIn.Database.Models.User", "Organizer")
                        .WithMany("OrganizedEvents")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HeyImIn.Database.Models.EventInvitation", b =>
                {
                    b.HasOne("HeyImIn.Database.Models.Event", "Event")
                        .WithMany("EventInvitations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HeyImIn.Database.Models.EventParticipation", b =>
                {
                    b.HasOne("HeyImIn.Database.Models.Event", "Event")
                        .WithMany("EventParticipations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HeyImIn.Database.Models.User", "Participant")
                        .WithMany("EventParticipations")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HeyImIn.Database.Models.PasswordReset", b =>
                {
                    b.HasOne("HeyImIn.Database.Models.User", "User")
                        .WithMany("PasswordResets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HeyImIn.Database.Models.Session", b =>
                {
                    b.HasOne("HeyImIn.Database.Models.User", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}