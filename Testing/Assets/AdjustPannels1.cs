using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
//using ArabicSupport;
//using SmartLocalization;

[System.Serializable]
public class Adjustments1
{
	public List<TextList> textToTransform;
	public List<TextListToSwap> textToSwap;
	public List<BgList> bgToTransform;
	public List<gameobject> gameobjectToTransform;
	public List<stringForText> stringValueForText;
	public bool wantArabicFixed;
}
[System.Serializable]
public class TextList
{
	public Vector3 MyTextTransPos;
	public Text myText;
}

[System.Serializable]
public class TextListToSwap
{
	public Text myTextToSwap1;
	public Text myTextToSwap2;
}


[System.Serializable]
public class BgList
{
	public Vector3 MyImageTransPos;
	public Image MyImage;
}

[System.Serializable]
public class gameobject
{
	public Vector3 MyGameobjectTransPos;
	public GameObject gameobjectForArabic;
}
[System.Serializable]
public class stringForText
{
	public Text ForArabictext;
	public string MyString;
}

public class AdjustPannels1 : MonoBehaviour
{
	public Cards card;
	public static AdjustPannels1 instance;
	public List<Adjustments1> adjustmentAttributes;
	int elementNumberForAttributes;

	void Start () 
	{
		card.value = 80;
		//if(LanguageHandler.instance.IsRightToLeft)
		instance = this;
	}

	public void Arabic( int elementNumberForAttributes)
	{
		print (elementNumberForAttributes + " elementNumberForAttributes");
		//If you want to hive the text particular positions
		if (adjustmentAttributes[elementNumberForAttributes].textToTransform != null) 
		{
			for (int i = 0; i < adjustmentAttributes[elementNumberForAttributes].textToTransform.Count; i++) 
			{
				//adjustmentAttributes [elementNumberForAttributes].textToTransform [i].myText.rectTransform.anchorMax = new Vector2 (0.5f,0.5f);
				//adjustmentAttributes [elementNumberForAttributes].textToTransform [i].myText.rectTransform.anchorMin = new Vector2 (0.5f,0.5f);

				adjustmentAttributes[elementNumberForAttributes].textToTransform [i].myText.transform.localPosition = adjustmentAttributes[elementNumberForAttributes].textToTransform [i].MyTextTransPos;
			}
		}
		//If you want to swap the texts
		if (adjustmentAttributes[elementNumberForAttributes].textToSwap != null) 
		{
			Vector3 temp;
			for (int i = 0; i < adjustmentAttributes[elementNumberForAttributes].textToSwap.Count; i++) 
			{
				temp = adjustmentAttributes [elementNumberForAttributes].textToSwap [i].myTextToSwap2.gameObject.transform.position;
				adjustmentAttributes [elementNumberForAttributes].textToSwap [i].myTextToSwap2.gameObject.transform.position = adjustmentAttributes [elementNumberForAttributes].textToSwap [i].myTextToSwap1.gameObject.transform.position;
				adjustmentAttributes [elementNumberForAttributes].textToSwap [i].myTextToSwap1.gameObject.transform.position = temp;
			}
		}

		if (adjustmentAttributes[elementNumberForAttributes].stringValueForText != null) 
		{
			for (int i = 0; i < adjustmentAttributes[elementNumberForAttributes].stringValueForText.Count; i++) 
			{	
//				adjustmentAttributes [elementNumberForAttributes].stringValueForText [i].ForArabictext.transform.parent.GetComponent<LocaliseTextAndVoiceOver> ().enabled = false;
				if (adjustmentAttributes [elementNumberForAttributes].wantArabicFixed) {
					//adjustmentAttributes [elementNumberForAttributes].stringValueForText [i].ForArabictext.text = ArabicFixer.Fix (adjustmentAttributes [elementNumberForAttributes].stringValueForText [i].MyString, false, false);
					adjustmentAttributes [elementNumberForAttributes].stringValueForText [i].ForArabictext.alignment = TextAnchor.MiddleRight;
				}
				else
					adjustmentAttributes [elementNumberForAttributes].stringValueForText [i].ForArabictext.text = adjustmentAttributes [elementNumberForAttributes].stringValueForText [i].MyString;
			}
		}
		if (adjustmentAttributes[elementNumberForAttributes].gameobjectToTransform != null) 
		{
			for (int i = 0; i < adjustmentAttributes[elementNumberForAttributes].gameobjectToTransform.Count; i++) 
			{
				adjustmentAttributes[elementNumberForAttributes].gameobjectToTransform [i].gameobjectForArabic.transform.localPosition = adjustmentAttributes[elementNumberForAttributes].gameobjectToTransform [i].MyGameobjectTransPos;
			}
		}

		if (adjustmentAttributes[elementNumberForAttributes].bgToTransform != null) 
		{
			for (int i = 0; i < adjustmentAttributes[elementNumberForAttributes].bgToTransform.Count; i++) 
			{
				adjustmentAttributes[elementNumberForAttributes].bgToTransform [i].MyImage.transform.localPosition = adjustmentAttributes[elementNumberForAttributes].bgToTransform [i].MyImageTransPos;
			}
		}
		elementNumberForAttributes++;
	}		

	public void call(int i)
	{
		print ("enter");
		//if (LanguageHandler.instance.IsRightToLeft) {
			Arabic (i);
		}
		
}