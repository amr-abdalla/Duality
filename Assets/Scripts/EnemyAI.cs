using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyAI : MonoBehaviour
{
    private enum state
    {
        TargetPlayer,
        SaveTree
    }

    private EnemyAI.state currentState = EnemyAI.state.TargetPlayer;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float MovementAdjustmentRate = 0.5f;
    [SerializeField] private float maxDelayTime = 0.3f;
    [SerializeField] private float minDelayTime = 0.1f;

    private SkillManager skillManager;
    private NavMeshAgent agent;
    private float nextActionStartTime;
    private IEnumerable<TreeController> trees;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        skillManager = GetComponent<SkillManager>();
        agent.updateRotation = false;
        nextActionStartTime = Time.time;
        trees = FindObjectsOfType<TreeController>();
    }

    private void Update()
    {
        if(nextActionStartTime >= Time.time)
        {
            return;
        }

        nextActionStartTime = Time.time + Random.Range(minDelayTime, maxDelayTime);

        if (currentState == EnemyAI.state.TargetPlayer)
        {
            ShootPlayer();
        }
        else
        {
            SaveTree(trees.First(tree => tree.state == "burning").gameObject);
        }
    }

    private void LateUpdate()
    {
        if(trees.Any(tree => tree.state == "burning"))
        {
            currentState = EnemyAI.state.SaveTree;
        }
        else
        {
            currentState = EnemyAI.state.TargetPlayer;
        }
    }

    void ShootPlayer()
    {
        float distanceToPlayer = playerTransform.position.x - transform.position.x;

        if (distanceToPlayer.FloatInRange(-MovementAdjustmentRate, MovementAdjustmentRate))
        {
            skillManager.TryInvokeSkill(0);
        }
        else
        {
            agent.destination = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
        }
    }

    void SaveTree(GameObject tree)
    {
        if(tree.transform.position.x != transform.position.x)
        {
            agent.destination = new Vector3(tree.transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            skillManager.TryInvokeSkill(0);
        }
    }
}

public static class Utils
{
    public static bool FloatInRange(this float testValue, float bound1, float bound2)
    {
        return (testValue >= Mathf.Min(bound1, bound2) && testValue <= Mathf.Max(bound1, bound2));
    }
}