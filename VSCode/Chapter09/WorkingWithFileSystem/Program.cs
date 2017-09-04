using System;
using static System.Console;
using System.IO;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace WorkingWithFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // OutputFileSystemInfo();
            WorkWithDrives();
            //WorkWithDirectories();

            //WorkWithFiles();
        }

        public static void OutputFileSystemInfo()
        {
            WriteLine($"Path.PathSeparator:              {PathSeparator}");
            WriteLine($"Path.DirectorySeparatorChar:     {DirectorySeparatorChar}");
            WriteLine($"Directory.GetCurrentDirectory(): {GetCurrentDirectory()}");
            WriteLine($"Environment.CurrentDirectory:    {CurrentDirectory}");
            WriteLine($"Environment.SystemDirectory:     {SystemDirectory}");
            WriteLine($"Path.GetTempPath():              {GetTempPath()}");
            WriteLine($"GetFolderPath(SpecialFolder):");
            WriteLine($"  System:                        {GetFolderPath(SpecialFolder.System)}");
            WriteLine($"  ApplicationData:               {GetFolderPath(SpecialFolder.ApplicationData)}");
            WriteLine($"  MyDocuments:                   {GetFolderPath(SpecialFolder.MyDocuments)}");
            WriteLine($"  Personal:                      {GetFolderPath(SpecialFolder.Personal)}");
        }

        public static void WorkWithDrives()
        {
            WriteLine($"|--------------------------------|------------|---------|--------------------|--------------------|");
            WriteLine($"| Name                           | Type       | Format  |               Size |         Free space |");
            WriteLine($"|--------------------------------|------------|---------|--------------------|--------------------|");
            foreach(DriveInfo drive in DriveInfo.GetDrives())
            {
                WriteLine($"| {drive.Name,-30} | {drive.DriveType,-10} | {drive.DriveFormat, -7} | {drive.TotalSize,18:N0} | {drive.AvailableFreeSpace,18:N0} |");
            }
            WriteLine($"|--------------------------------|------------|---------|--------------------|--------------------|");
        }

        public static void WorkWithDirectories()
        {
            // define a custom directory path 
            string userFolder = GetFolderPath(SpecialFolder.Personal);

            var customFolder = new string[]
                { userFolder, "Code", "Chapter09", "OutputFiles" };

            string dir = Combine(customFolder);

            WriteLine($"Working with: {dir}");

            // check if it exists 
            WriteLine($"Does it exist? {Exists(dir)}");

            // create a directory 
            WriteLine("Creating it...");
            CreateDirectory(dir);
            WriteLine($"Does it exist? {Exists(dir)}");

            Write("Confirm the directory exists, and then press ENTER: ");
            ReadLine();

            // delete a directory 
            WriteLine("Deleting it...");
            Delete(dir, recursive: true);
            WriteLine($"Does it exist? {Exists(dir)}");
        }

        public static void WorkWithFiles()
        {
            // define a custom directory path 
            string userFolder = GetFolderPath(SpecialFolder.Personal);

            var customFolder = new string[]
                { userFolder, "Code", "Chapter09", "OutputFiles" };

            string dir = Combine(customFolder);
            CreateDirectory(dir);

            // define file paths
            string textFile = Combine(dir, "Dummy.txt");
            string backupFile = Combine(dir, "Dummy.bak");

            WriteLine($"Working with: {textFile}");

            // check if a file exists 
            WriteLine($"Does it exist? {File.Exists(textFile)}");

            // create a new text file and write a line to it 
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#!");
            textWriter.Close(); // close file and release resources

            WriteLine($"Does it exist? {File.Exists(textFile)}");

            // copy a file and overwrite if it already exists 
            File.Copy(
                sourceFileName: textFile,
                destFileName: backupFile,
                overwrite: true);

            WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

            Write("Confirm the files exist, and then press ENTER: ");
            ReadLine();

            // delete a file 
            File.Delete(textFile);

            WriteLine($"Does it exist? {File.Exists(textFile)}");

            // read from a text file 
            WriteLine($"Reading contents of {backupFile}:");
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();

            WriteLine($"File Name: {GetFileName(textFile)}");
            WriteLine($"File Name without Extension: {GetFileNameWithoutExtension(textFile)}");
            WriteLine($"File Extension: {GetExtension(textFile)}");
            WriteLine($"Random File Name: {GetRandomFileName()}");
            WriteLine($"Temporary File Name: {GetTempFileName()}");

            var info = new FileInfo(backupFile);
            WriteLine($"{backupFile}:");
            WriteLine($"  Contains {info.Length} bytes");
            WriteLine($"  Last accessed {info.LastAccessTime}");
            WriteLine($"  Has readonly set to {info.IsReadOnly}");

            WriteLine($"Compressed? {info.Attributes.HasFlag(FileAttributes.Compressed)}");

        }
    }
}
