using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;
    public GameObject[] fruitPrefabs;
    public float minSpawnDelay = 0.25f, maxSpawnDelay = 1f, minAngle = -15f, maxAngle = 15f, minForce = 18f, maxForce = 22f, maxLifetime = 5f;

    [Range(0f, 1f)]
    public float bombChance = 0.05f;
    public GameObject bombPrefab;

    private void Awake() {
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable() {
        StartCoroutine(Spawn());
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    private IEnumerator Spawn() {
        yield return new WaitForSeconds(2f);

        while (enabled) {
            GameObject prefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];

            if(Random.value < bombChance) {
                prefab = bombPrefab;
            }

            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject fruit = Instantiate(prefab, position, rotation);
            Destroy(fruit, maxLifetime);

            float force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
}
