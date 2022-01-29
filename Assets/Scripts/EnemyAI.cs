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
    [SerializeField] private float maxDistanceToPlayer = 5f;
    [SerializeField] private float minDistanceToPlayer = 4f;
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
      //  agent.updateRotation = false;
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
            SaveTree(trees.FirstOrDefault(tree => tree.state == "burning")?.gameObject);
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

        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position); //playerTransform.position.x - transform.position.x;
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

        if (distanceToPlayer > maxDistanceToPlayer)
        {
            MoveToDirection(directionToPlayer);
            return;
        }

        if (distanceToPlayer < minDistanceToPlayer)
        {
            MoveToDirection(-directionToPlayer);
            return;
        }

        MoveToDirection(RandomVector(-2f, 2f).normalized);

        skillManager.TryInvokeSkill(0);

    }

    private void MoveToDirection(Vector3 direction)
    {
        agent.destination = agent.transform.position + direction * agent.speed * Time.deltaTime;

      /*  if (agent.transform.position.z < 0.86f)
        {
            agent.Move(new Vector3(0, 0, 0.86f));
        }
      */

        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionToPlayer), 0.5f);
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = 0;
        var z = Mathf.Clamp(Random.Range(min, max), 0.86f, max);
        return new Vector3(x, y, z);
    }

    void SaveTree(GameObject tree)
    {
        if(!tree)
        {
            return;
        }

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