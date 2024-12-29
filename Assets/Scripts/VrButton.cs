using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VrButton : MonoBehaviour
{
    public UnityEvent OnPressed, OnReleased;
    public float deadzone = 0.0000020f;
    private bool isPressed;
    private Vector3 startPosition;
    private ConfigurableJoint joint;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"value + threshold = {getValue()+threshold}");
        if (!isPressed && getValue()> 0)
        {
            Pressed();
        }
        if (isPressed && getValue() <= 0)
        {
            Released();
        }
    }

    private float getValue()
    {
        var value = Vector3.Distance(startPosition,transform.localPosition)/joint.linearLimit.limit;
        
        if (Mathf.Abs(value) < deadzone)
        {
            value = 0;
            
        }
       // Debug.Log(Mathf.Clamp(value, -1, 1));
        return Mathf.Clamp(value, -1, 1);
    
    }

    private void Pressed()
    {
        isPressed = true;
        OnPressed.Invoke();
        Debug.Log("Pressed");

    }
    private void Released() {
        isPressed = false;
        OnReleased.Invoke();
        Debug.Log("Released");
    }

}
