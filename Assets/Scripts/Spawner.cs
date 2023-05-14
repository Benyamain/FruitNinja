using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;
    public GameObject[] fruitPrefabs;
    public float minSpawnDelay = 0.25f, maxSpawnDelay = 1f, minAngle = -15f, maxAngle = 15f, minForce = 18f, maxForce = 22f, maxLifeTime = 5f;

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

    }
}
