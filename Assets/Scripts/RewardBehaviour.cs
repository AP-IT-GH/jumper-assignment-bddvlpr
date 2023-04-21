using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBehaviour : MonoBehaviour
{
    private bool _isCollected = false;

    public void OnTriggerEnter(Collider collision)
    {
        if (_isCollected) return;

        if (collision.gameObject.tag.Equals("Player"))
        {
            _isCollected = true;
            collision.gameObject.GetComponent<AgentBehaviour>().AddReward(1f);
            Debug.Log("* Got reward");
        }
    }
}
