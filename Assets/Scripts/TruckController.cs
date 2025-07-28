using UnityEngine;

public class TruckController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 50f;
    public float fuel = 100f;
    public float fuelConsumption = 0.1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(moveInput) > 0.1f)
        {
            fuel -= fuelConsumption * Time.deltaTime;
            if (fuel <= 0) moveInput = 0;
        }

        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        float rotation = rotationInput * rotationSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GasStation"))
        {
            fuel = 100f;
            Debug.Log("Getankt!");
        }
    }
}