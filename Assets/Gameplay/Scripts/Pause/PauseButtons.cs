using UnityEngine;
using UnityEngine.SceneManagement;
using Gameplay.Save;
using Gameplay.Board;

namespace Gameplay.Pause
{
    public class PauseButtons : MonoBehaviour
    {
        public void SaveGame()
        {
            GameSession gameSession = GameObject.Find("_Scripts").GetComponent<GameSession>();
            Boxes boxes = GameObject.Find("Boxes").GetComponent<Boxes>();

            SaveObject save = new SaveObject(boxes.GetAllRemaningBoxesPositions(),
                gameSession.Lifes,
                gameSession.Score);

            SaveManager.SaveToJSON(save);
        }

        public void Exit()
		{
            if (Time.timeScale == 0.0f)
                Time.timeScale = 1.0f;

            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
		}
    }
}
