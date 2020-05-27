using System.IO;
using UnityEngine;

namespace Gameplay.Save
{
    public class SaveManager
    {
        [SerializeField] private static SaveObject dataToSave = null;

        public static void SaveToJSON(SaveObject data)
		{
            SaveManager.dataToSave = data;
            
            string json = JsonUtility.ToJson(SaveManager.dataToSave, true);
            File.WriteAllText(Application.persistentDataPath + "/save.json", json);

            SaveManager.dataToSave = null;
		}
    }
}
