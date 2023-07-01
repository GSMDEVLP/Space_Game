using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadLevelDelay;
    [SerializeField] GameObject explosionFX;
    private void OnTriggerEnter(Collider other)
    {
        print("Hit!");
        GameOver();
        explosionFX.SetActive(true);
        Invoke("RestartLevel", loadLevelDelay);
    }

    void GameOver()
    {
        SendMessage("OnPlayerDeath");
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }    
}
