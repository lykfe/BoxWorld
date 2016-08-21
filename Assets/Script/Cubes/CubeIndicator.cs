using UnityEngine;
using System.Collections;

public class CubeIndicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "Cubes";
        this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 50;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
