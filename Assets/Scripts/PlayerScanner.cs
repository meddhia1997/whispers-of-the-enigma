using UnityEngine;

[System.Serializable]
public class PlayerScanner
{
public float meleeDetectionRadius = 2.0f;
public float detectionRadius = 10.0f;
public float detectionAngle = 90.0f;
public string playerTag = "XR Origin";
public GameObject Detect(Transform detector)
{
    GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

    if (players.Length == 0)
    {
        return null;
    }

    foreach (GameObject player in players)
    {
        Vector3 toPlayer = player.transform.position - detector.position;
        toPlayer.y = 0;

        if (toPlayer.magnitude <= detectionRadius)
        {
            if ((Vector3.Dot(toPlayer.normalized, detector.forward) >
                Mathf.Cos(detectionAngle * 0.5f * Mathf.Deg2Rad)) ||
                toPlayer.magnitude <= meleeDetectionRadius)
            {
                return player;
            }
        }
    }

    return null;
}
}

