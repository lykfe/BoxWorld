using UnityEngine;
using System.Collections;

public class NameIndicator : MonoBehaviour {

    private string Name;
    private string Function;
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "NameIndicator";
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetUpText()
    {
        Cube cube = this.gameObject.GetComponentInParent<Cube>();
        NPC npc = this.gameObject.GetComponentInParent<NPC>();
        
        if (cube)
        {
            this.gameObject.GetComponent<TextMesh>().text = cube.Name;
        } else if(npc)
        {
            this.gameObject.GetComponent<TextMesh>().text = npc.Name;
        }

    }
}
