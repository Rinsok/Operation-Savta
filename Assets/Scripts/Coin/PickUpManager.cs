using UnityEngine;
using UnityEngine.UI;

public class PickUpManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static PickUpManager instance;

    [SerializeField] private Text coinsText;
    [SerializeField] private int coins = 0;
    [SerializeField] private int totalCoins = 20;
    [SerializeField] private GameObject totem;

    
    
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (coins == totalCoins)
        {

        }
    }


    public void AddCoins()
    {
        coins++;
        coinsText.text = coins.ToString();
    }
}
