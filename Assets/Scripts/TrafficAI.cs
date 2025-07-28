using UnityEngine;

public class TrafficAI : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;

    void Start()
    {
        direction = transform.forward;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoadEnd"))
        {
            Destroy(gameObject);
        }
    }
}