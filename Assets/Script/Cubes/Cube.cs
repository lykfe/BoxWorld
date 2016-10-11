using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    public bool IsActive { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsTargetted { get; set; }
    public GameObject SpawnedNpc;
    public bool IsMoving { get; set; }
    public string Name { get; set; }

    private float timer;
    

    public CubeController controller;

    public Cube()
    {
        IsActive = false;
        IsTargetted = false;
        IsEnabled = false;
        Name = "Default";
    }
	// Use this for initialization
	public void Start () {
	}
	
	// Update is called once per frame
	public void Update () {
	    IsMoving = GetComponent<Rigidbody2D>().velocity.magnitude > 4.0f;
    }

    public void OnNPCEnter()
    {

    }

    void OnCollisionStay2D()
    {
        if(!IsActive)
        {
            timer += Time.deltaTime;
            if (timer >= .5f && !IsMoving)
            {
                IsActive = true;
            }
        }
    }
}
