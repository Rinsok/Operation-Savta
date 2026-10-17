using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    
    public int health;
    public int numOfHearts;

    [SerializeField] CharacterController ortal;
    [SerializeField] MotiController moti;
    [SerializeField] ExoController exo;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        ortal.SetHP(health);
        moti.SetHP(health); 
        exo.SetHP(health);  

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
}
