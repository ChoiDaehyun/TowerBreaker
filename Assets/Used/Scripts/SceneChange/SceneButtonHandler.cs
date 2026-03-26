using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtonHandler : MonoBehaviour
{
    public void OnWorldBtnClicked()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnInvenBtnClicked()
    {
        SceneManager.LoadScene("Inventory");
    }
}
