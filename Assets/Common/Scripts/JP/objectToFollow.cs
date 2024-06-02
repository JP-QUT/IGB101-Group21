using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmortalSnail : MonoBehaviour
{
    public Transform objectToFollow;
    public float followSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        // Calculate distance between object and target object
        // Then follow the object each frame (Not affected by FPS (due to: Time.deltaTime))

        var delta = objectToFollow.position - transform.position;
        transform.position += delta * Time.deltaTime * followSpeed;
    }
}
