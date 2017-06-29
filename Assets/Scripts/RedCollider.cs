using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCollider : MonoBehaviour {

    private float HighScore;

	void Start () {
        HighScore = PlayerPrefs.GetFloat("HighScore");
        PlayerScript.Instance.totalPoints = PlayerPrefs.GetFloat("TotalScore");
	}

	void Update () {
		
	}

    void OnTriggerEnter()
    {
        if (PlayerScript.Instance.isBlue == true)
        {
            PlayerScript.Instance.PauseMusic();
            PlayerScript.Instance.speed = 0;
            PlayerScript.Instance.gameOver.enabled = true;
            PlayerScript.Instance.NewHighScrTxt.enabled = false;
            PlayerScript.Instance.totalPointsTxt.text = "Points: " + PlayerScript.Instance.points;
            if(PlayerScript.Instance.points > HighScore)
            {
                PlayerScript.Instance.NewHighScrTxt.enabled = true;
                PlayerPrefs.SetFloat("HighScore", PlayerScript.Instance.points);
                HighScore = PlayerPrefs.GetFloat("HighScore");
                PlayerScript.Instance.HighScoreTxt.text = "High Score: " + HighScore;
            }
            else
            {
                PlayerScript.Instance.HighScoreTxt.text = "High Score: " + HighScore;
            }
            PlayerScript.Instance.totalPoints += PlayerScript.Instance.points;
            PlayerPrefs.SetFloat("TotalScore", PlayerScript.Instance.totalPoints);
        }
    }
}
