using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Text hint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void displayHint(string text)
    {
        Debug.Log(text);
        IEnumerator myCouroutine = showHint(text);
        StartCoroutine(myCouroutine);
    }


    public IEnumerator showHint(string text)
    {
        Debug.Log(text);
        hint.gameObject.SetActive(true);
        hint.enabled = true;
        hint.text = text;
        yield return new WaitForSeconds(2);
        hint.enabled = false;

    }
    

}
