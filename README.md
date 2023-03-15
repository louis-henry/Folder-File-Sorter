# Folder File Sorter
A simple console application designed to sort files from a source folder into sub folders (based on the file extension).

## About
This application is purely a hobby project intended for my own personal use. The aim was to target a generic 'Downloads' folder where many types of files are often put together. Instead of having to manually sort, this application can do this for you by moving files into generic folder types (eg. Music, Photos, Videos etc.). Users may dictate their own extensions or simply use a generic list (as specified below). 

## Setup
In the appsettings.json file, please ensure the following values have been setup for any functionality to work:
- LogPathToWrite - A folder path for logging outputs, where users can track any issues/activity
- FromPath - The folder path where the files are coming FROM
- MiscFilePath - A folder path where files are copied to when a matching extension is not found.

In the appsettings.json file, the following optional values should be setup, although are not required:
- SoftwareFilePath - Designated path for files types related to software/execution/installation (eg. .exe, .bat, .cmd, .run)
- MusicFilePath - Designated path for files types related to music (eg. .mp3, .flac)
- PhotoFilePath - Designated path for files types related to photos (eg. .png, .jpeg)
- VideoFilePath - Designated path for files types related to videos (eg. .mkv, .avi)
- DocFilePath - Designated path for files types related to documents (eg. .pdf, .doc)
- CodeFilePath - Designated path for files types related to programming (eg. .py, .c)
- SystemFilePath - Designated path for files types related to system (eg. .msi, .dll)
- CompressFilePath - Designated path for files types related to compression (eg. .zip, .rar)

In the appsettings.json the following optional values can be setup when users want to specify their own file types (instead of the default):
- UseCustomExtensions - A flag to indicate whether the application should run using custom extensions(true) or the default (false)
- SoftwareExt - A string (using a '|' delimeter) for the various software/execution/installation extension types (eg. '.exe|.bat')
- MusicExt - A string (using a '|' delimeter) for the various music extension types (eg. '.mp3|.flac|.cmd|.run')
- PhotoExt - A string (using a '|' delimeter) for the various photo extension types (eg. '.png|.jpeg')
- VideoExt - A string (using a '|' delimeter) for the various video extension types (eg. '.mkv|.avi')
- DocExt - A string (using a '|' delimeter) for the various document extension types (eg. '.pdf|.doc')
- CodeExt - A string (using a '|' delimeter) for the various programming extension types (eg. '.py|.c')
- SystemExt - A string (using a '|' delimeter) for the various system extension types (eg. '.msi|.dll')
- CompressExt - A string (using a '|' delimeter) for the various compression extension types (eg. '.zip|.rar')

## Default Extensions
 - Software - .exe.bat|.com|.cmd|.inf|.ipa|.osx|.pif|.run
- Music - .m4a|.flac|.mp3|.wav|.wma|.aac|.aiff|.alac|.dsd|.mqa|.ogg
- Photo - .jpeg|.gif|.png|.tiff|.psd|.ai|.indd|.raw|.svg|.eps|.xcf|.psd|.heif|.wdbp|.heic
- Video - .mp4|.mov|.wmv|.avi|.avchd|.flv|.f4v|.swf|.mkv|.webm|.vod|.mng|.asf|.amv|.mpeg|.mpg|mpv|.svi
- Document - .doc|.docx|.csv|.xls|.xlsx|.ppt|.pptx|.pdf|.txt|.json|.wpd|.rtf
- Code - .cs|.py|.ts|.c|.java|.php|.html|.css|.vb|.swift
- System - .sys|.tmp|.icns|.ini|.cgf|.msi|.ico|.dll|.cer|.crt|.pfx
- Compression - .zip|.rar|.pkg|.tar|.xz|.gzip|.iso|.gz|.7z|.s7z

## Contributing
Pull requests are welcome!
