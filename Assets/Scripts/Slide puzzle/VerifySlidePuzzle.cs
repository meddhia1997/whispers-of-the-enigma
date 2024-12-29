using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class VerifySlidePuzzle : MonoBehaviour
{
    Ray ray;
    RaycastHit[] hits;
    private Animator animator;
    public Transform[] targets;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        verifyComplted();
    }


    public void verifyComplted()
    {
      
     int[] tiles=new int[9];
    for(int i=0; i< 3;i++)
        {

            ray.direction = -transform.right * 0.4f;
            ray.origin = targets[i].position;
            hits = Physics.RaycastAll(ray,0.35f);
            if(hits.Length > 0)
            {
                Array.Sort(hits, (RaycastHit x, RaycastHit y) => x.distance.CompareTo(y.distance));
               

                int [] inter = hits.Select(element => int.Parse(element.collider.name)).ToArray();
                inter.CopyTo(tiles, i*3);
                
            }
            
        }
        for (int i = 0; i < tiles.Length-1; i++)
        {
            if (tiles[i] != 0)
            {
                if (tiles[i] > tiles[i + 1] && tiles[i+1]!=0)
                {
                    return;

                }

            }
            
           
             }
        animator.SetBool("openBox",true);
        PlayerPrefs.SetInt("OpenBox", 1);
    }
    
}
