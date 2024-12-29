using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Hand : MonoBehaviour
{
    //Animations
    private float triggerTarget;
    private float gripTarget;
    private float triggerCurrent;
    private float gripCurrent;
    public float speed;
    Animator animator;
    //Physics
    /*the controller*/ public GameObject followObject;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    private Transform followTarget;
    private Rigidbody body;
    public float rotateSpeed=100f;
    public float followSpeed =30f;
    private Collider[] handcolliders;
    private SkinnedMeshRenderer skinnedMeshRenderer;

   

    void Start()
    {
        animator = GetComponent<Animator>();
        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        body.position=followTarget.position;
        body.rotation=followTarget.rotation;
        handcolliders = GetComponentsInChildren<Collider>();
        skinnedMeshRenderer=GetComponentInChildren<SkinnedMeshRenderer>();
    }


    private void Update()
    {
        AnimateHand();
        //PhysicsMove();



    }

    private void FixedUpdate()
    {
        PhysicsMove();
    }

    public void enableSkinnedMeshRenderer()
    {
        skinnedMeshRenderer.enabled = true;
    }
    public void disbleSkinnedMeshRenderer()
    {
        skinnedMeshRenderer.enabled = false;


    }
    public void enableHandCollidersDelay(float delay)
    {
        Invoke("enableHandColliders",delay);
    }

    public void enableHandColliders()
    {
        IEnumerator couroutine = ColliderDelay();
        StartCoroutine(couroutine);
        
    }
    public void disableHandColliders()
    {
       
        foreach (Collider collider in handcolliders)
        {
            collider.enabled = false;

        }


    }
    internal void SetGrip(float v)
    {
        gripTarget = v;
        
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
       
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
   

    void AnimateHand()
    {
    if(gripCurrent != gripTarget)
        {
            gripCurrent=Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime*speed);
            animator.SetFloat("grip", gripCurrent);
        }
        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat("trigger", triggerCurrent);
        }

    }

    private void PhysicsMove()
    {
        
        var positionWithOffset = followTarget.position + positionOffset;
        //position
        var distance =Vector3.Distance(positionWithOffset, transform.position);
        body.velocity = (positionWithOffset - transform.position).normalized*(followSpeed*distance);
        //rotation
        var rotationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        if (Mathf.Abs(axis.magnitude) != Mathf.Infinity)
        {
            if (angle > 180.0f) { angle -= 360.0f; }
            body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
        }




    }
    public IEnumerator ColliderDelay()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(1f);
        foreach (Collider collider in handcolliders)
        {
            collider.enabled = true;

        }
        Debug.Log("Waiting completed");
      

    }

}
