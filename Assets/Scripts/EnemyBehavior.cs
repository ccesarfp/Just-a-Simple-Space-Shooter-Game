using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minDistance = 10f;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, minDistance);
        bool playerDetected = false;

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                playerDetected = true;
                break;
            }
        }

        if (playerDetected)
        {
            Vector3 playerDirection = (player.transform.position - transform.position).normalized;
            Vector3 targetPosition = player.transform.position - (playerDirection * minDistance);

            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}