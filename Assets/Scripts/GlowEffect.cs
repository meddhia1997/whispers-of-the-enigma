using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GlowEffect : MonoBehaviour
{
    Renderer renderer;


   

    // Start is called before the first frame update
    void Start()
    {
       renderer= gameObject.GetComponent<Renderer>();
        renderer.material.shader = Shader.Find("Custom/Glow");
        renderer.material.SetInt("_Frequency", 120);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeGlow()
    {
        gameObject.GetComponent<Renderer>().material.SetInt("_Frequency", 0);
    }
    public void enableGlow()
    {
        gameObject.GetComponent<Renderer>().material.SetInt("_Frequency", 120);
    }
}
