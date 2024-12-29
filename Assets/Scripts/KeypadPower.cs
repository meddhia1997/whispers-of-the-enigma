using HurricaneVR.TechDemo.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadPower : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    DemoKeypadButton[] scripts;
    // Start is called before the first frame update
    void Start()
    {
        scripts = gameObject.GetComponentsInChildren<DemoKeypadButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PowerOn()
    {
        gameObject.GetComponent<DemoKeypad>().enabled = true;
        scripts = gameObject.GetComponentsInChildren<DemoKeypadButton>();
        foreach (DemoKeypadButton script in scripts)
        {
            script.enabled = true;
        }
        textMeshPro.text = "****";
    }
    public void PowerOff()
    {
        gameObject.GetComponent<DemoKeypad>().enabled = false;

        foreach (DemoKeypadButton script in scripts)
        {
            script.enabled = true;
        }
        textMeshPro.text = "";

    }
}
