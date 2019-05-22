using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {

    [Tooltip("Where the first brick will ne spawned")]
    public GameObject firstSpawnPoint;

    [Tooltip("Number Of Row Of BrickPrefab")]
    public int row;
    [Tooltip("Number Of Col Of BrickPrefab")]
    public int col;

    [Tooltip("Space On X-Axis Between Each Brick")]
    public float spacingX;
    [Tooltip("Space On Y-Axis Between Each Brick")]
    public float spacingY;

    [Tooltip("Brick Prefab Of Different Color To Be Spawn")]
    public Brick[] brickPrefabs;

    void Awake()
    {
        SpawnBrickPrefabs();
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnBrickPrefabs() {
        //If there's no Brick Prefab stored, skio this process
        if (brickPrefabs.Length <= 0) {
            return;
        }
        
        //Spawn bricks here
        for (int i = 0; i < col; i++) {
            for (int j = 0; j < row; j++)
            {
                Vector2 spawnPosition = (Vector2)firstSpawnPoint.transform.position + new Vector2(
                                            (i * spacingX),
                                            -j * spacingY);
                Instantiate(RandomlyGenerateBrickPrefab(), spawnPosition, Quaternion.identity, this.transform);
            }
        }
    }

    //Randomly generate a brick prefab from brick prefabs list
    Brick RandomlyGenerateBrickPrefab() {
        
        int randomBrickIndex = Random.Range(0, brickPrefabs.Length);
        return brickPrefabs[randomBrickIndex];
    }

}
