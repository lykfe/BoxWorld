﻿using UnityEngine;
using System.Collections;


public class PlayerState : MonoBehaviour, IPlayerController {

    private string playerName;
    public string Playername { get; set; }

    private int currency;
    public int Currency { get; set; }


    // Use this for initialization
    void Start () {
        currency = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IncrementResource(int val)
    {
        currency += val;
    }
}
