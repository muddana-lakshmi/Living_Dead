using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int speed,score,jumpSpeed,runspeed;
    public Text scoreText,TimerText,HealthText;
    float timee;
    public Animator Anime;
    public GameObject Arrow;
    float health=100f;
    public Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        Anime = GetComponent<Animator>();
        score=0;
        timee=00;
        health=100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health==0)
        {
            Destroy(gameObject);
        }
        if(health>90)
        {
            GetComponent<SpriteRenderer>().color=Color.white;
        }
        HealthText.text=health.ToString()+"%";
        timee += Time.deltaTime;
        TimerText.text="Time : "+Mathf.Round(timee).ToString();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += new Vector3(2, 0, 0);
            transform.Translate(new Vector3(0.1f * speed * Time.deltaTime, 0));
            //Cam.transform.Translate(new Vector3(0.1f * speed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX = false;
            Anime.SetBool("Idle", false);
            Anime.SetBool("Walk", true);
            Anime.SetBool("Run", false);
            Anime.SetBool("Jump", false);
            Anime.SetBool("Attack", false);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //transform.position += new Vector3(2, 0, 0);
            transform.Translate(new Vector3(0.1f * speed * Time.deltaTime, 0));
            //Cam.transform.Translate(new Vector3(0.1f * speed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX = false;
            Anime.SetBool("Idle", true);
            Anime.SetBool("Walk", false);
            Anime.SetBool("Run", false);
            Anime.SetBool("Jump", false);
             Anime.SetBool("Attack", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //transform.position += new Vector3(2, 0, 0);
            transform.Translate(new Vector3(-0.1f * speed * Time.deltaTime, 0));
            //Cam.transform.Translate(new Vector3(-0.1f * speed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX = true;
            Anime.SetBool("Idle", true);
            Anime.SetBool("Walk", false);
            Anime.SetBool("Run", false);
            Anime.SetBool("Jump", false);
             Anime.SetBool("Attack", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.1f * speed * Time.deltaTime, 0));
            //Cam.transform.Translate(new Vector3(-0.1f * speed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX = true;
            Anime.SetBool("Walk", true);
            Anime.SetBool("Idle", false);
            Anime.SetBool("Run", false);
            Anime.SetBool("Jump", false);
             Anime.SetBool("Attack", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;
            SourceHandler.playtheAudio("Jump");
            Anime.SetBool("Idle", false);
            Anime.SetBool("Walk", false);
            Anime.SetBool("Jump", true);
            Anime.SetBool("Run", false);
             Anime.SetBool("Attack", false);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;
            Anime.SetBool("Idle", false);
            Anime.SetBool("Walk", false);
            Anime.SetBool("Jump", true);
            Anime.SetBool("Run", false);
             Anime.SetBool("Attack", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-0.1f * runspeed * Time.deltaTime, 0));
                Anime.SetBool("Idle", false);
                Anime.SetBool("Walk", false);
                Anime.SetBool("Jump", false);
                Anime.SetBool("Run", true);
                 Anime.SetBool("Attack", false);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-0.1f * runspeed * Time.deltaTime, 0));
                Anime.SetBool("Idle", false);
                Anime.SetBool("Walk", false);
                Anime.SetBool("Jump", false);
                Anime.SetBool("Run", true);
                 Anime.SetBool("Attack", false);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(0.1f * runspeed * Time.deltaTime, 0));
                Anime.SetBool("Idle", false);
                Anime.SetBool("Walk", false);
                Anime.SetBool("Jump", false);
                Anime.SetBool("Run", true);
                 Anime.SetBool("Attack", false);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(0.1f * runspeed * Time.deltaTime, 0));
                Anime.SetBool("Idle", false);
                Anime.SetBool("Walk", false);
                Anime.SetBool("Jump", false);
                Anime.SetBool("Run", true);
                 Anime.SetBool("Attack", false);
            }
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            if(GetComponent<SpriteRenderer>().flipX == false)
            {
                SourceHandler.playtheAudio("Arrow");
                 Anime.SetBool("Idle", false);
                Anime.SetBool("Walk", false);
                Anime.SetBool("Jump", false);
                Anime.SetBool("Run", false);
                 Anime.SetBool("Attack", true);
                 GameObject instBullet=Instantiate(Arrow,new Vector2(transform.position.x+0.4f,transform.position.y), Quaternion.identity);
                instBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(200*100*Time.deltaTime,0));
            }
            else{
                GameObject instBullet=Instantiate(Arrow,new Vector2(transform.position.x-0.4f,transform.position.y), Quaternion.identity);
                instBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200*100*Time.deltaTime,0));
                Anime.SetBool("Idle", false);
                Anime.SetBool("Walk", false);
                Anime.SetBool("Jump", false);
                Anime.SetBool("Run", false);
                 Anime.SetBool("Attack", true);
            }
        }
        if(Input.GetKeyUp(KeyCode.G))
        {
            if(GetComponent<SpriteRenderer>().flipX == false)
            {
                 Anime.SetBool("Idle", true);
                Anime.SetBool("Walk", false);
                Anime.SetBool("Jump", false);
                Anime.SetBool("Run", false);
                 Anime.SetBool("Attack",false);
            }
            else{
                Anime.SetBool("Walk", false);
                Anime.SetBool("Jump", false);
                Anime.SetBool("Run", false);
                 Anime.SetBool("Attack", false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            SourceHandler.playtheAudio("Enemy");
            Debug.Log("Touched");
            health-=10;
            healthbar.fillAmount=health/100;
            HealthText.text=health.ToString()+"%";
            GetComponent<SpriteRenderer>().color=Color.green;
            score+=1;
            scoreText.text="Score :"+score;
        }
        if(collision.gameObject.CompareTag("MovingTile"))
        {
            transform.parent=collision.gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("MovingTile"))
        {
            transform.parent=null;
        }
        if(other.gameObject.CompareTag("Enemy") && health>90)
        {
            GetComponent<SpriteRenderer>().color=Color.white;
        }
    }
    private void OnTriggerEnter2D(Collider2D tou)
    {
        if (tou.gameObject.tag=="Sprite")
        {
            SourceHandler.playtheAudio("Sprite");
            if(health<100)
            {
            health+=5;
            healthbar.fillAmount=health/100;
            HealthText.text=health.ToString()+"%";
            }
            score+=1;
            scoreText.text="Score :"+score;
             Destroy(tou.gameObject);
            
        }
        if (tou.gameObject.tag=="Burger")
        {
            SourceHandler.playtheAudio("Burger");
            if(health<100)
            {
            health+=10;
            healthbar.fillAmount=health/100;
            HealthText.text=health.ToString()+"%";
            }
            score+=5;
            scoreText.text="Score :"+score;
             Destroy(tou.gameObject);
        }
    }
}
