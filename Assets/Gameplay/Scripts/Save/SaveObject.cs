using System.Collections.Generic;

namespace Gameplay.Save
{
    [System.Serializable]
    public class SaveObject
    {
        public int score = 0;
        public int lifes = 0;

        public List<BoxPosition> remaningBoxesPosiotions = null;

        private SaveObject() { }

        public SaveObject(List<int[]> boxesPositions, int lives, int score)
		{
            this.remaningBoxesPosiotions = new List<BoxPosition>();

            foreach (int[] position in boxesPositions)
			{
                BoxPosition boxPosition = new BoxPosition(position[0], position[1]);
                this.remaningBoxesPosiotions.Add(boxPosition);
			}
            this.score = score;
            this.lifes = lives;
		}
    }

    [System.Serializable]
    public class BoxPosition
	{
        public int positionX;
        public int positionY;

        public BoxPosition(int x, int y)
		{
            this.positionX = x;
            this.positionY = y;
		}
	}
}
