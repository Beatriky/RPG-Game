using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName="Inventory/Equipment")]
public class Equipment : Item
{   
    public int armorModifier;
    public int damageModifier;
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;
public override void Use(){
    base.Use();
    EquipmentManager.instance.Equip(this);  //equip the item remove it from the inventory
  //remove from inventory
    RemoveFromInventory();
    
}

}


public enum EquipmentSlot {Head, Chest, Legs, Weapon, Shield, Feet}
public enum EquipmentMeshRegion { Legs, Arms, torso }; //body blend shape


