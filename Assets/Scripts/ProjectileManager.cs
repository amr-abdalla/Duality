using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector3 original;
    public float maxDistance = 20;
    // Start is called before the first frame update
    void Start()
    {
        original = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        if (Vector3.Distance(original, transform.position) > 20)
        {
            Destroy(gameObject);
        }

    }
}
