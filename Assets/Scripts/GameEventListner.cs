using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class GameEventWithString : UnityEvent<string> { }

public class GameEventListner : MonoBehaviour
{
    public GameEvent gameEvent;

    public GameEventWithString responseStr;
    public UnityEvent response;

  

    private void OnEnable()
    {
        gameEvent.RegisterListner(this);
    }

    private void OnDisable()
    {
        gameEvent.UnRegisterListner(this);
    }
    public void OnEventRaised()
    {
        Debug.Log("Event Raised");
        response.Invoke();
       
    }

    public void OnEventRaised(string s)
    {
        Debug.Log("Event Raised");
        responseStr.Invoke(s);

    }

}
