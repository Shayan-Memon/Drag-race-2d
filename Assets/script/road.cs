using UnityEngine;

public class Road : MonoBehaviour
{
    public float speed = 0f; // Speed at which the road moves back
    public float resetPosition = 6.5f; // Position at which the road will reset
    public float startPosition = 0f; // Starting position of the road

    public Transform target;

    // Update is called once per frame
    void Update()
    {
        // Move the road left based on the speed and time
        transform.position += Vector3.left * speed * Time.deltaTime;


                        
        // Check if the road has reached the reset position
        if (target.position.x >= resetPosition)
        {
            // Reset the road's position to the starting position
            Vector3 newPos = transform.position;
            newPos.x = startPosition;
            transform.position = newPos;
            resetPosition = target.position.x+6.5f;
            startPosition = target.position.x;
            
        }
    }
}
