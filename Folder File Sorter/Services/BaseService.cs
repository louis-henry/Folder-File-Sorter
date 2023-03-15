// Author:		Louis Henry
// Date:		March 2023
// Environment:	.NET 6.0

using Folder_File_Sorter.Interfaces;
using Microsoft.Extensions.Logging;

namespace Folder_File_Sorter.Services
{
    public class BaseService : IBaseService
    {
        /// <summary>
        /// Re-usable logging method for all services
        /// </summary>
        /// <param name="_logger"></param>
        /// <param name="ex"></param>
        /// <param name="args"></param>
        public void LogForError(ILogger _logger, Exception ex, string[]? args = null)
        {
            switch (ex.GetType().ToString())
            {
                default:
                    _logger.LogError("Exception Type: {0}", ex.GetType().ToString());
                    break;
            }
        }
    }
}
