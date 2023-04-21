using UnityEngine;

public class CylinderBehaviour : MonoBehaviour
{
    public Vector3 randomStepMin;
    public Vector3 randomStepMax;

    private Rigidbody rigidBody;
    private Vector3 randomDirection;
    private float dieAfter;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        randomDirection = new Vector3(
            Random.Range(randomStepMin.x, randomStepMax.x),
            Random.Range(randomStepMin.y, randomStepMax.y),
            Random.Range(randomStepMin.z, randomStepMax.z)
        );
        dieAfter = Time.time + 10f;
    }

    private void FixedUpdate()
    {
        if (Time.time > dieAfter)
            Destroy(gameObject);
        rigidBody.MovePosition(transform.position + randomDirection * Time.deltaTime);
    }
}
