using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    [Header("Acid Settings")]
    [SerializeField] private float _speed = 3.0f;

    private void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit Something");

        if(other.TryGetComponent<IDamagable>(out IDamagable damageable))
        {
            damageable.Damage();
            Destroy(this.gameObject,0.1f);
        }
    }
}
