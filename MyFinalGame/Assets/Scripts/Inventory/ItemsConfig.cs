using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsConfig", menuName = "MyGame/ItemsConfig")]
public class ItemsConfig : ScriptableObject
{
    public ItemData[] items;
}