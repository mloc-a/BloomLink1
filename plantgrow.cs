using UnityEngine;

public class SeedGrowth : MonoBehaviour
{
    public GameObject rebento; // Objeto que deve aparecer
    public GameObject[] landObjects; // Objetos com os quais o cubo vai interagir
    private float[] landTimers; // Temporizadores para cada land
    private bool[] landTouched; // Controle de interação de cada land

    public AudioClip audioClip; // Áudio que será tocado
    private AudioSource audioSource; // Componente de áudio

    private void Start()
    {
        // Inicializa os arrays de temporizadores e controle de interação
        landTimers = new float[landObjects.Length];
        landTouched = new bool[landObjects.Length];

        // Inicialmente desativa o rebento
        if (rebento != null)
        {
            rebento.SetActive(false);
        }

        // Adiciona o componente AudioSource se não existir
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < landObjects.Length; i++)
        {
            // Verifica se o cubo colidiu com algum dos objetos da lista landObjects
            if (other.gameObject == landObjects[i] && !landTouched[i])
            {
                landTimers[i] += Time.deltaTime; // Incrementa o tempo de toque

                if (landTimers[i] >= 4f) // Se o tempo for 4 segundos ou mais
                {
                    ShowRebento(); // Torna o rebento visível
                    PlayAudio(); // Toca o áudio
                    landTouched[i] = true; // Garante que o rebento só aparece uma vez
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < landObjects.Length; i++)
        {
            // Quando o cubo sair da colisão, reseta o tempo
            if (other.gameObject == landObjects[i])
            {
                landTimers[i] = 0f;
                landTouched[i] = false; // Reseta o estado de toque
            }
        }
    }

    private void ShowRebento()
    {
        // Torna o "rebento" visível se ele estiver desativado
        if (rebento != null)
        {
            rebento.SetActive(true); // Torna o rebento visível
        }
    }

    private void PlayAudio()
    {
        // Se o áudio não estiver tocando, começa a reprodução
        if (audioSource != null && audioClip != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip); // Toca o áudio uma vez
        }
    }
}
