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
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update ()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;
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

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, _speed * Time.deltaTime);
    }
}
