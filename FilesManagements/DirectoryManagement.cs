using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesManagements
{
    public class DirectoryManagement
    {
        /// <summary>
        /// This method creates the list oof directories if their do not exist 
        /// </summary>
        /// <param name="directories"> List of directories to create </param>
        /// <param name="files"> List of files with full path to create </param>
        public void CheckDirectories(string[] directories)
        {
            foreach (string directory in directories)
            {
                try
                {
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to create directory {directory}:{ex.Message}");
                }
            }
        }

        /// <summary>
        /// Get a list of top folders from the full path of a file. Top folders are sorted from the root. 
        /// </summary>
        /// <param name="path"> File full path </param>
        private List<string> GetTopFolders(string path)
        {
            List<string> directories = new List<string>();
            string directory = path;
            string root = Path.GetPathRoot(path);
            do
            {
                directory = Path.GetDirectoryName(directory);
                if (directory == root || string.IsNullOrEmpty(directory))
                    break;
                else
                    directories.Insert(0, directory);
            }
            while (true);
            return directories;
        }
    }
}
