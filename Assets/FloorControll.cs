using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorControll : SingletonMonoBehavior<FloorControll>
{

    int SpawnFloor = 2;

    CubeControll cubeControll;

    public int GetCurrentFloor()
    {
        return SpawnFloor;
    }

    void OnNextFloor()
    {
        SpawnFloor++;
    }


    private void Start()
    {
        Invoke("SpawnOneChunk", 0.1f);
        Invoke("SpawnOneChunk", 0.2f);
        Invoke("SpawnOneChunk", 0.3f);
    }

    public void SpawnOneChunk()
    {
        GameObject Cube = CubeSpawner.Spawn();
        if (Random.Range(0, 100) <= 30)
        {
            Cube.AddComponent<SimpleMoveLeftRight>();
        }

        if (Random.Range(0, 100) <= 30)
        {
            GameObject Block = BlockSpawner.Spawn();
            if (Random.Range(0, 100) <= 30)
            {
                Block.AddComponent<SimpleMoveLeftRight>();
            }
        }
        OnNextFloor();
    }


}
