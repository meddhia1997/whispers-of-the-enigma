using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkRoleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.isEditor)
        {
            NetworkManager.Singleton.StartHost();

        }
        else
        {
            NetworkManager.Singleton.StartClient();

        }

    }


}