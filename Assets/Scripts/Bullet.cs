using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int BulletColour; 
    public float BulletRadius;
    public Vector3 BulletDirection;
    public float BulletSpeed = 5;
    void Start()
    {
        // We need to have the bullets fetch the following when created.
        // 1. They need to have their colour, determined by the player script. 
        // 2. They need to have their direction of travel, determined by inverting their angle relative to the player. 
        
        
        // No idea what this does. - Payton 
        //GetComponent<Bullet>();
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
        if (collision.gameObject.tag != "PlatformPrefab")
        {
            Bullet.Destroy(collision.gameObject);
        }
    }

}
