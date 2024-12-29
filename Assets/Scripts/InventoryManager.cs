using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static Dictionary <string, bool> inventoryItems;
    public GameObject Flashlight, fuse1, fuse2, fuse3, fuse4, firstFusePiece, secondFusePiece, fuseBody;
    public static InventoryManager instance;

    private void Awake()
    {

        inventoryItems = new Dictionary<string, bool>
        {
            {Flashlight.name, false },
            {fuse1.name, false },
            {fuse2.name, false },
            {fuse3.name, false },
            {fuse4.name, false },
            {firstFusePiece.name, false },
            {secondFusePiece.name, false },
            {fuseBody.name, false }
        };
    }

    
    

    // Update is called once per frame
    void Update()
    {
        
    }


}
