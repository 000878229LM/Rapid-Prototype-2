using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Collider2D LevelCollider;
    public string LevelName;
    public void LoadConditionTriggered()
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadConditionTriggered();
    }
}