using System;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerSowAbility : MonoBehaviour
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

        SeedParticles.onSeedsColided += SeedsCollidedCallback;
        CropField.onFullySown += CropFieldFullySownCallback;
        PlayerToolSelector.onToolSelected += ToolSelectedCallback;

    }    

    void OnDestroy()
    {
        SeedParticles.onSeedsColided -= SeedsCollidedCallback;        
        CropField.onFullySown -= CropFieldFullySownCallback;
        PlayerToolSelector.onToolSelected -= ToolSelectedCallback;
    }


    private void ToolSelectedCallback(PlayerToolSelector.Tool selectedTool)
    {
        if(!playerToolSelector.CanSow())
            playerAnimator.StopSowAnimation();
    }

    private void SeedsCollidedCallback(Vector3[] seedPositions)
    {
        if(currentCropField == null)
            return;

        currentCropField.SeedsCollidedCallBack(seedPositions);
    }

    private void CropFieldFullySownCallback(CropField cropField)
    {
        if(currentCropField == cropField)
            playerAnimator.StopSowAnimation();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CropField") && other.GetComponent<CropField>().IsEmpty() ){
            currentCropField = other.GetComponent<CropField>();
            EnterCropField(currentCropField);
            
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsEmpty()){
            currentCropField = other.GetComponent<CropField>();
            EnterCropField(currentCropField);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CropField")){
            playerAnimator.StopSowAnimation();
            currentCropField = null;
        }
    }

    private void EnterCropField(CropField cropField)
    {        
        if(playerToolSelector.CanSow())
            playerAnimator.PlaySowAnimation();
    }
   
}
