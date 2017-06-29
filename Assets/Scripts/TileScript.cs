using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour {

    public float speedInc;
    public float ptInc;

	void Start () {
        speedInc = 1;
        ptInc = 1;
	}

	void Update () {
        
	}

    void OnTriggerExit (Collider other) {
        if (other.tag == "Player")
        {
            PlayerScript.Instance.points += ptInc;
            TileManager.Instance.SpawnTiles();
            int randomSpeed = Random.Range(1, 11);
            if (randomSpeed == 1)
            {
                PlayerScript.Instance.speed += speedInc;
            }
            PlayerScript.Instance.pointsTxt.text = "Points: " + PlayerScript.Instance.points;
        }
    }
}
