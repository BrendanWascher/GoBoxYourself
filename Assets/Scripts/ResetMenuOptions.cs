using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMenuOptions : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenuPanel;
    [SerializeField]
    private GameObject InGamePanel;
    [SerializeField]
    private GameObject EndGamePanel;
    
    public void ResetMenu()
    {
        MainMenuPanel.SetActive(true);
    }

    public void StartInGameMenu()
    {
        InGamePanel.SetActive(true);
    }

    public void EndGameMenu()
    {
        InGamePanel.SetActive(false);
        EndGamePanel.SetActive(true);
    }
}
