using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private  LastDoor lastDoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(door == null )
        {
            lastDoor = FindAnyObjectByType<LastDoor>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            if (door != null)
            {
                Destroy(door);
                Destroy(gameObject);

            }
            else
            {
                lastDoor.numOfButtons--;
                Destroy(gameObject);

            }

        }
    }
    
}
