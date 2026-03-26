using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] temp;
    private GameObject[] enemies;
    public GameObject[] Boss;

    private int pivot = 0;
    private float spawnRate = 2.0f;
    private float timeAfterSpawn;
    public int enemyCnt = 0;
    public int bossCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[30];
        for (int i = 0; i < 30; i++)
        {
            int randomIdx = Random.Range(0, temp.Length);
            GameObject gameObject
                = Instantiate(temp[randomIdx], temp[randomIdx].transform.position, Quaternion.identity);
            enemies[i] = gameObject;
            gameObject.SetActive(false);
        }
        StartCoroutine("EnableEnemy");


    }

    IEnumerator EnableEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            enemies[pivot++].SetActive(true);
            enemyCnt++;
            if (pivot == 30) pivot = 0;
            if (enemyCnt >= 50)
            {
                int randIdx = Random.Range(0, Boss.Length);
                Instantiate(Boss[randIdx], Boss[randIdx].transform.position, Quaternion.identity);
                yield break;
            }
        }
    }
}
