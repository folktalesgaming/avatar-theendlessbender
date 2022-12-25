using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spwanTime = 2.0f;
    private float spwanInterval = 6.0f;

    void Start()
    {
        InvokeRepeating("SpwanEnemy", spwanTime, spwanInterval);   
    }

    void Update()
    {
        
    }

    private void SpwanEnemy() {
        Vector3[] spwanPositions = {
            new Vector3(-11, 2, 0),
            new Vector3(11, 2, 0)
        };
        // TODO: fix the rotation on spawn
        int rndVector = Random.Range(0, spwanPositions.Length);

        if(rndVector == 1) {
            enemyPrefab.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    
        Instantiate(enemyPrefab, spwanPositions[rndVector], enemyPrefab.transform.rotation);
    }
}
