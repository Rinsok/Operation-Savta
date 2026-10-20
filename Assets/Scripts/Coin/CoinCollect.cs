using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public bool isCollected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.isActiveAndEnabled &&!isCollected)
        {
            isCollected = true;
            PickUpManager.instance.AddCoins();
            this.gameObject.SetActive(false);
            if(PickUpManager.instance.coins == PickUpManager.instance.totalCoins)
            {
                PickUpManager.instance.totem.SetActive(true);
            }
        }
    }
}
