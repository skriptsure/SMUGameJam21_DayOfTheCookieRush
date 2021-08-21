using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    private GameObject pausePanel;

    private void Awake()
    {
        pausePanel = transform.GetChild(0).gameObject;
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePauseMenu();
    }
    public void TogglePauseMenu()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        Time.timeScale = pausePanel.activeSelf ? 0 : 1;
    }

    public void GoToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
