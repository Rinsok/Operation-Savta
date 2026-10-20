using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VidOutro : MonoBehaviour
{
    [SerializeField] private VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component

    void Start()
    {
        VideoPlayer.loopPointReached += LoadScene;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }

    }
    void LoadScene(VideoPlayer vp)
    {

      Application.Quit();

    }

}
