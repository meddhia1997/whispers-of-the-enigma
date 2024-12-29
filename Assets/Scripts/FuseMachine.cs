using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FuseMachine : MonoBehaviour
{
    private Animation animation;
    public GameObject firstPiece, secondPiece, bodyFuse, SecondFuse;
    // Start is called before the first frame update
    private void Start()
    {
        animation = GetComponent<Animation>();
   
    }
    


    public void FuseIn()
    {
        Debug.Log("Marche");
        // Set the "PlayAnimation" trigger parameter in the animator to true
        StartCoroutine(WaitForSeconds(2));
        }
       
  
    
    private IEnumerator WaitForSeconds(float seconds)
    {

        // Player has waited for 2 seconds, continue with the desired logic
        animation.Play("CloseFuseMachine");
        yield return new WaitForSeconds(seconds);
        Destroy(firstPiece);
        Destroy(secondPiece);
        Destroy(bodyFuse);
        SecondFuse.SetActive(true);
        animation.Play("OpenFuseMachine");



    }


}
