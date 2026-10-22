using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static UnityEngine.InputManagerEntry;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int BulletColour;
    public GameObject Bullet;
    Vector2 BulletTarget;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            colourSwap(); 
        }
        if (Input.GetMouseButtonDown (0)) 
        {
            shootBullet();
        }

    }
    void colourSwap()
    {
        Debug.Log("Pressed e key");
        if (BulletColour == 0) { BulletColour = 1; Debug.Log("Colour is green"); }
        else if (BulletColour == 1) { BulletColour = 2; Debug.Log("Colour is blue"); }
        else if (BulletColour == 2) { BulletColour = 0; Debug.Log("Colour is red"); }
        return;
    }
    void shootBullet()
    {
        // This should set the target for the bullets end position. 
        BulletTarget = Input.mousePosition;

        // This should allow us to spawn the actual bullets upon left clicking, 
        // but I dont know how to write it. 
        //Instantiate(bulletPrefab, BulletTarget);
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.position = transform.position;
        
        return;
    }
}
