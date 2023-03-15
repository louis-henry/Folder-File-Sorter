// Author:		Louis Henry
// Date:		March 2023
// Environment:	.NET 6.0

namespace Folder_File_Sorter.ViewModels
{
    /// <summary>
    /// AppSettings view model used for all input settings via appsettings.json
    /// </summary>
    public class AppSettings
    {
        /// appsettings.json Section
        public const string AppSettingsOptions = "Settings";

        /// <summary>
        /// Retrieval path where files will be moved from 
        /// </summary>
        public string FromPath { get; set; } = "";

        /// <summary>
        /// Flag to indicate whether the file should be moved to misc if the relevant folder path has not been setup
        /// </summary>
        public bool MoveToMiscWhenNoFilePath { get; set; } = true;

        /// <summary>
        /// Target path for software related files (eg. exe)
        /// </summary>
        public string? SoftwareFilePath { get; set; }

        /// <summary>
        /// Target path for music related files (eg. wav, mp3, flac)
        /// </summary>
        public string? MusicFilePath { get; set; }

        /// <summary>
        /// Target path for photo related files (eg. png, jpeg)
        /// </summary>
        public string? PhotoFilePath { get; set; }

        /// <summary>
        /// Target path for video related files (eg. mkv, mp4)
        /// </summary>
        public string? VideoFilePath { get; set; }

        /// <summary>
        /// Target path for zip related files (eg. rar, zip)
        /// </summary>
        public string? CompressFilePath { get; set; }

        /// <summary>
        /// Target path for doc related files (eg. docx, xlxs)
        /// </summary>
        public string? DocFilePath { get; set; }

        /// <summary>
        /// Target path for programming related files (eg. c, py)
        /// </summary>
        public string? CodeFilePath { get; set; }

        /// <summary>
        /// Target path for system related files (eg. dll, msi)
        /// </summary>
        public string? SystemFilePath { get; set; }

        /// <summary>
        /// Target path for misc files
        /// </summary>
        public string MiscFilePath { get; set; } = "";
    }
}
