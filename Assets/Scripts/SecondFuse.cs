using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SecondFuse : MonoBehaviour
{
    
    private bool firstPieceConnected = false;
    private bool secondPieceConnected= false;
    private XRGrabInteractable xrGrabInteractable;
    [SerializeField] private InteractionLayerMask fuseLayerMask,defaultLayerMask,inventoryItemLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        xrGrabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void firstPieceDisconnected()
    {
        firstPieceConnected = false;
        checkConnection();
    }
    public void firstPiece()
    {
        firstPieceConnected = true;
        Debug.Log("first connected");
        checkConnection();

    }
    public void secondPieceDisconnected()
    {
        secondPieceConnected = false;
        checkConnection();

    }
    public void secondPiece()
    {
        secondPieceConnected = true;
        Debug.Log("second connected");
        checkConnection();

    }

    public void checkConnection()
    {
        if (firstPieceConnected && secondPieceConnected) 
        {
            Debug.Log("connected true");
            xrGrabInteractable.interactionLayers = fuseLayerMask;
            xrGrabInteractable.interactionLayers += inventoryItemLayerMask;


        }
        else
        {
            Debug.Log("connected false");
            xrGrabInteractable.interactionLayers = defaultLayerMask;
            xrGrabInteractable.interactionLayers += inventoryItemLayerMask;
        }
    }

}
