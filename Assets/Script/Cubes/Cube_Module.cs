using UnityEngine;
using System.Collections;

public enum EModType { None, Type1, Type2, Type3, Type4 }

public class Cube_Module : Cube {

    public EModType Module { get; set; }

	// Use this for initialization
	void Start () {
        Module = EModType.None;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
