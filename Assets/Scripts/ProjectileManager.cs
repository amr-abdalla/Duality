using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public string type;
    public float speed = 0.1f;
    private Vector3 original;
    public float maxDistance = 20;

    private void Start()
    {
        original = transform.position;
    }


    private void FixedUpdate()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        if (Vector3.Distance(original, transform.position) > 20)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (type)
        {
            case "fire":
                {
                    if (other.gameObject.TryGetComponent(out TreeController treeController))
                    {
                        treeController.state = "burning";
                        Destroy(gameObject);
                    }
                }
                break;

            case "water":
                {
                    if (other.gameObject.name == "Player")
                    {
                        PlayerHealth playerHealth = GameObject.Find("PlayerHealthBar").GetComponent<PlayerHealth>();
                        playerHealth.hit();
                        Destroy(gameObject);
                    }

                    if (other.gameObject.TryGetComponent(out TreeController treeController))
                    {
                        treeController.state = "well";
                        Destroy(gameObject);
                    }
                }
                break;
        }

    }
}
