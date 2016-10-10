using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

    public PlayerState playerState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IncrementResource(int val)
    {
        if(playerState)
        {
            playerState.IncrementResource(val);
            SendMessageUpwards("UpdateCurrency", 2);
        }
    }


}
