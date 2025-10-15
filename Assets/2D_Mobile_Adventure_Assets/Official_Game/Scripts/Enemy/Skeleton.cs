using System.Collections;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
    public int Health { get; set; }

    //Use for Initialize
    public override void Init()
    {
        base.Init();
        Health = base._health;
    }

    public void Damage()
    {
        Debug.Log("Damage");
        Health--;
        if(Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
