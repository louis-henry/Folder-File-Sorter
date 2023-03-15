// Author:		Louis Henry
// Date:		March 2023
// Environment:	.NET 6.0

namespace Folder_File_Sorter.Resources
{
    /// <summary>
    /// Helper class for logging
    /// </summary>
    public static class LogMessage
    {
        public static string FILE_FAIL_OPERATION { get { return "Failed to {0} file (name: {1}, from: {2})"; } }
        public static string FILE_SUCCESS_OPERATION { get { return "Sucessfully {0} file (name: {1}, from: {2}, to: {3})"; } }
        public static string NO_MIN_REQ { get { return "The application must have a FromPath and MiscPath specified in appsettings.json"; } }
        public static string NO_PATH { get { return "The specified folder path does not exist"; } }
        public static string NO_FOLDER_PATH { get { return "No folder path has been specified for the {0} folder"; } }
    }
}
