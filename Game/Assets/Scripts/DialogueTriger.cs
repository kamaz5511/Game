using UnityEngine;

public class DialogueTriger : MonoBehaviour,IUsable
{
    public Dialogue _dialogue;
    [SerializeField] private bool DialogByButton = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>() != null && !DialogByButton)
        {
            Debug.Log("fasdfs");
            StartDialogue();
        }
    }
    private void StartDialogue()
    {
        FindObjectOfType<DialogueManager>()?.StartDialogue(_dialogue);
    }

    public void Use()
    {
        if(!_dialogue.Started)StartDialogue();
    }
}
