using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    private Coroutine _cooldownAttackRoutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);
        IDamagable damageable = other.GetComponent<IDamagable>();
        if(damageable != null )
        {
            if(_canDamage)
            {
                damageable.Damage();
                _canDamage = false;
                _cooldownAttackRoutine = StartCoroutine(CooldownAttackRoutine());
            }
        }
    }


    private IEnumerator CooldownAttackRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
        _cooldownAttackRoutine = null;
    }
}
