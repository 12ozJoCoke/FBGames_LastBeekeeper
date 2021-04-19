using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public float cameraForwardOffset, cameraLerpSpeed;
    public Transform objectToFollow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mov = new Vector3(objectToFollow.position.x, objectToFollow.position.y, transform.position.z);
        
        transform.position = mov;
    }
}
