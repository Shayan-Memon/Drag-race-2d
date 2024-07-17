using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private CarMove roadvals;
    public float targetPositionX = 400.0f;
    public Vector3 newPosition = new Vector3(450.0f, 0.0f, 0.0f); // Change this to your desired position

    void Start()
    {

        transform.position = new Vector3(-100.0f, 0.0f, 0.0f); ;
        roadvals = GameObject.FindGameObjectWithTag("Player").GetComponent<CarMove>();
        
    }

    void Update()
    {

        
        if (roadvals.transform.position.x > targetPositionX)
        {
            
            transform.position = newPosition; // Move the sprite to the new position
        }
    }
}
