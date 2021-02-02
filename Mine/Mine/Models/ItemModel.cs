using SQLite;
using System;

namespace Mine.Models
{
    /// <summary>
    /// Items for the Characters and Monsters to use
    /// </summary>
    public class ItemModel
    {
        // Id for the Item
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        // The Display Text for the Item
        public string Text { get; set; }
        // The Description of the item
        public string Description { get; set; }

        //The Value of the Item +9 Damage
        public int Value { get; set; } = 0;
    }
}