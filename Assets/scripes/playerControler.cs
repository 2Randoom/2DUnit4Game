using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
    public Rigidbody2D bowlingBallRB;
    public float speed;
    public float jumpForce;
    private bool isOnGround = true;

    private bool hasPowerUP = false;
    private float powerupStrength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
       PlayerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
   
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround)
        {
            PlayerRB.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            if (!hasPowerUP)
            {
                isOnGround = false;
            }
                
                    
        }
    }
    private void FixedUpdate()
    {
        float horizontalMovment = Input.GetAxis("Horizontal");
        PlayerRB.AddForce(Vector2.right * speed * horizontalMovment);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (other.CompareTag("PowerUP"))
        {
            hasPowerUP = true;
            Destroy(other.gameObject);
            Debug.Log("POWER UP!");
            isOnGround = true;
            //COROUTINE
            StartCoroutine("PowerUpCoolDown");
        }
    }

    //MAKE COROUTINE
    IEnumerator PowerUpCoolDown()
    {
        yield return new WaitForSeconds(5);
        hasPowerUP = false;
        isOnGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    

       
     
    }
    
}
