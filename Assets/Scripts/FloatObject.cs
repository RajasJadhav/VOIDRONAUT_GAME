using UnityEngine;

public class FloatObject : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatHeight = 0.5f;
    public float rotationSpeed = 50f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Floating up & down
        transform.position = startPos + new Vector3(0,
            Mathf.Sin(Time.time * floatSpeed) * floatHeight, 0);

        // Rotation
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}