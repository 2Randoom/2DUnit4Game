using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManiger : MonoBehaviour
{
    public GameObject BowlingBallPF;
    public int enemyCount;
    public int waveNumber;
    public GameObject powerUP;

  
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);

        Instantiate(BowlingBallPF, GenrateSpawnPos(), BowlingBallPF.transform.rotation);

    }

    void SpawnEnemyWave(int NumberofEnemysToSpawn)
    {
       
        for (int i = 0; i < NumberofEnemysToSpawn; i++)
        {
            Instantiate(BowlingBallPF, GenrateSpawnPos(), BowlingBallPF.transform.rotation);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyCount = FindObjectsByType<BowlingBallControler>(0).Length;

        if (enemyCount == 0||Input.GetKeyDown(KeyCode.Escape))
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUP, GenrateSpawnPos(), powerUP.transform.rotation);
        }
    }

    //Create the spot to spawn 
    private Vector2 GenrateSpawnPos ()
    {
    float spawnPosY = 1;
    float spawnPosX = Random.Range(-8, 1);
        Vector2 randomPos = new Vector2(spawnPosX, spawnPosY);
       return randomPos;
    }


       
}
