using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManiger : MonoBehaviour
{
    public GameObject BowlingBallPF;
  
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(BowlingBallPF, GenrateSpawnPos(), BowlingBallPF.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        {
         
            
        }

    }
    private Vector2 GenrateSpawnPos ()
    {
    float spawnPosY = 1;
    float spawnPosX = Random.Range(-8, 1);
        Vector2 randomPos = new Vector2(spawnPosX, spawnPosY);
       return randomPos;
    }
}
