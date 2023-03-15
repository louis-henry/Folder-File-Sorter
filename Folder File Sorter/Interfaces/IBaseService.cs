// Author:		Louis Henry
// Date:		March 2023
// Environment:	.NET 6.0

using Microsoft.Extensions.Logging;

namespace Folder_File_Sorter.Interfaces
{
    /// <summary>
    /// Interface for base methods in all services
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// Re-usable logging method for all services
        /// </summary>
        /// <param name="_logger"></param>
        /// <param name="ex"></param>
        /// <param name="args"></param>
        void LogForError(ILogger _logger, Exception ex, string[]? args = null);
    }
}
