using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.fixedTime % .5 < .3)
        {
            rend.enabled = false;
        }
        else
        {
            rend.enabled = true;
        }
    }
}
