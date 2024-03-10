using System.Data.Entity;
using EntityFramework6.Npgsql.Tests.Support;
using NLog.Config;
using NLog.Targets;
using NUnit.Framework;

// ReSharper disable CheckNamespace

[SetUpFixture]
public class AssemblySetup
{
    [OneTimeSetUp]
    public void RegisterDbProvider()
    {
        var config = new LoggingConfiguration();
        var consoleTarget = new ConsoleTarget();
        consoleTarget.Layout = @"${message} ${exception:format=tostring}";
        config.AddTarget("console", consoleTarget);
        var rule = new LoggingRule("*", NLog.LogLevel.Info, consoleTarget);
        config.LoggingRules.Add(rule);
        NLog.LogManager.Configuration = config;

        DbConfiguration.SetConfiguration(new TestDbConfiguration());
    }
}
