using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInput gameInputs;
    private Transform spawnLoc;
    [SerializeField] private Transform EnemySpawnPoint1;
    [SerializeField] private Transform EnemySpawnPoint2;
    [SerializeField] private Transform EnemySpawnPoint3;
    [SerializeField] private Transform EnemySpawnPoint4;
    [SerializeField] private Transform EnemySpawnPoint5;
    private GameObject enemy;
    [SerializeField] private GameObject enemyFast;
    [SerializeField] private GameObject enemyMedium;
    [SerializeField] private GameObject enemySlow;
    [SerializeField] private float enemyCooldown;

    ///[SerializeField] private InputAction ManagerControls;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnTimer());
    }
    private IEnumerator spawnTimer()
    {
        while (true)
        {
            yield return new
                WaitForSeconds(enemyCooldown);
            EnemySpawner();
            //yield return true;

        }
    }

    void QuitGame()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        gameInputs.enabled = true;
    }

    private void OnDisable()
    {
        gameInputs.enabled = false;
    }

    void EnemySpawner()
    {
        DecideEnemyType();
        DecideEnemyLocation();
        Instantiate(enemy, spawnLoc);
    }

    void DecideEnemyType()
    {
        float type = Random.Range(1, 4);
        if(type == 1)
        {
            enemy = enemyFast;
        }
        else if( type == 2)
        {
            { enemy = enemyMedium; }
        }
        else { enemy = enemySlow; }
    }

    void DecideEnemyLocation()
    {
        float location = Random.Range(1, 6);
        if(location == 1 )
        {
            spawnLoc = EnemySpawnPoint1;
        }
        else if (location == 2 )
        {
            spawnLoc = EnemySpawnPoint2;
        }
        else if(location == 3 )
        {
            spawnLoc = EnemySpawnPoint3;
        }
        else if (location == 4)
        {
            spawnLoc = EnemySpawnPoint4;
        }
        else
        {
            spawnLoc = EnemySpawnPoint5;
        }
    }
}
