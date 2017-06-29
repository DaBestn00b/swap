using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScrnScript : MonoBehaviour {

    public Canvas quitmenu;
    public Button startText;
    public Button quitText;

    void Start () {
        quitmenu = quitmenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        quitText = quitText.GetComponent<Button>();
        quitmenu.enabled = false;
    }

    public void ExitPress()
    {
        quitmenu.enabled = true;
        startText.enabled = false;
        quitText.enabled = false;
    }

    public void NoPress()
    {
        quitmenu.enabled = false;
        startText.enabled = true;
        quitText.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("SwapGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShopPress()
    {
        SceneManager.LoadScene("SwapShop");
    }
}
