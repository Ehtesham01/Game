using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject enemyPrefab;
    public float minInstantiateValue;
    public float maxInstantiateValue;
    public float enemyDestroyTime= 10f;

    [Header("partical Effect")]
    public GameObject explosion;
    public GameObject muzzleFlash;


    [Header("Panels")]
    public GameObject startMenu;
    public GameObject pauseMenu;
    private void Awake()
    {
        instance = this;
    }


    public void Start()
    {
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f; //if it is not written game is directly started in background when startmenu come.
        InvokeRepeating("InstantiateEnemy", 1f, 1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //if we press escape button then pausemenu came
        {
            PauseGame(true);
        }

    }

    void InstantiateEnemy()
    {
        Vector3 enemypos = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 6f);
        GameObject enemy= Instantiate(enemyPrefab, enemypos, Quaternion.Euler(0f,0f,180f));
        Destroy(enemy,enemyDestroyTime);
    }

    public void StartGameButton()
    {
        startMenu.SetActive(false);//start menu panel deactivate
        Time.timeScale = 1f; //game start

    }

    public void PauseGame(bool isPaused)
    {
        if (isPaused==true)
        {
            pauseMenu.SetActive(true); //if game pause then pause menu came.
            Time.timeScale = 0f; //game stop.
        }
        else
        {
            pauseMenu.SetActive(false); 
            Time.timeScale = 1f;

        }
      
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

}
