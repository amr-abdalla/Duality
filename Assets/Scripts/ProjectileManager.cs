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
        if (Vector3.Distance(original, transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (gameObject.tag)
        {
            case "red":
                {
                    if (other.gameObject.tag == "blueBox")
                    {
                        other.GetComponent<BoxController>().hit();
                        Destroy(gameObject);
                    }
                    if (other.gameObject.tag == "Enemy")
                    {
                        // Decrease enemy health
                        Destroy(gameObject);
                    }
                }
                break;

            case "blue":
                {
                    if (other.gameObject.tag == "Player")
                    {
                        PlayerHealth playerHealth = GameObject.Find("PlayerHealthBar").GetComponent<PlayerHealth>();
                        playerHealth.hit();
                        Destroy(gameObject);
                    }

                    if (other.gameObject.tag == "redBox")
                    {
                        other.GetComponent<BoxController>().hit();
                        Destroy(gameObject);
                    }
                }
                break;
        }

    }
}
