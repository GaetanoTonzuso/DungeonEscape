using UnityEngine;

public class Spider : Enemy, IDamagable
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
