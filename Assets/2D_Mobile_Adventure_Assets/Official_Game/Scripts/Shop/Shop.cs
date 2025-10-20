using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    private int _currentItemSelected;
    private int _currentItemCost;
    private Player _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _player = other.GetComponent<Player>();

            if(_player != null)
            {
                UIManager.Instance.OpenShop(_player.CurrentGems);
            }
            
            _shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        _shopPanel.SetActive(false);
    }

    public void SelectItem(int item)
    {
        Debug.Log("Item selected" + item);

        switch(item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(81);
                _currentItemSelected = item;
                _currentItemCost = 200;
                break;

            case 1:
                UIManager.Instance.UpdateShopSelection(-33);
                _currentItemSelected = item;
                _currentItemCost = 400;
                break;

            case 2:
                UIManager.Instance.UpdateShopSelection(-135);
                _currentItemSelected = item;
                _currentItemCost = 100;
                break;

            default:
                break;
        }
    }

    public void BuyItem()
    {
        if(_player.CurrentGems >= _currentItemCost)
        {
            if(_currentItemSelected == 2)
            {
                GameManager.Instance.hasKeyToCastle = true;
            }

            Debug.Log("Grant item");
            _player.CurrentGems -= _currentItemCost;
            UIManager.Instance.OpenShop(_player.CurrentGems);
        }
        else
        {
            _shopPanel.SetActive(false);
        }
    }
}
