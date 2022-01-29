using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    Plane plane = new Plane(Vector3.up, 0);

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 cameraWorldPosition = ray.GetPoint(distance);

            var direction = (cameraWorldPosition - transform.position).normalized;

            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

        }
    }
}