using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
   private  Light light;
   private bool hasBattery=false;
   public GameEvent gameEvent;
    [SerializeField]
    private GameObject battery;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableFlashlight()
    {
        light = GetComponentInChildren<Light>();
        if (hasBattery) {
            light.enabled = true;
            Debug.Log("herre battery");
        }
    }

    public void disableFlashlight()
    {
        light.enabled = false;
    }


    public void addBattery()
    {

        this.hasBattery = true;
        enableFlashlight();
        Destroy(battery);
    }

  

}
