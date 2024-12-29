using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LobbyNetworkPlayer : NetworkBehaviour
{

   
    

    public override void OnNetworkSpawn()
    {
        DisableClients();

    }

    public void DisableClients()
    {
        if (IsClient && !IsOwner)
        {
            gameObject.SetActive(false);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (IsClient && IsOwner)
        {
            transform.position = new Vector3(0f, 0.95f, -10.15f);

        }
    }
    
}
