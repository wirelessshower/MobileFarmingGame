using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private ParticleSystem seedParticles;

    private void PlaySeedParticles()
    {
        seedParticles.Play();
    }
}
