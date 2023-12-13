using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    public Camera cam;

    private Vector2 movement;
    private Vector2 mousePosition;
    private Vector2 playerScreenPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector2.zero;

        // Check each key and add the direction to the movement vector
        if (Input.GetKey(KeyCode.W))
        {
            movement.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x += 1;
        }

        // Normalize the movement vector to maintain consistent speed in all directions
        movement.Normalize();
        
        mousePosition = Input.mousePosition;
        playerScreenPosition = cam.WorldToScreenPoint(transform.position);

        double dx = mousePosition.x - playerScreenPosition.x;
        double dy = mousePosition.y - playerScreenPosition.y;

        double angle = -Math.Atan2(dx, dy);
        
        transform.rotation = Quaternion.Euler(0, 0, (float) (angle * (180/Math.PI)));
        transform.position = new Vector3(transform.position.x + movement.x * movementSpeed * Time.deltaTime, transform.position.y + movement.y * movementSpeed * Time.deltaTime, transform.position.z);
        cam.transform.position = new Vector3(transform.position.x + movement.x * movementSpeed * Time.deltaTime, (transform.position.y + movement.y * movementSpeed * Time.deltaTime), cam.transform.position.z);

    }
}
