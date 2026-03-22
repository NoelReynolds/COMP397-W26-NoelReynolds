using System.Collections.Generic;

public class SimpleInventory : PersistantSingleton<SimpleInventory>
{
    public int currency = 0;
    public int wood = 0;
    public int metal = 0;
    public int food = 0;

    public bool hasSword = false;
    public bool hasSpear = false;
    public bool hasShield = false;
    public bool hasHelmet = false;
}

public class ArrayInventory : PersistantSingleton<ArrayInventory>
{
    public Item[] backPack = new Item[8];
    public Item[] homeChest = new Item[64];
    public List<Item> dynamicSizeBackpack = new List<Item>();
}

[System.Serializable]
public class Item
{
    //public int maxStack = 1;
    public bool isStackable = false;
}
