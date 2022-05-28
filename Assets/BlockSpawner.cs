using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : SingletonMonoBehavior<BlockSpawner>
{
    [SerializeField]
    GameObject SpawnPrefab;

    public static GameObject Spawn()
    {
        GameObject SpawnedObject = Instantiate(instance.SpawnPrefab, new Vector3(), Quaternion.identity);
        BlockControll.instance.OnSpawned(SpawnedObject);
        SpawnedObject.GetComponent<PositionDispenser>().Init();
        return SpawnedObject;
    }
}
