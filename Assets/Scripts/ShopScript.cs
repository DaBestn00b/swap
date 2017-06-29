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
    public Text RootsSelected;
    public Text SpectreSelected;
    public Text FadeSelected;
    public Text LightSelected;
    public AudioSource PlayRootsSouce;
    public AudioSource PlaySpectreSource;
    public AudioSource PlayFadeSource;
    public AudioSource PlayLightSource;
    public float totalScore;
    private float TobuRootsEnabled;
    private float WalkerSpectreEnabled;
    private float WalkerFadeEnabled;
    private float ElectroLightEnabled;

    void Start()
    {
        TotalScoreTxt = TotalScoreTxt.GetComponent<Text>();
        ShopInfo = ShopInfo.GetComponent<Text>();
        Title = Title.GetComponent<Text>();
        MusicShop = MusicShop.GetComponent<Canvas>();
        ColorShop = ColorShop.GetComponent<Canvas>();
        MusicShop.enabled = false;
        ColorShop.enabled = false;
        totalScore = PlayerPrefs.GetFloat("TotalScore");
        SetMusicToSave();
        if(WalkerSpectreEnabled == 0 && WalkerFadeEnabled == 0 && ElectroLightEnabled == 0)
        {
            SelectTobu();

        }else if(WalkerSpectreEnabled == 1)
        {
            SelectSpectre();
        }else if(WalkerFadeEnabled == 1)
        {
            SelectFade();
        }else
        {

        }
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
        SetMusicSaves();
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

    public void SelectTobu()
    {
        DeselectMusic();
        TobuRootsEnabled = 1;
        RootsSelected.enabled = true;
    }

    public void PlayRoots()
    {
        StopAllMusic();
        PlayRootsSouce.Play();
    }

    public void StopAllMusic()
    {
        PlayRootsSouce.Stop();
        PlaySpectreSource.Stop();
        PlayFadeSource.Stop();
        PlayLightSource.Stop();
    }

    public void SelectSpectre()
    {
        DeselectMusic();
        WalkerSpectreEnabled = 1;
        SpectreSelected.enabled = true;
    }

    public void SelectFade()
    {
        DeselectMusic();
        WalkerFadeEnabled = 1;
        FadeSelected.enabled = true;
    }

    public void SelectLight()
    {
        DeselectMusic();
        ElectroLightEnabled = 1;
        LightSelected.enabled = true;
    }

    public void DeselectMusic()
    {
        TobuRootsEnabled = 0;
        WalkerFadeEnabled = 0;
        WalkerSpectreEnabled = 0;
        ElectroLightEnabled = 0;
        RootsSelected.enabled = false;
        //FadeSelected.enabled = false;
        //SpectreSelected.enabled = false;
        //LightSelected.enabled = false;
    }

    public void SetMusicToSave()
    {
        TobuRootsEnabled = PlayerPrefs.GetFloat("RootsEnabled");
        WalkerSpectreEnabled = PlayerPrefs.GetFloat("SpectreEnabled");
        WalkerFadeEnabled = PlayerPrefs.GetFloat("FadeEnabled");
        ElectroLightEnabled = PlayerPrefs.GetFloat("LightEnabled");
    }

    public void SetMusicSaves()
    {
        PlayerPrefs.SetFloat("RootsEnabled", TobuRootsEnabled);
        PlayerPrefs.SetFloat("SpectreEnabled", WalkerSpectreEnabled);
        PlayerPrefs.SetFloat("FadeEnabled", WalkerFadeEnabled);
        PlayerPrefs.SetFloat("LightEnabled", ElectroLightEnabled);
    }
}
