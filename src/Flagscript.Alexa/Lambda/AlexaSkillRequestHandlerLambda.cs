using System;
using System.Text;

using Amazon.Lambda.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Flagscript.Alexa.Handler;
using Flagscript.Alexa.Request;
using Flagscript.Alexa.Response;
using Flagscript.Alexa.Configuration;
using Flagscript.Aws.Startup;

namespace Flagscript.Alexa.Lambda
{

	/// <summary>
	/// Base class for Alexa skills in the Flagscript framework.
	/// </summary>
	public abstract class AlexaSkillRequestHandlerLambda
	{

		#region Properties

		/// <summary>
		/// Flagscript Alexa Configuration
		/// </summary>
		/// <value>The flagscript alexa configuration.</value>
		public FlagscriptAlexaConfiguration FlagscriptAlexaConfiguration { get; }

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

		/// <summary>
		/// The Alexa Request Handler for this skill.
		/// </summary>
		/// <value>The alexa request handler for this skill.</value>
		public IAlexaRequestHandler AlexaRequestHandler { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected AlexaSkillRequestHandlerLambda(IEnvironmentService environmentService = null)
		{

			// Set up Dependency Injection
			var serviceCollection = new ServiceCollection();
			ConfigureDefaultServices(serviceCollection, environmentService);
			ServiceProvider = serviceCollection.BuildServiceProvider();

			// Get configuration service from DI system
			ConfigurationService = ServiceProvider.GetService<IConfigurationService>();

			// Get Alexa request handler from DI system
			AlexaRequestHandler = ServiceProvider.GetService<IAlexaRequestHandler>();

			// Configure Logging
			ConfigureLogging(ServiceProvider);

			// Setup Logger
			FlagscriptAlexaConfiguration fsAlexaConfiguration = ServiceProvider.GetService<FlagscriptAlexaConfiguration>();
			ILoggerFactory loggerFactory = ServiceProvider.GetService<ILoggerFactory>();
			Logger = loggerFactory.CreateLogger(fsAlexaConfiguration.AlexaLoggerCategory);

			// Setup Request Handler

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

			// Perform Validations

			// Validate we have a request. 
			if (alexaRequest == null)
			{
				// 400 bad response
			}

			// Validate the timestamp properties.

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
					// response = HandleLaunchRequest(launchRequest, alexaRequest.Context, alexaRequest.Session);
					ILaunchRequestHandler launchRequestHandler = AlexaRequestHandler.GetLaunchRequestHandler();
					response = null;
					break;

				// Handle Session ended request. Note, session ended does not return a response. 
				case AlexaRequestType.SessionEndedRequest:					
					AlexaSessionEndedRequest sessionEndedRequest = alexaRequest.RequestData as AlexaSessionEndedRequest;
					if (Logger.IsEnabled(LogLevel.Debug))
					{
						Logger.LogDebug($"Received Alexa Session Ended Request: ID = {sessionEndedRequest.RequestId}, Reason={sessionEndedRequest.Reason.ToString()}");
					}
					ISessionEndedRequestHandler sessionEndedRequestHandler = AlexaRequestHandler.GetSessionEndedRequestHandler();
					sessionEndedRequestHandler.HandleRequest(sessionEndedRequest, alexaRequest.Context, alexaRequest.Session);
					return null;

				// Handle Intent Request
				case AlexaRequestType.IntentRequest:
					AlexaIntentRequest intentRequest = alexaRequest.RequestData as AlexaIntentRequest;
					if (Logger.IsEnabled(LogLevel.Debug))
					{
						StringBuilder debugBuilder = new StringBuilder();
						debugBuilder.Append($"Received Alexa Intent Request: ID = {intentRequest.RequestId}, ");
						debugBuilder.Append($"IntentName = {intentRequest.Intent?.Name}, ");

						if (intentRequest.Intent?.Slots != null)
						{
							debugBuilder.Append($"Slots = {string.Join(",", intentRequest.Intent?.Slots?.Keys)}, ");
							debugBuilder.Append($"Slot Values = {string.Join(",", intentRequest.Intent?.Slots?.Values)}");
						}
						Logger.LogDebug(debugBuilder.ToString());
					}
					// response = HandleIntentRequest(intentRequest, alexaRequest.Context, alexaRequest.Session);
					IIntentRequestHandler intentRequestHandler = AlexaRequestHandler.GetIntentRequestHandler();
					response = null;
					break;

				// Handle Can Fulfill Intent Request
				case AlexaRequestType.CanFulfillIntentRequest:
					AlexaCanFulfillIntentRequest canFulfillIntentRequest = alexaRequest.RequestData as AlexaCanFulfillIntentRequest;
					if (Logger.IsEnabled(LogLevel.Debug))
					{
						string debug = $"Received Can Fulfill Intent Request: ID = {canFulfillIntentRequest.RequestId}, ";
						Logger.LogDebug(debug);
					}
					// response = HandleCanFulfillIntentRequest(canFulfillIntentRequest, alexaRequest.Context, alexaRequest.Session);
					ICanFulfillIntentRequestHandler canFulfillIntentRequestHandler = 
						AlexaRequestHandler.GetCanFulfillIntentRequestHandler();
					response = null;
					break;

				default:
					Logger.LogError($"Received not implemented Alexa request type: {alexaRequest.RequestData.RequestType}");
					throw new NotImplementedException($"{alexaRequest.RequestData.RequestType} is not yet implemented.");

			}


			return response;
		}

		#endregion

		#region Dependancy Injection Configuration

		/// <summary>
		/// Configured detault DI services. 
		/// </summary>
		/// <param name="serviceCollection">The DI service collection.</param>
		/// <param name="environmentService">The environment of the skill.</param>
		private void ConfigureDefaultServices(IServiceCollection serviceCollection, IEnvironmentService environmentService = null)
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
			FlagscriptAlexaConfiguration fsAlexaConfiguration = configuration
				.GetSection(FlagscriptAlexaConfiguration.Configurationname)
				.Get<FlagscriptAlexaConfiguration>();
			serviceCollection.AddSingleton(fsAlexaConfiguration);

			// Add aws options for unit test and development
			if (configuredEnvironmentService.IsUnitTest || configuredEnvironmentService.IsDevelopment)
			{
				serviceCollection.AddDefaultAWSOptions(configuration.GetAWSOptions());
			}

			// Add logging
			serviceCollection.AddLogging(builder =>
				builder.AddConfiguration(configurationService.GetConfiguration().GetSection("Logging"))
			);

			// Add the request handler
			serviceCollection.AddSingleton<IAlexaRequestHandler>(GetSkillRequestHandler());

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
			FlagscriptAlexaConfiguration fsAlexaConfiguration = serviceProvider.GetService<FlagscriptAlexaConfiguration>();
			if (fsAlexaConfiguration.EnableAlexaLogger)
			{
				loggerFactory.AddAWSProvider(configuration.GetAWSLoggingConfigSection());
			}

		}

		#endregion

		#region Abstract Methods

		public abstract IAlexaRequestHandler GetSkillRequestHandler();

		#endregion

	}

}
