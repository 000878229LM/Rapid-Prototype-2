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
    public Vector3 MousePosition; //Where the bullet will go, where the player clicked

    public float directBullet;
    void Start()
    {
        // We need to have the bullets fetch the following when created.
        // 2. They need to have their direction of travel, determined by inverting their angle relative to the player. 

        MousePosition = Input.mousePosition;
        Debug.Log(MousePosition); 
        GetBulletColour(); //Gets at start so player can't change the bullet after it's fired
        ChangeColour();

    }

    // Update is called once per frame
    void Update()
    {
        DestroyBullet();

        // This should work as is to move the bullet towards its target.
       //transform.position = Vector3.MoveTowards(transform.position, MousePosition, BulletSpeed * Time.deltaTime); 
        
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
    private void GetBulletColour()
    {
        Player player = FindFirstObjectByType<Player>(); //Creates a player object it can read the colour from
        BulletColour = player.BulletColour; //Makes the bullet colour the same as the player
        Debug.Log("int value is " + BulletColour); //Checks value of int that it has changed for the bullet
    }

    /// <summary>
    /// Changes the sprite render colour based on bullet colour
    /// </summary>
    private void ChangeColour()
    {
        if (BulletColour == 0) { GetComponent<SpriteRenderer>().color = Color.red; }
        else if (BulletColour == 1) { GetComponent<SpriteRenderer>().color = Color.green; }
        else if (BulletColour == 2) { GetComponent<SpriteRenderer>().color = Color.blue; }


    }

    /// <summary>
    /// Destroy bullet object if object is not on camera
    /// </summary>
    private void DestroyBullet()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0 || viewPos.x > 1 ||
            viewPos.y < 0 || viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }


    /// <summary>
    /// Just some garbage I was trying - Liam
    /// </summary>
    void MovementCode2()
    {
        float eX = MousePosition.x;
        float eY = MousePosition.y;
        float tempX = transform.position.x;
        float tempY = transform.position.y;

        if (transform.position.x > eX) { tempX++; }
        if (transform.position.y > eY) { tempY++; }
        if (transform.position.x < eX) { tempX--; }
        if (transform.position.y < eY) { tempY--; }
        transform.position = new Vector3(tempX, tempY, transform.position.z);
    }

}
