using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private LogicManager logicManager;

    private float spwanTime = 2.0f;
    private float spwanInterval = 6.0f;

    void Start()
    {
        InvokeRepeating("SpwanEnemy", spwanTime, spwanInterval);
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    void Update()
    {
        if(logicManager.isGameOver()) {
            CancelInvoke("SpwanEnemy");
        }
    }

    private void SpwanEnemy() {
        Vector3[] spwanPositions = {
            new Vector3(-11, 2, 0),
            new Vector3(11, 2, 0)
        };
        // TODO: fix the rotation on spawn
        int rndVector = Random.Range(0, spwanPositions.Length);
    
        Instantiate(enemyPrefab, spwanPositions[rndVector], enemyPrefab.transform.rotation);
    }
}
