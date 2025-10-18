using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    Spider _spider;

    private void Start()
    {
        _spider = GetComponentInParent<Spider>();
        if(_spider == null)
        {
            Debug.LogError("Spider is NULL on SpiderAnimationEvent");
        }
    }

    public void Fire()
    {
        _spider.Attack();
    }
}
