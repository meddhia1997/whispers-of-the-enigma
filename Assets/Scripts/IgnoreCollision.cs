using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public Collider[] colliders;
    private Collider thisCollider;
    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<Collider>();
        foreach(Collider collider in colliders){
            Physics.IgnoreCollision(thisCollider, collider);
        }
    }

   
}
