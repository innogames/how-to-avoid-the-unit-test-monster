using System;
using UnityEngine;
using UnityEngine.UI;

public interface IInventoryUI
{
	event Action<ItemId> ItemAdded;
}

public class InventoryUI : MonoBehaviour, IInventoryUI
{
	public event Action<ItemId> ItemAdded; 
	
	// this is connected in the inspector to the SwordUIButton
	public void AddSword()
	{
		AddItem(ItemId.Sword);
	}
	
	// this is connected in the inspector to the ShieldUIButton
	public void AddShield()
	{
		AddItem(ItemId.Shield);
	}
	
	// this is connected in the inspector to the HelmetUIButton
	public void AddHelmet()
	{
		AddItem(ItemId.Helmet);
	}

	private void AddItem(ItemId id)
	{
		if (ItemAdded != null)
		{
			ItemAdded(id);
		}
	}
}
