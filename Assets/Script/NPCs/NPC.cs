using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    public string Name { get; set; }
    public bool IsActive;
    public GameObject TargetCube;
    public float MovtSpeed;

	// Use this for initialization
	public void Start () {

    }
	
	// Update is called once per frame
	public void Update () {
	}

    public GameObject FindClosestCUBE(string targetTag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector2 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector2 diff = (Vector2)go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            Cube cube = go.GetComponent<Cube>();
            //Cube must be active and not targetted
            if (curDistance < distance && cube.IsActive && !cube.IsTargetted)
            {
                closest = go;
                distance = curDistance;
            } else
            {
                cube.IsTargetted = false;
            }
        }

        //if closest one is valid, then set targetted to true
        if(closest)
        {
            closest.GetComponent<Cube>().IsTargetted = true;
        }

        return closest;
    }

    public void MoveToTarget()
    {

        //really hacky way
        if (transform.position.y < -220.0f)
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        float step = MovtSpeed * Time.deltaTime;
        Vector2 currentPos = transform.position;
        Vector2 targetPos = TargetCube.transform.position;
        
        //Move in X-axis first
        if (Mathf.Abs(transform.position.x - TargetCube.transform.position.x) > 5.0f)
        {
            targetPos = new Vector2(targetPos.x, currentPos.y);
        }

        transform.position = Vector2.MoveTowards(currentPos, targetPos, step);


    }
}
