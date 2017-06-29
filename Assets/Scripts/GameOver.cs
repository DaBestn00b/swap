using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void resetLvl()
    {
        SceneManager.LoadScene("SwapGame");
    }

    public void toHome()
    {
        SceneManager.LoadScene("Start");
    }

}