using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour, IGameController {

    private int Resources;

    //HUD Related
    public GameObject HUD;
    private GameObject resourceUI;
    private GameObject CubeMenus;
    

	// Use this for initialization
	void Start () {
        Resources = 0;
        if(HUD)
        {
            resourceUI = HUD.transform.GetChild(0).GetChild(0).gameObject;
            CubeMenus = HUD.transform.GetChild(1).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void UpdateCurrency(int val)
    {
        Resources += val;
        resourceUI.gameObject.GetComponent<UnityEngine.UI.Text>().text = "Resource : " + Resources;

        print(Resources);
    }

}
