using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{

    private enum GAME_MODE {
        ENDLESS,
        TIMED,
        STORY,
    }

    [SerializeField] private GAME_MODE gameMode;
    public GameObject enemyPrefab;
    private LogicManager logicManager;
    private EnemyIndicator enemyIndicator;

    private int waves, numberOfEnemies, numberOfEnemiesInScene, numberOfSpwanedEnemies;
    private int baseNumberOfEnemies = 4;
    private float spwanInterval, currentSpwanTime;
    private bool hasNumberOfEnemiesInWaveSpwaned;

    private void Awake() {
        EnemyController.OnEnemyDied += EnemyController_OnEnemyDied;

        waves = 1;
        numberOfEnemies = baseNumberOfEnemies;
        numberOfEnemiesInScene = 0;
        numberOfSpwanedEnemies = 0;
        spwanInterval = 3f;
        hasNumberOfEnemiesInWaveSpwaned = false;
    }

    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        enemyIndicator = GameObject.Find("EnemyIndicator").GetComponent<EnemyIndicator>();

        if(gameMode == GAME_MODE.TIMED) {
            logicManager.SetIsNewWaveStarting(false);
        }
    }

    void Update()
    {
        if(logicManager.isNewWaveStart()) {
            // TODO: remove magic number later
            Invoke("ContinueNewWave", 6f);
        }

        bool canRunSpwaner = (!logicManager.isGameOver() && !logicManager.isPausedOverlayOpen() && !logicManager.isNewWaveStart() && !hasNumberOfEnemiesInWaveSpwaned);
        
        if(canRunSpwaner) {
            currentSpwanTime += Time.deltaTime;

            if(gameMode == GAME_MODE.TIMED) {
                if(currentSpwanTime > spwanInterval) {
                    SpwanEnemy();
                    currentSpwanTime = 0f;
                }

                return;
            }

            if(numberOfSpwanedEnemies < numberOfEnemies) {
                if(numberOfEnemiesInScene == 0 && waves == 1) {
                    SpwanEnemy();
                    numberOfSpwanedEnemies++;
                    numberOfEnemiesInScene++;
                } else {
                    if(currentSpwanTime > spwanInterval) {
                        SpwanEnemy();
                        numberOfSpwanedEnemies++;
                        numberOfEnemiesInScene++;
                        currentSpwanTime = 0f;
                    }
                }

                if(numberOfEnemies == numberOfSpwanedEnemies) {
                    hasNumberOfEnemiesInWaveSpwaned = true;
                }
            }
        }
    }

    private void EnemyController_OnEnemyDied(object sender, System.EventArgs e) {
        numberOfEnemiesInScene--;

        if(numberOfEnemiesInScene == 0 && numberOfEnemies == numberOfSpwanedEnemies) {
            logicManager.SetIsNewWaveStarting(true);

            hasNumberOfEnemiesInWaveSpwaned = false;
            waves++;
            numberOfSpwanedEnemies = 0;

            numberOfEnemies = waves <= 3 ? baseNumberOfEnemies * waves : 15;
            spwanInterval = waves <= 3 ? 4.5f : 6f;
        }
    }

    private void ContinueNewWave() {
        logicManager.SetIsNewWaveStarting(false);
    }

    private void SpwanEnemy() {
        Vector3[] spwanPositions = {
            new Vector3(-11, 2, 0),
            new Vector3(11, 2, 0)
        };
        int rndVector = Random.Range(0, spwanPositions.Length);
    
        Instantiate(enemyPrefab, spwanPositions[rndVector], enemyPrefab.transform.rotation);
        enemyIndicator.AddEnemy(enemyPrefab.transform);
    }
}
