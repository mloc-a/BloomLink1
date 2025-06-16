using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderCanController : MonoBehaviour
{
    public ParticleSystem powderEffect; // Arrasta o Particle System no Inspector
    public AudioSource powderSound; // Arrasta o AudioSource com o som de poeira
    public float tiltMin = -78f; // Limite inferior do intervalo de inclinação
    public float tiltMax = -45f; // Limite superior do intervalo de inclinação

    void Start()
    {
        if (powderEffect != null)
        {
            powderEffect.Stop(); // Garante que a poeira esteja desligada no início
        }

         if (powderSound != null)
        {
            powderSound.Stop(); // Garante que o som da poeira esteja desligado no início
        }
    }

    void Update()
    {
        if (powderEffect == null) return; // Evita erro se não houver efeito atribuído

        // Obtém a rotação do recipiente no eixo Z
        float currentZRotation = transform.eulerAngles.z;

        // Corrigir valores de rotação para evitar problemas com ângulos acima de 180°
        if (currentZRotation > 180f)
        {
            currentZRotation -= 360f;
        }

        // Ativa ou desativa o efeito de poeira se a rotação estiver dentro do intervalo
        if (currentZRotation >= tiltMin && currentZRotation <= tiltMax)
        {
            if (!powderEffect.isPlaying)
            {
                Debug.Log("Ativando poeira! Rotação Z = " + currentZRotation);
                powderEffect.Play();

                 if (!powderSound.isPlaying) // Reproduz o som se não estiver tocando
                {
                    powderSound.Play();
                }
            }
        }
        else
        {
            if (powderEffect.isPlaying)
            {
                Debug.Log("Parando poeira! Rotação Z = " + currentZRotation);
                powderEffect.Stop();
            }

            if (powderSound.isPlaying) // Para o som se a poeira parar
                {
                    powderSound.Stop();
                }
        }
    }
}
