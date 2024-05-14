using System.Collections;
using TMPro;
using UnityEngine;

public class PunchingBag : Health
{
    public TextMeshProUGUI text;

    public override void OnDamaged(int damage)
    {
        text.text =  "-" + damage.ToString();
        StartCoroutine(Clear());
    }
    private IEnumerator Clear()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
        yield break;
    }
}
