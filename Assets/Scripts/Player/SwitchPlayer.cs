using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    [SerializeField] private int currentCharacter;
    private Vector3 lastPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCharacter = Random.Range(0, transform.childCount);
        UpdateCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lastPosition = transform.GetChild(currentCharacter).position;
            currentCharacter++;
            
            if (currentCharacter >= transform.childCount)
            {
                currentCharacter = 0;
            }
            transform.GetChild(currentCharacter).position = lastPosition;
            UpdateCharacter();
        }
    }

    private void UpdateCharacter()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(currentCharacter).gameObject.SetActive(true);

    }
}
