using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MazeGameManager : NetworkBehaviour
{
    [SerializeField] private Transform playerPrefab;
    //public override void OnNetworkSpawn()
    //{
        //if (IsServer)
        //{
        //    NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += SceneManager_OnLoadEventCompleted;
        //}
    //}
    /*
        private void SceneManager_OnLoadEventCompleted(string sceneName, UnityEngine.SceneManagement.LoadSceneMode loadSceneMode, System.Collections.Generic.List<ulong> clientsCompleted, System.Collections.Generic.List<ulong> clientsTimedOut)
        {
            foreach(ulong cliendId in NetworkManager.Singleton.ConnectedClientsIds)
            {
                Vector3 spawnPos = FindObjectOfType<MapGenerator>().findNetworkPlayerSpawnCell();
                Transform playerTransform = Instantiate(playerPrefab,spawnPos,Quaternion.identity);
                playerTransform.GetComponent<NetworkObject>().SpawnAsPlayerObject(cliendId);
            }
        }
    */


    public void SpawnPlayers(Vector3[] SpawnPos)
    {
        if (IsServer) {
            int i = 0;
            foreach (ulong cliendId in NetworkManager.Singleton.ConnectedClientsIds)
            {
                Vector3 spawnPos = SpawnPos[i];
                i++;
                Transform playerTransform = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
                playerTransform.GetComponent<NetworkObject>().SpawnAsPlayerObject(cliendId);
            }
        }
    }


}
