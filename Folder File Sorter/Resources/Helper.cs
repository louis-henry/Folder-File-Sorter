// Author:		Louis Henry
// Date:		March 2023
// Environment:	.NET 6.0

namespace Folder_File_Sorter.Resources
{
    /// <summary>
    /// Helper class for console app
    /// </summary>
    public static class Helper
    {
        public static KeyValuePair<Extension, string> SOFTWARE_EXT 
        { 
            get 
            { 
                return new KeyValuePair<Extension, string>(Extension.SOFTWARE, ".exe|.bat|.com|.cmd|.inf|.ipa|.osx|.pif|.run"); 
            } 
        }
        public static KeyValuePair<Extension, string> MUSIC_EXT 
        { 
            get 
            { 
                return new KeyValuePair<Extension, string>(Extension.MUSIC, ".m4a|.flac|.mp3|.wav|.wma|.aac|.aiff|.alac|.dsd|.mqa|.ogg");
            } 
        }
        public static KeyValuePair<Extension, string> PHOTO_EXT 
        { 
            get 
            { 
                return new KeyValuePair<Extension, string>(Extension.PHOTO, ".jpeg|.gif|.png|.tiff|.psd|.ai|.indd|.raw|.svg|.eps|.xcf|.psd|.heif|.wdbp|.heic"); 
            } 
        }
        public static KeyValuePair<Extension, string> VIDEO_EXT 
        { 
            get 
            {
                return new KeyValuePair<Extension, string>(Extension.VIDEO, ".mp4|.mov|.wmv|.avi|.avchd|.flv|.f4v|.swf|.mkv|.webm|.vod|.mng|.asf|.amv|.mpeg|.mpg|mpv|.svi");
            } 
        }
        public static KeyValuePair<Extension, string> DOC_EXT 
        { 
            get 
            {
                return new KeyValuePair<Extension, string>(Extension.DOC, ".doc|.docx|.csv|.xls|.xlsx|.ppt|.pptx|.pdf|.txt|.json|.wpd|.rtf");
            } 
        }
        public static KeyValuePair<Extension, string> CODE_EXT 
        { 
            get 
            {
                return new KeyValuePair<Extension, string>(Extension.CODE, ".cs|.py|.ts|.c|.java|.php|.html|.css|.vb|.swift"); 
            } 
        }
        public static KeyValuePair<Extension, string> SYSTEM_EXT 
        { 
            get 
            {
                return new KeyValuePair<Extension, string>(Extension.SYSTEM, ".sys|.tmp|.icns|.ini|.cgf|.msi|.ico|.dll|.cer|.crt|.pfx");
            }
        }
        public static KeyValuePair<Extension, string> COMPRESS_EXT 
        { 
            get 
            {
                return new KeyValuePair<Extension, string>(Extension.COMPRESS, ".zip|.rar|.pkg|.tar|.xz|.gzip|.iso|.gz|.7z|.s7z"); 
            }
        }

        public static List<KeyValuePair<Extension, string>> GetDefaultExtenionList()
        {
            return new List<KeyValuePair<Extension, string>> { SOFTWARE_EXT, MUSIC_EXT, PHOTO_EXT, VIDEO_EXT, DOC_EXT, CODE_EXT, SYSTEM_EXT, COMPRESS_EXT };
        }
    }

    /// <summary>
    /// Extension types used
    /// </summary>
    public enum Extension
    {
        INVALID = -1,
        FROM,
        SOFTWARE,
        MUSIC,
        PHOTO,
        VIDEO,
        DOC,
        CODE,
        SYSTEM,
        COMPRESS,
        MISC
    }
}
