using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldobject;
    private Rigidbody heldobjectrb;

    [Header("Physics")]
    [SerializeField] private float pickuprange = 5.0f;
    [SerializeField] private float pickupforce = 150.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldobject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickuprange))
                {
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                //object gets dropped
                DropObject();
            }
        }
        if (heldobject != null)
        {
            //allow the object to move around
            Moveobject();
        }
    }

    void Moveobject()
    {
        if (Vector3.Distance(heldobject.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 movedirection = (holdArea.position - heldobject.transform.position);
            heldobjectrb.AddForce(movedirection * pickupforce);
        }
    }
    void PickUpObject(GameObject pickobj)
    {
        if (pickobj.GetComponent<Rigidbody>())
        {
            heldobjectrb = pickobj.GetComponent<Rigidbody>();
            heldobjectrb.useGravity = false;
            heldobjectrb.drag = 10f;
            heldobjectrb.constraints = RigidbodyConstraints.FreezeRotation;

            heldobjectrb.transform.parent = holdArea;
            heldobject = pickobj;
        }
    }
    void DropObject()
    {


        heldobjectrb.useGravity = true;
        heldobjectrb.drag = 1f;
        heldobjectrb.constraints = RigidbodyConstraints.None;

        heldobjectrb.transform.parent = null;
        heldobject = null;
    }
}
