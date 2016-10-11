using UnityEngine;
using System.Collections;

public class NPC_RC : NPC {

    
    public NPC_RC ()
    {
        Name = "NPC_RC";
    }

	// Use this for initialization
	new void Start () {
        base.Start();
        MovtSpeed = 40.0f;
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();

        // TargetCube is not set, keep trying to find one
        if (!TargetCube)
        {
            TargetCube = FindClosestCUBE("Cube_RC");
        } else if (TargetCube)
        {
            MoveToTarget();
        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject == TargetCube)
        {
            Cube_RC cube = other.gameObject.GetComponent<Cube_RC>();
            if (cube && cube.IsActive && !cube.IsEnabled)
            {
                cube.IsEnabled = true;
                cube.InvokeRepeating("Income", 2.0f, 2.0f);
            }
        }
    }


}
