using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject hintZones,headset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateHints()
    {
        hintZones.SetActive(true);
        Destroy(headset);
        Destroy(gameObject);
    }
}
