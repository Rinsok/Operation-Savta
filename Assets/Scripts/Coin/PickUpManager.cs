using UnityEngine;
using UnityEngine.UI;

public class PickUpManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static PickUpManager instance;

    [SerializeField] private Text coinsText;
    [SerializeField] public int coins = 0;
    [SerializeField] public int totalCoins = 20;
    [SerializeField] public GameObject totem;

    
    
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
