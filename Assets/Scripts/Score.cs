using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public int score;
    private Text scoreKeeper;

    // Use this for initialization
    void Start () {
        scoreKeeper = GetComponent<Text>();
        ResetScore();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore()
    {
        score += 1;
        scoreKeeper.text = "Score: " + score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreKeeper.text = "Score: " + score.ToString();
    }
}
