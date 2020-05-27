using UnityEngine;
using UnityEngine.UI;
using Game;

namespace Result
{
    public class ResultController : MonoBehaviour
    {
		private void Start()
		{
			GameManager gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();

			if (gameManager.gameResult == EndTypes.Win)
				GameObject.Find("Result Title").GetComponent<Text>().text = "YOU WIN";
			else
				GameObject.Find("Result Title").GetComponent<Text>().text = "YOU LOSE";

			GameObject.Find("Score Title").GetComponent<Text>().text = "YOUR SCORE: " + gameManager.score;
		}
	}
}
