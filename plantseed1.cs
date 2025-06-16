using UnityEngine;

public class PlayAudioOnCollision : MonoBehaviour
{
    public AudioSource audioSource;  // Arrasta o AudioSource no Inspector
    public GameObject targetObject;  // Define o objeto no Inspector

    private void OnTriggerEnter(Collider other) // Muda de OnCollisionEnter para OnTriggerEnter
    {
        if (other.gameObject == targetObject)
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}