using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class Hint : MonoBehaviour
{
    public float radius;
    public string content;
    public float timeToTrigger;
    public GameObject player;
    private bool coroutineStarted=false;
    public GameEvent gameEvent;
    public Text hintUi;
    IEnumerator myCouroutine;
   
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
       Debug.Log(Vector3.Distance(transform.position, player.transform.position));

        if (Vector3.Distance(transform.position, player.transform.position) <= radius && !coroutineStarted)
        {
            coroutineStarted = true;
            myCouroutine = TriggerTimer();
            StartCoroutine(myCouroutine); 

        }
        if(Vector3.Distance(transform.position, player.transform.position) >= radius && coroutineStarted)
        {
            coroutineStarted =false;
            StopCoroutine(myCouroutine);

        }
        
    }
    IEnumerator TriggerTimer()
    {
        Debug.Log("Hint timer started");
        yield return new WaitForSeconds(timeToTrigger);
        //gameEvent.Raise(content);
        IEnumerator couroutine = displayHint();
        StartCoroutine(couroutine);

       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public IEnumerator displayHint()
    {
        
        hintUi.gameObject.SetActive(true);
        hintUi.enabled = true;
        hintUi.text = content;
        yield return new WaitForSeconds(2);
        hintUi.text = "";
        hintUi.enabled = false;
       
        //gameEvent.Raise(content);


    }

    public void DisableHint()
    {
        StopCoroutine(myCouroutine);
        this.enabled = false;
    }


}
