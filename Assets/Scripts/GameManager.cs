using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInput gameInputs;

    ///[SerializeField] private InputAction ManagerControls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
