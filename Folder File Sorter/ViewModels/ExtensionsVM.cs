// Author:		Louis Henry
// Date:		March 2023
// Environment:	.NET 6.0

namespace Folder_File_Sorter.ViewModels
{
    /// <summary>
    /// Extensions view model used for all extension settings via appsettings.json
    /// </summary>
    public class ExtensionsVM
    {
        /// appsettings.json Section
        public const string ExtensionOptions = "Extensions";

        /// <summary>
        /// Option whether to use specified extensions or those provided by default
        /// </summary>
        public bool UseCustomExtensions { get; set; } = false;

        /// <summary>
        /// Software extensions
        /// </summary>
        public string? SoftwareExt { get; set; }

        /// <summary>
        /// Music extensions
        /// </summary>
        public string? MusicExt { get; set; }

        /// <summary>
        /// Photo extensions
        /// </summary>
        public string? PhotoExt { get; set; }

        /// <summary>
        /// Video extensions
        /// </summary>
        public string? VideoExt { get; set; }

        /// <summary>
        /// Compress extensions
        /// </summary>
        public string? CompressExt { get; set; }

        /// <summary>
        /// Doc extensions
        /// </summary>
        public string? DocExt { get; set; }

        /// <summary>
        /// Code extensions
        /// </summary>
        public string? CodeExt { get; set; }

        /// <summary>
        /// System extensions
        /// </summary>
        public string? SystemExt { get; set; }
    }
}
