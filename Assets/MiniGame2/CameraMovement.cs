/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

Vector3 moveToPosition; // This is where the camera will move after the start
float speed = 2f; // this is the speed at which the camera moves
bool started = false; // stops the movement until we want it

void Start()
{
    // Since this object as an child the (0, 0, 0) position will be the same as the players. So we can just add to the zero vector and it will be position correctly. 

    moveToPosition = new Vector3(0, 2, -0.01f); // 2 meters above/ 0.01 meters behind
                                                // If you are allowed to rotate your camera the change the -0.01 to 0

    // The following function decides how long to stare at the player before moving
    LookAtPlayerFor(3.5f); // waits for 3.5 seconds then starts 
}

void Update()
{
    // so we only want the movement to start when we decide
    if (!started)
        return;

    // Move the camera into position
    transform.position = Vector3.lerp(transform.position, moveToPosition, speed);

    // Ensure the camera always looks at the player
    transform.LookAt(transform.parent);
}

Enumarator LookAtPlayerFor(float time)
{
    yield return new WaitForSeconds(time);
    started = true;
}
*/