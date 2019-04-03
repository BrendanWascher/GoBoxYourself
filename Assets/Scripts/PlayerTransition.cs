using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransition : MonoBehaviour
{
    [HideInInspector]
    public bool canTransition = true;
    [SerializeField]
    private GameManager GameManager;
    [SerializeField]
    private Transform StartPosition;

    [SerializeField]
    private Transform GamePosition;

    [SerializeField]
    private Transform PlayerPosition;

    [SerializeField]
    private float transitionSpeed = 1f;

    private float startTime;
    private float movementDistance;
    private bool isStartingGame = true;
    // Start is called before the first frame update
    void Start()
    {
        movementDistance = Vector3.Distance(StartPosition.position, GamePosition.position);
    }

    public void PlayerTransitionStart()
    {
        if (canTransition)
        {
            canTransition = false;
            StartCoroutine("StartGameTransition");
        }
    }

    /*
     * Code from the following section has been taken in sections from the following
     * Lerp rotation from: https://answers.unity.com/questions/643141/how-can-i-lerp-an-objects-rotation.html
     * Lerp position from: https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
    */

    private IEnumerator StartGameTransition()
    {
        Transform ToThisPosition;
        Transform FromThisPosition;
        Vector3 targetAngle;
        Vector3 currentAngle;
        float distanceCovered;
        float fractionJourney;
        startTime = 0f;
        if(isStartingGame)
        {
            ToThisPosition = GamePosition;
            FromThisPosition = StartPosition;
        }
        else
        {
            ToThisPosition = StartPosition;
            FromThisPosition = GamePosition;
        }
        targetAngle = ToThisPosition.eulerAngles;
        currentAngle = PlayerPosition.eulerAngles;
        while(PlayerPosition.position != ToThisPosition.position)
        {
            distanceCovered = startTime * transitionSpeed;
            fractionJourney = distanceCovered / movementDistance;
            PlayerPosition.position = Vector3.Lerp(FromThisPosition.position,
                ToThisPosition.position, fractionJourney);
            currentAngle = new Vector3(
                Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
                Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));
            PlayerPosition.transform.eulerAngles = currentAngle;
            startTime += Time.deltaTime;
            //Debug.Log("While still running");
            yield return null;
        }
        //Debug.Log("GameManager called");
        GameManager.EnemyStartUp(isStartingGame);
        isStartingGame = !isStartingGame;
        canTransition = true;
        yield return null;
    }
}
