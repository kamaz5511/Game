using UnityEngine;

public class HiddenPlace : MonoBehaviour, IUsable
{
    private bool Hidden = false;
    public void Use()
    {
        Hide();
    }
    private void Hide()
    {
        Movement.Instance.GetComponent<SpriteRenderer>().enabled = Hidden;
        Hidden = !Hidden;
        if (Hidden)
        {
            Movement.Instance.Freeze();
            Movement.Instance.Physick.gravityScale = 0f;
        }
        else
        {
            Movement.Instance.UnFreeze();
            Movement.Instance.Physick.gravityScale = 1f;
        }
        Movement.Instance.GetComponent<Collider2D>().isTrigger = Hidden;
        Movement.Instance.Hidden = Hidden;
    }
}
