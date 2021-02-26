using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float pickUpRange = 5f;
    public float moveForce = 250f;
    public Transform heldParent;
    private GameObject heldObject;


    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {   
            if(heldObject == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, pickUpRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }
        
        if(heldObject != null)
        {
            MoveObject();

        }
    }
    void MoveObject()
    {
        if(Vector3.Distance(heldObject.transform.position, heldParent.position) > 0.1f)
        {
            Vector3 moveDirection = (heldParent.position - heldObject.transform.position);
            heldObject.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObject)
    {
        if(pickObject.GetComponent<Rigidbody>())
        {
            Rigidbody objectRig = pickObject.GetComponent<Rigidbody>();
            objectRig.useGravity = false;
            objectRig.drag = 10f;

            objectRig.transform.parent = heldParent;
            heldObject = pickObject;
        }
    }
    void DropObject()
    {
        Rigidbody heldRig = heldObject.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1f;

        heldObject.transform.parent = null;
        heldObject = null;
    }
}
