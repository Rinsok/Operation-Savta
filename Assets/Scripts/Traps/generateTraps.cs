using Unity.VisualScripting;
using UnityEngine;

public class generateTraps : MonoBehaviour
{

    [SerializeField] private GameObject[] traps = new GameObject [3];
    [SerializeField] private GameObject currentTrap;
    private int randomNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomNum = Random.Range(0, 3);
        currentTrap = traps[randomNum];
        Instantiate(currentTrap, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
