using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject cuboidPrefab;
    [SerializeField] private GameObject kamikazePrefab;
    [SerializeField] private GameObject bouncyPrefab;

    [SerializeField] private ParticleSystem indicatorPrefab;

    private GameObject[] cuboidArray;
    private GameObject[] kamikazeArray;
    private GameObject[] bouncyArray;

    private int multipleSpawnsChance;

    public float cuboidInterval;
    public float kamikazeInterval;
    public float bouncyInterval;

    public int cuboidNum;
    public int kamikazeNum;
    public int bouncyNum;

    public float intervalDecreaseRate;
    public float intervalDecreaseInterval;

    public float indicatorDuration;

    // Start is called before the first frame update
    void Start() {
        cuboidArray = GameObject.FindGameObjectsWithTag("Cuboid");
        kamikazeArray = GameObject.FindGameObjectsWithTag("Kamikaze");
        bouncyArray = GameObject.FindGameObjectsWithTag("Bouncy");

        StartCoroutine(SpawnEnemy(cuboidInterval, cuboidPrefab, "Cuboid", cuboidNum));
        StartCoroutine(SpawnEnemy(kamikazeInterval, kamikazePrefab, "Kamikaze", kamikazeNum));
        StartCoroutine(SpawnEnemy(cuboidInterval, cuboidPrefab, "Cuboid", cuboidNum));
        StartCoroutine(SpawnEnemy(kamikazeInterval, kamikazePrefab, "Kamikaze", kamikazeNum));
        StartCoroutine(SpawnBouncy(bouncyInterval, bouncyPrefab, "Bouncy", bouncyNum));
        StartCoroutine(SpawnEnemy(kamikazeInterval, kamikazePrefab, "Kamikaze", kamikazeNum));
        StartCoroutine(SpawnBouncy(bouncyInterval, bouncyPrefab, "Bouncy", bouncyNum));
        StartCoroutine(DecreaseIntervals());
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy, string enemyType, int numOfEnemies) {
        yield return new WaitForSeconds(interval);

        int enemyCount = GameObject.FindGameObjectsWithTag(enemyType).Length;

        if (enemyCount < numOfEnemies) {
            // Spawn the indicator object at the spawn location
            ParticleSystem indicator = Instantiate(indicatorPrefab, new Vector3(Random.Range(-50f, 50f), Random.Range(-25f, 25f), 0), Quaternion.identity);

            // Delay the enemy spawn by a short duration to allow the indicator to be visible
            yield return new WaitForSeconds(indicatorDuration);

            // Spawn the enemy at the same spawn location
            Instantiate(enemy, indicator.transform.position, Quaternion.identity);

            // Destroy the indicator object
            indicator.Stop();
            Destroy(indicator);
        }

        StartCoroutine(SpawnEnemy(interval, enemy, enemyType, numOfEnemies));
    }

    private IEnumerator SpawnBouncy(float interval, GameObject bouncy, string bouncyType, int numOfBouncies) {
        while (true) {
            yield return new WaitForSeconds(interval);
            int bouncyCount = GameObject.FindGameObjectsWithTag(bouncyType).Length;
            int numOfEnemies = GameObject.FindGameObjectsWithTag("Kamikaze").Length + GameObject.FindGameObjectsWithTag("Cuboid").Length;
            if (bouncyCount < numOfBouncies && numOfEnemies > 10) {
                Instantiate(bouncy, new Vector3(Random.Range(-50f, 50f), Random.Range(-25f, 25f), 0), Quaternion.identity);
            }
        }
    }

    private IEnumerator DecreaseIntervals() {
        while (true) {
            yield return new WaitForSeconds(intervalDecreaseInterval);
            cuboidInterval -= intervalDecreaseRate;
            kamikazeInterval -= intervalDecreaseRate;
        }
    }
}
