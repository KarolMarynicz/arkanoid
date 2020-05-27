using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Gameplay.Save;

namespace Game
{
	public class GameManager : MonoBehaviour
	{
		public EndTypes gameResult;
		public int score { get; set; } = 0;
		public bool isMouse { get; private set; } = false;
		public SaveObject savedData { get; private set; } = null;

		private void Awake()
		{
			if (File.Exists(Application.persistentDataPath + "/save.json"))
			{
				GameObject.Find("Continue Button").GetComponent<Button>().interactable = true;
			}

			DontDestroyOnLoad(this.gameObject);
		}

		public void MouseOptionChange(bool value)
		{
			this.isMouse = value;
		}

		public void GetDataFromSavedFile()
		{
			this.savedData = JsonUtility.FromJson<SaveObject>(File.ReadAllText(Application.persistentDataPath + "/save.json"));
		}

		public void ClearSavedData()
		{
			this.savedData = null;
		}
	}
}
