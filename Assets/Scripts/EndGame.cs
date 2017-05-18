using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public GameObject player1Wins;
    public GameObject player2Wins;
    public GameObject tie;

    private Score score1;
    private Score score2;
    private int foodLeft;

    // Use this for initialization
    void Start () {
        score1 = GameObject.Find("Score").GetComponent<Score>();
        score2 = GameObject.Find("Score2").GetComponent<Score>();
    }
	
	// Update is called once per frame
	void Update () {
        countFood();
	}

    void countFood()
    {
        foodLeft = transform.childCount;
        if (foodLeft == 0)
        {
            if (score1.score == score2.score)
                tie.SetActive(true);
            else if (score1.score > score2.score)
                player1Wins.SetActive(true);
            else
                player2Wins.SetActive(true);
        }
    }
}
