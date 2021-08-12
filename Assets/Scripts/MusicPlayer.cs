using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    
    private void Awake()
    {
        int numPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numPlayers > 1)
        {
            Destroy(gameObject);
        }
        else 
        { 
            DontDestroyOnLoad(gameObject); 
        } 
    }

}
