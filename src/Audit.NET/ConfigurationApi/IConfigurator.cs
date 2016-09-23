using System;

namespace Audit.Core.ConfigurationApi
{
    /// <summary>
    /// Provides a configuration for Audit mechanism.
    /// </summary>
    public interface IConfigurator
    {
        /// <summary>
        /// Store the events in files.
        /// </summary>
        /// <param name="config">The file log provider configuration.</param>
        ICreationPolicyConfigurator UseFileLogProvider(Action<IFileLogProviderConfigurator> config);
        /// <summary>
        /// Store the events in files.
        /// </summary>
        /// <param name="directoryPath">Specifies the directory where to store the audit log files.</param>
        /// <param name="filenamePrefix">Specifies the filename prefix to use in the audit log files.</param>
        ICreationPolicyConfigurator UseFileLogProvider(string directoryPath = null, string filenamePrefix = null, Func<AuditEvent, string> directoryPathBuilder = null,
            Func<AuditEvent, string> filenameBuilder = null);
#if NET45
        /// <summary>
        /// Store the events in the windows Event Log.
        /// </summary>
        /// <param name="logName">The windows event log name to use</param>
        /// <param name="sourcePath">The source path to use</param>
        /// <param name="machineName">The name of the machine where the event logs will be save. Default is "." (local machine)</param>
        ICreationPolicyConfigurator UseEventLogProvider(string logName = "Application", string sourcePath = "Application", string machineName = ".");
        /// <summary>
        /// Store the events in the windows Event Log.
        /// </summary>
        /// <param name="config">The windows event log configuration</param>
        ICreationPolicyConfigurator UseEventLogProvider(Action<IEventLogProviderConfigurator> config);
#endif
        /// <summary>
        /// Use a custom provider for the event output.
        /// </summary>
        ICreationPolicyConfigurator UseCustomProvider(AuditDataProvider provider);
    }
}