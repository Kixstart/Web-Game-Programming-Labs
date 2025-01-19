using UnityEngine;
using UnityEditor;
using System.IO;
public class MySetup
{ 
    [MenuItem("setup/Create Folders")]
public static void CreateMyFolders()
{
    folder.createFolders("_Project", "Animations", "Art", "Audio",
        "Fonts", "Materials",
        "Prefabs", "ScriptableObjects", "Scripts", "Settings");
    AssetDatabase.Refresh();
}
static class folder
    {
        public static void createFolders(string root, params string[] folders)
        {
            var fullpath = Path.Combine(Application.dataPath, root);
            foreach(string folder in folders)
            {
                var path = Path.Combine(fullpath, folder);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}

