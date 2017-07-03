using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float speed;
    public bool isBlue;
    public Canvas begin;
    public Canvas gameOver;
    public Canvas pauseMenu;
    public float currentSpeed;
    public Text pointsTxt;
    public Text totalPointsTxt;
    public Text HighScoreTxt;
    public Text NewHighScrTxt;
    public Text currentScore;
    public float points;
    public float totalPoints;
    private Vector3 dir;
    public MeshRenderer myRenderer;
    public Material red;
    public Material blue;
    private AudioSource currentAudio;
    public AudioSource TobuRootsSource;
    public AudioSource WalkerFadeSource;
    public AudioSource WalkerSpectreSource;
    private static PlayerScript instance;
    public static PlayerScript Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerScript>();
            }
            return PlayerScript.instance;
        }
    }

	void Start () {
        isBlue = true;
        dir = Vector3.zero;
        begin = begin.GetComponent<Canvas>();
        gameOver = gameOver.GetComponent<Canvas>();
        pauseMenu = pauseMenu.GetComponent<Canvas>();
        myRenderer = myRenderer.GetComponent<MeshRenderer>();
        pointsTxt = pointsTxt.GetComponent<Text>();
        gameOver.enabled = false;
        pauseMenu.enabled = false;
        points = 0;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            if (dir != Vector3.forward)
            {
                dir = Vector3.forward;
                if(begin.enabled == true)
                {
                    PlayMusic();
                }
                begin.enabled = false;
            }
        }
        float amountToMove = speed * Time.deltaTime;
        transform.Translate(dir * amountToMove);
	}

    public void SwapColors () {
        if (isBlue == true) {
            isBlue = false;
            myRenderer.material = red;
        }else {
            isBlue = true;
            myRenderer.material = blue;
        }
    }

    public void PauseGame () {
        PauseMusic();
        currentSpeed = speed;
        speed = 0;
        pauseMenu.enabled = true;
        currentScore.text = "Current Score: " + points;
    }

    public void ResumeGame () {
        PlayMusic();
        speed = currentSpeed;
        pauseMenu.enabled = false;
    }

    public void PlayMusic()
    {
        if(PlayerPrefs.GetFloat("RootsEnabled") == 1)
        {
            currentAudio = TobuRootsSource;
        }else if(PlayerPrefs.GetFloat("FadeEnabled") == 1)
        {
            currentAudio = WalkerFadeSource;
        }else if(PlayerPrefs.GetFloat("SpectreEnabled") == 1)
        {
            currentAudio = WalkerSpectreSource;
        }
        currentAudio.Play();
    }

    public void PauseMusic()
    {
        currentAudio.Pause();
    }
}
