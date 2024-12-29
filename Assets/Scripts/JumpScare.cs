using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public DoorAnimation doorAnimation;
    // Start is called before the first frame update

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "XR Origin")
        {
            doorAnimation.closeDoor();
            Destroy(gameObject);
        }
    }
}
