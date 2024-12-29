using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public String keyTag;
    private Rigidbody doorRigidBody;
    public static DoorUnlock instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        doorRigidBody =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UnlockDoor()
    {
        doorRigidBody = GetComponent<Rigidbody>();
        doorRigidBody.constraints = RigidbodyConstraints.None;
    }
   
    public void saveBasementDoor()
    {
        PlayerPrefs.SetInt("BasementDoor", 1);
    }
    public void saveWallSafe()
    {
        PlayerPrefs.SetInt("WallSafeOpen", 1);
    }
}
