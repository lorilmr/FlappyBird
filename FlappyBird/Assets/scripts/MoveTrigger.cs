using UnityEngine;
using System.Collections;

public class MoveTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		if (col.tag.Equals ("bird")) {
			transform.parent.position=new Vector3 ( GameManager.Insance.firstTrans.position.x+10f,GameManager.Insance.firstTrans.position.y,GameManager.Insance.firstTrans.position.z);
			GameManager.Insance.firstTrans = transform.parent;
		}
	}
}
