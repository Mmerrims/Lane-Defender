using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInput gameInputs;
    [SerializeField] private InputAction restartInput;
    [SerializeField] private InputAction quitInput;
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
    [SerializeField] private AudioClip loseLifeSound;

    
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
        restartInput.Enable();
        quitInput.Enable();
    }

    private void OnDisable()
    {
        restartInput.Disable();
        quitInput.Disable();
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
        float type = UnityEngine.Random.Range(1, 4);
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
        float location = UnityEngine.Random.Range(1, 6);
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
        LivesText.GetComponent<TextMeshProUGUI>().text = ("Lives:" + health).ToString();
        AudioSource.PlayClipAtPoint(loseLifeSound, Vector3.zero, 1f);
        if(health == 0 )
        {
            //Game Ends Here
            DeathScreen.SetActive(true);
            gameIsActive = false;
        }
        
    }

    public void AddScore(float score)
    {
        ScoreText.GetComponent<TextMeshProUGUI>().text = ("Score:" + score).ToString();
    }

    private void FixedUpdate()
    {
        if( quitInput.IsPressed())
        {
            QuitGame();
        }

        if( restartInput.IsPressed() )
        {
            RestartGame();
        }
    }
}
