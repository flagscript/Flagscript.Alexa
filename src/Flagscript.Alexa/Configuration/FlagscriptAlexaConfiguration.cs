namespace Flagscript.Alexa.Configuration
{

	/// <summary>
	/// appsettings.json configuration values for the Flagscript Alexa handler. 
	/// </summary>
	public class FlagscriptAlexaConfiguration
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

		/// <summary>
		/// The tolerance in seconds when an out of bounds timestamp should yield a bad request.
		/// </summary>
		/// <value>The timestamp tolerance in seconds..</value>
		public int TimestampTolerance { get; set; } = 250;

		#endregion

	}

}
