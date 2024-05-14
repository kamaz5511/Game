using UnityEngine;

public class DestroyingObjectToEnter : MonoBehaviour,IUsable
{
    [SerializeField] private ParticleSystem BreakParticle;
    [SerializeField] private Sprite BreakObject;
    [SerializeField] private Buildings _buildToEnter;
    private SpriteRenderer _spriteRenderer;
    private bool Broken = false;

    private void Start() => _spriteRenderer = GetComponent<SpriteRenderer>();
    public void Use()
    {
        if (!Broken)
        {
            //Play Sound For Broke and Animation
            BreakParticle.Play();
            _spriteRenderer.sprite = BreakObject;
            Broken = true;
        }
        else
        {
            _buildToEnter.EnterOnBuild();
        }
    }
}
