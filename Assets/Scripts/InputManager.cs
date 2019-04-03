using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public bool hasGameStarted = false;
    [SerializeField]
    private UseCamera EnemyCamera;
    [SerializeField]
    private Animator PlayerAnimator;
    [SerializeField]
    private string attackInputName;
    [SerializeField]
    private float punchCoolDownDelay = .2f;

    // Update is called once per frame
    void Update()
    {
        if (hasGameStarted)
        {
            //CheckTouchInput();
            CheckMouseInput();
        }
    }

    private void CheckMouseInput()
    {
        if(PlayerAnimator.GetBool("shouldPunch"))
        {
            Debug.Log("Enemy hit 2!");
        }
        else
        {
            //Debug.Log("No attack...");
        }
    }

    private void CheckTouchInput()
    {
        //Do touch input here
    }

    public void EnemyAttacked()
    {
        if (!PlayerAnimator.GetBool("shouldPunch"))
        {
            PlayerAnimator.SetBool("shouldPunch", true);
            if (PlayerAnimator.GetBool("shouldRightPunch"))
            {
                PlayerAnimator.SetBool("shouldRightPunch", false);
            }
            else
            {
                PlayerAnimator.SetBool("shouldRightPunch", true);
            }
            StopCoroutine("PunchCoolDown");
            StartCoroutine("PunchCoolDown");
            Debug.Log("Enemy hit!");
        }
    }

    public void StartGame()
    {
        hasGameStarted = true;
    }

    private IEnumerator PunchCoolDown()
    {
        yield return new WaitForSeconds(punchCoolDownDelay);
        PlayerAnimator.SetBool("shouldPunch", false);

    }
}
