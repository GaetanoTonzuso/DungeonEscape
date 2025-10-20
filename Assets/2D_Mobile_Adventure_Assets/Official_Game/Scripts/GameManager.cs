using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null )
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    public bool hasKeyToCastle { get; set; }

    private void Awake()
    {
        _instance = this;
    }
}
