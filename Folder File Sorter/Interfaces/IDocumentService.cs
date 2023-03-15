// Author:		Louis Henry
// Date:		March 2023
// Environment:	.NET 6.0

using Folder_File_Sorter.Resources;

namespace Folder_File_Sorter.Interfaces
{
    /// <summary>
    /// Interface for methods in document service
    /// </summary>
    public interface IDocumentService
    {
        /// <summary>
        /// Check if the appsettings contains the minimum information required to run
        /// </summary>
        /// <returns>Success or fail bool</returns>
        bool HasValidSetup();

        /// <summary>
        /// Process all the files in the specified folder
        /// </summary>
        /// <returns>Success or fail bool</returns>
        bool ProcessFiles();
    }
}
