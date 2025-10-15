using UnityEngine;

public class MossGiant : Enemy, IDamagable
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
       
    }
}
