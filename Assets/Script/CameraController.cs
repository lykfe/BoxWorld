using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Camera cam;

   
	// Use this for initialization
	void Start () {
        if(cam == null)
        {
            cam = Camera.main;
        }

    }
	
	// Update is called once per frame
	void LateUpdate () {

    }
    
}
