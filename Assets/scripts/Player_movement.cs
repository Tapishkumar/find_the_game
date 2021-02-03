using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float Player_Speed = 5;
    public float Player_Jump_force = 5;
    public bool Is_Ground = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Transformation_player();
        Rotation_of_player();
        jump();
        emote();
        emote2();

        Vector3 movment = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += movment * Player_Speed * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(movment.x));
        
    }
    public void jump()
    {
        if (Input.GetButtonUp("Jump") && Is_Ground == true)
        {
            Rotation_of_player();
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Player_Jump_force), ForceMode2D.Impulse);
            Is_Ground = false;
            animator.SetBool("Is_ground", true);
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        Is_Ground = true;
        Rotation_of_player();
        animator.SetBool("Is_ground", false);
    }
    public void Rotation_of_player()
    {
        Quaternion therotion = transform.localRotation;
        therotion.x = 0;
        therotion.y = 0;
        therotion.z = 0;
        transform.Rotate(Vector3.zero* 0);
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void Transformation_player()
    {
        Vector3 flip_the_charator = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            flip_the_charator.x = -0.6504115f;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            flip_the_charator.x = 0.6504115f;
        }
        transform.localScale = flip_the_charator;
    }
    public void emote()
    {
        if (Input.GetKey(KeyCode.E) && Is_Ground == true)
        {
            animator.SetTrigger("emote_1");
        }
    }
    public void emote2()
    {
        if (Input.GetKey(KeyCode.Q) && Is_Ground == true)
        {
            animator.SetTrigger("emote_2");
        }
    }
     void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("spiks"))
        {

           
             
                GetComponent<player>().Damageplayer(999999);
            
        }
    }
}
