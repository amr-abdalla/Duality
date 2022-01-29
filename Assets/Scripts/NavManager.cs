using UnityEngine;
using UnityEngine.AI;

public class NavManager : MonoBehaviour
{
    private NavMeshSurface navMeshSurface;

    private void Awake()
    {
        navMeshSurface = GameObject.Find("Floor").GetComponent<NavMeshSurface>();

        navMeshSurface.BuildNavMesh();
    }

    private void OnDestroy()
    {
        if (navMeshSurface)
        {
            navMeshSurface.BuildNavMesh();
        }
    }
}
