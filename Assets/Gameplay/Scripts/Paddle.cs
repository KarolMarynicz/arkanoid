using UnityEngine;
using Game;

namespace Gameplay
{ 
	public class Paddle : MonoBehaviour
	{
		private readonly float SCREEN_MOVE_BOUND = 7.95f;

		public float speed = 7.5f;
		private bool isMouseEnabled = false;

		private void Start()
		{
			this.isMouseEnabled = GameObject.Find("_GameManager").GetComponent<GameManager>().isMouse;
		}

		private void Update()
		{
			if (this.isMouseEnabled)
				this.MouseMove();
			else
				this.KeysMove();
		}

		private void KeysMove()
		{
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				if (this.transform.position.x > -this.SCREEN_MOVE_BOUND)
					this.transform.Translate(Vector2.left * this.speed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				if (this.transform.position.x < this.SCREEN_MOVE_BOUND)
					this.transform.Translate(Vector2.right * this.speed * Time.deltaTime);
			}
		}

		private void MouseMove()
		{
			this.transform.Translate(Vector2.right * Input.GetAxis("Mouse X") * this.speed * Time.deltaTime);
		}
	}
}
