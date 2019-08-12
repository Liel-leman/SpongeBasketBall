using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
public class ShootScript : MonoBehaviour {

    public Dialog dialog;
    public VoiceDialog dialogV2;
    public AudioClip[] clips;
	public float power=2.0f;
	public float deadSense=25f;
	public int dots=30;
	private Vector2 startPosition;
	private bool shoot=false,aiming=false,hitground=false, hitNet = false;
	private GameObject Dots;
	private List<GameObject>Path;
	private Rigidbody2D rb;
	private Collider2D coll;


    //new

    public BallInstantiation ballInstantiation;
    private AudioSource audioSrc;
    private Animator anim;
    private GameSession gameSession;
    // Use this for initialization
    void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		coll= GetComponent<Collider2D> ();
	}
	void Start () {
        audioSrc= GetComponent<AudioSource>();
        float volume = PlayerPrefsManager.GetSFX();
        audioSrc.volume = volume;
        gameSession = FindObjectOfType<GameSession>();
        ballInstantiation = FindObjectOfType<BallInstantiation>().GetComponent<BallInstantiation>();
        dialog = FindObjectOfType<Dialog>();
        if (!dialog)
        {
            dialogV2 = FindObjectOfType<VoiceDialog>();
            Debug.Log("cant find dialog using dialog v2");
        }
        anim = GetComponent<Animator>();
        Dots = GameObject.Find ("dots");
		rb.isKinematic=(true);
		coll.enabled = false;
		startPosition = transform.position;
		Path = Dots.transform.Cast<Transform> ().ToList ().ConvertAll (t=>t.gameObject);//Convert children in game
		for( int i =0; i<Path.Count;i++)
		{
			Path [i].GetComponent<Renderer> ().enabled = false;
		}
	}
	// Update is called once per frame
	void Update () {
		Aim ();
		if (hitground) 
		{
            anim.SetTrigger("TouchFloor");

            // Application.LoadLevel ("02 Level_01");
        }
	}
	void Aim () {
		if (shoot)
			return;
		if (Input.GetAxis ("Fire1") == 1){
			if (!aiming) {
				aiming = true;
				startPosition = Input.mousePosition;
				CalculatepATH ();
				ShowPath ();
			} else {
				CalculatepATH ();
			}
		}
        else if(aiming &&!shoot){
			if(indeadzone(Input.mousePosition)||Inrelease(Input.mousePosition)){
				aiming = false;
				HidePath ();
				return;
			}
			rb.isKinematic = false;
			coll.enabled = true;
			shoot = true;
			aiming = false;
			rb.AddForce(OttieniForza(Input.mousePosition));
			HidePath ();
		}
	}
	Vector2 OttieniForza(Vector3 mouse)
	{
		return(new Vector2(startPosition.x,startPosition.y)-new Vector2(mouse.x,mouse.y))*power;
	}
	bool indeadzone(Vector2 mouse)
	{
		if(Mathf.Abs(startPosition.x-mouse.x)<=deadSense&&Mathf.Abs(startPosition.x-mouse.x)<=deadSense){
			return true;
		}else{
			return false;
		}
	}
	Vector2 PathPoint(Vector2 startP ,Vector2  vel , float t)
	{
		return startP + vel * t + 0.5f * Physics2D.gravity*t*t;
	}
	bool Inrelease(Vector2 mouse)
	{
		if(mouse.x<=70){
			return true;
		}else{
			return false;
		}
	}
	void CalculatepATH() {
		Vector2 vel = OttieniForza (Input.mousePosition) * Time.fixedDeltaTime / rb.mass;
		for(int i=0; i<Path.Count;i++)
			{
			Path [i].GetComponent<Renderer> ().enabled = true;
			float t = i / 30f;
			Vector3 point = PathPoint (transform.position, vel, t);
			point.z = 1.0f;
			Path [i].transform.position = point;
		}
	}
	void HidePath() {
		for( int i =0; i<Path.Count;i++)
		{
			Path [i].GetComponent<Renderer> ().enabled = false;
		}
	}
	void ShowPath() {
		for( int i =0; i<Path.Count;i++)
		{
			Path [i].GetComponent<Renderer> ().enabled = true;
		}
	}

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            audioSrc.PlayOneShot(clips[Random.Range(1, 3)]);//bounce sound 1,2
            hitground = true;

        }
        if (target.gameObject.tag == "Canestro" || target.gameObject.tag == "Ram" || target.gameObject.tag == "Ram")
        {
            audioSrc.PlayOneShot(clips[Random.Range(3, 5)]);//ram,canestro sound 3,4

        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Net")
        {
            Debug.Log("Goal");
            audioSrc.PlayOneShot(clips[0]);//net hit sound 0 
            
            if (hitNet==false)//before it set the bool of hitNet to TRUE it will add the score (in tearm to reduce duplication)
            {
                audioSrc.PlayOneShot(clips[5]);//sound - "yeyy!"
                gameSession.AddToScore();
                if (dialog)
                    dialog.NextSentense();
                else
                    dialogV2.NextSentense();//for lvl 3
            }
            hitNet = true;
            
        }
        if (target.gameObject.tag == "Wall")
        {
            hitground = true;
        }
    }
    void Destroyball()
    {
       // if(hitground == true && hitNet == false)
       // {
            ballInstantiation.ins();
       // }
        Destroy(gameObject);

    }
    void HealthUpdate()
    {
        Debug.Log("update health - from animator");
        if (hitNet == false)// if it doesnt hit the Net
        {
            gameSession.UpdateHealth(-1);
            audioSrc.PlayOneShot(clips[6]);// "aw no!" sound 
        }
    }
}

