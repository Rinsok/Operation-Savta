using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    
    public int health;
    public int numOfHearts;
    public AudioSource bg;
    [SerializeField] public CharacterController ortal;
    [SerializeField] public MotiController moti;
    [SerializeField] public ExoController exo;
    [SerializeField] public Transform respawn;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bg = FindAnyObjectByType<AudioSource>();
        health = ortal.GetCurrentHP();
        numOfHearts = ortal.GetMaxHP();
    }

    // Update is called once per frame
    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        health = Mathf.Min(ortal.GetCurrentHP(), moti.GetCurrentHP(), exo.GetCurrentHP());
        ortal.updateHP(health);
        moti.updateHP(health); 
        exo.updateHP(health);  

        if(health <= 0)
        {
            respawnFunc();
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHearts;
            }
            else 
            {

                hearts[i].sprite = emptyHearts;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void respawnFunc()
    {
        ortal.updateHP(numOfHearts);
        moti.updateHP(numOfHearts);
        exo.updateHP(numOfHearts);
        ortal.transform.position = respawn.position;
        moti.transform.position = respawn.position;
        exo.transform.position = respawn.position;
        bg.Stop();
        bg.Play();

    }
}
