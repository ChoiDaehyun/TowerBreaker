using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool playerDead = false;
    public bool stageClear = false;
    public GameObject gameoverUI;
    public GameObject stageClearUI;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (playerDead && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Loby");
        }
        else if (stageClear && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Loby");
        }
    }

    public void OnGameOver()
    {
        playerDead = true;
        gameoverUI.SetActive(true);
    }
    public void StageClear()
    {
        stageClear = true;
        stageClearUI.SetActive(true);
    }
}
