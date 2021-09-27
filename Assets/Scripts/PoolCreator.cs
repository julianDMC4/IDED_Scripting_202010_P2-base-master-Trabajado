using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCreator : MonoBehaviour
{
   

    [SerializeField] private List<GameObject> objetosEnPool;
    [SerializeField] private GameObject objetodelpool;
    public int cantidad;

    private void Start()
    {
        objetosEnPool = new List<GameObject>();
        for (int i = 0; i < cantidad; i++)
        {
            CreateObject();
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < objetosEnPool.Count; i++)
        {
            if (!objetosEnPool[i].activeInHierarchy)
            {
                return objetosEnPool[i];
            }
        }
        return CreateObject();
    }
    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(objetodelpool);
        obj.SetActive(false);
        objetosEnPool.Add(obj);
        return obj;
    }
}

