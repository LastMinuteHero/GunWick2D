﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public BoardManager boardScript;

	// Use this for initialization
	void Awake () 
	{
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}
	void InitGame()
	{
		boardScript.SetupScene ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
