using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    //make the bat move towards the player
    private GameObject player;
    private Vector2 playerLocation;
    public float speed;
    public float bounceForce;
    public float health;
    private GameObject gameManager;
    private PlayerScore playerScore;
    public int batVal;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //find the game manager gameobject so we can have reference to the player's score
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        //Get reference to the script PlayerScore so we can increment the score when we kill an enemy
        playerScore = gameManager.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision " + collision.gameObject.name);
        if(collision.gameObject.CompareTag("Player"))
        {
            playerScore.setPlayerScore(batVal);
            Destroy(this.gameObject);
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, bounceForce);
        }
        else if(collision.gameObject.CompareTag("Bullet"))
        {
            MoveBullet mb = collision.gameObject.GetComponent<MoveBullet>();
            health -= mb.getBulletDamage();
            isDead();
        }
    }

    private void isDead()
    {
        if(health <= 0)
        {
            playerScore.setPlayerScore(batVal);
            Destroy(this.gameObject);
        }
    }
}
