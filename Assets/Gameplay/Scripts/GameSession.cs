using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Game;
using Gameplay.Board;

namespace Gameplay
{
	public class GameSession : MonoBehaviour
	{
		public bool isGameRun = false;

		private int _lifes = 0;
		public int Lifes 
		{ 
			get { return this._lifes; }
			set
			{
				this._lifes = value;
				this.livesText.text = "Lifes: " + this._lifes;

				if (_lifes <= 0)
				{
					this.EndGame(EndTypes.Defeat);
				}
			}
		}
		private int _score = 0;
		public int Score
		{
			get { return this._score; }
			set
			{
				this._score = value;
				this.scoreText.text = "Score: " + this._score;
			}
		}

		private Text scoreText = null;
		private Text livesText = null;
	
		private Ball ball = null;
		private GameObject hint = null;
		private GameManager gameManager = null;

		private void Start()
		{
			this.scoreText = GameObject.Find("Score").GetComponent<Text>();
			this.livesText = GameObject.Find("Lives").GetComponent<Text>();

			this.hint = GameObject.Find("Hint");
			this.ball = GameObject.Find("Ball").GetComponent<Ball>();

			this.gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();
			Boxes boxes = GameObject.Find("Boxes").GetComponent<Boxes>();
			if (this.gameManager.savedData != null)
			{
				this.Lifes = this.gameManager.savedData.lifes;
				this.Score = this.gameManager.savedData.score;
				boxes.CreateBoardFromSave(gameManager.savedData);
			}
			else
			{
				this.Lifes = 3;
				this.Score = 0;
				boxes.CreateBoard();
			}

			this.gameManager.ClearSavedData();
		}

		private void Update()
		{
			if (!this.isGameRun)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					this.ball.StartBall();
					this.hint.SetActive(false);
					this.isGameRun = true;
				}
			}
		}

		public void RemoveSingleLife()
		{
			this.Lifes--;
			this.ResetToStartState();
		}

		public void EndGame(EndTypes end)
		{
			this.gameManager.score = this._score;

			switch (end)
			{
				case EndTypes.Win:
					this.gameManager.gameResult = EndTypes.Win;
					break;
				case EndTypes.Defeat:
					this.gameManager.gameResult = EndTypes.Defeat;
					break;
			}

			SceneManager.LoadScene("Result", LoadSceneMode.Single);
		}

		private void ResetToStartState()
		{
			this.isGameRun = false;
			this.hint.SetActive(true);
			this.ball.StopBall();
			this.ball.transform.position = this.ball.originPosition;
		}
	}
}
