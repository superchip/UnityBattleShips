using UnityEngine;
using System.Collections;

public class AILogic : MonoBehaviour 
{
	GameEntities.GameGrid gameGrid;
	bool smartAi;
	int lastHitX, lastHitY;
	int sideLogic = -1;

	public AILogic(GameEntities.GameGrid playerGameGrid)
	{
		Random.seed = System.Environment.TickCount;
		gameGrid = playerGameGrid;
	}

	public void DrawSpot()
	{
		if(smartAi)
			DrawSmartSpot();
		else	
			DrawRandomSpot();
	}

	private void DrawRandomSpot()
	{
		sideLogic = -1;

		int x = Random.Range(-gameGrid.ColumnSize-1,gameGrid.ColumnSize+1);
		int y = Random.Range(-gameGrid.RowSize-1,gameGrid.RowSize+1);

		GameEntities.WarCube warCube = gameGrid.GetWarCube(x,y);

		if(warCube != null)
		{
			WarCubeScript warCubeScript = (WarCubeScript)GameObject.Find(warCube.WarCubeGameObject.name).GetComponent("WarCubeScript");

			// If Hit we want the computer ai to check surrondings
			if(warCubeScript.CheckHit())
			{
				// TODO - omry uncomment the below once you have implemented DrawSmartSpot
				//smartAi = true;
				lastHitX = x;
				lastHitY = y;
			}
		}
	}

	// TODO - Omry to implement
	private void DrawSmartSpot()
	{

	}

}
