using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    Animator animator;
    Rigidbody2D rb;
    int at = 1;
    [System.NonSerialized]
    public int currentHealth;//現在のHP
    public int maxHealth;//最大HP
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;//ゲーム開始時は体力満タン

        GameManager.instance.UpdateHealthUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("IsAttack");
        }
        Movement();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
    public void Attack()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            Debug.Log(hitEnemy.gameObject.name + "に攻撃");
            hitEnemy.GetComponent<EnemyManager>().OnDamage(at);
        }
    }
    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");//方向キーの横
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        animator.SetFloat("Speed", Mathf.Abs(x));
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
    }
}
