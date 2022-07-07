using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class streetCollider : MonoBehaviour
{

    AudioSource skid;
    GameObject puck;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        skid = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Puck")
        {
            puck = GameObject.Find("Puck"); 
            puck = puck.GetComponent<movePuck>().nextPuck;
            rb = puck.GetComponent<Rigidbody>();
            if (rb.velocity.z > .01)
            {
                skid.Play(0);
            }
        }
    }

}
