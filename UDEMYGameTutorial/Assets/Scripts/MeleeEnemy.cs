using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{

    public float stopDistance;
    public float meleeAttackSpeed;

    float timer;

    void Update()
    {
        if (player != null)
        {
            
        

        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
        else
        {

            if (Time.time > timer)
            {
                timer = Time.time + timeBetweenAttacks;
                StartCoroutine(MeleeAttack());
            }

        }

        }

    }

    IEnumerator MeleeAttack()
    {

        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPos = transform.position;
        Vector2 targetPos = player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * meleeAttackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPos, targetPos, interpolation);
            yield return null;
        }

    }


}
