using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character3d : MonoBehaviour
{
	public Transform ShieldAttachmentPoint;
	public Transform HelmetAttachmentPoint;
	public Transform SwordAttachmentPoint;

	private IInventoryUI _attachedUi;
	private IResourceLoader _resourceLoader;

	public void Init(IInventoryUI inventoryUi, IResourceLoader resourceLoader)
	{
		_resourceLoader = resourceLoader;
		_attachedUi = inventoryUi;
		_attachedUi.ItemAdded += UpdateItemView;
	}

	private void UpdateItemView(ItemId itemId)
	{
		switch (itemId)
		{
			case ItemId.Helmet:
				InstantiateItem("Helmet", HelmetAttachmentPoint);
				break;
			case ItemId.Shield:
				InstantiateItem("Shield", ShieldAttachmentPoint);
				break;
			case ItemId.Sword:
				InstantiateItem("Sword", SwordAttachmentPoint);
				break;
		}
	}

	private void InstantiateItem(string itemId, Transform attachmentPoint)
	{
		if (attachmentPoint.childCount > 0)
		{
			return;
		}

		var prefab = _resourceLoader.Load<GameObject>(itemId);
		var item = Instantiate(prefab);
		item.transform.SetParent(attachmentPoint);
		item.transform.localPosition = Vector3.zero;
		item.transform.localRotation = Quaternion.identity;
	}
}
