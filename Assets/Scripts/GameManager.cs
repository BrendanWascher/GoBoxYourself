using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager InputManager;
    [SerializeField]
    private UseCamera UseCamera;
    [SerializeField]
    private PlayerTransition PlayerTransition;
    [SerializeField]
    private ResetMenuOptions MenuOptions;
    [SerializeField]
    private Animator EnemyController;

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyStartUp(bool isStarting)
    {
        if(isStarting)
        {
            EnemyController.SetBool("shouldOpen", true);
            EnemyController.SetBool("shouldFaceOpen", true);
            EnemyController.SetBool("shouldClose", false);
            StartCoroutine("WaitToStartGame");
        }
    }

    public void EnemyShutDown()
    {
        EnemyController.SetBool("shouldFaceOpen", false);
        EnemyController.SetBool("shouldOpen", false);
        EnemyController.SetBool("shouldClose", true);
        StartCoroutine("WaitBeforeMovePlayer");
    }

    private IEnumerator WaitBeforeMovePlayer()
    {
        yield return new WaitForSeconds(2f);
        PlayerTransition.PlayerTransitionStart();
        yield return new WaitForSeconds(1f);
        MenuOptions.ResetMenu();
    }

    private IEnumerator WaitToStartGame()
    {
        yield return new WaitForSeconds(3f);
        MenuOptions.StartInGameMenu();
    }
}
