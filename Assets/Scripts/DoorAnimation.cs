using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public AudioClip doorSound;
    private Animation doorCloseAnimation;
    private AudioSource doorAudioSource;
    private Rigidbody rb;
    
    // Start is called before the first frame update
   
    void Start()
    {
        doorAudioSource = GetComponent<AudioSource>();
        doorCloseAnimation = GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();
    }

   public void closeDoor()
    {
        doorCloseAnimation.Play();
        doorAudioSource.PlayOneShot(doorSound);
        rb.constraints = RigidbodyConstraints.None;

    }
}
