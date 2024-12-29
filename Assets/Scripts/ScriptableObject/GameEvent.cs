using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/gameEvents")]
public class GameEvent : ScriptableObject
{
    public List<GameEventListner> listners =new List<GameEventListner>();

    public void Raise()
    {
        for (int i = 0; i < listners.Count; i++)
        {
            {
                listners[i].OnEventRaised();
            }

        }
    }
    public void Raise(string s)
    {
        for (int i = 0; i < listners.Count; i++)
        {
            {
                listners[i].OnEventRaised(s);
            }

        }
    }
  
    public void RegisterListner(GameEventListner listner)
    {
        if (!listners.Contains(listner))
        {
            listners.Add(listner);
        }

    }
   public void UnRegisterListner(GameEventListner listner)
    {
        if (listners.Contains(listner))
        {
            listners.Remove(listner);
        }

    }

}
