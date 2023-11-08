using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;

    [SerializeField] private int numberOfEnemies = 15;
    [SerializeField] private int xPos;
    [SerializeField] private int zPos;
    [SerializeField] private int enemyCount;
    [SerializeField] private float hordeTime = 20.0f;
    [SerializeField] private float minHordeTime = 10.0f;

    [SerializeField] private int hordeCounter = 0;

    [SerializeField] private float timeUntilNextHorde; // Nuevo campo Serialize Field

    void Start()
    {
        timeUntilNextHorde = hordeTime; // Inicializa el tiempo hasta la siguiente horda
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (true)
        {
            int numberOfEnemiesRandom = Random.Range(10, numberOfEnemies);

            for (int i = 0; i < numberOfEnemiesRandom; i++)
            {
                xPos = Random.Range(264, 260);
                zPos = Random.Range(-95, -120);

                if (enemyCount % 2 == 0)
                {
                    Instantiate(enemy, new Vector3(xPos, 0.4f, zPos), Quaternion.identity);
                }
                else
                {
                    Instantiate(enemy2, new Vector3(xPos, 0.4f, zPos), Quaternion.identity);
                }
                enemyCount += 5;
                yield return new WaitForSeconds(0.1f);
            }

            hordeCounter += 1;

            if (hordeCounter > 0 && hordeTime > minHordeTime)
            {
                hordeTime -= 5;
            }

            timeUntilNextHorde = hordeTime; // Actualiza el tiempo hasta la siguiente horda

            while (timeUntilNextHorde > 0)
            {
                yield return new WaitForSeconds(1.0f);
                timeUntilNextHorde -= 1.0f;
            }
        }
    }
}
