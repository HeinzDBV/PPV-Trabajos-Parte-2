using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    public GameObject enemy;
    
    [SerializeField] public int numberOfEnemies = 3;
    
     [SerializeField] public int xPos;
     [SerializeField]public int zPos;
    // [SerializeField] public int yPos;
    [SerializeField] public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < numberOfEnemies)
        {
            xPos = Random.Range(264, 260);
            zPos = Random.Range(-95, -120);
            
            Instantiate(enemy, new Vector3(xPos, 0.4f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }


}
