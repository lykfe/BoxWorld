using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    public bool isActive { get; set; }
    private string NPCname;
    public string Name { get; set; }

	// Use this for initialization
	void Start () {
        isActive = false;
        NPCname = null;
        Name = "Default";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnNPCEnter()
    {

    }
}
