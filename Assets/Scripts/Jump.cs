using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpButton;
    [SerializeField] private float jumpHeight = 0.2f;
    [SerializeField] private float gravityValue=-9.81f;
    

    private CharacterController _characterController;
    private Vector3 _playerVelocity ;


    private void awake() => _characterController = GetComponent<CharacterController>();



    private void OnEnable() => jumpButton.action.performed += Jumping;

    private void OnDisable() => jumpButton.action.performed -= Jumping;

    private void Jumping (InputAction.CallbackContext obj)
    {

        _playerVelocity.y = Mathf.Sqrt( jumpHeight * -3.0f * gravityValue);
    }


    private void Update ()
    {
        if(_playerVelocity.y < 0) {
        _playerVelocity.y = 0;
        }
        _playerVelocity.y=gravityValue*Time.deltaTime;
       
    }
}