using UnityEngine;
using System.Collections;

public class BGmove : MonoBehaviour {
	private Transform BirdTrans;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.Insance.gState==GameState.GamePlaying){
		BirdTrans = GameObject.FindGameObjectWithTag ("bird").transform;
		}
		if (GameManager.Insance.gState==GameState.GamePlaying&&BirdTrans.position.x > transform.position.x + 15f) {
			//Debug.Log ("zz");
			transform.position = new Vector3 ( transform.position.x+30f, transform.position.y,transform.position.z);
			transform.Find ("pipe1").GetComponent<pipeParent> ().RandomPosition ();
			transform.Find ("pipe2").GetComponent<pipeParent> ().RandomPosition ();
			transform.Find ("jinbi").GetComponent<JinbiControl> ().RandomPosition ();
			transform.Find("jinbi").GetComponent<MeshRenderer>().enabled=true;
			
		}
	}
}
