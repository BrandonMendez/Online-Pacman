using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDot : MonoBehaviour {

    private Score score1;
    private Score score2;
    public AudioClip food;

	// Use this for initialization
	void Start () {
        score1 = GameObject.Find("Score").GetComponent<Score>();
        score2 = GameObject.Find("Score2").GetComponent<Score>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collider)
    {
        SetupLocalPlayer pacman = collider.gameObject.GetComponent<SetupLocalPlayer>();
        if (pacman.pname == "Player1")
        {
            score1.AddScore();
        }
        else if(pacman.pname == "Player2")
        {
            score2.AddScore();
        }

        AudioSource.PlayClipAtPoint(food, transform.position);
        Destroy(gameObject);
    }
}
