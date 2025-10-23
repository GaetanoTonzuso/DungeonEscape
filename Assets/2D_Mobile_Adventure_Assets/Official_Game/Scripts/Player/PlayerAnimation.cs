using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordAnim;
    private string _moveString = "Move";
    private string _jumpString = "Jumping";
    private string _attackString = "Attack";
    private string _deathString = "Death";

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if(_anim == null)
        {
            Debug.LogError("Anim is NULL on Player Anim");
        }

        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
        if(_swordAnim == null)
        {
            Debug.LogError("Sword Anim is null on PLAYER ANIM");
        }
    }

   
    public void Move(float Move)
    {
        _anim.SetFloat(_moveString, Mathf.Abs(Move));
    }

    public void Jump(bool Jumping)
    {
        _anim.SetBool(_jumpString, Jumping);
    }

    public void Attack()
    {
        _anim.SetTrigger(_attackString);
        _swordAnim.SetTrigger("SwordAnimation");
    }

    public void Death()
    {
        _anim.SetTrigger(_deathString);
    }
}
