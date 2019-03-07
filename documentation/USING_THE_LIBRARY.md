# Using The Library (>= v0.2.0)

The following shows briefly how to handle requests in v0.2.0. This is going to drastically change and the library is not ready until v1.0.0, so this will change in the next release. 

## Modify Function Class

In the Function.cs, make your lambda function inherit from **_AlexaSkillRequestHandlerLambda_**. 

```csharp
using Flagscript.Alexa.Lambda;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace Flagscript.TestAlexaServices 
{

  public class Functions : AlexaSkillRequestHandlerLambda
  {

    /// <summary>
    /// Default constructor that Lambda will invoke.
    /// </summary>
    public Functions() : base()
    {
      // Your things.
    }

  }

}
```

## Override Virtual Handler Methods

The following methods (one or all) can be overridden in your class. Each method will handle a specific Alexa request type. You only need to return an **_AlexaResponse_** for each method that has a response return type. As for the details of what to return, refer to the [Alexa Guide to Fulfilling Basic Types](https://developer.amazon.com/docs/custom-skills/request-and-response-json-reference.html#standard-response-to-canfulfillintentrequest-launchrequest-or-intentrequest-example).

```csharp
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
```

---

That's it until v0.3.0 folks!