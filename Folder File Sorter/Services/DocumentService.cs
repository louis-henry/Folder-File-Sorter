// Author:		Louis Henry
// Date:		March 2023
// Environment:	.NET 6.0

using Folder_File_Sorter.ViewModels;
using Folder_File_Sorter.Interfaces;
using Microsoft.Extensions.Logging;
using Folder_File_Sorter.Resources;
using Microsoft.Extensions.Options;

namespace Folder_File_Sorter.Services
{
    /// <summary>
    /// Document data handling service
    /// </summary>
    public class DocumentService : BaseService, IDocumentService
    {
        private readonly ILogger<DocumentService> _logger;
        private readonly ExtensionsVM _extensions;
        private readonly AppSettings _appSettings;

        /// Constructor
        public DocumentService(ILogger<DocumentService> logger, IOptions<AppSettings> appSettings, IOptions<ExtensionsVM> extensions)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
            _extensions = extensions.Value;
        }

        /// <summary>
        /// Check if the appsettings contains the minimum information required to run
        /// </summary>
        /// <returns>Success or fail bool</returns>
        public bool HasValidSetup()
        {
            /// Check mandatory folder paths for values and if the paths exist
            foreach (var fp in GetMandatoryFolderPaths())
            {
                if (string.IsNullOrEmpty(fp.Value))
                {
                    _logger.LogError(LogMessage.NO_MIN_REQ);
                    return false;
                }
                
                if (!Directory.Exists(fp.Value))
                {
                    _logger.LogError(LogMessage.NO_PATH);
                    return false;
                }
            }

            foreach (var fp in GetOptionalFolderPaths())
            {
                /// No path has been specified but we can still continue
                if (string.IsNullOrEmpty(fp.Value))
                {
                    _logger.LogWarning(LogMessage.NO_FOLDER_PATH, fp.Key.ToString());
                }
                else
                {
                    /// We do not want to continue when a path is specified but it does not exist
                    if (!Directory.Exists(fp.Value))
                    {
                        _logger.LogError(LogMessage.NO_PATH);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Get a list of the optional file paths, to check if they are valid
        /// </summary>
        /// <returns>A list of key value pairs with both extension type and folder path</returns>
        private List<KeyValuePair<Extension, string>> GetMandatoryFolderPaths()
        {
            return new List<KeyValuePair<Extension, string>>
            {
                new KeyValuePair<Extension, string>(Extension.FROM, _appSettings.FromPath),
                new KeyValuePair<Extension, string>(Extension.MISC, _appSettings.MiscFilePath),
            };
        }

        /// <summary>
        /// Get a list of the optional file paths, to check if they are valid
        /// </summary>
        /// <returns>A list of key value pairs with both extension type and folder path</returns>
        private List<KeyValuePair<Extension, string?>> GetOptionalFolderPaths()
        {
            return new List<KeyValuePair<Extension, string?>>
            {
                new KeyValuePair<Extension, string?>(Extension.SOFTWARE, _appSettings.SoftwareFilePath),
                new KeyValuePair<Extension, string?>(Extension.MUSIC, _appSettings.MusicFilePath),
                new KeyValuePair<Extension, string?>(Extension.PHOTO, _appSettings.PhotoFilePath),
                new KeyValuePair<Extension, string?>(Extension.VIDEO, _appSettings.VideoFilePath),
                new KeyValuePair<Extension, string?>(Extension.DOC, _appSettings.DocFilePath),
                new KeyValuePair<Extension, string?>(Extension.CODE, _appSettings.CodeFilePath),
                new KeyValuePair<Extension, string?>(Extension.SYSTEM, _appSettings.SystemFilePath),
                new KeyValuePair<Extension, string?>(Extension.COMPRESS, _appSettings.CompressFilePath)
            };
        }

        /// <summary>
        /// Process all the files in the specified folder
        /// </summary>
        /// <returns>Success or fail bool</returns>
        public bool ProcessFiles()
        {
            try
            {
                if (Directory.Exists(_appSettings.FromPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(_appSettings.FromPath);
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        if (CopyFile(file.Name))
                        {
                            DeleteFile(file.Name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogForError(_logger, ex);
            }
            return false;
        }

        /// <summary>
        /// Get the extension via the file name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Extension type</returns>
        private Extension GetExtension(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Extension.INVALID;
            }

            int index = name.LastIndexOf(".");
            if (index > 1)
            {
                string ext = name.Substring(index).ToLower();
                
                if (_extensions.UseCustomExtensions)
                {
                    return GetCustomExtension(ext);
                }
                else
                {
                    foreach (var format in Helper.GetDefaultExtenionList())
                    {
                        if (format.Value.Contains(ext))
                        {
                            return format.Key;
                        }
                    }
                }
            }

            return Extension.MISC;
        }

        /// <summary>
        /// Used to find the correct extension type when user has specified a custom list
        /// </summary>
        /// <param name="extension"></param>
        /// <returns>Extension type</returns>
        private Extension GetCustomExtension(string extension)
        {
            if (_extensions.SoftwareExt != null && _extensions.SoftwareExt.Contains(extension))
            {
                return Extension.SOFTWARE;
            }
            else if (_extensions.MusicExt != null && _extensions.MusicExt.Contains(extension))
            {
                return Extension.MUSIC;
            }
            else if (_extensions.PhotoExt != null && _extensions.PhotoExt.Contains(extension))
            {
                return Extension.PHOTO;
            }
            else if (_extensions.VideoExt != null && _extensions.VideoExt.Contains(extension))
            {
                return Extension.VIDEO;
            }
            else if (_extensions.DocExt != null && _extensions.DocExt.Contains(extension))
            {
                return Extension.DOC;
            }
            else if (_extensions.CodeExt != null && _extensions.CodeExt.Contains(extension))
            {
                return Extension.CODE;
            }
            else if (_extensions.SystemExt != null && _extensions.SystemExt.Contains(extension))
            {
                return Extension.SYSTEM;
            }
            else if (_extensions.CompressExt != null && _extensions.CompressExt.Contains(extension))
            {
                return Extension.COMPRESS;
            }
            return Extension.MISC;
        }

        /// <summary>
        /// Delete a file from a specified path
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Success or fail bool</returns>
        private bool DeleteFile(string fileName)
        {
            try
            {
                File.Delete(Path.Combine(_appSettings.FromPath, fileName));
                _logger.LogInformation(LogMessage.FILE_SUCCESS_OPERATION, "deleted", fileName, _appSettings.FromPath, "N/A");
                return true;
            }
            catch (Exception ex)
            {
                LogForError(_logger, ex);
            }
            _logger.LogInformation(LogMessage.FILE_FAIL_OPERATION, "delete", fileName, _appSettings.FromPath);
            return false;
        }

        /// <summary>
        /// Copy the file to new path
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Success or fail bool</returns>
        private bool CopyFile(string fileName)
        {
            try
            {
                string? toPath = GetPathToWrite(GetExtension(fileName));
                if (!string.IsNullOrEmpty(toPath))
                {
                    string origFileName = fileName;
                    fileName = EnsureUniqueFileName(toPath, fileName);
                    File.Copy(Path.Combine(_appSettings.FromPath, origFileName), Path.Combine(toPath, fileName));
                    _logger.LogInformation(LogMessage.FILE_SUCCESS_OPERATION, "copied", fileName, _appSettings.FromPath, toPath);
                    return true;
                }
                else
                {
                    /// Copy to misc path when toPath cannot return a value (eg. when no path is specified)
                    if (_appSettings.MoveToMiscWhenNoFilePath)
                    {
                        File.Copy(Path.Combine(_appSettings.FromPath, fileName), Path.Combine(_appSettings.MiscFilePath, fileName));
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogForError(_logger, ex);
            }
            _logger.LogInformation(LogMessage.FILE_FAIL_OPERATION, "copy", fileName, _appSettings.FromPath);
            return false;
        }

        /// <summary>
        /// Ensures that the fileName is unique (eg. will add _1.extension, _2, _3 etc.)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns>A unique file name if one duplicate of original name is found</returns>
        private string EnsureUniqueFileName(string path, string fileName)
        {
            try
            {
                bool isUnique = false;
                int extIndex = fileName.LastIndexOf(".");
                string name = extIndex == -1 ? fileName : fileName.Substring(0, (fileName.Length - (fileName.Length - extIndex)));
                string extension = extIndex == -1 ? ".unknown" : fileName.Substring(extIndex);
                if (extIndex == -1)
                {
                    fileName = fileName + extension;
                }
                int count = 1;

                while (!isUnique)
                {
                    if (System.IO.File.Exists(Path.Combine(path, fileName)))
                    {
                        if (fileName.Contains("_" + (count - 1).ToString() + "."))
                        {
                            fileName.Replace(("_" + (count - 1).ToString() + "."), ".");
                        }
                        fileName = name + "_" + count.ToString() + extension;
                    }
                    else
                    {
                        isUnique = true;
                    }
                    count++;

                    /// This should never occur, but as a safegaurd against a hung process, we will exit an infinite While
                    /// loop
                    if (count > 500)
                    {
                        isUnique = true;
                    }
                }
                return fileName;
            }
            catch (Exception ex)
            {
                LogForError(_logger, ex);
            }
            return fileName;
        }

        /// <summary>
        /// Get the path to write based on the extension of the file
        /// </summary>
        /// <param name="extension"></param>
        /// <returns>The path of where to copy the doc</returns>
        private string? GetPathToWrite(Extension extension)
        {
            switch(extension)
            {
                case Extension.SOFTWARE:
                   return _appSettings.SoftwareFilePath;

                case Extension.MUSIC:
                    return _appSettings.MusicFilePath;

                case Extension.PHOTO:
                    return _appSettings.PhotoFilePath;

                case Extension.VIDEO:
                    return _appSettings.VideoFilePath;

                case Extension.DOC:
                    return _appSettings.DocFilePath;

                case Extension.CODE:
                    return _appSettings.CodeFilePath;

                case Extension.SYSTEM:
                    return _appSettings.SystemFilePath;

                case Extension.COMPRESS:
                    return _appSettings.CompressFilePath;

                case Extension.MISC:
                    return _appSettings.MiscFilePath;
            }
            return null;
        }
    }
}
