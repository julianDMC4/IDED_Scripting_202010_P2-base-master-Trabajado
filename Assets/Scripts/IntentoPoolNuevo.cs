using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntentoPoolNuevo : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        //Etiqueta
        public string tag;
        //tipo objeto 
        public GameObject prefab;
        //tamaño pool
        public int size;
    }

    //listas pool
    public List<Pool> pools;
    //diccionario etiqueta cola y lo que se almacena en la cola
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    // Start is called before the first frame update
    void Start()
    {
        //diccionario vacio 
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        //llamar a cada pool dentro del grupo de pools
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            //bucle se mantiene mientras el i sea menor al tamaño del pool
            for (int i = 0; i < pool.size; i++)
            {

                //referencia del objeto
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                //agregarlo al final de cola
                objectPool.Enqueue(obj);

            }

            poolDictionary.Add(pool.tag, objectPool);

        }

    }
}
