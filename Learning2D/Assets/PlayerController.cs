using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f; // �̵��ӵ�

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool goJump = false;
    bool onGround = false;

    Animator animator;
    public string stopAnime = "PlayerStop";
    public string moveAnime = "Playermove";
    public string jumpAnime = "PlayerJump";
    public string goalAnime = "PlayerGoal";
    public string deadAnime = "PlayerOver";
    string nowAnime = "";
    string oldAnime = "";

    public static string gameState = "playing";

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        nowAnime = stopAnime;
        oldAnime = stopAnime;
        gameState = "playing";
    }

    void Update()
    {
        if (gameState != "playing")
        {
            return;
        }
        axisH = Input.GetAxisRaw("Horizontal");
        if (axisH > 0.0f)
        {
            Debug.Log("������ �̵�");
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (axisH < 0.0f)
        {
            Debug.Log("���� �̵�");
            transform.localScale = new Vector2(-1f, 1f);
        }
        if  (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }
        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);
        if (onGround || axisH != 0)
        { rbody.velocity = new Vector2(speed * axisH, rbody.velocity.y); }
        if (onGround && goJump)
        {
            Debug.Log(" ����! ");
            Vector2 jumpPw = new Vector2(0, jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }
        if (onGround)
        {
            if (axisH == 0)
            { nowAnime = stopAnime; }
            else
            { nowAnime = moveAnime; }
        }
        else
        { nowAnime = jumpAnime; }

        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);
        }
        
    }

    public void Jump()
    {
        goJump = true;
        Debug.Log("���� ��ư ����!");
        animator.Play(jumpAnime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag == "Dead")
        {
            GameOver();
        }
    }
    public void Goal()
    {
        animator.Play(goalAnime);
        gameState = "GameClear";
        GameStop();
    }
    public void GameOver()
    {
        animator.Play(deadAnime);
        gameState = "GameOver";
        GameStop();
        //=================
        //���� ��������
        //=================
        //�÷��̾��� �浹���� ��Ȱ��
        GetComponent<CapsuleCollider2D>().enabled = false;
        //�÷��̾ ���� Ƣ������� �ϴ� ����
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

    }
    //��������
    void GameStop()
    {
        //Rigidbody 2D ��������
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        //�ӵ��� 0���� �Ͽ� ���� ����
        rbody.velocity = new Vector2(0, 0) ;
    }

       
    }


