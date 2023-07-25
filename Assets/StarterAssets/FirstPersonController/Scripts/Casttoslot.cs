using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casttoslot : MonoBehaviour
{
    public static string hoveredobject;
    public string internalobject;
    public RaycastHit Object;
    // Update is called once per frame
    void Update()
    {
     if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Object))
        {
            hoveredobject = Object.transform.gameObject.name;
            internalobject = Object.transform.gameObject.name;
        }   
    }
}
