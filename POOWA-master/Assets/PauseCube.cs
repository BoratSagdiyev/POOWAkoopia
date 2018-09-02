using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCube : MonoBehaviour {

    private void OnMouseDown()
    {
        PauseMenu.instance.PauseButton();
    }
}
