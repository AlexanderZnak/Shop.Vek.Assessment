namespace Shop.Vek.Assessment.Tests.Utilities;

/// <summary>
/// Handles directory path creation for various resources required in the test framework.
/// </summary>
internal static class DirectoryBuilder
{
    /// <summary>
    /// The directory path for the base resource folder.
    /// If the folder does not exist, it will be created.
    /// </summary>
    public static readonly string BaseResourceDirectoryPath =
        CreateDirectoryPath(AppContext.BaseDirectory, "Resources");

    /// <summary>
    /// The directory path for the Screenshots subfolder within the base resource folder.
    /// If the folder does not exist, it will be created.
    /// </summary>
    public static readonly string ScreenshotsDirectoryPath =
        CreateDirectoryPath(BaseResourceDirectoryPath, "Screenshots");

    /// <summary>
    /// The directory path for the AttachmentsOnFailed subfolder within the Screenshots folder.
    /// If the folder does not exist, it will be created.
    /// </summary>
    public static readonly string AttachmentsOnFailureDirectoryPath =
        CreateDirectoryPath(ScreenshotsDirectoryPath, "AttachmentsOnFailed");

    /// <summary>
    /// Creates a new directory at the specified path, or returns the path if the directory already exists.
    /// If the directory does not exist, it will be created.
    /// </summary>
    /// <param name="directoryPath">The base path of the directory.</param>
    /// <param name="directoryName">The name of the directory to create.</param>
    /// <returns>The full path of the created directory.</returns>
    private static string CreateDirectoryPath(string directoryPath, string directoryName)
    {
        return Directory.CreateDirectory(Path.Combine(directoryPath, directoryName)).FullName;
    }
}