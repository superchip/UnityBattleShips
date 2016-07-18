using UnityEngine;
using System.Collections;

public class AILogic : MonoBehaviour 
{
	GameEntities.GameGrid gameGrid;

	public AILogic(GameEntities.GameGrid playerGameGrid)
	{
		Random.seed = System.Environment.TickCount;
		gameGrid = playerGameGrid;
	}

	public void DrawSpot()
	{
		DrawRandomSpot();
	}

	private void DrawRandomSpot()
	{
		int x = Random.Range(-gameGrid.ColumnSize-1,gameGrid.ColumnSize+1);
		int y = Random.Range(-gameGrid.RowSize-1,gameGrid.RowSize+1);

		GameEntities.WarCube warCube = gameGrid.GetWarCube(x,y);

		if(warCube != null)
		{
			WarCubeScript warCubeScript = (WarCubeScript)GameObject.Find(warCube.WarCubeGameObject.name).GetComponent("WarCubeScript");
			warCubeScript.CheckHit();
		}
	}

	private void DrawSmartSpot()
	{

	}

}
