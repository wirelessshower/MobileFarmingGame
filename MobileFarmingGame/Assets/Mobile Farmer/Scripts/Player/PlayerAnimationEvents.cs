using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private ParticleSystem seedParticles;
    [SerializeField] private ParticleSystem waterParticles;

    private void PlaySeedParticles()
    {
        seedParticles.Play();
    }

    private void PlayWaterParticles()
    {
        waterParticles.Play();
    }
}
