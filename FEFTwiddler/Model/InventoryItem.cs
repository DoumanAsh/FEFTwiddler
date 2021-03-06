﻿using System;

namespace FEFTwiddler.Model
{
    public class InventoryItem : Item
    {
        public InventoryItem(byte[] bytes) : base(bytes)
        {
            if (bytes.Length != 4) throw new ArgumentException("Inventory items must be 4 bytes");
            ItemNameID = bytes[2];
            Uses = (byte)((int)bytes[3] & ~0x40);
            IsEquipped = (bytes[3] & 0x40) == 0x40;
        }

        /// <summary>
        /// A reference to the name of the item. Not sure quite how this works yet.
        /// </summary>
        public byte ItemNameID { get; set; }
        /// <summary>
        /// Doubles as forge level. 0x41 and up, I think
        /// </summary>
        public byte Uses { get; set; }
        public bool IsEquipped { get; set; }
    }
}
