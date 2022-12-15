using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class BirdControl : MonoBehaviour {
	private Material BirdMaterial;
	private float time;
	public float frame;
	private int count;
	// Use this for initialization
	void Start () {
		BirdMaterial = transform.GetComponent<MeshRenderer> ().material;
		//time = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Insance.gState == GameState.GamePlaying) {
			//if(EventSystem.current.IsPointerOverGameObject()==false)
				if(Input .GetMouseButtonDown(0)){
					GameManager.Insance.tapImg.SetActive (false);
					//激活重力
					ActiveGravity();
					time+=Time.deltaTime;//一秒有frame帧
					//Debug.Log(time);
					if(time >1/frame){
						count++;
						//Debug.Log (count);
						int index = count % 3;
						BirdMaterial.SetTextureOffset ("_MainTex",new Vector2 (0.333f*index,0f));
						time = time - 1 / frame;
					}
					//给鸟一个向前的力
					Rigidbody rigidpre=transform.GetComponent<Rigidbody>();
					rigidpre.velocity = new Vector3 (4f, rigidpre.velocity.y, rigidpre.velocity.z);
					//当鼠标按下给鸟一个向上的力
					if(Input.GetMouseButtonDown(0)){
						Rigidbody rigidnow = transform.GetComponent<Rigidbody> ();
						rigidnow.velocity = new Vector3 (rigidnow.velocity.x, 4f, rigidnow.velocity.z);
						GameManager.Insance.PlayAudioClip (GameManager.Insance.aSource, AudioClipName.wing);
					}
				}
		}
		//计数器
//		time -= Time.deltaTime;
//		if (time>1f&&time <= 1.5f) {
//			Vector2 offset = new Vector2 (0.333f, 0f);
//			BirdMaterial.SetTextureOffset ("_MainTex", offset);
//		}
//		else if (time>0.5f&&time <= 1f) {
//			Vector2 offset = new Vector2 (0.666f, 0f);
//			BirdMaterial.SetTextureOffset ("_MainTex", offset);
//		}
//		else if (time <= 0.5f) {
//			time = 2f;
//			Vector2 offset = new Vector2 (0f, 0f);
//			BirdMaterial.SetTextureOffset ("_MainTex", offset);
//		}

	}
	//重力激活函数
	public void ActiveGravity(){
		Rigidbody rigid = transform.GetComponent<Rigidbody> ();
		rigid.useGravity = true;
	}
	void OnCollisionEnter(Collision col){
		if (col.transform.tag.Equals ("pipe")) {
			//游戏结束
			//Debug.Log("zz");
			//只播放一次
			if(GameManager.Insance.gState != GameState.GameEnding){
				GameManager.Insance.PlayAudioClip (GameManager.Insance.aSource, AudioClipName.die);
			}
			GameManager.Insance.gState = GameState.GameEnding;
		}
		if (col.transform.tag.Equals ("back")) {
			//游戏结束
			//Debug.Log("zz");
			GameManager.Insance.gState = GameState.GameEnd;
			GameManager.Insance.PlayAudioClip (GameManager.Insance.aSource2, AudioClipName.hit);
			//transform.GetComponent<Rigidbody> ().freezeRotation= true;
			Destroy(gameObject,0.1f);
		}
	}
}
