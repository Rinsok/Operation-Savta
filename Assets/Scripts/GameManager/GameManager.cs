using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private HPBar bar;
    public static GameManager Instance;
    
    public bool collectedTotem = false;

    void Awake()
    {
        
        if (collectedTotem)
        {
            bar.numOfHearts = 4;
            bar.health = 4;
            bar.ortal.SetHP(4);
            bar.moti.SetHP(4);
            bar.exo.SetHP(4);
            bar.ortal.updateHP(4);
            bar.moti.updateHP(4);
            bar.exo.updateHP(4);
        }
        bar = FindAnyObjectByType<HPBar>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextScene()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

 
}
