using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

/// <summary>
/// Game Manager singleton class
/// </summary>
public class GameManager : MonoSingleton<GameManager>
{
    public string DbName = "SaveData.sqlite3";
    public Text displayText;

    private SaveGameManager _saveGameManager;

    protected override void Awake()
    {
        base.Awake();
        _saveGameManager = new SaveGameManager(DbName);
    }

    public void OnPlayerInfoCount()
    {
        displayText.text = $"{nameof(OnPlayerInfoCount)}: {_saveGameManager.GetPlayerInfoCount()}\n";
    }

    public void OnPlayerInfoFirst()
    {
        displayText.text = $"{nameof(OnPlayerInfoFirst)}:\n\n{_saveGameManager.GetFirstPlayerInfo()}";
    }

    public void OnPlayerInfoAll()
    {
        displayText.text = nameof(OnPlayerInfoAll) + "\n\n";
        _saveGameManager.GetAllPlayerInfo().ForEach(x => displayText.text += $"{x}\n\n");
    }

    public void OnPlayerInfoFromId()
    {

    }

    public void OnPlayerInfoFromName()
    {

    }

    public void OnCreateNewPlayer()
    {
        _saveGameManager.CreateNewPlayerInfo(RandomName.Generate(new Random().Next(2, 10)));
        displayText.text = $"{nameof(OnCreateNewPlayer)}:\n\n {_saveGameManager.GetLastPlayerInfo()}";
    }
}