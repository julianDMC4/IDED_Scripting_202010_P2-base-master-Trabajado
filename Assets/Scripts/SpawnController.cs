using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private PoolCreator[] spawnObjects;

    [SerializeField]
    private float spawnRate = 1f;


    [SerializeField]
    private Player player;




    // Start is called before the first frame update
    private void Start()
    {
        if (spawnObjects.Length > 0)
        {
            InvokeRepeating("SpawnObject", 0.1f, spawnRate);

            if (player != null)
            {
                player.OnPlayerDied += StopSpawning;
            }
        }
    }

    private void SpawnObject()
    {
        GameObject spawnGO = spawnObjects[Random.Range(0, spawnObjects.Length)].GetObject();

        if (spawnGO != null)
        {
            spawnGO.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(
                   Random.Range(0F, 1F), 1F, transform.position.z));
            spawnGO.SetActive(true);
        }
    }

    private void StopSpawning()
    {
        CancelInvoke();
    }
}
