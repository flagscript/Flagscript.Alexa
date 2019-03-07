# Project Setup (>= v0.2.0)

The Flagscript.Alexa library is meant to be used within a .NET Core 2.1 Lambda Library Project. If you have knowledge on Lambda projects, you can skip this section. If not, the easiest way to start is by using 
the Lambda serverless template. 


## Install Amazon.Lambda.Templates

The easiest way to create a project with a lambda template is to install the Amazon.Lambda.Templates to the dotnet command line. 

```bash
dotnet install -i Amazon.Lambda.Templates
dotnet new -all
```
The new command should now display amazon templates, including the **_serverless.EmptyServerless_** template.

## Create a New Serverless Project

Select the location of your new project, and decide on a namespace you would like to use for your project. We will create an example project named TextAlexaServerless in the Flagscript namespace. 

```bash
cd [your directory here]
dotnet new serverless.EmptyServerless --name Flagscript.TestAlexaServerless
```

For more information on creating preojects with the CLI, please visit the [AWS .NET Core CLI Page](https://docs.aws.amazon.com/lambda/latest/dg/lambda-dotnet-coreclr-deployment-package.html).

## Add Flagscript.Alexa

Now we will add the Flagscript.Alexa nuget to the newly created project. 

```bash
dotnet add ./Flagscript.TestAlexaServerless/src/Flagscript.TestAlexaServerless/Flagscript.TestAlexaServerless.csproj package Flagscript.Alexa
```
---

That's it! We are now ready to open the project and [configure it](./CONFIGURATION.md)!
