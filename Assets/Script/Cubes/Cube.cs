using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    public bool isActive { get; set; }
    private string NPCname;
    public string Name { get; set; }
    

    public CubeController controller;

    public Cube()
    {
        isActive = false;
        NPCname = null;
        Name = "Default";
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnNPCEnter()
    {

    }
}
