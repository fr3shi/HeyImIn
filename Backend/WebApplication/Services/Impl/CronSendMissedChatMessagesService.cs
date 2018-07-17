﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HeyImIn.Database.Context;
using HeyImIn.Database.Models;
using HeyImIn.MailNotifier;
using HeyImIn.MailNotifier.Models;
using HeyImIn.Shared;
using Microsoft.EntityFrameworkCore;

namespace HeyImIn.WebApplication.Services.Impl
{
	/// <summary>
	///     Sends notifications for missed chat messages.
	///     Chat messages are sent in bulk to prevent spam.
	/// </summary>
	public class CronSendMissedChatMessagesService : ICronService
	{
		public CronSendMissedChatMessagesService(INotificationService notificationService, HeyImInConfiguration configuration, GetDatabaseContext getDatabaseContext)
		{
			_notificationService = notificationService;
			_minimumChatMessageNotificationTimeSpan = configuration.TimeSpans.MinimumChatMessageNotificationTimeSpan;
			_getDatabaseContext = getDatabaseContext;
		}

		public async Task RunAsync(CancellationToken token)
		{
			IDatabaseContext context = _getDatabaseContext();

			DateTime maxAge = DateTime.UtcNow - _minimumChatMessageNotificationTimeSpan;

			var chatMessagesToNotifyAbout = await context.EventParticipations
				.Select(ep => new
				{
					participation = ep,
					participant = ep.Participant,
					eventId = ep.EventId,
					eventTitle = ep.Event.Title,
					messages = ep.Event.ChatMessages
						.AsQueryable()
						.Where(c => c.SentDate < maxAge)
						.Where(c => c.SentDate > ep.LastReadMessageSentDate)
						.OrderByDescending(c => c.SentDate)
						.Select(c => new { authorName = c.Author.FullName, sentDate = c.SentDate, content = c.Content })
				})
				.Where(x => x.messages.AsQueryable().Any())
				.ToListAsync(token);

			foreach (var chatMessage in chatMessagesToNotifyAbout)
			{
				List<ChatMessageNotificationInformation> messages = chatMessage.messages.Select(m => new ChatMessageNotificationInformation(m.authorName, m.sentDate, m.content)).ToList();
				await _notificationService.NotifyUnreadChatMessagesAsync(new ChatMessagesNotificationInformation(chatMessage.eventId, chatMessage.eventTitle, chatMessage.participant, messages));

				chatMessage.participation.LastReadMessageSentDate = messages[0].SentDate;
			}

			// Save sent chat messages
			await context.SaveChangesAsync(token);
		}

		public string DescriptiveName { get; } = "SendMissedChatMessagesCron";

		private readonly INotificationService _notificationService;
		private readonly GetDatabaseContext _getDatabaseContext;
		private readonly TimeSpan _minimumChatMessageNotificationTimeSpan;
	}
}