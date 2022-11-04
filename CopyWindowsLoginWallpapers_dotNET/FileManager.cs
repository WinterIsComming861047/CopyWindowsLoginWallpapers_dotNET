using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace CopyWindowsLoginWallpapers
{
    internal class FileManager
    {
        static private string _SrcWindowsLoginWallpaper = $@"C:\Users\{Environment.GetEnvironmentVariable("UserName")}\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets\";
        string WorkingFolderPath;
        
        public FileManager(string workingFolderPath)
        {
            WorkingFolderPath = workingFolderPath;
        }
        public void Classification()
        {

            try
            {
                string PortraitFolderPath = "Portrait";
                string LandscapeFolderPath = "Landscape";

                if (!System.IO.Directory.Exists(PortraitFolderPath))
                {
                    System.IO.Directory.CreateDirectory(PortraitFolderPath);
                }
                if (!System.IO.Directory.Exists(LandscapeFolderPath))
                {
                    System.IO.Directory.CreateDirectory(LandscapeFolderPath);
                }
                string[] PathEntries = SearchAllInDirectory(WorkingFolderPath);
                foreach (var item in PathEntries)
                {
                    string SrcFile = Path.Combine(WorkingFolderPath, Path.GetFileName(item));
                    string PortraitDstFile = Path.Combine($@"{PortraitFolderPath}", Path.GetFileName(item));
                    string LandscapeDstFile = Path.Combine($@"{LandscapeFolderPath}", Path.GetFileName(item));
                    int ImgInfo;
                    using (Image img = Image.FromFile(SrcFile))
                    {
                        ImgInfo = img.Width;
                    }
                    var zz = Path.GetFileName(item);
                    //System.IO.File.Move(SrcFile, LandscapeDstFile,true);


                    switch (ImgInfo)
                    {
                        case 1920:
                            System.IO.File.Move(SrcFile, LandscapeDstFile);
                            //Process.Start("MovePic.bat", @$"Windows_Login_Wallpaper\{Path.GetFileName(item)} Landscape\");
                            Console.WriteLine($"Move {item} to Local {LandscapeDstFile}.");
                            break;
                        case 1080:
                            System.IO.File.Move(SrcFile, PortraitDstFile);
                            //Process.Start("MovePic.bat", @$"Windows_Login_Wallpaper\{Path.GetFileName(item)} Portrait\");
                            Console.WriteLine($"Move {item} to Local {PortraitDstFile}.");
                            break;
                        default:                            
                            Console.WriteLine($"{item} is not Wallpaper.");
                            break;
                    }
                }
                Console.WriteLine("Classification work complete.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void CopyAllFile()
        {
            try
            {
                string[] PathEntries = SearchAllInDirectory(_SrcWindowsLoginWallpaper);
                string TargetPath = "Windows_Login_Wallpaper";
                if (!System.IO.Directory.Exists(TargetPath))
                {
                    System.IO.Directory.CreateDirectory(TargetPath);
                }
                foreach (var item in PathEntries)
                {
                    string SrcFile = item;
                    string DstFile = Path.Combine(WorkingFolderPath, Path.GetFileName(item) + ".jpg");
                    System.IO.File.Copy(SrcFile, DstFile, true);
                    Console.WriteLine($"Copy {item} to Local path.");
                }
                Console.WriteLine("Copy work complete.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static public string[] SearchAllInDirectory(string Path)
        {
            try
            {
                string[] entries = Directory.GetFiles(Path);
                return entries;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
