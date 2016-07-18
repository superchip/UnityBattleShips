using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	bool playerMove;
	public GameEntities.GameGrid PlayerGameGrid;
	public GameEntities.GameGrid ComputerGameGrid;

	public GameObject PlayerGridGameObject;
	public GameObject ComputerGridGameObject;

	// Use this for initialization
	void Start () 
	{
		PlayerGameGrid   = new GameEntities.GameGrid(true,  PlayerGridGameObject);
		ComputerGameGrid = new GameEntities.GameGrid(false, ComputerGridGameObject);



	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
