using UnityEngine;
using System.Collections;

public class MoveHandler : MonoBehaviour {

	public static GameManager gameManagerScript = (GameManager)GameObject.Find("BattleShipsMain").GetComponent("GameManager");


	public static bool IsWarCubedTouched(Vector3 position, out GameEntities.WarCube outWarCube)
	{
		outWarCube = null;

		GameEntities.WarCube warCube = gameManagerScript.ComputerGameGrid.GetWarCube(position);

		if(warCube!=null)
		{
			outWarCube = warCube;
			return warCube.Touched;
		}

		return false;
	}

	// Going over 
	public static bool CheckHit(GameEntities.WarCube warCubeInput)
	{
		foreach(GameEntities.WarCube warCube in gameManagerScript.ComputerGameGrid.warCubes)
		{
			if(warCube.Touched)
				continue;

			// if statement to check which war cube is pressed
			if(warCube.Position.x == warCubeInput.Position.x && warCube.Position.y == warCubeInput.Position.y)
			{
				warCube.Touched = true;

				// Found plane
				if(checkPlaneHit(warCube))
				{
					return true;
				}

			}
		}
		return false;
	}

	private static bool checkPlaneHit(GameEntities.WarCube warCubeInput)
	{
		foreach(GameEntities.Plane plane in gameManagerScript.ComputerGameGrid.planes)
		{
			// Skip destroyed planes
			if(plane.IsDestroyed)
				continue;
			
			foreach(GameEntities.WarCube warCube in plane.WarCubes)
			{
				if(warCube.Position.x == warCubeInput.Position.x && warCube.Position.y == warCubeInput.Position.y)
				{
					// Destroy plane
					if(--plane.PlaneSize == 0)
					{
						plane.IsDestroyed = true;
					}

					return true;
				}
			}
		}

		return false;
	}
}
