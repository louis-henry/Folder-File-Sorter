// Author:		Louis Henry
// Date:		March 2023
// Environment:	.NET 6.0

using Folder_File_Sorter.Services;
using Folder_File_Sorter.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;

namespace Folder_File_Sorter.Controllers
{
    /// <summary>
    /// Controller class for Utility
    /// </summary>
    public class AppController
    {
        private readonly AppSettings _appSettings;
        private readonly ExtensionsVM _extensions;
        private DocumentService _docServ;

        /// Constructor
        public AppController(IHost host, IOptions<AppSettings> appSettings, IOptions<ExtensionsVM> extensions)
        {
            _appSettings = appSettings.Value;
            _extensions = extensions.Value;

            _docServ = ActivatorUtilities.CreateInstance<DocumentService>(host.Services);

            Log.Logger.Information("Application Started Successfully");
        }

        /// <summary>
        /// Run main application
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RunApp()
        {
            if (_docServ.HasValidSetup())
            {
                if (_docServ.ProcessFiles())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
