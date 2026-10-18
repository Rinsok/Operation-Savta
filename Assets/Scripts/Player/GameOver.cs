using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{

    [SerializeField] private SwitchPlayer player;
    [SerializeField] private HPBar bar;
    [SerializeField] private Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bar.health <= 0)
        {
            player.SetPlayerSpawn(spawnPoint);
            bar.health = bar.numOfHearts;
        }
    }

}
