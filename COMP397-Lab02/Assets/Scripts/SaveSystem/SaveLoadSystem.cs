using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SaveLoadSystem : PersistantSingleton<SaveLoadSystem>
{
    public GameData gameData;
    IDataService dataService;

    protected override void Awake()
    {
        base.Awake();
        dataService = new FileDataService(new JsonSerializer());
    }

    public void SaveGame()
    {
        dataService.Save(gameData);
    }

    public void LoadGame(string gameName)
    {
        gameData = dataService.Load(gameName);
        if (string.IsNullOrWhiteSpace(gameData.fileName))
        {
            gameData.sceneName = "SampleScene";
        }
        SceneManager.LoadScene(gameData.sceneName);
    }

    public void DeleteGame(string gameName)
    {
        dataService.Delete(gameName);
    }

    public IEnumerator<string> ListAllSaves()
    {
        //It asked for a cast like this for some reason
        return (IEnumerator<string>)dataService.ListSaves();
    }
}
