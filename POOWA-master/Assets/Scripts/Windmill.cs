using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour {

    // Use this for initialization
    void Update()
    {
        transform.Rotate(0, 0, 2, Space.World);
    }
    
}
