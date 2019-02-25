using UnityEngine;

public class Main : MonoBehaviour {

	public Character3d ConnectedCharacter;
	public InventoryUI ConnectedInventory; 
	
	// Use this for initialization
	void Start () {
		ConnectedCharacter.Init(ConnectedInventory, new UnityResourceLoader());
	}
}
