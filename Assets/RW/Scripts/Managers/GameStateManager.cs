using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; 

    [HideInInspector]
    public int sheepSaved; 

    [HideInInspector]
    public int sheepDropped; 

    public int sheepDroppedBeforeGameOver; 
    public SheepSpawner sheepSpawner; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }

    private void GameOver()
    {
        sheepSpawner.canSpawn = false; 
        sheepSpawner.DestroyAllSheep();
        UIManager.Instance.ShowGameOverWindow();
    }

    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();

        if (sheepDropped == sheepDroppedBeforeGameOver) 
        {
            GameOver();
        }
    }


}
