using UnityEngine;

public class BlindsCollisionDetector : MonoBehaviour
{
    public int collisionCount = 0;  // keep track of collision count
    public GameObject vent;  // reference to the game object with name "vent"

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "blinds")
        {
            collisionCount++;  // increment collision count if collision is with "blinds" object
            if (collisionCount >= 3)
            {
                Destroy(collision.gameObject);  // destroy "blinds" object if collision count is 3 or more
                if (vent != null)  // check if "vent" object exists
                {
                    vent.SetActive(false);  // deactivate "vent" object
                }
            }
        }
    }
}