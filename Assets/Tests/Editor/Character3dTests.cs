using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tests.Editor
{
	public class Character3dTests  {
	
		private Character3d _testObject;
		private DummyInventory _dummyInventory;
		private DummyResourceLoader _dummyResourceLoader;

		[SetUp]
		public void RunBeforeEveryTest()
		{
			_testObject = new GameObject("TestCharacter").AddComponent<Character3d>();
			_dummyInventory = new DummyInventory();
			_dummyResourceLoader = new DummyResourceLoader();
			_testObject.Init(_dummyInventory, _dummyResourceLoader);
		}
	
		[TearDown]
		public void RunAfterEveryTest()
		{
			Object.DestroyImmediate(_testObject.gameObject);
		}
	
		[Test]
		[TestCase(ItemId.Helmet)]
		[TestCase(ItemId.Shield)]
		[TestCase(ItemId.Sword)]
		public void AddItemButton_ShouldInstantiate_Item(ItemId itemId)
		{
			// Setup test specific objects
			_testObject.HelmetAttachmentPoint = _testObject.transform;
			_testObject.ShieldAttachmentPoint = _testObject.transform;
			_testObject.SwordAttachmentPoint = _testObject.transform;
		
			// trigger function to test
			_dummyInventory.Fire(itemId);
		
			// evaluate result
			var firstChild = _testObject.HelmetAttachmentPoint.GetChild(0);
			Assert.IsTrue(firstChild.name.Contains(itemId.ToString()));
		}

		private class DummyInventory : IInventoryUI
		{
			public event Action<ItemId> ItemAdded;

			public void Fire(ItemId id)
			{
				ItemAdded(id);
			}
		}

		private class DummyResourceLoader : IResourceLoader
		{
			public T Load<T>(string resourcePath) where T : Object
			{
				var item = new GameObject(string.Format("Dummy:{0}", resourcePath));
				return (item as T);
			}
		}
	}
}