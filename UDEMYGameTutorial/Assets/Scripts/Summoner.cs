using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy {

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 targetPosition;

    Animator anim;

    public float stopDistance;

    private float attackTime;

    public float attackSpeed;


    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if(player != null) {

            if ((Vector2)transform.position != targetPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            } else {
                anim.SetBool("isRunning", false);
            }

            if (Vector2.Distance(transform.position, player.position) <= stopDistance)
            {
                if (Time.time >= attackTime)
                {
                    attackTime = Time.time + timeBetweenAttacks;
                    StartCoroutine(Attack());
                }
            }



        }
    }

    IEnumerator Attack()
    {

        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0f;
        while (percent <= 1)
        {

            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, interpolation);
            yield return null;

        }

    }


}
