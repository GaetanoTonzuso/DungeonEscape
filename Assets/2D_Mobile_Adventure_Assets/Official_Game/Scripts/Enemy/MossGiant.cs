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
        if(!isDead)
        {
            Debug.Log("Damage");
            Health--;
            anim.SetTrigger("Hit");
            isHit = true;
            anim.SetBool("InCombat", true);

            if (Health < 1)
            {
                isDead = true;
                anim.SetTrigger("Death");
                GameObject gem = Instantiate(_gemPrefab, transform.position, Quaternion.identity);
                gem.GetComponent<Diamond>().gems = base._gems;
            }
        }
    }
}
