using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material newMaterial; // Novo material a ser aplicado
    public GameObject[] landObjects; // Array para armazenar os objetos de "land"
    public AudioClip changeMaterialSound; // Áudio que será tocado
    private AudioSource audioSource; // Referência para o AudioSource

    private float[] landTimers; // Temporizadores para cada land
    private bool[] landChanged; // Controle de alteração de material para cada land

    private void Start()
    {
        // Inicializa o AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Adiciona se não houver
        }

        // Inicializa os arrays de temporizadores e controle de mudança
        landTimers = new float[landObjects.Length];
        landChanged = new bool[landObjects.Length];
    }

    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < landObjects.Length; i++)
        {
            if (other.gameObject == landObjects[i] && !landChanged[i])
            {
                landTimers[i] += Time.deltaTime;
                if (landTimers[i] >= 4f)
                {
                    ChangeMaterial(landObjects[i], i);
                    landChanged[i] = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < landObjects.Length; i++)
        {
            if (other.gameObject == landObjects[i])
            {
                landTimers[i] = 0f; // Reseta o tempo se o cubo sair
            }
        }
    }

    private void ChangeMaterial(GameObject obj, int index)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        if (objRenderer != null && newMaterial != null)
        {
            objRenderer.material = newMaterial;
            PlayChangeSound(); // Toca o som quando mudar o material
        }
    }

    private void PlayChangeSound()
    {
        if (changeMaterialSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(changeMaterialSound); // Reproduz o som uma vez
        }
    }
}
