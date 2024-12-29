using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FuseSocket : MonoBehaviour
{
    public GameObject light;
    public Material greenlight;
    public Material redlight;
    private bool isConnected = false;
    public GameObject controlledLights;
    public FuseSocket previousSocket;
    public FuseSocket nextSocket;
    public LastDoor lastDoor;
    private XRSocketInteractor socket;
    private string fuseName;

    void Start()
    {
        socket= gameObject.GetComponent<XRSocketInteractor>();

    }

    public void fuseConnected()
    {
        if (isConnected)
        {

           
            if (this.Equals(previousSocket) || previousSocket.getConnectionStatus())
            {
                light.GetComponent<Renderer>().material = greenlight;
                controlledLights.SetActive(true);
                if (!this.Equals(nextSocket))
                {
                    nextSocket.fuseConnected();
                }
                else
                {
                    lastDoor.Unlock();
                }

            }
        }
       

    }

    public void fuseSocketSaveIn()
    {
        socket = gameObject.GetComponent<XRSocketInteractor>();
        fuseName = socket.GetOldestInteractableSelected().transform.name;
        Debug.Log(fuseName+" IN");
        PlayerPrefs.SetInt(fuseName,1);
    }

    public void fuseSocketSaveOut()
    {
        //PlayerPrefs.SetInt(fuseName,0);
        //Debug.Log(fuseName + " Out");
    }



    public void fuseDisconnected()
    {
       
        light.GetComponent<Renderer>().material = redlight;
        controlledLights.SetActive(false);
        if (!this.Equals(nextSocket))
        {
            nextSocket.fuseDisconnected();
        }
        else
        {
            lastDoor.Lock();
        }
    }

    public void switchConnection()
    {
        this.isConnected = !this.isConnected;
    }



    public bool getConnectionStatus()
    {
        if (!this.Equals(previousSocket))
        {
            return (this.isConnected && previousSocket.getConnectionStatus());

        }
        return this.isConnected;
    }

  
  
}