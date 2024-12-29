using HurricaneVR.TechDemo.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class BasementDoor : MonoBehaviour
{
    public Material[] materials;
    public GameObject[] papers;
    public Texture[] numberTextures;

    public static string code;

    private void Start()
    {
        code = Random.Range(1000, 10000).ToString() ;
        for (int i = 0; i < code.Length ; i++)
        {
            int digit = int.Parse(code[i].ToString());
            Renderer renderer = papers[i].GetComponent<Renderer>();
            renderer.material = materials[digit];
            RawImage rawImage = papers[i].GetComponentInChildren<RawImage>();
            rawImage.texture = numberTextures[i];
        }
    }
}
