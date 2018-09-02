using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill3 : MonoBehaviour {

    void Update()
    {
        transform.Rotate(0, 0, -250 * Time.deltaTime, Space.World);
    }
}
