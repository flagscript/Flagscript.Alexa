using System.Runtime.CompilerServices;

using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;

// Enable Lambda Serializion
[assembly: LambdaSerializer(typeof(JsonSerializer))]

// Make internals visible to unit testing
[assembly: InternalsVisibleTo("Flagscript.Alexa.Test")]
