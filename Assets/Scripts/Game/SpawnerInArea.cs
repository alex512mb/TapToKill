using System.Collections;
using UnityEngine;

public class SpawnerInArea : MonoBehaviour
{
    public SpawnProgramm[] spawnProgramms;
    public float deleyStart;
    public float deleySpawn = 1;

    public GameObject prefab;
    public Vector3Int sizeSpawnZone;

    public float lifeTime = 1;

    public event System.Action<GameObject> OnObjectSpawned;


    private void Start()
    {
        StartCoroutine(ProgrammWork());
    }

    private IEnumerator ProgrammWork()
    {
        yield return new WaitForSeconds(deleyStart);
        while (enabled == true)
        {
            Spawn();
            yield return new WaitForSeconds(deleySpawn);
        }
    }

    private void Spawn()
    {
        Vector3 ranomPos = new Vector3(Random.Range(-sizeSpawnZone.x, sizeSpawnZone.x), 0, Random.Range(-sizeSpawnZone.z, sizeSpawnZone.z));
        GameObject go = Instantiate(prefab, ranomPos, Quaternion.identity);
        if(lifeTime != -1)
            Destroy(go, lifeTime);
        OnObjectSpawned?.Invoke(go);
    }

    public struct SpawnProgramm
    {

    }
}
