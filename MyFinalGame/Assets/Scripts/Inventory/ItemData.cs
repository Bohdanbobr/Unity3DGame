using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public int Damege { get; private set; }
    [field: SerializeField] public int Armor { get; private set; }
    [field: SerializeField] public int MaxCountInSlot { get; private set; }
    [field: SerializeField] public InventorySlotType SlotType { get; private set; }
}