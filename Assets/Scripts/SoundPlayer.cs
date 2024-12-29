using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundPlayer : MonoBehaviour
{
    public AudioSource source;
    public float stepInterval = 0.4f; // intervalle minimum entre chaque pas
    private float lastStepTime = 0f; // temps du dernier pas
    public CharacterController characterController; // référence au CharacterController

   

    private void Update()
    {
        // Vérifier si le personnage bouge
        if (characterController.velocity.magnitude > 0 && Time.time > lastStepTime + stepInterval)
        {
            // Jouer le son de pas
            source.Play();
            Debug.Log("Yass");
            lastStepTime = Time.time;
        }
    }
}
