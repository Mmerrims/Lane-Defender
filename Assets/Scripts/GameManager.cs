using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInput gameInputs;
    private Vector3 spawnLoc;
    [SerializeField] private float health;
    private GameObject enemy;
    [SerializeField] private GameObject enemyFast;
    [SerializeField] private GameObject enemyMedium;
    [SerializeField] private GameObject enemySlow;
    [SerializeField] private float enemyCooldown;
    [SerializeField] private GameObject LivesText;
    [SerializeField] private GameObject ScoreText;
    [SerializeField] private GameObject DeathScreen;
    private bool gameIsActive = true;

    
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
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
        if (gameIsActive == true)
        {
            DecideEnemyType();
            DecideEnemyLocation();
            Instantiate(enemy, spawnLoc, Quaternion.identity);
        }
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
            spawnLoc = new Vector3 (10, 0, 0);
        }
        else if (location == 2 )
        {
            spawnLoc = new Vector3 (10, -1, 0);
        }
        else if(location == 3 )
        {
            spawnLoc = new Vector3(10, -2, 0);
        }
        else if (location == 4)
        {
            spawnLoc = new Vector3(10, -3, 0);
        }
        else
        {
            spawnLoc = new Vector3(10, -4, 0);
        }
    }
    public void LoseLife()
    {
        health--;
        LivesText.GetComponent<TextMesh>().text = ("Lives:" + health).ToString();
        if(health == 0 )
        {
            //Game Ends Here
            DeathScreen.SetActive(true);
            gameIsActive = false;
        }
    }
}
