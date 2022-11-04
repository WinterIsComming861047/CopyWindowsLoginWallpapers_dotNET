using CopyWindowsLoginWallpapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyWindowsLoginWallpapers_dotNET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FolderPath = $@"Windows_Login_Wallpaper";
            FileManager fileManager = new FileManager(FolderPath);
            fileManager.CopyAllFile();
            fileManager.Classification();
        }
    }
}
