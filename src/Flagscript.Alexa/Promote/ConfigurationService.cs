﻿using System;
using System.Diagnostics;
using System.IO;

using Microsoft.Extensions.Configuration;

namespace Flagscript.Alexa.Promote
{

	/// <summary>
	/// Hold the configuration stack outside of the asp.net core stack.
	/// </summary>
	public class ConfigurationService : IConfigurationService
	{

		#region Properties

		/// <summary>
		/// The system configuration.
		/// </summary>
		/// <value>The system configuration.</value>
		public IEnvironmentService EnvironmentService { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Default Constructor.
		/// </summary>
		/// <param name="environmentService">Service to access the current environment.</param>
		public ConfigurationService(IEnvironmentService environmentService)
		{
			EnvironmentService = environmentService;
		}

		#endregion

		#region Methods

		/// <summary>
		/// The system configuration.
		/// </summary>
		/// <value>The system configuration.</value>
		public IConfiguration GetConfiguration()
		{
			return new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{EnvironmentService.EnvironmentName}.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables()
				.Build();

		}

		#endregion

	}

}
