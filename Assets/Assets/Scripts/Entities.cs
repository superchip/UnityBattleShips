using UnityEngine;
using System.Collections.Generic;

namespace GameEntities
{
	public class WarCube
	{
		public WarCube(GameObject gameObject, Vector3 position)
		{
			WarCubeGameObject = gameObject;
			Position = position;
		}

		public GameObject WarCubeGameObject {get;set;}
		public Vector3 Position             {get;set;}
		public bool Touched                 {get;set;}
	}

	public class Plane
	{
		public List<WarCube> WarCubes;
		public bool IsDestroyed {get;set;}
		public int PlaneSize {get;set;}

		public Plane()
		{
			WarCubes = new List<WarCube>();
		}

		public void AddWarCube(WarCube warCube)
		{
			WarCubes.Add(warCube);
			PlaneSize = WarCubes.Count;
		}


	}

	public class GameGrid
	{
		public List<WarCube> warCubes {get;set;}
		public List<Plane> planes {get;set;}

		public int RowSize;
		public int ColumnSize;

		bool playerGrid;

		GameObject parentGrid;



		public GameGrid(bool isPlayerGrid, GameObject parentGridGameObject)
		{
			warCubes = new List<WarCube>();
			planes   = new List<Plane>();

			parentGrid = parentGridGameObject;

			playerGrid = isPlayerGrid;

			buildGrid();
		}

		// Getting the war cube from the grid by position
		public WarCube GetWarCube(Vector3 position)
		{
			foreach(GameEntities.WarCube warCube in this.warCubes)
			{
				if(warCube.WarCubeGameObject.transform.position.x == position.x &&
					warCube.WarCubeGameObject.transform.position.y == position.y)
				{
					return warCube;
				}
			}

			return null;
		}

		// Getting the war cube from the grid by war cube postion
		public WarCube GetWarCube(int x, int y)
		{
			foreach(GameEntities.WarCube warCube in this.warCubes)
			{
				if(warCube.Position.x == x && warCube.Position.y == y)
				{
					return warCube;
				}
			}

			return null;
		}

		// Build the Game grid
		private void buildGrid()
		{
			// Getting all children
			Transform[] ts = parentGrid.GetComponentsInChildren<Transform>();

			// Finding grid row and column length
			int size =  (int)Mathf.Sqrt(ts.Length);

			RowSize    = size / 2;
			ColumnSize = size / 2;

			int count = 1;

			// Assigning Grid Warcubes position
			for(int i = ColumnSize ; i >= -ColumnSize ; --i)
			{
				for(int j = -RowSize ; j <= RowSize ; ++j)
				{
					Vector3 pos = new Vector3((float)j,(float)i,0F);
					GameEntities.WarCube warCube = new WarCube(ts[count++].gameObject, pos);
					warCubes.Add(warCube);
				}
			}

			// Add computer planes
			//TODO change this to use player UI
			//if(!playerGrid)
			{
				buildComputerGrid();
			}
				
		}

		// Adding "Random" Planes
		private void buildComputerGrid()
		{
			Plane plane = new Plane();
			plane.AddWarCube(warCubes[0]);
			plane.AddWarCube(warCubes[1]);

			planes.Add(plane);

		}
	}
}
