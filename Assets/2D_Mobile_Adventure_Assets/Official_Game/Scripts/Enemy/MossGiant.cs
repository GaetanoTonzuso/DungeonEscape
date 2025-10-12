using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;

    public override void Update()
    {
        if(transform.position == _pointA.transform.position)
        {
            _currentTarget = _pointB.transform.position;       
        }

        else if (transform.position == _pointB.transform.position)
        {
            //Change Waypoint once arrived at first point
            _currentTarget = _pointA.transform.position;
        }

        MoveToWaypoint(_currentTarget);
    }

    private void MoveToWaypoint(Vector3 currentTarget)
    {
        var step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
    }
}
