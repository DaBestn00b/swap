using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;
    public GameObject currentTile;
    private static TileManager instance;
    public static TileManager Instance
    {
        get {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return TileManager.instance; }
    }
    
    void Start () {
        for (int i = 0; i < 10; i++)
        {
            SpawnTiles();
        }
	}
	
	void Update () {
		
	}

    public void SpawnTiles () {
        int randomIndex = Random.Range(0, 2);
        currentTile = Instantiate(tilePrefabs[randomIndex], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity); 
    }
}
