﻿using UnityEngine;
using System.Collections;

public enum ECursorMode { Build, Scroll, Menu}
public class InputController : MonoBehaviour {

    //Serialized
    [SerializeField]
    private float MouseSensitivity = 5.0f;

    //Current cursor pointer
    public ECursorMode CursorMode { get; set; }
    
    //Camera Controller
    public CameraController Camcontroller;
    private Camera Cam;

    //Cube Assets
    public Cube Cube;
    public Cube PreviewCube;

    //Mouse
    private float MouseX, MouseY;
    private bool IsLeftPressed, IsRightPressed;

    //Cube
    private bool PreviewingCube;

    // Use this for initialization
    void Start () {

        if(Camcontroller)
        {
            this.Cam = Camcontroller.cam;
        }

        if(!Cube)
        {
            print("Cube is NULL");
        }

        CursorMode = ECursorMode.Scroll;

        IsLeftPressed = IsRightPressed = false;
        PreviewingCube = false;

        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CursorMode = ECursorMode.Scroll;
            print("ScrollMode Entered");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CursorMode = ECursorMode.Build;
            print("BuildMode Entered");
        }
        */

        //Mouse input update
        IsLeftPressed = Input.GetKey(KeyCode.Mouse0);
        IsRightPressed = Input.GetKey(KeyCode.Mouse1);
        

        if (CursorMode == ECursorMode.Scroll)
        {
            UpdateCamera();

        }
        else if (CursorMode == ECursorMode.Build)
        {
            //spawn Cube
            if (IsLeftPressed)
            {
                SpawnCube();
            }
            else if(!IsLeftPressed && PreviewCube)
            {
                PreviewCube.gameObject.layer = 10;
                PreviewCube = null;
            }
            //Update Camera Location
        }
    }

    void UpdateCamera()
    {
        if (IsRightPressed)
        {
            float deltaMouseX = (MouseX - Input.GetAxis("Mouse X")) * MouseSensitivity;
            float deltaMouseY = (MouseY - Input.GetAxis("Mouse Y")) * MouseSensitivity;

            if(Cam)
            {
                Cam.transform.Translate(new Vector3(deltaMouseX, deltaMouseY, 0.0f));
            }
        }
    }

    void SpawnCube()
    {
        if (!PreviewCube)
        {
            PreviewCube = Instantiate(Cube);
            PreviewCube.gameObject.AddComponent<Cube_RC>();
            PreviewCube.gameObject.GetComponentInChildren<CubeIndicator>().SetUpText();
        }

        if (PreviewCube)
        {
            //print(PreviewCube.transform.position);
            PreviewingCube = true;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            mousePos.z = 0;
            PreviewCube.transform.position = mousePos;
            //cubejoint.anchor = mousePos;


        }
            
    }
    
}
