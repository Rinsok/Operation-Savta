using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    [SerializeField] private int currentCharacter;

    [SerializeField] private GameObject moti;
    [SerializeField] private GameObject ortal;
    [SerializeField] private GameObject exo;
    [SerializeField] private GameObject[] players = new GameObject [3]; 
    private Vector3 lastPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        players[0] = moti;
        players[1] = ortal;
        players[2] = exo;
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(false);
        }
        currentCharacter = Random.Range(0, 3);
        UpdateCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lastPosition = players[currentCharacter].transform.position;
            currentCharacter++;
            
            if (currentCharacter >= 3)
            {
                currentCharacter = 0;
            }
            if (players[currentCharacter] == players[2])
            {
                players[currentCharacter].transform.position = new Vector2(lastPosition.x, lastPosition.y - 0.453f);

            }
            else
            {
                players[currentCharacter].transform.position = lastPosition;
            }
            UpdateCharacter();
        }
    }

    private void UpdateCharacter()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (i == currentCharacter)
            {
                players[i].SetActive(true);
            }
            else
            {
                players[i].SetActive(false);
            }
        }
    }

    public GameObject GetCurrentCharacter()
    {
        return players[currentCharacter];
    }
}
