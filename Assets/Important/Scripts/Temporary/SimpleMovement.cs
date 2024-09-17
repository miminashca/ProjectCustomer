using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 0.1f;
    public float rotationSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //creating a movevector by wasd key input (or arrows)
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);

        //rotate the movevector by the y rotation of the player so the moveVector is now facing forwards, then add the movevector to the players position
        moveVector = Quaternion.Euler(0, gameObject.transform.rotation.eulerAngles.y, 0) * moveVector;
        transform.position += moveVector;

        //rotate the player by the change in position of the mouse
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
    }
}
