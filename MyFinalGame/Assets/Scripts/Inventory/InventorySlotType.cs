using System;

[Flags]
public enum InventorySlotType
{
    None = 0,
    Weapon = 1 << 0,
    Armor = 1 << 1,
    Boots = 1 << 2,
    Heat = 1 << 3,
    All = Weapon | Boots | Heat | Armor
}
