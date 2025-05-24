using System;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerWaterAbility : MonoBehaviour
{

    [Header("Elements")]
    private PlayerAnimator playerAnimator;
    private PlayerToolSelector playerToolSelector;

    [Header("Settings")]
    private CropField currentCropField;


    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerToolSelector = GetComponent<PlayerToolSelector>();

        WaterParticles.onWaterColided += WaterCollidedCaback;
        CropField.onFullyWatered += CropFieldFullyWateredCallback;
        PlayerToolSelector.onToolSelected += ToolSelectedCallback;

    }

    void OnDestroy()
    {
        WaterParticles.onWaterColided -= WaterCollidedCaback;
        CropField.onFullyWatered -= CropFieldFullyWateredCallback;
        PlayerToolSelector.onToolSelected -= ToolSelectedCallback;
    }


    private void ToolSelectedCallback(PlayerToolSelector.Tool selectedTool)
    {
        if (!playerToolSelector.CanSow())
            playerAnimator.StopWaterAnimation();
    }

    private void WaterCollidedCaback(Vector3[] waterPosition)
    {
        if (currentCropField == null)
            return;

        currentCropField.WaterColidedCallback(waterPosition);
    }

    private void CropFieldFullyWateredCallback(CropField cropField)
    {
        if (currentCropField == cropField)
            playerAnimator.StopWaterAnimation();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsSown())
        {
            currentCropField = other.GetComponent<CropField>();
            EnterCropField(currentCropField);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsSown())
            EnterCropField(other.GetComponent<CropField>());
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CropField"))
        {
            playerAnimator.StopWaterAnimation();
            currentCropField = null;
        }
    }

    private void EnterCropField(CropField cropField)
    {
        if (playerToolSelector.CanWater())
        {
            if (currentCropField == null)
                currentCropField = cropField;

            playerAnimator.PlayWaterAnimation();
        }
    }

    
   
}
