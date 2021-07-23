using UnityEngine;
using Random = System.Random;

/// <summary>
/// Game Manager singleton class
/// </summary>
public class GameManager : MonoSingleton<GameManager>
{
    public string DbName = "SaveData.sqlite3";

    private SaveGameManager _saveGameManager;

    protected override void Awake()
    {
        base.Awake();
        _saveGameManager = new SaveGameManager(DbName);
    }

    private void Start()
    {
        if (_saveGameManager.GetPlayerInfoCount() <= 0)
        {
            _saveGameManager.CreateNewPlayerInfo(RandomName.Generate(new Random().Next(2, 10)));
        }

        _saveGameManager.GetAllPlayerInfo().ForEach(x => Debug.Log(x.ToString()));
    }
}