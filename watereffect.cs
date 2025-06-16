using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCanController : MonoBehaviour
{
    public ParticleSystem waterEffect; // Arrasta o Particle System no Inspector
     public AudioSource waterSound; // Arrasta o AudioSource com o som da água
    public float tiltThreshold = -78f; // Ângulo de inclinação para ativar a água

    void Start()
    {
        if (waterEffect != null)
        {
            waterEffect.Stop(); // Garante que a água esteja desligada no início
        }
        
        if (waterSound != null)
        {
            waterSound.Stop(); // Garante que o som da água esteja desligado no início
        }
    }

    void Update()
    {
        if (waterEffect == null) return; // Evita erro se não houver efeito atribuído

        // Obtém a rotação do regador no eixo Z
        float currentZRotation = transform.eulerAngles.z;

        // Corrigir valores de rotação para evitar problemas com ângulos acima de 180°
        if (currentZRotation > 180f)
        {
            currentZRotation -= 360f;
        }

        // Ativa ou desativa a água dependendo da inclinação
        if (currentZRotation < tiltThreshold)
        {
            if (!waterEffect.isPlaying)
            {
                Debug.Log("Ativando água! Rotação Z = " + currentZRotation);
                waterEffect.Play();
            }

              if (!waterSound.isPlaying) // Reproduz o som se não estiver tocando
                {
                    waterSound.Play();
                }
        }
        else
        {
            if (waterEffect.isPlaying)
            {
                Debug.Log("Parando água! Rotação Z = " + currentZRotation);
                waterEffect.Stop();
            

                if (waterSound.isPlaying) // Para o som se a água parar
                {
                    waterSound.Stop();
                }
            }
        }
    }
}
