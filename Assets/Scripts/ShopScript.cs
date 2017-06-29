using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{

    public Canvas MusicShop;
    public Canvas ColorShop;
    public Text Title;
    public Text ShopInfo;
    public Text TotalScoreTxt;
    public float totalScore;

    void Start()
    {
        TotalScoreTxt = TotalScoreTxt.GetComponent<Text>();
        ShopInfo = ShopInfo.GetComponent<Text>();
        Title = Title.GetComponent<Text>();
        MusicShop = MusicShop.GetComponent<Canvas>();
        ColorShop = ColorShop.GetComponent<Canvas>();
        totalScore = PlayerPrefs.GetFloat("TotalScore");
        UpdateText();
    }

    void Update()
    {

    }

    public void UpdateText()
    {
        TotalScoreTxt.text = "Points: " + totalScore;
    }

    public void Back()
    {
        SceneManager.LoadScene("Start");
    }

    public void MusicClick()
    {
        DisableEverything();
        MusicShop.enabled = true;
        Title.text = "Shop - Music";
    }

    public void ColorClick()
    {
        DisableEverything();
        ColorShop.enabled = true;
        Title.text = "Shop - Colors";
    }

    public void DisableEverything()
    {
        ShopInfo.enabled = false;
        MusicShop.enabled = false;
        ColorShop.enabled = false;
    }
}
