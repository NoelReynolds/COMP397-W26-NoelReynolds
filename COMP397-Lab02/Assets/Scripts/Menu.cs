using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : PersistantSingleton<Menu>
{
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;

    private void Start()
    {
        saveButton.onClick.AddListener(() =>
        {
            SaveLoadSystem.instance.gameData.fileName = "Menu";
            SaveLoadSystem.instance.gameData.sceneName = "SampleScene";
            SaveLoadSystem.instance.SaveGame();
        });
        loadButton.onClick.AddListener(() =>
        {
            SaveLoadSystem.instance.LoadGame("Menu");
        });
    }

    public void StartPlayGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
    }

    public void StartPlayGameSingle()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
