using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//adds each additional puck to sphere collider array under cloth in inspector
public class clothCollision : MonoBehaviour
{
    Cloth flag;
    GameObject puck;
    movePuck currentPuck;
    // Start is called before the first frame update
    void Start()
    {
        flag = GetComponent<Cloth>();
        puck = GameObject.Find("Puck");
        currentPuck = puck.GetComponent<movePuck>();
        
    }

    void Update()
    {
        puck = currentPuck.nextPuck;
        var colliders = new ClothSphereColliderPair[1];
        colliders[0] = new ClothSphereColliderPair(puck.GetComponent<SphereCollider>());
        flag.sphereColliders = colliders;
    }
  
}
