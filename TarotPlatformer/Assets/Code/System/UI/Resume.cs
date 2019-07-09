using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;

    private void Update()
    {

        /* if(Input.GetMouseButtonDown(0))
        {
            PauseMenu.isPaused = !PauseMenu.isPaused;
        }

        if(PauseMenu.isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }*/
    }

    void ActivateMenu()
{
    Time.timeScale = 0;
    AudioListener.pause = true;
    //PauseMenu.pauseMenuUI.SetActive(true);
}

void DeactivateMenu()
{
    Time.timeScale = 1;
    AudioListener.pause = false;
    //PauseMenu.pauseMenuUI.SetActive(false);
}
   /* {
        if (Input.GetMouseButtonDown(0))
        {
            isPaused = !isPaused;
        }

        if(isPaused)
        {
            DeactivateMenu();
        }

    }

    

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
   */ }

