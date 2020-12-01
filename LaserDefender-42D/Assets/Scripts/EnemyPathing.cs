using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;

    int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[wayPointIndex].position;

    }

   

    void EnemyMove()
    {
        if (wayPointIndex < waypoints.Count - 1)
        // if(wayPointIndex < waypoints.Count)
        {
            var targetPosition = waypoints[wayPointIndex].transform.position;

            var movementThisFrame = moveSpeed * Time.deltaTime; //making the enemy movement frame-independent (moving at the same speed on every PC)

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
                wayPointIndex++;
        }
        else
        {
            Destroy(gameObject);
        }

    }

     // Update is called once per frame
    void Update()
     {
        EnemyMove();
     }
}
