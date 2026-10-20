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
