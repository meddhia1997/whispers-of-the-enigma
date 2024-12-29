using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class MapGenerator : NetworkBehaviour
{
    public class Cell
    {
        public bool visited=false;
        public bool[] status=new bool[4];
    }
    public Vector2Int size;
    public Vector2Int startPos;
    Cell[,] board;
    public Transform[] rooms;
    public Vector2 offset;
    public Vector3[] spawnPos;

    // Start is called before the first frame update
 
    void Start()
    {
        spawnPos = new Vector3[2];
        if (IsHost)
        {
            MazeGenerator();

            spawnPos[0] = findNetworkPlayerSpawnCell();
            spawnPos[1] = findNetworkPlayerSpawnCell();
            FindObjectOfType<MazeGameManager>().SpawnPlayers(spawnPos);
        }
    }

    // Update is called once per frame
   
    void GenerateMap()
    {
        bool spawnCorridor=false;
        int randomRoom;
        for(int i = 0; i < size.x; i++)
        {
            for(int j= 0; j < size.y; j++)
            {
                if (i == size.x - 1 && j == size.y - 1)
                {
                    randomRoom = rooms.Length - 1;
                    Transform room = Instantiate(rooms[randomRoom], new Vector3(-i * offset.x, 0, -j * offset.y), Quaternion.identity);
                    room.GetComponent<NetworkObject>().Spawn();
                    var newRoom = room.gameObject.GetComponentInChildren<Room>();
                    newRoom.UpdateRoom(board[i, j].status);
                    newRoom.name += "" + i + "-" + j;
                }
                else if (board[i, j].visited)
                {
                    if (spawnCorridor)
                    {
                        randomRoom = rooms.Length - 2;
                        Transform room = Instantiate(rooms[randomRoom], new Vector3(-i * offset.x, 0, -j * offset.y), Quaternion.identity);
                        room.GetComponent<NetworkObject>().Spawn();
                        var newRoom = room.gameObject.GetComponentInChildren<Room>();
                        newRoom.UpdateRoom(board[i, j].status);
                        newRoom.name += "" + i + "-" + j;
                        spawnCorridor = false;
                    }else{
                        randomRoom = Random.Range(0, rooms.Length - 2);
                        Transform room = Instantiate(rooms[randomRoom], new Vector3(-i * offset.x, 0, -j * offset.y), Quaternion.identity);
                        room.GetComponent<NetworkObject>().Spawn();
                        var newRoom = room.gameObject.GetComponentInChildren<Room>();
                        newRoom.UpdateRoom(board[i, j].status);
                        if (Random.Range(0, 100) >= 60)
                        {
                            Debug.Log("Puzzle if");
                            newRoom.setAsPuzzleRoom(board[i,j].status);
                            newRoom.name += "puzzle";
                            spawnCorridor=true;
                        }
                        
                    }
                    
                    
                    
                }
            }
        }

    }
    void MazeGenerator()
    {
        board = new Cell[size.x,size.y];

        for(int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {

                board[i,j]=new Cell();     
            }
        }
    Vector2Int currentCell=startPos;
    Stack<Vector2Int> path=new Stack<Vector2Int>();
    int k=0;
        while (k < 1000)
        {
            k++;
            board[currentCell.x,currentCell.y].visited=true;
            if (currentCell.x ==size.x-1 && currentCell.y==size.y-1)
            {
                Debug.Log(k);
                break;
            }
            List<Vector2Int> neighbors = CheckNeighbors(currentCell);
            if (neighbors.Count == 0)
            {   
                if(path.Count == 0)
                {
                    //no more available paths
                    break;
                }
                else
                {
                    //all neighbors of current cell are visited
                    currentCell=path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);
                Vector2Int newCell = neighbors[Random.Range(0,neighbors.Count)]; 
                if (newCell.y > currentCell.y)
                { //right neighbor
                    board[currentCell.x,currentCell.y].status[2] = true;
                    currentCell = newCell;
                    board[currentCell.x,currentCell.y].status[3] = true;
                }
                else if(newCell.y<currentCell.y)
                {
                    board[currentCell.x, currentCell.y].status[3] = true;
                    currentCell = newCell;
                    board[currentCell.x, currentCell.y].status[2] = true;

                }else if (newCell.x < currentCell.x)
                {//up neighbor
                    board[currentCell.x, currentCell.y].status[0] = true;
                    currentCell = newCell;
                    board[currentCell.x, currentCell.y].status[1] = true;

                }else if(newCell.x > currentCell.x)
                {
                    board[currentCell.x, currentCell.y].status[1] = true;
                    currentCell = newCell;
                    board[currentCell.x, currentCell.y].status[0] = true;


                }
            }
        }

        GenerateMap();
    }

    List<Vector2Int> CheckNeighbors(Vector2Int cell)
    {
       // Debug.Log("cell " + cell);
        List<Vector2Int> neighbors = new List<Vector2Int>();
       //check up
        if(cell.x-1>=0 && !board[cell.x-1,cell.y].visited)
        {
            //Debug.Log("up");
            Vector2Int neighbor=new Vector2Int();
            neighbor.x = cell.x-1;
            neighbor.y = cell.y;
            neighbors.Add(neighbor);

        }
       //check down
        if (cell.x+1 < size.x && !board[cell.x+1, cell.y].visited)
        {
           // Debug.Log("down");
            Vector2Int neighbor = new Vector2Int();
            neighbor.x = cell.x+1;
            neighbor.y = cell.y;
            neighbors.Add(neighbor);
        }
       //check right
        if (cell.y+1 <size.y  && !board[cell.x,cell.y+1].visited)
        {
            //Debug.Log("right");
            Vector2Int neighbor = new Vector2Int();
            neighbor.x = cell.x;
            neighbor.y = cell.y+1;
            neighbors.Add(neighbor);
        }
        //check left
        if (cell.y-1 >= 0 && !board[cell.x,cell.y-1].visited)
        {
            //Debug.Log("left");
            Vector2Int neighbor = new Vector2Int();
            neighbor.x = cell.x;
            neighbor.y = cell.y-1;
            neighbors.Add(neighbor);
        }

        return neighbors;

    }

   public  Vector3  findNetworkPlayerSpawnCell()
    {
       
        Vector2Int randomCell = new Vector2Int();
        randomCell.x = Random.Range(0,size.x-1);
        randomCell.y = Random.Range(0,size.y-1);
        while (!board[randomCell.x,randomCell.y].visited || (randomCell.x==size.x-1 && randomCell.y==size.y-1) )
        {
            randomCell.x = Random.Range(0, size.x - 1);
            randomCell.y = Random.Range(0, size.y - 1);
        }

        Vector3 spawnPostion = new Vector3(-randomCell.x*offset.x,0,-randomCell.y*offset.y);




        return spawnPostion;
    }


    
}
