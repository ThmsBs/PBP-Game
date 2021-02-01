using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyPress;
    private float xInput;
    private float zInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPress = true;
        }

        xInput = Input.GetAxis("x");
    }

    //physics updates at 100 times per second
    void FixedUpdate()
    {
        if (jumpKeyPress)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up*5 , ForceMode.Impulse);
            jumpKeyPress = false;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(xInput, GetComponent<Rigidbody>().velocity.y, 0);
    }


}
