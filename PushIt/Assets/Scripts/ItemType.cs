using UnityEngine;
using static CarController;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Coin,
        Gem
    }
    public ItemType type;
    public int value = 1;
    
}
