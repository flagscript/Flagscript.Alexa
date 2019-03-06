using System;

using static Flagscript.Alexa.Promote.Constants;

namespace Flagscript.Alexa.Promote
{

	/// <summary>
	/// Hold the environment variable outside of the asp.net core stack.
	/// </summary>
	public class EnvironmentService : IEnvironmentService
	{

		#region Properties

		/// <summary>
		/// Configured environment name.
		/// </summary>
		/// <value>Configured environment name.</value>
		public string EnvironmentName { get; set; }

		/// <summary>
		/// Whether or not the current environment is production.
		/// </summary>
		/// <value><c>true</c> if the enviornment is production, otherwise false.</value>
		public bool IsProduction => EnvironmentName == Environments.Production;

		/// <summary>
		/// Whether or not the current environment is staging.
		/// </summary>
		/// <value><c>true</c> if the enviornment is staging, otherwise false.</value>
		public bool IsStaging => EnvironmentName == Environments.Staging;

		/// <summary>
		/// Whether or not the current environment is development.
		/// </summary>
		/// <value><c>true</c> if the enviornment is development, otherwise false.</value>
		public bool IsDevelopment => EnvironmentName == Environments.Development;

		/// <summary>
		/// Whether or not the current environment is unit test.
		/// </summary>
		/// <value><c>true</c> if the enviornment is unit test, otherwise false.</value>
		public bool IsUnitTest => EnvironmentName == Environments.Production;

		#endregion

		#region Constructors

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public EnvironmentService()
		{

			EnvironmentName = Environment.GetEnvironmentVariable(EnvironmentVariables.AspnetCoreEnvironment)
				?? Environments.Production;

		}

		/// <summary>
		/// Unit testing constructor.
		/// </summary>
		/// <param name="environment">Environment to use for unit testing.</param>
		public EnvironmentService(string environment)
		{
			EnvironmentName = environment ?? throw new ArgumentNullException(nameof(environment));
		}

		#endregion

	}

}
