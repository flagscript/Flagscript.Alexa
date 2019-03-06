using Microsoft.Extensions.Configuration;

namespace Flagscript.Alexa.Promote
{

	/// <summary>
	/// Interface to hold the configuration stack outside of the asp.net core stack.
	/// </summary>
	public interface IConfigurationService
	{

		/// <summary>
		/// The system configuration.
		/// </summary>
		/// <value>The system configuration.</value>
		IConfiguration GetConfiguration();

	}

}
