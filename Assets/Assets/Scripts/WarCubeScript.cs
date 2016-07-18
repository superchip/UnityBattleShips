using UnityEngine;
using System.Collections;

public class WarCubeScript : MonoBehaviour 
{
	void OnMouseDown() 
	{
		GameEntities.WarCube warCube = null;

		// If cube was touched already
		if(MoveHandler.IsWarCubedTouched(this.transform.position,out warCube))
		{
			return;
		}

		// Plane Hit
		if(MoveHandler.CheckHit(warCube))
		{
			// hit is red
			changeColor(Color.red);
		}
		else
		{
			// miss is blue
			changeColor(Color.blue);
		}
			
	}

	// Change war cube color
	void changeColor(Color color)
	{
		Renderer rend = GetComponent<Renderer>();
		rend.material.color = color;
	}
}


