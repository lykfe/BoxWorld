using UnityEngine;
using System.Collections;

public enum ETPType { None, RC, WEA, MER}
public class Cube_Troop : Cube {

    public ETPType SpawnType { get; set; }

    private Object NpcPrefab;

    private bool invoked;

    public Cube_Troop()
    {
        Name = "Cube_Troop";
        SpawnType = ETPType.RC;
    }

	// Use this for initialization
	new void Start () {
        base.Start();
        NpcPrefab = Resources.Load("NPC", typeof(GameObject));
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
        
        if (!SpawnedNpc && !invoked && IsActive)
        {
            Invoke("SpawnNpc", 2.0f);
            invoked = true;
        }
	}

    void SpawnNpc()
    {
        SpawnedNpc = Instantiate(NpcPrefab) as GameObject;
        if (SpawnedNpc)
        {
            switch (SpawnType)
            {
                case ETPType.RC:
                    SpawnedNpc.gameObject.AddComponent<NPC_RC>();
                    break;
                case ETPType.WEA:
                    SpawnedNpc.gameObject.AddComponent<NPC_WEA>();
                    break;
                case ETPType.MER:
                    SpawnedNpc.gameObject.AddComponent<NPC_MER>();
                    break;
                case ETPType.None:
                    break;
                default:
                    break;
            }
            SpawnedNpc.gameObject.GetComponentInChildren<NameIndicator>().SetUpText();
            SpawnedNpc.gameObject.transform.position = gameObject.transform.position;
            SpawnedNpc.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }

        invoked = false;
    }
}
