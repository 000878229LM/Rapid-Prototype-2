using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int BulletColour; 
    public float BulletRadius;
    public Vector3 BulletDirection;
    public float BulletSpeed;
    void Start()
    {
        // We need to have the bullets fetch the following when created.
        // 2. They need to have their direction of travel, determined by inverting their angle relative to the player. 

        GetBulletColour(); //Gets at start so player can't change the bullet after it's fired
        ChangeColour();
    }

    // Update is called once per frame
    void Update()
    {
 
        // This should work as is to move the bullet towards its target. 
        transform.position = Vector3.MoveTowards(transform.position, BulletDirection, BulletSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        //This either destroys the bullet when it collides with non platforms, or it destroys the object. 
        if (collision.gameObject.tag != "PlatformPrefab" || collision.gameObject.tag != "Player")
        {
            Bullet.Destroy(collision.gameObject);
        }
    }


    /// <summary>
    /// Opens the player object and saves its colour to the bullet object
    /// </summary>
    private void GetBulletColour(){
        Player player = FindFirstObjectByType<Player>(); //Creates a player object it can read the colour from
        BulletColour = player.BulletColour; //Makes the bullet colour the same as the player
        Debug.Log("int value is " + BulletColour); //Checks value of int that it has changed for the bullet
    }

    /// <summary>
    /// Changes the sprite render colour based on bullet colour
    /// </summary>
    private void ChangeColour(){
        if (BulletColour == 0) { GetComponent<SpriteRenderer>().color = Color.red; }
        else if (BulletColour == 1) { GetComponent<SpriteRenderer>().color = Color.green; }
        else if (BulletColour == 2) { GetComponent<SpriteRenderer>().color = Color.blue; }
        

    }

}
