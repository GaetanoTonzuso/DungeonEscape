using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float _speed;
    [SerializeField]
    protected int _health;
    [SerializeField]
    protected int _gems;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer spriteRenderer;

    protected bool isHit = false;

    protected Player player;

    [Header("Waypoints")]
    [SerializeField] protected Transform _pointA, _pointB;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        if(anim == null)
        {
            Debug.LogError("Anim is NULL on: " + this.gameObject.name);
        }

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("Sprite Renderer is NULL on: " + this.gameObject.name);
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player == null)
        {
            Debug.LogError("Player is NULL on: " + this.gameObject.name);
        }
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update ()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }

        Movement();
    }

    public virtual void Movement()
    {
        if (currentTarget == _pointA.position)
        {
            spriteRenderer.flipX = true;
        }
        else if (currentTarget == _pointB.position)
        {
            spriteRenderer.flipX = false;
        }

        if (transform.position == _pointA.position)
        {
            currentTarget = _pointB.position;
            anim.SetTrigger("Idle");
        }

        else if (transform.position == _pointB.position)
        {
            currentTarget = _pointA.position;
            anim.SetTrigger("Idle");
        }

        if(!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, _speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance > 2f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
            Debug.Log("Player is out of distance");
        }

    }
}
