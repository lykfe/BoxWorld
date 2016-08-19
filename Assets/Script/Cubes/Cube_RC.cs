using UnityEngine;
using System.Collections;

public enum ERCType { None, Type1, Type2, Type3, Type4 }
public class Cube_RC : Cube {

    public ERCType Resource { get; set; }

	// Use this for initialization
	void Start () {
        Resource = ERCType.None;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		print ("contact");
	}
}
