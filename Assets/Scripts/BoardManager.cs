﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public class Count
	{
		public int minimum;
		public int maximum;
	
		public Count (int min, int max)
		{
			minimum = min;
			maximum = max; 
		}
	}

	public int columns = 15;
	public int rows = 15;
	public Count wallCount = new Count (10, 18);
	public GameObject floorTiles;
	public GameObject wallTiles;
	public GameObject outerWallTiles;

	private Transform boardHolder;
	private List<Vector3> gridPositions = new List<Vector3> ();

	void InitiateList()
	{
		gridPositions.Clear ();

		for (int x = 1; x < columns - 1; x++) 
		{
			for (int y = 1; y < rows - 1; y++) 
			{
				gridPositions.Add (new Vector3 (x, y, 0f));
			}
		}

	}

	void BoardSetup()
	{
		boardHolder = new GameObject ("Board").transform;

		for (int x = -1; x < columns + 1; x++) 
		{
			for (int y = -1; y<columns +1; y++)
			{
				GameObject toInstantiate = floorTiles;

				if(x == -1 || x == columns || y == -1 || y == rows)
					toInstantiate = outerWallTiles;
				
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x, y ,0f), Quaternion.identity) as GameObject;

				instance.transform.SetParent (boardHolder);
			}
		}
	}

	Vector3 RandomPosition()
	{
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}


	void LayoutObjectAtRandom (GameObject tile, int minimum, int maximum)
	{
		int objectCount = Random.Range (minimum, maximum + 1);

		for(int i = 0; i<objectCount; i++){
			Vector3 randomPosition= RandomPosition();
			Instantiate(tile, randomPosition, Quaternion.identity);
		}
	}


	public void SetupScene ()
	{
		InitiateList();
        BoardSetup();

        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
	}
}
