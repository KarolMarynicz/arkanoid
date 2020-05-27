using UnityEngine;
using UnityEngine.SceneManagement;
using Game;

namespace Menu
{
	public class Buttons : MonoBehaviour
	{
		public void Exit()
		{
			Application.Quit();
		}

		public void Continue()
		{
			GameObject.Find("_GameManager").GetComponent<GameManager>().GetDataFromSavedFile();
			this.Play();
		}

		public void Play()
		{
			SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
		}
	}
}
