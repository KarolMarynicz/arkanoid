using UnityEngine;

namespace Gameplay.Pause
{
	public class PauseMenu : MonoBehaviour
	{
		private bool isGamePaused = false;

		private GameObject screenFade = null;
		private GameObject pauseMenuUI = null;

		private void Start()
		{
			this.screenFade = GameObject.Find("Canvas").transform.Find("Pause Screen Fade").gameObject;
			this.pauseMenuUI = GameObject.Find("Canvas").transform.Find("Pause Menu").gameObject;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (this.isGamePaused)
					this.ResumeGame();
				else
					this.PauseGame();
			}
		}

		public void ResumeGame()
		{
			Time.timeScale = 1.0f;
			this.isGamePaused = false;

			this.screenFade.SetActive(false);
			this.pauseMenuUI.SetActive(false);
		}

		private void PauseGame()
		{
			Time.timeScale = 0.0f;
			this.isGamePaused = true;

			this.screenFade.SetActive(true);
			this.pauseMenuUI.SetActive(true);
		}
	}
}
