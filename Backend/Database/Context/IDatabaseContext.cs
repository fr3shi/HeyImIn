﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using HeyImIn.Database.Models;

namespace HeyImIn.Database.Context
{
	public delegate IDatabaseContext GetDatabaseContext();

	public interface IDatabaseContext : IDisposable
	{
		// Main tables
		DbSet<User> Users { get; }
		DbSet<Appointment> Appointments { get; }
		DbSet<Event> Events { get; }
		DbSet<Session> Sessions { get; }

		// Many-To-Many relation tables
		DbSet<AppointmentParticipation> AppointmentParticipations { get; }
		DbSet<EventParticipation> EventParticipations { get; }

		// Token tables
		DbSet<PasswordReset> PasswordResets { get; }
		DbSet<EventInvitation> EventInvitations { get; }


		// DbContext methods we want to provide
		Task<int> SaveChangesAsync();
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		IEnumerable<DbEntityValidationResult> GetValidationErrors();
	}
}