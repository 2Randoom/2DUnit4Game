using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManiger : MonoBehaviour
{
    public GameObject BowlingBallPF;
    public int enemyCount;
    public int waveNumber;
    public GameObject powerUP;
    private bool canSpawn = false;



    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        
        Instantiate(BowlingBallPF, GenrateSpawnPos1(), BowlingBallPF.transform.rotation);

    }

    void SpawnEnemyWave(int NumberofEnemysToSpawn)
    {

        for (int i = 0; i < NumberofEnemysToSpawn; i++)
        {
            Instantiate(BowlingBallPF, GenrateSpawnPos1(), BowlingBallPF.transform.rotation);

        }
    }

    void SpawnEnemyWave2(int NumberofEnemysToSpawn)
    {
        for (int i = 0; i < NumberofEnemysToSpawn; i++)
        {

            Instantiate(BowlingBallPF, GenrateSpawnPos2(), BowlingBallPF.transform.rotation);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyCount = FindObjectsByType<BowlingBallControler>(0).Length;

        if (enemyCount == 0 || Input.GetKeyDown(KeyCode.Escape))
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUP, GenrateSpawnPos1(), powerUP.transform.rotation);
        }
   /*     if (canSpawn == true)
        {
            waveNumber++;
            SpawnEnemyWave2(waveNumber);
            Instantiate(BowlingBallPF, GenrateSpawnPos2(), BowlingBallPF.transform.rotation);
        }*/
    }

    //Create the spot to spawn 
    private Vector2 GenrateSpawnPos1()
    {
        float spawnPosY = 1;
        float spawnPosX = Random.Range(-8, 1);
        Vector2 randomPos1 = new Vector2(spawnPosX, spawnPosY);
        return randomPos1;
    }


    private Vector2 GenrateSpawnPos2()
    {
        float spawnPosy = 0.09f;
        float spawnPosX = Random.Range(18, 48);
        Vector2 randomPos2 = new Vector2(spawnPosX, spawnPosy);
        return randomPos2;
    }
    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("SPAWN TRIGGER!");
        StartCoroutine(SpawnStuff());
    }

    IEnumerator SpawnStuff()
    {
        canSpawn = true;
        while(canSpawn)
        {
           
            
                Instantiate(BowlingBallPF, GenrateSpawnPos2(), BowlingBallPF.transform.rotation);
                yield return new WaitForSeconds(5);
            
        }
    }    




}
