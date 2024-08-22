using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private int HP = 100;
    public Animator animator;
    public Slider HPBar;


    void Update()
    {
        HPBar.value = HP;
    }
    public void TakeDamage (int DamageAmout) 
    { 
    HP -= DamageAmout;
        if (HP <= 0) 
        {
            animator.SetTrigger("death");
            GetComponent<Collider>().enabled = false;
            HPBar.gameObject.SetActive(false);
        }
    }
}
