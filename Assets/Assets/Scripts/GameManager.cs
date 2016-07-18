using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool   PlayerMove;
	public GameEntities.GameGrid PlayerGameGrid;
	public GameEntities.GameGrid ComputerGameGrid;

	public GameObject PlayerGridGameObject;
	public GameObject ComputerGridGameObject;

	AILogic aiLogic;

	// Use this for initialization
	void Start () 
	{
		PlayerMove = true;

		PlayerGameGrid   = new GameEntities.GameGrid(true,  PlayerGridGameObject);
		ComputerGameGrid = new GameEntities.GameGrid(false, ComputerGridGameObject);

		aiLogic = new AILogic(PlayerGameGrid);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!PlayerMove)
		{
			aiLogic.DrawSpot();
		}
	}
}
