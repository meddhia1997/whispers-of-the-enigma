using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum RoomType
{
    Corridor,Room
}
public class Room : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject[] doors;
    public GameObject[] puzzleDoors;
    public RoomType type;

 

    public void UpdateRoom(bool[] status)
    {
      
      for(int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }

    }

    public void setAsPuzzleRoom(bool[]status)
    {
        for(int i=0; i < puzzleDoors.Length; i++)
        {
            puzzleDoors[i].SetActive(status[i]);
        }
       
    }

    public void closeDoors()
    {
        for (int i = 0; i < puzzleDoors.Length; i++)
        {
            if (puzzleDoors[i].activeSelf)
            {
                puzzleDoors[i].GetComponent<Animator>().SetBool("close",true);
            }
        }

    }
    public void openDoors()
    {
        for (int i = 0; i < puzzleDoors.Length; i++)
        {
            if (puzzleDoors[i].activeSelf)
            {
                puzzleDoors[i].GetComponent<Animator>().SetBool("close", false);
            }
        }

    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="XR Origin")
        {
            closeDoors();
        }
        

    }


    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "XR Origin")
        {
            openDoors();
        }

    }



}
