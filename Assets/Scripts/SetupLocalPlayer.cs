using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {

    [SyncVar]
    public string pname;
    

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            GetComponent<CharacterController>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
