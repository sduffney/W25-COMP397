using UnityEngine;
using UnityEditor;
using System.IO;

public static class MySetup
{
    [MenuItem("Setup/Create Folders")]
    public static void CreateMyFolders()
    {
        Folder.CreateFolders("_Project", "Animations", "Art", "Audio", "Fonts",
        "Materials", "Prefabs", "ScriptableObjects", "Scripts", "Settings");
        AssetDatabase.Refresh();
    }
    static class Folder

    {
        public static void CreateFolders(string root, params string[] folders)
        {
            var fullPath = Path.Combine(Application.dataPath, root); // Application is from unity and is where the aplication is located, data path is whew the project is
            foreach (string folder in folders)
            {
                var folderPath = Path.Combine(fullPath, folder);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
        }
    }
}
