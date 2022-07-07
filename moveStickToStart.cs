using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveStickToStart : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    private int current;
    Rigidbody m_Rigidbody;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("we are in the update function");
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            m_Rigidbody.MovePosition(pos);
        }
        else current = (current + 1) % target.Length;

    }

    
}
