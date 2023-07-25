using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    GameObject objectToSnap;
    public LayerMask layerMask;
    public bool IscorrectCube = false;
    public bool IsEmpty = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        
        if (Input.GetMouseButtonDown(0) == false && objectToSnap!=null)
        {

            objectToSnap.transform.position = this.transform.root.position;
            //objectToSnap = null;
        }
        Collider[] Blockcheck = Physics.OverlapSphere((Vector3)transform.position, 0.5f,layerMask);
        if(Blockcheck.Length == 0)
        {
            IsEmpty = true;
            
        }
        for (int i = 0; i < Blockcheck.Length; i++)
        {
            var blocktag = Blockcheck[i].tag;
            IsEmpty = false;

            if(blocktag == target.tag)
            {
                IscorrectCube = true;
                
                
            }
            else
            {
                IscorrectCube = false;
            }
        }
        Debug.Log(IsEmpty.ToString());
        
       
    }
    void OnTriggerEnter3D(Collider otherCollider)
    {
        Debug.Log("Pickedup");
        objectToSnap = otherCollider.gameObject;
        if (otherCollider.gameObject.tag == target.tag)
        {
            Debug.Log("correct");
        }
    }

    void OnTriggerExit3D(Collider otherCollider)
    {
        Debug.Log("Collected");
        objectToSnap = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector3)transform.position, 0.5f);
    }

}
