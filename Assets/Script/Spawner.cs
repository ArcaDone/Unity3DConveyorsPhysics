using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] prefab;
    public float minDelay = 0.1f;
    public float maxDelay = 1f;

    public int maxRandDist = 25;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPrefabs());
    }

    IEnumerator SpawnPrefabs()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            GameObject pref = prefab[Random.Range(0, prefab.Length)];
            yield return new WaitForSeconds(delay);

            int spawnPointX = Random.Range(-maxRandDist, maxRandDist);
            int spawnPointZ = Random.Range(-maxRandDist, maxRandDist);

            Vector3 spawnPoint = new Vector3(transform.position.x + spawnPointX, transform.position.y, transform.position.z + spawnPointZ);

            Instantiate(pref, spawnPoint, pref.transform.rotation);
        }
    }

}
