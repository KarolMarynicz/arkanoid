using UnityEngine;
using UnityEngine.SceneManagement;

namespace Result
{
    public class Buttons : MonoBehaviour
    {
		public void ExitToMenu()
		{
			SceneManager.LoadScene("Menu", LoadSceneMode.Single);
		}

		public void PlayAgain()
		{
			SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
		}
	}
}
