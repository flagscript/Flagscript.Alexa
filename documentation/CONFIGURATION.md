# Configuration (>= v0.2.0)

This section discusses the configuration options available with the Flagscript.Alexa library.

## Project Configuration Files

Although Alexa Lambda functions do not spawn in an ASP.NET Core environment, the Flagscript.Alexa library utilizes packages that provide ASP.NET Core Dependancy Injection and Logging, among other services. This section discusses the available options and how to configure them. 

## Add appsettings.json

In your project, add an appsettings.json file. Make sure you set this file to copy to the output directory. The following is a sample of the options available in the Flagscript.Alexa appsettings.json. 

```json
{
	"FlagscriptAlexa": {
		"AlexaLoggerCategory": "FlagscriptAlexa",
		"EnableAwsLogging": true
	},
	"Logging": {
		"LogLevel": {
			"Default": "Information",
			"Microsoft": "Information",
			"FlagscriptAlexa": "Debug"
		}
	},
	"AWS.Logging": {
		"Region": "us-west-1",
		"LogGroup": "FlagscriptAlexaTestLogGroup",
		"LogLevel": {
			"Default": "Information",
			"Microsoft": "Information",
			"FlagscriptAlexa": "Debug"
		}
	}
}
```

The following explains the configuration options:

* **_FlagscriptAlexa_**: Configuration Settings specific to this library  
  * **_EnableAwsLogging_**: The Flagscript.Alexa project includes an option to send logs to cloud watch using the standard ASP.NET Core logging infrastructionwith a specific log category and to an AWS log group. If you wish to send logs to cloud watch, enable this setting. Disabling this setting will not send the Flagscript.Alexa specific logs to cloud watch (although the ILambdaLogger will send it's standard logs).  
  * **_AlexaLoggerCategory_**: The category name to use for the Flagscript.Alexa ASP.NET Logging ILogger.

* **_Logging_**: Standard logging configuration for the ASP.NET Core Logging Framework. Be sure to include a specific setting for your AlexaLoggerCategory above if you wish.

* **_AWS.Logging_**: Logging configuration if the logger includes a cloudwatch logger enabled with the EnableAwsLogging setting. For more information about this configuration, visit the [ASP.NET Core Logging section in the aws-logging-dotnet project](https://github.com/aws/aws-logging-dotnet).


## ASPNETCORE_ENVIRONMENT

The Flagscript.Alexa library adheres to the ASPNETCORE_ENVIRONMENT environment variable to stay in line with ASP.NET Core. If no value is provided, the Production environment setting will be used.  

You many use any setting you choose including the standards (such as Development and Staging). In addition, the Flagscript.Alexa library recognized the 'UnitTest' setting. If you use the Development or UnitTest setting, both a Console and Debug provider will be added to the ASP.NET Core Logger used by the library.

## appsettings.{ASPNETCORE_ENVIRONMENT}.json

Whichever ASPNETCORE_ENVIRONMENT is specified (including the default of production), the Flagscript.Alexa library will add this on top of the standard appsettings.json. This allows you to override settings for instance on a Development environment. 

Consider the following appsettings.Development.json file. 

```json
{
	"AWS": {
		"Profile": "local-test-profile",
		"Region":  "us-west-1"
	},
	"Logging": {
		"LogLevel": {
			"Default":  "Debug",
			"Microsoft":  "Debug",
			"FlagscriptAlexa": "Debug"
		},
		"Console":  {
			"LogLevel": {
				"Default": "Debug",
				"Microsoft": "Debug",
				"FlagscriptAlexa": "Debug"
			}
		}
	}
}
```

The above will override logger levels if you are runing with the Development ASPNETCORE_ENVIRONMENT. If you include the **_AWS_** configuration block above, in the Development or UnitTest environments the Flagscript.Alexa library will call **_AddDefaultAWSOptions()_** from the **_AWSSDK.Extensions.NETCore.Setup_** library. This is an additional feature if you don't want to use the **_aws-lambda-tools-defaults_** included in the serverless template.

---

That wasn't so bad. [Let's start writing Lambdas for our Alexa Skill](./USING_THE_LIBRARY.md)!