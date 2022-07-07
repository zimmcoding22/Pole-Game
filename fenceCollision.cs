using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fenceCollision : MonoBehaviour
{
    AudioSource fence_hit;

    // Start is called before the first frame update
    void Start()
    {
        fence_hit = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.tag == "Puck")
        {
            fence_hit.Play(0);
            //Debug.Log("fence has been hit: " + col.relativeVelocity.magnitude);
        }
    }
}
