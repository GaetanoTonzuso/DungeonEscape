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
    [SerializeField] private TextMeshProUGUI _gemCountUI;
    [SerializeField] private GameObject[] _livesUi;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemsCount)
    {
        _gemsText.text = gemsCount.ToString() + "G";
    }

    public void UpdateShopSelection (int yPos)
    {
        _selection.rectTransform.anchoredPosition = new Vector2(_selection.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        _gemCountUI.text = "" + count.ToString();
    }

    public void UpdateLives(int livesRemaining)
    {
        //loop through lives
        //active and deactivate ui live
        for(int i = 0; i < _livesUi.Length; i++)
        {
            if(livesRemaining == i)
            _livesUi[i].SetActive(false);
        }
    }

}
