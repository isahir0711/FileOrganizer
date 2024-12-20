string currentDirectoryPath = Directory.GetCurrentDirectory();

Console.WriteLine($"El directorio {currentDirectoryPath}");

const string imagesDirName = "images";
const string docsDirName = "docs";
const string videosDirName = "videos";
const string textDirName = "text";
const string othersDirName = "others";
const string execDirName = "exec";
const string audioDirName = "audio";
const string compressedDirName = "compressed";

//Dictionary for each type of file and their respective folder
Dictionary<string, string> fileTypesDir = new()
{
    {".jpg", imagesDirName},
    {".jpeg", imagesDirName},
    {".png",imagesDirName},
    {".svg", imagesDirName},
    {".gif", imagesDirName},
    {".bmp", imagesDirName},
    {".tiff", imagesDirName},
    {".jfif",imagesDirName},
    {".ico", imagesDirName},
    {".webp", imagesDirName},

    {".doc", docsDirName},
    {".docx", docsDirName},
    {".pdf", docsDirName},
    {".xls", docsDirName},
    {".xlsx", docsDirName},
    {".ppt", docsDirName},
    {".pptx",docsDirName},

    {".mp4", videosDirName},
    {".avi", videosDirName},
    {".mkv", videosDirName},
    
    {".txt",textDirName},
    {".exe",execDirName},
    
    {".mp3",audioDirName},
    {".ogg",audioDirName},
    {".m4a",audioDirName},
    
    {".zip", compressedDirName},
    {".rar", compressedDirName}
};

//have a dir for each type of file
string[] dirs = [ Path.Combine(currentDirectoryPath,imagesDirName), 
                  Path.Combine(currentDirectoryPath,docsDirName), 
                  Path.Combine(currentDirectoryPath,videosDirName),
                  Path.Combine(currentDirectoryPath,textDirName),
                  Path.Combine(currentDirectoryPath,othersDirName),
                  Path.Combine(currentDirectoryPath,execDirName),
                    Path.Combine(currentDirectoryPath,audioDirName),
                    Path.Combine(currentDirectoryPath,compressedDirName)
                  ];

//create the directories
foreach (string dir in dirs)
{
    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }
}

var files = Directory.GetFiles(currentDirectoryPath);


foreach(string file in files)
{
    string extension = Path.GetExtension(file);
    string fileName = Path.GetFileName(file);

    //check if the file is not the program itself
    if (fileName == "FileOrganizer.exe")
    {
        continue;
    }

    //check if the file is not a directory
    if (string.IsNullOrEmpty(extension))
    {
        continue;
    }

    //check if the extension is in the dictionary
    if (!fileTypesDir.ContainsKey(extension))
    {
        string otherDestinationFile = Path.Combine(currentDirectoryPath, othersDirName, fileName);
        File.Move(file, otherDestinationFile);
        continue;
    }
    
    string destinationFile = Path.Combine(currentDirectoryPath, fileTypesDir[extension], fileName);

    File.Move(file, destinationFile);
}