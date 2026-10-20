using UnityEngine;
using UnityEngine.UI;

public class LastDoor : MonoBehaviour
{
    [SerializeField] private Text buttonText;
    [SerializeField] private GameObject lastDoor;
    [SerializeField] public int numOfButtons = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buttonText.text = numOfButtons.ToString();
        if (numOfButtons == 0)
        {
            Destroy(lastDoor);
        }
    }
}
