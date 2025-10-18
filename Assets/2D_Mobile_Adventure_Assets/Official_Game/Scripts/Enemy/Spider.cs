using UnityEngine;

public class Spider : Enemy, IDamagable
{
    public int Health { get; set; }
    [SerializeField] private GameObject _acidPrefab;

    //Use for Initialize
    public override void Init()
    {
        base.Init();
        Health = base._health;
    }

    public override void Update()
    {
        

    }

    public override void Movement()
    {
        //Sit
    }

    public void Damage()
    {
        if(!isDead)
        {
            Health--;
            if(Health < 1)
            {
                isDead = true;
                anim.SetTrigger("Death");
                GameObject gem = Instantiate(_gemPrefab, transform.position, Quaternion.identity);
                gem.GetComponent<Diamond>().gems = base._gems;
            }
        }
    }

    //Called on Spider Animation Event script
    public void Attack()
    {
        GameObject acid = Instantiate(_acidPrefab,transform.position, Quaternion.identity);
        acid.transform.SetParent(this.transform,true);
    }
}
