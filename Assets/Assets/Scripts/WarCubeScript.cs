using UnityEngine;
using System.Collections;

public class WarCubeScript : MonoBehaviour 
{
	void OnMouseDown() 
	{
		if(!MoveHandler.IsPlayerMove())
			return;

		CheckHit();
	}

	public bool CheckHit()
	{
		GameEntities.WarCube warCube = null;

		// If cube was touched already
		if(MoveHandler.IsWarCubedTouched(this.transform.position,out warCube))
		{
			return false;
		}

		// Plane Hit
		if(MoveHandler.CheckHit(warCube))
		{
			// hit is red
			changeColor(Color.red);
			return true;
		}
		else
		{
			// miss is blue
			changeColor(Color.blue);
			return false;
		}

	}

	// Change war cube color
	void changeColor(Color color)
	{
		Renderer rend = GetComponent<Renderer>();
		rend.material.color = color;
	}
}


