using System.Collections;
using TMPro;
using UnityEngine;

public class StupidAttackjingEnemy : Health
{
    public TextMeshProUGUI text;
    public override void OnDamaged(int damage)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Health>() != null)
        {
               StartCoroutine(Damage(collision.GetComponent<Health>()));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            StopAllCoroutines();
        }
    }
    private IEnumerator Damage(Health player)
    {
        yield return new WaitForSeconds(1f);
        text.text = "go!";
        yield return new WaitForSeconds(0.25f);
        player.ApplyDamage(20);
        StartCoroutine(Clear());
        StartCoroutine(Damage(player));
        yield break;
    }
    private IEnumerator Clear()
    {
        yield return new WaitForSeconds(0.4f);
        text.text = "";
        yield break;
    }
}
