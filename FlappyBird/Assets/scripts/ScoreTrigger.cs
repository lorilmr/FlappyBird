using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		if (col.tag.Equals ("bird")) {
			GameManager.Insance.AddScore (1);
			GameManager.Insance.PlayAudioClip (GameManager.Insance.aSource1, AudioClipName.point);
		}
	}
}
