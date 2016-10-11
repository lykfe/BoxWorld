using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public enum ERCType { None, Type1, Type2, Type3, Type4 }
public class Cube_RC : Cube
{
    public ERCType Resource { get; set; }
    
    public Cube_RC()
    {
        Resource = ERCType.None;
        Name = "Cube_RC";
    }
    // Use this for initialization
    void Start()
    {
        this.gameObject.tag = Name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Income()
    {
        if(controller && IsEnabled)
        {
            controller.IncrementResource(2);
        }
    }
}
