using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DeathPlayer : MonoBehaviour
{
    private CharacterController characterController;
    public Animator animator;
    public GameObject locomotionSystem;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyWeapon"))
        {
            locomotionSystem.SetActive(false);
            animator.SetBool("caught", true);
        }
    }
}
