using UnityEngine;
using System.Collections;

public class JinbiControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public void RandomPosition()
	{
		float randomY = Random.Range(-0.09f, 0.17f);
		transform.localPosition = new Vector3(transform.localPosition.x, randomY, transform.localPosition.z);
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag.Equals("bird"))
		{
			GameManager.Insance.AddScore(1);
			GameManager.Insance.PlayAudioClip(GameManager.Insance.aSource1, AudioClipName.point);
			transform.GetComponent<MeshRenderer>().enabled=false;
			
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
