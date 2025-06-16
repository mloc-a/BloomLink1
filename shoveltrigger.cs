using UnityEngine;

public class ShowCoverSoil : MonoBehaviour
{
    public GameObject coverSoil;  // Arrasta "coversoil" aqui no Inspector
    public GameObject seed1;      // Arrasta "seed1" aqui
    public GameObject land3;      // Arrasta "land (3)" aqui
    public AudioSource audioSource; // Arrasta o componente AudioSource aqui

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == seed1 || other.gameObject == land3)
        {
            if (coverSoil != null)
            {
                coverSoil.SetActive(true);  // Faz "coversoil" aparecer
            }

            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();  // Toca o áudio
            }
        }
    }
}
