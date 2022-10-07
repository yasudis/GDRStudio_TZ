using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenegerMenu : MonoBehaviour
{
    static public bool isPaused = false;
    public GameObject panelOfMenu;
    public GameObject textOfGameOver;
    public GameObject textOfVictory;
    public GameObject thron;
    public GameObject coin;
    public GameObject player;
    public float sizeX;
    public float sizeZ;
    public int numberOfcoint;
    public int numberOfThron;
    public int numberOfScence = 1;


    private void Start()
    {
        isPaused = false;
        textOfGameOver.SetActive(false);
        textOfVictory.SetActive(false);
        SpawnCointAndThron();
        Instantiate(player, Vector3.zero, Quaternion.identity);


        //  panel.SetActive(false);
        // panel= GameObject.FindGameObjectWithTag("Panel");
    }

    // Update is called once per frame
    public void GameOver()
    {
        panelOfMenu.SetActive(true);
        textOfGameOver.SetActive(true);
        textOfVictory.SetActive(false);

        // numberOfScence += 1;
    }
    public void Victory()
    {
        panelOfMenu.SetActive(true);
        textOfGameOver.SetActive(false);
        textOfVictory.SetActive(true);
    }
    public void ChangeOfRestart()
    {
        panelOfMenu.SetActive(false);
        textOfGameOver.SetActive(false);
        textOfVictory.SetActive(false);
        SceneManager.LoadScene("scene_" + numberOfScence);

    }

   
    public void OnGUI()
    {
        if (isPaused == true)
        {
            Time.timeScale = 0;
            panelOfMenu.SetActive(true);
        }
        if (panelOfMenu.active == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
    }

    public void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
    public void SpawnCointAndThron()
    {
        for (int i = 0; i < numberOfcoint; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-sizeX, sizeX), 0, Random.Range(-sizeZ, sizeZ));
            Instantiate(coin, pos, Quaternion.identity);

        }
        for (int i = 0; i < numberOfThron; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-sizeX, sizeX), 0, Random.Range(-sizeZ, sizeZ));
            Instantiate(thron, pos, Quaternion.identity);
        }
    }
}

