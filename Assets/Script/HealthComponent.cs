using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour {

    [SerializeField]
    private float health;
    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0.0f)
        {
            return true;
        }

        return false;
    }
}
