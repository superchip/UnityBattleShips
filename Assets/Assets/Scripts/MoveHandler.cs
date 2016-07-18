using UnityEngine;
using System.Collections.Generic;

public class MoveHandler : MonoBehaviour {

	public static GameManager gameManagerScript = (GameManager)GameObject.Find("BattleShipsMain").GetComponent("GameManager");


	public static bool IsWarCubedTouched(Vector3 position, out GameEntities.WarCube outWarCube)
	{
		outWarCube = gameManagerScript.PlayerGameGrid.GetWarCube(position);

		if(gameManagerScript.PlayerMove)
		{
			outWarCube = gameManagerScript.ComputerGameGrid.GetWarCube(position);
		}
			
		if(outWarCube!=null)
		{
			return outWarCube.Touched;
		}

		return false;
	}

	// Going over 
	public static bool CheckHit(GameEntities.WarCube warCubeInput)
	{
		List<GameEntities.WarCube> warCubes = gameManagerScript.PlayerGameGrid.warCubes;

		if(gameManagerScript.PlayerMove)
		{
			warCubes = gameManagerScript.ComputerGameGrid.warCubes;
		}
			

		foreach(GameEntities.WarCube warCube in warCubes)
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

	public static bool IsPlayerMove()
	{
		return gameManagerScript.PlayerMove;
	}

	private static bool checkPlaneHit(GameEntities.WarCube warCubeInput)
	{
		List<GameEntities.Plane> planes = gameManagerScript.PlayerGameGrid.planes;

		if(gameManagerScript.PlayerMove)
		{
			planes = gameManagerScript.ComputerGameGrid.planes;
		}

		foreach(GameEntities.Plane plane in planes)
		{
			// Skip destroyed planes
			if(plane.IsDestroyed)
				continue;
			
			foreach(GameEntities.WarCube warCube in plane.WarCubes)
			{
				// Point was found on plane
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

		// Switch state since we didn't find a plane
		gameManagerScript.PlayerMove = !gameManagerScript.PlayerMove;
		return false;
	}
}
