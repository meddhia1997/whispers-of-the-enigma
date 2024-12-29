using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LastDoor : MonoBehaviour
{
    [SerializeField]
    private Light light;
    [SerializeField]
    private MeshRenderer meshRenderer;
    [SerializeField]
    private Material green,red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlock()
    {
        light.color = Color.green;
        meshRenderer.material = green;
    }

    public void Lock()
    {
        light.color = Color.red;
        meshRenderer.material = red;


    }
}
