using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private string moveString = "Move";
    private string jumpString = "Jumping";

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if(_anim == null)
        {
            Debug.LogError("Anim is NULL on Player Anim");
        }
    }

   
    public void Move(float Move)
    {
        _anim.SetFloat(moveString, Mathf.Abs(Move));
    }

    public void Jump(bool Jumping)
    {
        _anim.SetBool(jumpString, Jumping);
    }
}
