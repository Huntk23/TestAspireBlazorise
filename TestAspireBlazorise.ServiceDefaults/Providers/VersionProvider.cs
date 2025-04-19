using System.Reflection;

namespace Microsoft.Extensions.Hosting.Providers;

internal class VersionProvider : IVersionProvider
{
    Lazy<Version> version;

    public VersionProvider()
    {
        version = new Lazy<Version>(() => Assembly.GetExecutingAssembly().GetName().Version);
    }

    public string Version => version.Value.ToString();

    public string MilestoneVersion => version.Value.ToString(3);
}

/// <summary>
/// Provider used to get the Blazorise version number.
/// </summary>
public interface IVersionProvider
{
    /// <summary>
    /// Gets the version number.
    /// </summary>
    string Version { get; }

    /// <summary>
    /// Gets the milestone version number.
    /// </summary>
    string MilestoneVersion { get; }
}