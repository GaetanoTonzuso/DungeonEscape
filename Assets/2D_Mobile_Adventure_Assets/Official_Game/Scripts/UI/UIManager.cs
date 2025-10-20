using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if( _instance == null )
            {
                _instance = new UIManager();
            }
                return _instance;
        }
    }

    [SerializeField] private TextMeshProUGUI _gemsText;
    [SerializeField] private Image _selection;

    public void OpenShop(int gemsCount)
    {
        _gemsText.text = gemsCount.ToString() + "G";
    }

    public void UpdateShopSelection (int yPos)
    {
        _selection.rectTransform.anchoredPosition = new Vector2(_selection.rectTransform.anchoredPosition.x, yPos);
    }

    private void Awake()
    {
        _instance = this;
    }
}
