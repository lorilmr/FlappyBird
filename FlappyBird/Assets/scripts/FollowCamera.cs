using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public Transform BirdTrans;
	// Use this for initialization
	void Start () {
		BirdTrans = GameObject.FindGameObjectWithTag ("bird").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.Insance.gState==GameState.GamePlaying){
			BirdTrans = GameObject.FindGameObjectWithTag ("bird").transform;
		}
		if (GameManager.Insance.gState == GameState.GamePlaying) {
			transform.position = new Vector3 (BirdTrans.position.x, transform.position.y, transform.position.z);
		}
	}
}
