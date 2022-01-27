using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum state
    {
        TargetPlayer,
        SaveTree
    }

    private EnemyAI.state currentState = EnemyAI.state.TargetPlayer;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float MovementAdjustmentRate = 0.5f;

    private void Update()
    {
        if(currentState == EnemyAI.state.TargetPlayer)
        {
            ShootPlayer();
        }
        else
        {
            SaveTree();
        }
    }

    void ShootPlayer()
    {
        float y = playerTransform.position.x - transform.position.x;

        if (y.FloatInRange(-MovementAdjustmentRate,MovementAdjustmentRate))
        {
            Debug.Log("TRUE");
            return;
        }
        else
        {
            Debug.Log("False");
        }
    }

    void SaveTree()
    {

    }
}

public static class Utils
{
    public static bool FloatInRange(this float testValue, float bound1, float bound2)
    {
        return (testValue >= Mathf.Min(bound1, bound2) && testValue <= Mathf.Max(bound1, bound2));
    }
}