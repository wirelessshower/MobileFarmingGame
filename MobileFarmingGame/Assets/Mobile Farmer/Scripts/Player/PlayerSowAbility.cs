using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class PlayerSowAbility : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private PlayerAnimator playerAnimator;


    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CropField"))
            playerAnimator.PlaySowAnimation();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CropField"))
            playerAnimator.StopSowAnimation();
    }
}
