﻿using System;

using Amazon.Lambda.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Flagscript.Alexa.Request;
using Flagscript.Alexa.Response;
using Flagscript.Alexa.Promote;
using Flagscript.Alexa.Configuration;

namespace Flagscript.Alexa.Lambda
{

	/// <summary>
	/// Base class for Alexa skills in the Flagscript framework.
	/// </summary>
	public abstract class AlexaSkillRequestHandlerLambda
	{

		#region Properties

		/// <summary>
		/// Populated configuration service.
		/// </summary>
		/// <value>Populated configuration service.</value>
		public IConfigurationService ConfigurationService { get; }

		/// <summary>
		/// The configured logger
		/// </summary>
		/// <remarks>
		/// Note - the ILambdaLogger is still available in every call should you prefer.
		/// </remarks>
		public ILogger Logger { get; }

		/// <summary>
		/// Local Service Provider.
		/// </summary>
		/// <value>Local Service Provider.</value>
		public IServiceProvider ServiceProvider { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected AlexaSkillRequestHandlerLambda(IEnvironmentService environmentService = null)
		{

			// Set up Dependency Injection
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection, environmentService);
			ServiceProvider = serviceCollection.BuildServiceProvider();

			// Get service from DI system
			ConfigurationService = ServiceProvider.GetService<IConfigurationService>();

			// Configure Logging
			ConfigureLogging(ServiceProvider);

			// Setup Logger
			AlexaLambdaConfiguration alexaLambdaConfiguration = ServiceProvider.GetService<AlexaLambdaConfiguration>();
			ILoggerFactory loggerFactory = ServiceProvider.GetService<ILoggerFactory>();
			Logger = loggerFactory.CreateLogger(alexaLambdaConfiguration.AlexaLoggerCategory);

		}

		#endregion

		#region Core Handler

		/// <summary>
		/// Handler Lambda function for the alexa skill.
		/// </summary>
		/// <param name="alexaRequest">The alexa skill request.</param>
		/// <param name="lambdaContext">The context of the executing lambda.</param>
		/// <returns>The alexa response.</returns>
		public AlexaResponse HandleAlexaSkillRequest(AlexaRequest alexaRequest, ILambdaContext lambdaContext)
		{

			AlexaResponse response;

			switch (alexaRequest.RequestData.RequestType)
			{
				// Handle Launch request.
				case AlexaRequestType.LaunchRequest:
					AlexaLaunchRequest launchRequest = alexaRequest.RequestData as AlexaLaunchRequest;
					if (Logger.IsEnabled(LogLevel.Debug))
					{
						Logger.LogDebug($"Recieved Alexa Launch Request: ID = {launchRequest.RequestId}");
					}
					response = HandleLaunchRequest(launchRequest, alexaRequest.Context, alexaRequest.Session);
					break;
				// Can not send response to session ended request.
				case AlexaRequestType.SessionEndedRequest:					
					AlexaSessionEndedRequest sessionEndedRequest = alexaRequest.RequestData as AlexaSessionEndedRequest;
					if (Logger.IsEnabled(LogLevel.Debug))
					{
						Logger.LogDebug($"Received Alexa Session Ended Request: ID = {sessionEndedRequest.RequestId}, Reason={sessionEndedRequest.Reason.ToString()}");
					}
					HandleSessionEndedRequest(sessionEndedRequest, alexaRequest.Context, alexaRequest.Session);
					return null;
				case AlexaRequestType.IntentRequest:
					AlexaIntentRequest intentRequest = alexaRequest.RequestData as AlexaIntentRequest;
					if (Logger.IsEnabled(LogLevel.Debug))
					{
						string debug = $"Received Alexa Intent Request: ID = {intentRequest.RequestId}, ";
						debug += $"IntentName = {intentRequest.Intent?.Name}, ";
						if (intentRequest.Intent?.Slots != null)
						{
							debug += $"Slots = {string.Join(",", intentRequest.Intent?.Slots?.Keys)}, ";
							debug += $"Slot Values = {string.Join(",", intentRequest.Intent?.Slots?.Values)}";
						}
						Logger.LogDebug(debug);
					}
					response = HandleIntentRequest(intentRequest, alexaRequest.Context, alexaRequest.Session);
					break;
				case AlexaRequestType.CanFulfillIntentRequest:
					AlexaCanFulfillIntentRequest canFulfillIntentRequest = alexaRequest.RequestData as AlexaCanFulfillIntentRequest;
					if (Logger.IsEnabled(LogLevel.Debug))
					{
						string debug = $"Received Can Fulfill Intent Request: ID = {canFulfillIntentRequest.RequestId}, ";
						Logger.LogDebug(debug);
					}
					response = HandleCanFulfillIntentRequest(canFulfillIntentRequest, alexaRequest.Context, alexaRequest.Session);
					break;
				default:
					Logger.LogError($"Received not implemented Alexa request type: {alexaRequest.RequestData.RequestType}");
					throw new NotImplementedException($"{alexaRequest.RequestData.RequestType} is not yet implemented.");

			}


			return response;
		}

		#endregion

		#region Request Type Handlers

		/// <summary>
		/// Function to handle Alexa launch requests.
		/// </summary>
		/// <param name="launchRequest">The alexa launch request information.</param>
		/// <param name="context">Context of the Alexa execution.</param>
		/// <param name="session">Current Alexa session.</param>
		/// <returns>The Alexa response.</returns>
		public virtual AlexaResponse HandleLaunchRequest(
			AlexaLaunchRequest launchRequest, 
			AlexaContext context, 
			AlexaSession session) 
			=> throw new NotImplementedException("HandleLaunchRequest not yet implemented.");

		/// <summary>
		/// Function to handle Alexa session ended requests.
		/// </summary>
		/// <param name="sessionEndedRequest">The alexa session ended request.</param>
		/// <param name="context">Context of the Alexa execution.</param>
		/// <param name="session">Current Alexa session.</param>
		public virtual void HandleSessionEndedRequest(
			AlexaSessionEndedRequest sessionEndedRequest, 
			AlexaContext context, 
			AlexaSession session) 
			=> throw new NotImplementedException("HandleSessionEndedRequest not yet implemented.");

		/// <summary>
		/// Function to handle Alexa intent requests.
		/// </summary>
		/// <param name="intentRequest">The alexa intent request.</param>
		/// <param name="context">Context of the Alexa execution.</param>
		/// <param name="session">Current Alexa session.</param>
		/// <returns>The Alexa response.</returns>
		public virtual AlexaResponse HandleIntentRequest(
			AlexaIntentRequest intentRequest, 
			AlexaContext context, 
			AlexaSession session) 
			=> throw new NotImplementedException("HandleIntentRequest not yet implemented.");

		/// <summary>
		/// Function to handle Alexa can fullfill intent requests.
		/// </summary>
		/// <param name="canFulfillIntentRequest">The alexa can fulfill intent request.</param>
		/// <param name="context">Context of the Alexa execution.</param>
		/// <param name="session">Current Alexa session.</param>
		/// <returns>The Alexa response.</returns>
		public virtual AlexaResponse HandleCanFulfillIntentRequest(
			AlexaCanFulfillIntentRequest canFulfillIntentRequest, 
			AlexaContext context, 
			AlexaSession session)
			=> throw new NotImplementedException("HandleCanFulfillIntentRequest not yet implemented.");

		#endregion

		#region Dependancy Injection Configuration

		/// <summary>
		/// Configured detault DI services. 
		/// </summary>
		/// <param name="serviceCollection">The DI service collection.</param>
		/// <param name="environmentService">The environment of the skill.</param>
		protected void ConfigureServices(IServiceCollection serviceCollection, IEnvironmentService environmentService = null)
		{
			IEnvironmentService configuredEnvironmentService;
			if (environmentService == null)
			{
				// Standard dotnet environment service.
				EnvironmentService defaultEnvironmentService = new EnvironmentService();
				serviceCollection.AddSingleton<IEnvironmentService>(defaultEnvironmentService);
				configuredEnvironmentService = defaultEnvironmentService;
			}
			else
			{
				// Unit Testing Environment Service
				serviceCollection.AddSingleton(environmentService);
				configuredEnvironmentService = environmentService;
			}


			// Add the configurations 
			ConfigurationService configurationService = new ConfigurationService(configuredEnvironmentService);
			serviceCollection.AddSingleton<IConfigurationService>(configurationService);

			// Add Flagscript Alexa Configuration
			IConfiguration configuration = configurationService.GetConfiguration();
			AlexaLambdaConfiguration alexaLambdaConfiguration = configuration
				.GetSection(AlexaLambdaConfiguration.Configurationname)
				.Get<AlexaLambdaConfiguration>();
			serviceCollection.AddSingleton(alexaLambdaConfiguration);

			// Add aws options for unit test and development
			if (configuredEnvironmentService.IsUnitTest || configuredEnvironmentService.IsDevelopment)
			{
				serviceCollection.AddDefaultAWSOptions(configuration.GetAWSOptions());
			}

			// Add logging
			serviceCollection.AddLogging(builder =>
				builder.AddConfiguration(configurationService.GetConfiguration().GetSection("Logging"))
			);

		}

		/// <summary>
		/// Configures default aws logging for the alexa skill.
		/// </summary>
		/// <param name="serviceProvider">The DI service provider.</param>
		protected void ConfigureLogging(IServiceProvider serviceProvider)
		{

			IEnvironmentService environmentService = serviceProvider.GetService<IEnvironmentService>();
			ILoggerFactory loggerFactory = serviceProvider.GetService<ILoggerFactory>();
			IConfiguration configuration = ConfigurationService.GetConfiguration();

			// Add Console and Debug logging in development/unittest.
			if (environmentService.IsUnitTest || environmentService.IsDevelopment)
			{
				loggerFactory.AddConsole(configuration.GetSection("Logging"));
				loggerFactory.AddDebug();
			}

			// Add AWS logging, optional.
			AlexaLambdaConfiguration alexaLambdaConfiguration = serviceProvider.GetService<AlexaLambdaConfiguration>();
			if (alexaLambdaConfiguration.EnableAlexaLogger)
			{
				loggerFactory.AddAWSProvider(configuration.GetAWSLoggingConfigSection());
			}

		}

		#endregion

	}

}
