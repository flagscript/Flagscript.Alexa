namespace Flagscript.Alexa.Configuration
{

	/// <summary>
	/// appsettings.json configuration values for the Alexa Lambda handler. 
	/// </summary>
	public class AlexaLambdaConfiguration
	{

		#region Const/Static

		/// <summary>
		/// Configuration Section name.
		/// </summary>
		public const string Configurationname = "FlagscriptAlexa";

		#endregion

		#region Configuration Properties

		/// <summary>
		/// The category for this alexa function implementation.
		/// </summary>
		/// <value>The alexa logger category.</value>
		public string AlexaLoggerCategory { get; set; }

		/// <summary>
		/// Whether or not to create the Alexa Logger.
		/// </summary>
		/// <value><c>true</c> if enable alexa logger; otherwise, <c>false</c>.</value>
		public bool EnableAlexaLogger { get; set; }

		#endregion

	}

}
