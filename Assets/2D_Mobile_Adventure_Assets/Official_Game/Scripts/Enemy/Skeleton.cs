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

    public override void Movement()
    {
        base.Movement();
        Vector3 direction = player.transform.localPosition - transform.position;
        Debug.Log("Direction X: " + direction.x);

        if(direction.x > 0 && anim.GetBool("InCombat"))
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat"))
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Damage()
    {
        Debug.Log("Damage");
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat",true);

        if(Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
