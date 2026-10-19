using UnityEngine;

public class TotemScript : MonoBehaviour
{
    [SerializeField] public HPBar hearts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hearts = FindAnyObjectByType<HPBar>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.Instance.collectedTotem = true;
            this.gameObject.SetActive(false);
            hearts.numOfHearts = 4;
            hearts.ortal.updateHP(hearts.numOfHearts);
            hearts.moti.updateHP(hearts.numOfHearts);
            hearts.exo.updateHP(hearts.numOfHearts);
        }
    }
}
