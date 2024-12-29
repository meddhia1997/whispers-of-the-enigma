using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip collisionSound1;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "XR Origin")
        {
            Debug.Log("Player detected");

            audioSource.PlayOneShot(collisionSound1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "XR Origin")
        {
            Destroy(gameObject);
        }
    }
}

  