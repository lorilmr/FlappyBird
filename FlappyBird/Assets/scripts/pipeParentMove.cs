using UnityEngine;
using System.Collections;

public class pipeParentMove : MonoBehaviour {
	private  float moveSpeed;
	private float time;
	// Use this for initialization
	void Start () {
		moveSpeed = 0.8f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-Vector3.up * moveSpeed*Time.deltaTime,Space.World);
		time=time-Time.deltaTime;
		if(time<=0){
			moveSpeed = -moveSpeed;
			time = 1f;
		}
	}
}
