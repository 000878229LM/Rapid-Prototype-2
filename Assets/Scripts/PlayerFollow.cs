using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private Transform target;

    public float smoothRate = 1.5f;
    public Vector3 cameraOffset = Vector3.zero;
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // LateUpdate runs after Update is finished
    void LateUpdate()
    {
        //TRANSFORM z not target z
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPos + cameraOffset, Time.deltaTime * smoothRate);
    }
}
