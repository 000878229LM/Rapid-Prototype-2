using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.hasKey)
            {
                SceneManager.LoadScene("level2");
            }
            else
            {
                SceneManager.LoadScene("endscreennokey");
            }
        }
    }
}