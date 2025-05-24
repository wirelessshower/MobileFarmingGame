using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimationEvents : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private ParticleSystem seedParticles;
    [SerializeField] private ParticleSystem waterParticles;


    [Header("Events")]
    [SerializeField] private UnityEvent StartHarvestingEvent;
    [SerializeField] private UnityEvent StopHarvestingEvent;

    

    private void PlaySeedParticles()
    {
        seedParticles.Play();
    }

    private void PlayWaterParticles()
    {
        waterParticles.Play();
    }
    
    private void StartHarvestingCallback()
    {
        StartHarvestingEvent?.Invoke();        
    }

    private void StopHarvestingCallback()
    {   
        StopHarvestingEvent?.Invoke();        
    }
}
