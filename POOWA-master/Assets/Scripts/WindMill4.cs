using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill4 : MonoBehaviour {

    void Update()
    {
        transform.Rotate(0 , 250 * Time.deltaTime, 0 , Space.World);
    }
}
