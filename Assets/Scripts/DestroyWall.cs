using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    private int collisionNumber = 0;
    public AudioClip collisionSound1;
    public AudioClip collisionSound2;
    public AudioSource audioSource;
    private MeshDestroy meshDestroy;
    private Rigidbody rb;
    public GameObject nextCellFloor;
    public GameEvent gameEvent;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshDestroy = GetComponent<MeshDestroy>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Interactable")
        {
            collisionNumber++;
            audioSource.PlayOneShot(collisionSound1);

            Debug.Log("collision"+collisionNumber);
            if (collisionNumber >= 3)
            {
                audioSource.PlayOneShot(collisionSound2);
                rb.constraints= RigidbodyConstraints.None;
                gameEvent.Raise();

            }
        }
        if (collision.collider.gameObject.Equals(nextCellFloor))
        {
            //meshDestroy.DestroyMesh();
            Destroy(gameObject);
        }
    }

        
    

}
