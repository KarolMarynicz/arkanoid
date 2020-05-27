using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections.Generic;
using UnityEngine;
using Game;
using Gameplay.Save;

namespace Gameplay.Board
{
	public class Boxes : MonoBehaviour
	{
		private static int BOXES_NUMBER = 18;

		private ObservableCollection<GameObject> boxesList = null;

		private void Start()
		{
			this.boxesList = new ObservableCollection<GameObject>();
			this.boxesList.CollectionChanged += this.NoBoxesHandler;
		}

		public void RemoveBoxFromBoard(GameObject boxToRemove)
		{
			this.boxesList.Remove(boxToRemove);
			GameObject.Destroy(boxToRemove);
		}

		public List<int[]> GetAllRemaningBoxesPositions()
		{
			List<int[]> remaningBoxes = new List<int[]>();

			foreach (GameObject box in this.boxesList)
			{
				int[] position = { (int)box.transform.localPosition.x, (int)box.transform.localPosition.y };
				remaningBoxes.Add(position);
			}

			return remaningBoxes;
		}

		public void CreateBoard()
		{
			int boxPositionX = 0;
			int boxPositionY = 0;
			for (int i = 0; i < Boxes.BOXES_NUMBER; i++)
			{
				GameObject boxPrefab = Resources.Load("Prefabs/Box") as GameObject;

				int x = -5 + (boxPositionX++ * 2);

				boxPrefab.transform.localPosition = new Vector2(x, boxPositionY);
				this.boxesList.Add(GameObject.Instantiate(boxPrefab, this.transform));

				if (x >= 5)
				{
					boxPositionY--;
					boxPositionX = 0;
				}

			}
		}

		public void CreateBoardFromSave(SaveObject savedData)
		{
			foreach (BoxPosition boxPosition in savedData.remaningBoxesPosiotions)
			{
				GameObject boxPrefab = Resources.Load("Prefabs/Box") as GameObject;
				boxPrefab.transform.localPosition = new Vector2(boxPosition.positionX, boxPosition.positionY);
				this.boxesList.Add(GameObject.Instantiate(boxPrefab, this.transform));
			}
		}

		private void NoBoxesHandler(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (this.boxesList.Count <= 0)
			{
				GameObject.Find("_Scripts").GetComponent<GameSession>().EndGame(EndTypes.Win);
			}
		}
	}
}
