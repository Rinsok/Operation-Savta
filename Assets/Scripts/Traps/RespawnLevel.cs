using UnityEngine;

public class RespawnLevel : MonoBehaviour
{
    [SerializeField] private HPBar hp;
    [SerializeField] private GameObject coins;
    [SerializeField] private GameObject traps;
    public CoinCollect[] allChildrenCoins; 
    public Transform[] allChildrenTraps; 
    public Transform[] breakableGrounds; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = FindAnyObjectByType<HPBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp.health <= 0)
        {
            resetGame();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            resetGame();

        }
    }


    public void resetGame()
    {
        allChildrenCoins = coins.GetComponentsInChildren<CoinCollect>(true);
        allChildrenTraps = traps.GetComponentsInChildren<Transform>(true);
        PickUpManager.instance.RemoveCoins();

        hp.respawnFunc();
        foreach (CoinCollect child in allChildrenCoins)
        {
            child.gameObject.SetActive(true);
            child.isCollected = false;
        }

        foreach (Transform child in allChildrenTraps)
        {
            child.gameObject.SetActive(true);
        }

        foreach (Transform a in breakableGrounds)
        {
            a.gameObject.SetActive(true);
        }
    }
}
