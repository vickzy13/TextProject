using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 2)]
public class Cards : ScriptableObject {
	public static Cards instance;
	public int value;
	public GameObject obj;
	public string currentString;
	public Texture shapeImage;
	public Color cardColor;
	public void CallObj()
	{
		instance = this;	
	}
}
