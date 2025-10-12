using UnityEngine;

public class Spider : Enemy
{
    public override void Attack()
    {
        Debug.Log("Spider Attack");
    }

    public override void Update()
    {
        Debug.Log("Spider Updating...");
    }

    
}
