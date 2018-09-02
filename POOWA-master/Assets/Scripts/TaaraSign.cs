using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaaraSign : MonoBehaviour {

    void Update()
    {
        transform.Rotate(0, 150 * Time.deltaTime, 25 * Time.deltaTime, Space.World);
    }
}
