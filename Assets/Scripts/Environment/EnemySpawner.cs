using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject cuboidPrefab;
    [SerializeField] private GameObject kamikazePrefab;
    [SerializeField] private GameObject bouncyPrefab;

    private GameObject[] cuboidArray;
    private GameObject[] kamikazeArray;
    private GameObject[] bouncyArray;

    public float cuboidInterval;
    public float kamikazeInterval;
    public float bouncyInterval;

    public int cuboidNum;
    public int kamikazeNum;
    public int bouncyNum;


    // Start is called before the first frame update
    void Start()
    {
        cuboidArray = GameObject.FindGameObjectsWithTag("Cuboid");
        kamikazeArray = GameObject.FindGameObjectsWithTag("Kamikaze");
        bouncyArray = GameObject.FindGameObjectsWithTag("Bouncy");

        StartCoroutine(spawnEnemy(cuboidInterval, cuboidPrefab, "Cuboid", cuboidNum));
        StartCoroutine(spawnEnemy(kamikazeInterval, kamikazePrefab, "Kamikaze", kamikazeNum));
        StartCoroutine(spawnEnemy(bouncyInterval, bouncyPrefab, "Bouncy", bouncyNum));
    }

    //private void Update() {
    //    cuboidArray = GameObject.FindGameObjectsWithTag("Cuboid");
    //    kamikazeArray = GameObject.FindGameObjectsWithTag("Kamikaze");
    //    bouncyArray = GameObject.FindGameObjectsWithTag("Bouncy");
    //}

    private IEnumerator spawnEnemy(float interval, GameObject enemy, string enemyType, int numOfEnemies) {
        yield return new WaitForSeconds(interval);
        int enemyCount = GameObject.FindGameObjectsWithTag(enemyType).Length;
        if (enemyCount < numOfEnemies) {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-15f, 15f), Random.Range(-8f, 7f), 0), Quaternion.identity);
        }
        StartCoroutine(spawnEnemy(interval, enemy, enemyType, numOfEnemies));
    }
}
