using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int _speed;
    [SerializeField]
    protected int _health;
    [SerializeField]
    protected int _gems;

    [Header("Waypoints")]
    [SerializeField] protected Transform _pointA, _pointB;

    public virtual void Attack()
    {
        Debug.Log("My name is: " + this.gameObject.name);
    }

    public abstract void Update();
}
