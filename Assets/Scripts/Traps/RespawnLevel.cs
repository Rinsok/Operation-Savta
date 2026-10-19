using UnityEngine;

public class RespawnLevel : MonoBehaviour
{
    [SerializeField] private HPBar hp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = FindAnyObjectByType<HPBar>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            hp.respawnFunc();
        }
    }
}
