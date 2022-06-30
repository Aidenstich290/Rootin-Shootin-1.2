using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    public Transform pos2; // Asigns second Position Location
    
    public float speed; // Asigns How fast it will Move
   
    public Transform startPos; // Asigns Start Position Location

    Vector3 nextPos; // Asigns the vector as Next Position

    void Start()
    {
        nextPos = startPos.position; // Tells to move to the Next Position
    }

    void Update()
    {

        if(transform.position == pos2.position) // Sees if the cloud is at pos2 
        {
            nextPos = startPos.position; // Tells to move to start position 
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime); // Use to move the clouds Position
    }
     
}
