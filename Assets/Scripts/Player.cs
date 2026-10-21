using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int BulletColour;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Keyboard.current.eKey.wasPressedThisFrame) {
            Debug.Log("Pressed e key");
            if (BulletColour == 0) {BulletColour = 1; Debug.Log("Colour is red"); }
            else if (BulletColour == 1) {BulletColour = 2; Debug.Log("Colour is green"); }
            else if (BulletColour == 2) {BulletColour = 0; Debug.Log("Colour is blue"); }


        }
    }
}
