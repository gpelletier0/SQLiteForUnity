using SQLite;
using System;

namespace SaveData
{
    /// <summary>
    /// Player Inventory table structure
    /// </summary>
    [Serializable]
    [Table("PlayerInventory")]
    public class PlayerInventory
    {
        [PrimaryKey, Unique]
        public Guid PlayerId { get; set; }

        [Unique]
        public int SlotNumber { get; set; }

        public int ItemType { get; set; }
        public int Amount { get; set; }
    }
}