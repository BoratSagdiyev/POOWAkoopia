using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;

    public void FixedUpdate()
    {
        
        rb.AddForce(0, 0, forwardForce* Time.deltaTime); //Consistent on all machines
}


}
