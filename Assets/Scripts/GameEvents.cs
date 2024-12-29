using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }


    public event Action onflashLightFound;
    public void flashLightFound()
    {
        if(onflashLightFound != null)
        {
            onflashLightFound();
        }

    }
    
}
