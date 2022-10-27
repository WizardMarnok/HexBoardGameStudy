using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    public float distance = 4.0f;
    public float delay = 1.0f;
    
    private float accumulatedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accumulatedTime += Time.deltaTime;

       // if (accumulatedTime > delay)
        if(1 == 1)
        {
            Vector3 player_movement = new Vector3(0,0,0);

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                player_movement.x=-distance;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))

            {
                player_movement.x=distance;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player_movement.z=distance;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player_movement.z=-distance;
            }

            transform.position = transform.position + player_movement;
        }
    }
}
