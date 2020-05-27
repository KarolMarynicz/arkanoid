using UnityEngine;

namespace Gameplay.Board
{
    public class Box : MonoBehaviour
    {
		public Boxes parent = null;

		private int health = 1;
		private SpriteRenderer boxSr = null;

		private void Start()
		{
			this.boxSr = this.GetComponent<SpriteRenderer>();
			this.boxSr.color = Color.red;

			this.parent = GameObject.Find("Boxes").GetComponent<Boxes>();
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.transform.tag == "Ball")
			{
				this.health--;
				if (this.health == 0)
					this.parent.RemoveBoxFromBoard(this.gameObject);

				GameObject.Find("_Scripts").GetComponent<GameSession>().Score++;
			}
		}
	}
}
