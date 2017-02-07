using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleLight : MonoBehaviour {

    void Awake()
    {
        toggle(true);
    }
    public void toggle(bool activated)
    {
        InputManager.tobiLight = activated;
    }
}
