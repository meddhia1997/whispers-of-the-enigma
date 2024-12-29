using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class QuestEventTrigger : MonoBehaviour
{

    //public UnityEvent triggerEvent;
    public bool repeatable;
    public GameEvent gameEvent;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void triggerQuestEvent() {
        Debug.Log("Event ");
        gameEvent.Raise();
        if (!repeatable)
        {
            this.enabled = false;
        }
      
        }

}
