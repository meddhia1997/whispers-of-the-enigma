using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public float maxDistance=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      

    }

    public void checkAvailableMovement()
    {
       
        Ray ray=new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, -transform.right*0.1f, Color.green);
        if (!Physics.Raycast(ray,maxDistance))
        {
            transform.Translate(0, 0.12f, 0);   
            return;
        }
        ray.direction = -transform.up;
        if(!Physics.Raycast(ray,maxDistance))
        {
            transform.Translate(0, -0.12f, 0);
            return;
        }
        ray.direction = transform.right;
        if (!Physics.Raycast(ray, maxDistance))
        {
            transform.Translate(0.12f, 0, 0);
            return;
        }
        ray.direction = -transform.right;
        if (!Physics.Raycast(ray, maxDistance))
        {
            transform.Translate(-0.12f, 0, 0);
            return;
        }
    }

}
