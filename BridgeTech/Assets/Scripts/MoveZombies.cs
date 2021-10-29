using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombies : MonoBehaviour
{
    public List<Transform> points;
    public Transform platform;
    int goalPoint = 0;
    public float speed = 2;

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //change the position of the platform (move towards the goal point)
        platform.position = Vector2.MoveTowards(platform.position, points[goalPoint].position, Time.deltaTime * speed);
        //Check if we are in very close proximity of the next point
        if (Vector2.Distance(platform.position, points[goalPoint].position) < 0.1f)
        {
            //If so change goal point to the next one
            //Check if we reached the last point, reset to first point
            if (goalPoint == points.Count - 1)
                goalPoint = 0;
            else
                goalPoint++;
        }
    }
}
