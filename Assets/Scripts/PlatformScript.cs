using UnityEngine;

public class ColourPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int PlatformColour; 
    public bool PlatformActive;

    void Start()
    {
        
    }

    // Update - Seems unnecessary for this script, leaving it because I'm unsure. 
    //void Update()
    //{
        
    //}
    
    // Collider information - WIP - This should allow the platform to detect when it is struck by a coloured ball. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlatformPrefab" || collision.gameObject.tag == "Bullet")
        {
            if (PlatformColour == BulletColour)
            {
                PlatformActive = true;
                return;
            }
            if (PlatformColour != BulletColour)
            {
                PlatformActive = false;
                return;
            }


        }
   
    }
    
}
