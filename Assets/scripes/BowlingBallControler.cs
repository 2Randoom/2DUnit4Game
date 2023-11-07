using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallControler : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D BowlingBallRb;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        BowlingBallRb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BowlingBallRb.AddForce((Player.transform.position - transform.position).normalized * Speed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
