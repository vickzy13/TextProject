using UnityEngine;
using System.Collections;

public class ImpleMentingScriptableObjs : MonoBehaviour {
	public Cards newcard;
	// Use this for initialization
	void Awake () {
		newcard.obj.GetComponent<MeshRenderer> ().sharedMaterial.color = newcard.cardColor;
		newcard.cardColor = Color.yellow;
		newcard.value = 0;
		newcard.currentString = "Mylanguage1";
	}
}
