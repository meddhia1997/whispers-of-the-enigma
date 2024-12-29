using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officeWallAnimation : MonoBehaviour
{
    Animator animator;
    private bool wallOpen = true;
    public static officeWallAnimation instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openWall()
    {
        animator = GetComponent<Animator>();
        if (wallOpen)
        {
            PlayerPrefs.SetInt("WallOpen", 1);
        }
        else
        {
            {
                PlayerPrefs.SetInt("WallOpen", 0);
            }
        }
        animator.SetBool("wallOpen", wallOpen);
        wallOpen = !wallOpen;
       


    }
}
