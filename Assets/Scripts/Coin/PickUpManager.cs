using UnityEngine;
using UnityEngine.UI;

public class PickUpManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static PickUpManager instance;

    public Text coinsText;
    public int coins;

    
    
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddCoins()
    {
        coins++;
        coinsText.text = coins.ToString();
    }
}
