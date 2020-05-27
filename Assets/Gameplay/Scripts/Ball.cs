using UnityEngine;

namespace Gameplay
{
	public class Ball : MonoBehaviour
	{
		private readonly int BALL_HORIZONTAL_FORCE = 250;
		private readonly int BALL_BOUNCE_FORCE = 200;

		public Vector2 originPosition { get; private set; } = Vector2.zero;
		private Rigidbody2D ballRb = null;

		private void Start()
		{
			this.ballRb = this.GetComponent<Rigidbody2D>();
			this.originPosition = this.transform.position;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.transform.tag == "Paddle")
				this.Bounce(collision.transform.position.x, collision.contacts[0].point.x);
			if (collision.transform.tag == "Death Wall")
				GameObject.Find("_Scripts").GetComponent<GameSession>().RemoveSingleLife();
		}

		public void StartBall()
		{
			this.ballRb.AddForce(new Vector2(0, -this.BALL_HORIZONTAL_FORCE));
		}

		public void StopBall()
		{
			this.ballRb.velocity = Vector2.zero;
		}

		private void Bounce(float paddleCenter, float hitPoint)
		{
			this.ballRb.velocity = Vector2.zero;

			float diffFromPaddleCenter = paddleCenter - hitPoint;

			if (hitPoint < paddleCenter)
				this.ballRb.AddForce(new Vector2(-Mathf.Abs(diffFromPaddleCenter * this.BALL_BOUNCE_FORCE), this.BALL_HORIZONTAL_FORCE));
			else
				this.ballRb.AddForce(new Vector2(Mathf.Abs(diffFromPaddleCenter * this.BALL_BOUNCE_FORCE), this.BALL_HORIZONTAL_FORCE));
		}
	}
}
