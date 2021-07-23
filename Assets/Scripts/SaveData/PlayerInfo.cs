using SQLite;
using System;

namespace SaveData
{
    /// <summary>
    /// Player Info table structure
    /// </summary>
    [Serializable]
    [Table("PlayerInfo")]
    public class PlayerInfo
    {
        [PrimaryKey, Unique]
        public Guid Id { get; set; }

        [Unique]
        public string Name { get; set; }

        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int MaxStam { get; set; }
        public int CurrentStam { get; set; }
        public uint Experience { get; set; }
        public string PlayerTransform { get; set; }

        public override string ToString() =>
            $"Id: {Id}, " +
            $"Player Name: {Name}, " +
            $"Max HP: {MaxHP}, Current HP: {CurrentHP}, " +
            $"Max STAM: {MaxStam}, Current Stam: {CurrentStam}, " +
            $"Experience: {Experience}, " +
            $"Player Transform: {PlayerTransform}";
    }
}