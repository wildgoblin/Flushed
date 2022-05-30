using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAi : MonoBehaviour
{
    //references
    Rigidbody2D rb2D;

    [SerializeField] float speed = 1;

    [SerializeField] Fish fish;
    [SerializeField] int characterIndex;


    Vector3 destination;

    Vector3 start;

    Vector3 boundries;

    float time;
    float interval;

    bool cutscene;
    bool death;

    [SerializeField] AudioClip toiletFlushSound;
    [SerializeField] AudioClip deadFishSound;
    [SerializeField] AudioClip fishInToiletSound;


    private void Awake()
    {
        boundries = GetComponent<BoxCollider2D>().size;        
    }

    private void Start()
    {
        GetNewTarget();
    }



    void Update()
    {
        if(!cutscene)
        {
            Movement();
        }
        if(death)
        {
            CutsceneDeath();
        }

    }

 

    private void Movement()
    {
        if (destination != null)
        {
            
            if (time < interval)
            {
                time += Time.deltaTime * speed;
                fish.transform.position = Vector3.Lerp(start, destination, time);
                ChangeFacingDirection();
            }
            else
            {
                time = Time.deltaTime * speed;
                GetNewTarget();
            }
        }
    }

    private void ChangeFacingDirection()
    {
        //Assumes Sprite is facing left by default
        if (start.x < destination.x)
        {
            fish.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (start.x > destination.x)
        {
            fish.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void GetNewTarget()
    {
        interval = Random.Range(.5f, 1.5f);
        start = fish.transform.position;
        destination = this.transform.position + new Vector3(Random.Range(-boundries.x, boundries.x), Random.Range(-boundries.y, boundries.y));
    }

    public void StartCutscene()
    {
        cutscene = true;
        StartCoroutine(Cutscene());
    }

    IEnumerator Cutscene()
    {

        //Flip fish upside down
        //fish.GetComponent<SpriteRenderer>().flipY = true;
        fish.ChangeToDeadFish();
        //Float Upwards
        death = true;
        AudioSource.PlayClipAtPoint(deadFishSound, Camera.main.transform.position);
        yield return new WaitForSeconds(5);
        Camera.main.backgroundColor = Color.black;
        Camera.main.transform.position = new Vector3(0, 0, 0);

        StartCoroutine(ToiletFlush());


        IEnumerator ToiletFlush()
        {
            AudioSource audioOnGameManager = GameManager.instance.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(fishInToiletSound, Camera.main.transform.position);
            MusicManager.instance.ToggleMute();
            yield return new WaitForSeconds(0.5f);
            //Play clip over to next scene
            audioOnGameManager.clip = toiletFlushSound;
            audioOnGameManager.Play();

            GameManager.instance.UpdateFishCharacterSelectIndex(characterIndex);

            StartCoroutine(LoadNextScene());
        }

        IEnumerator LoadNextScene()
        {
            
            yield return new WaitForSeconds(5);
            
            GameManager.instance.NextScene();

        }
    }
    private void CutsceneDeath()
    {
        float fraction = Time.deltaTime * 0.2f;
        Vector3 floatDestination = new Vector2(fish.transform.position.x, fish.transform.position.y + 1);
        if (fraction < 1)
        {
            fraction += Time.deltaTime * 0.01f;
            fish.transform.position = Vector3.Lerp(fish.transform.position, floatDestination, fraction);
        }
    }

}
