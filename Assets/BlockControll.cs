using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControll : SingletonMonoBehavior<BlockControll>
{

    [SerializeField] List<GameObject> List = new List<GameObject>();

    public void OnSpawned(GameObject Cube)
    {
        List.Add(Cube);
        Cube.transform.position = new Vector3(transform.position.x, GetCurrentSpawnY(), transform.position.z);
    }
    public void OnPlayerLand(GameObject Cube)
    {
        ClearAllBelowY(PlayerControll.instance.GetPlayerObject().transform.position.y - 2);
    }

    public GameObject GetNext()
    {
        return List[0];
    }

    public float GetCurrentSpawnY()
    {
        return (FloorControll.instance.GetCurrentFloor() * 5) - 2;
    }

    public void ClearAllBelowY(float Y)
    {
        List<GameObject> ClearList = new List<GameObject>();

        for (int i = 0; i < List.Count; i++)
        {
            GameObject item = List[i];
            if (item.transform.position.y < Y)
            {
                ClearList.Add(item);
            }
        }
        foreach (var item in ClearList)
        {
            Clear(item);
        }
    }

    public void ClearFirst()
    {
        Clear(0);
    }

    public void Clear(int Index)
    {
        Clear(List[Index]);
    }

    public void Clear(GameObject Obj)
    {
        Obj.AddComponent<CubeDestoryer>();
        List.Remove(Obj);
        OnClear();
    }

    public void OnClear()
    {
        FloorControll.instance.SpawnOneChunk();
    }

}
