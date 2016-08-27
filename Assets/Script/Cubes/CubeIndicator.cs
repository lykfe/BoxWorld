using UnityEngine;
using System.Collections;

public class CubeIndicator : MonoBehaviour {

    private string Name;
    private string Function;
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Cubes";
        this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 50;

        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetUpText()
    {
        Cube testing = this.gameObject.GetComponentInParent<Cube>();
        if (testing)
        {
            this.gameObject.GetComponent<TextMesh>().text = testing.Name;
        }
    }
}
