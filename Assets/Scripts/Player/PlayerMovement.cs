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
        var playerHorizontalInput = Input.GetAxis("Horizontal");
        var playerVerticalInput = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(playerHorizontalInput, 0f, playerVerticalInput);

        navAgent.Move(movementVector * Time.deltaTime * navAgent.speed);


        if(navAgent.transform.position.z > -0.4335016)
        {
            navAgent.transform.position = new Vector3(navAgent.transform.position.x, navAgent.transform.position.y, -0.4335016f);
        }
    }
}
