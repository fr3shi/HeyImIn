﻿using HeyImIn.WebApplication.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace HeyImIn.WebApplication.WebApiComponents
{
	/// <summary>
	///     Authenticates the user and calls <see cref="HttpActionExtensions.SetUserId" /> &
	///     <see cref="HttpActionExtensions.SetSessionToken" />
	/// </summary>
	public class AuthenticateUserAttribute : AuthorizeAttribute
	{
		public AuthenticateUserAttribute() : base("RequiresLogin")
		{
		}
	}
}