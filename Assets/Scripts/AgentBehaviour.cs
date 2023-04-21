using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;


public class AgentBehaviour : Agent
{
    public SpawnerBehaviour spawner;

    private Rigidbody _rigidBody;

    public void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        spawner.Reset();

        transform.localPosition = new Vector3(0f, 1.2f, 0f);
        transform.localRotation = Quaternion.identity;

        _rigidBody.velocity = Vector3.zero;
    }

    public override void CollectObservations(VectorSensor sensor)
    {

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        bool grounded = IsGrounded();

        if (actions.DiscreteActions[0] >= 1 && grounded)
        {
            AddReward(-.01f);
            _rigidBody.AddForce(new Vector3(0, 50, 0));
        }

        if (transform.position.y < -1 || transform.position.y > 20)
        {
            AddReward(-1f);
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var output = actionsOut.DiscreteActions;
        output[0] = Input.GetKey(KeyCode.Space) ? 1 : 0;
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1f);
    }
}
