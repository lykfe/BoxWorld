using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public GameObject DefaultCube;
    private GameObject PreviewCube;

    //Mouse
    private float MouseX, MouseY;
    private bool IsLeftPressed, IsRightPressed;

    //Cube
    private bool PreviewingCube;
    private bool CollidingCube;

    // Use this for initialization
    void Start () {

        if(Camcontroller)
        {
            this.Cam = Camcontroller.cam;
        }

        if(!DefaultCube)
        {
            print("DefaultCube is NULL");
        }

        CursorMode = ECursorMode.Scroll;

        IsLeftPressed = IsRightPressed = false;
        PreviewingCube = false;

        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
    }
	
	// Update is called once per frame
	void Update () {
        
        //Mouse input update
        IsLeftPressed = Input.GetKey(KeyCode.Mouse0);
        IsRightPressed = Input.GetKey(KeyCode.Mouse1);

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
        */

        //Make Spawned Cube Follow the mouse
        if(PreviewingCube)
        {
            //Set Collision and Release
            if(IsLeftPressed && !CollidingCube)
            {
                PreviewCube.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                PreviewCube.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                PreviewingCube = false;
                PreviewCube = null;
            }
            else if(IsRightPressed)
            {
                PreviewingCube = false;
                Destroy(PreviewCube);
            }
            else
            {
                CubeFollowCam();
            }
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

    public void SpawnCube(int typeID)
    {
        if (!PreviewCube)
        {
            PreviewCube = Instantiate(DefaultCube);
            if(PreviewCube)
            {
                switch (typeID)
                {
                    case 1:
                        PreviewCube.gameObject.AddComponent<Cube_RC>();
                        break;
                    case 2:
                        PreviewCube.gameObject.AddComponent<Cube_Troop>();
                        break;
                    case 3:
                        PreviewCube.gameObject.AddComponent<Cube_Weapon>();
                        break;
                    case 4:
                        PreviewCube.gameObject.AddComponent<Cube_Merchant>();
                        break;
                }
                PreviewCube.gameObject.GetComponentInChildren<CubeIndicator>().SetUpText();
            }
        }

        if (PreviewCube)
        {
            PreviewingCube = true;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            mousePos.z = 0;
            PreviewCube.transform.position = mousePos;
            //cubejoint.anchor = mousePos;


        }
            
    }

    void CubeFollowCam()
    {
        if(PreviewCube)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            PreviewCube.transform.position = mousePos;

            //Collision issues
            CollidingCube = PreviewCube.gameObject.GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Cubes", "Ground"));
            if(CollidingCube)
            {
                PreviewCube.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.76f, 0.76f, 1.0f);
            } else
            {
                PreviewCube.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }
    
}
