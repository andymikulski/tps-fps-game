using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingText : MonoBehaviour {
	private Text textBox;
	private int currentlyDisplayingText = -1;

	//Store all your text in this string array
	public string[] textToWrite;

	void Awake () {
		textBox = GetComponent<Text> ();
	}

	public void StartTyping() {
		currentlyDisplayingText = -1;
		SkipToNextText();
	}

	public void SetText (string[] newText){
		textToWrite = newText;
	}

	public void SkipToNextText(){
		StopAllCoroutines();
		if (currentlyDisplayingText + 1 >= textToWrite.Length && textToWrite.Length > 0) {
			StartCoroutine (DeanimateText ());
			return;
		}

		currentlyDisplayingText++;
		StartCoroutine(AnimateText());
	}

	IEnumerator AnimateText(){
		for (int i = 0; i <= textToWrite[currentlyDisplayingText].Length; i++)
		{
			textBox.text = textToWrite[currentlyDisplayingText].Substring(0, i);
			yield return new WaitForSeconds(.03f);
		}

		yield return new WaitForSeconds(3f);
		SkipToNextText ();
	}

	IEnumerator DeanimateText(){
		for (int i = textToWrite[currentlyDisplayingText].Length; i >= 0; i--)
		{
			textBox.text = textToWrite[currentlyDisplayingText].Substring(0, i);
			yield return new WaitForSeconds(.03f);
		}
	}
}
