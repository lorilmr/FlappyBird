using UnityEngine;
using System.Collections;

public class pipeParent : MonoBehaviour {
	private  float moveSpeed;
	private float time;
	// Use this for initialization
	void Start () {
		moveSpeed = 0.5f;
	}
	public void RandomPosition(){
		float randomY = Random.Range (-0.15f,0.028f);
		transform.localPosition = new Vector3 (transform.localPosition.x,randomY,transform.localPosition.z);
	}
	// Update is called once per frame
	void Update () {

	}
}
