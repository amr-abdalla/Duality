using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        var playerInput = Input.GetAxis("Horizontal");

        Vector3 movementVector = new Vector3(playerInput, 0f, 0f);

        navAgent.Move(movementVector * Time.deltaTime * navAgent.speed);

    }
}
