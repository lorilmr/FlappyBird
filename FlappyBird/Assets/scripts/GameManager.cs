using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//定义游戏状态
public enum GameState{
	GameMenu,
	GamePlaying,
	GameEnding,
	GameEnd,
}
//定义声音类型
public enum AudioClipName{
	wing,
	hit,
	die,
	point,
}
public class GameManager : MonoBehaviour {
	public static GameManager Insance;
	public GameState gState;
	//音效
	public AudioSource aSource;
	public AudioSource aSource1;
	public AudioSource aSource2;
	public AudioClip[] aClips;
	//背景移动
	public Transform firstTrans;
	//UI
	public Button BtnStart;
	public Button BtnQuit;
	public Button BtnReStart;
	public GameObject tapImg;
	public Text CurrentScoreText1;
	public Text MaxScoreText1;
	//鸟
	public GameObject birdPrefab;
	//重置背景板
	private Transform BG;
	private Transform BG1;
	private Transform BG2;
	//分数
	public Text CurrentScoreText;
	public Text MaxScoreText;
	private int currentScore;
	private int MaxValue;
	// Use this for initialization
	void Start () {
		gState = GameState.GameMenu;
		Insance = this;
		//监听
		BtnStart.onClick.AddListener(BtnStartClick);
		BtnQuit.onClick.AddListener(BtnQuitClick);
		BtnReStart.onClick.AddListener(BtnReStartClick);
		//找到鸟
		BG = GameObject.FindGameObjectWithTag("BG").transform;
		BG1 = GameObject.FindGameObjectWithTag("BG1").transform;
		BG2 = GameObject.FindGameObjectWithTag("BG2").transform;
		//最高分数
		MaxValue=PlayerPrefs.GetInt("MaxScore");
		MaxScoreText.text = MaxValue.ToString ();
	}
	//计数器
	public void AddScore(int score){
		currentScore += score;
		CurrentScoreText.text = currentScore.ToString ();
		if(currentScore>MaxValue){
			MaxValue = currentScore;
			PlayerPrefs.SetInt ("MaxScore",MaxValue);//存储最高分
			MaxScoreText.text = MaxValue.ToString ();
		}
	}
	// Update is called once per frame
	void Update () {
		if(gState==GameState.GameEnd){
			//设置死亡界面的分数
			CurrentScoreText1.text = currentScore.ToString ();
			MaxScoreText1.text = MaxValue.ToString ();
			//打开END UI
				BtnReStart.transform.parent.gameObject.SetActive (true);
		}
		if (gState == GameState.GameMenu) {
			//打开开始菜单
			BtnStart.transform.parent.gameObject.SetActive (true);
		}
	}
	//开始按钮
	public void BtnStartClick(){
		//改变游戏状态
		gState = GameState.GamePlaying;
		//关闭UI界面
		BtnStart.transform.parent.gameObject.SetActive (false);
		//打开tap
		tapImg.SetActive(true);
		//积分
		currentScore=0;
	}
	public void BtnQuitClick(){
		Application.Quit ();
	}
	//重新开始按钮
	public void BtnReStartClick(){
		//Debug.Log (Quaternion.identity);
		//重置背景板位置
		BG.position=new Vector3(0f,0f,0f);
		BG1.position=new Vector3(10f,0f,0f);
		BG2.position=new Vector3(20f,0f,0f);
		//关闭UI界面
		BtnReStart.transform.parent.gameObject.SetActive (false);
		//生成游戏玩家
		Instantiate(birdPrefab,birdPrefab.transform.position,birdPrefab.transform.rotation);
		//打开tap
		tapImg.SetActive(true);
		//重新积分
		currentScore=0;
		CurrentScoreText.text= currentScore.ToString ();
		//改变游戏状态
		gState = GameState.GamePlaying;
	}
	//播放音频
	public void PlayAudioClip(AudioSource aSource,AudioClipName clipName){
		aSource.clip = aClips [(int)clipName];
		aSource.Play ();
	}
}
