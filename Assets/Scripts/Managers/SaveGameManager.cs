using SaveData;
using SQLite;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Save Game Manager class
/// </summary>
public class SaveGameManager
{
    private readonly SQLiteConnection _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbName">name of database</param>
    public SaveGameManager(string dbName)
    {
        _db = new SQLiteConnection($"{Application.streamingAssetsPath}/{dbName}");
        _db.CreateTables<PlayerInfo, PlayerInventory>();
    }

    /// <summary>
    /// Creates a new player info and inserts it in the PlayerInfo table
    /// </summary>
    /// <param name="playerName">Name of new player</param>
    internal void CreateNewPlayerInfo(string playerName)
    {
        try
        {
            _db.Insert(
                new PlayerInfo()
                {
                    Id = Guid.NewGuid(),
                    Name = $"{playerName}",
                    MaxHP = 100,
                    CurrentHP = 100,
                    MaxStam = 100,
                    CurrentStam = 100,
                    Experience = 0,
                    PlayerTransform = JsonUtility.ToJson(new SerializableTransform())
                });
        }
        catch (SQLiteException ex)
        {
            Debug.LogError(ex);
        }
    }

    /// <summary>
    /// Gets the count of player info in the PlayerInfo table
    /// </summary>
    /// <returns>Player Info count</returns>
    public int GetPlayerInfoCount() => _db.Table<PlayerInfo>().Count();

    /// <summary>
    /// Gets the first player info in the PlayerInfo table
    /// </summary>
    /// <returns>PlayerInfo or null</returns>
    public PlayerInfo GetFirstPlayerInfo() => _db.Table<PlayerInfo>().FirstOrDefault();

    /// <summary>
    /// Gets the last player info in the PlayerInfo table
    /// </summary>
    /// <returns>PlayerInfo or null</returns>
    public PlayerInfo GetLastPlayerInfo() => _db.Table<PlayerInfo>().Skip(GetPlayerInfoCount() - 1).FirstOrDefault();

    /// <summary>
    /// Gets all player info from the PlayerInfo table
    /// </summary>
    /// <returns>List of PlayerInfo</returns>
    public List<PlayerInfo> GetAllPlayerInfo() => _db.Table<PlayerInfo>().ToList();

    /// <summary>
    /// Gets player info by player id from the PlayerInfo table
    /// </summary>
    /// <param name="playerId"></param>
    /// <returns>PlayerInfo or null</returns>
    public PlayerInfo GetPlayerInfoFromGuid(Guid playerId) => _db.Table<PlayerInfo>().FirstOrDefault(x => x.Id.Equals(playerId));

    /// <summary>
    /// Gets the player info by player name from the PlayerInfo table
    /// </summary>
    /// <param name="playerName"></param>
    /// <returns>PlayerInfo or null</returns>
    public PlayerInfo GetPlayerInfoFromName(string playerName) => _db.Table<PlayerInfo>().FirstOrDefault(x => x.Name.Equals(playerName));

    /// <summary>
    /// Gets the player info by player id from the PlayerInfo table
    /// </summary>
    /// <param name="playerId"></param>
    /// <returns>PlayerInfo or null</returns>
    public PlayerInventory GetPlayerInventory(Guid playerId) => _db.Table<PlayerInventory>().FirstOrDefault(x => x.PlayerId.Equals(playerId));
}