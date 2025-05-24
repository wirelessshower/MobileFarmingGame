using UnityEngine;
using System;

public class CropTile : MonoBehaviour
{
    private TileFieldState state;

    [Header("Elements")]
    [SerializeField] private Transform cropParent;
    [SerializeField] private MeshRenderer tileRenderer;
    private Crop crop;
    private CropData CropData;

    [Header("Events")]
    public static Action<CropType> onCropHarvested;

    void Start()
    {
        state = TileFieldState.Empty;
    }

    public void Sow(CropData cropData)
    {
        state = TileFieldState.Sown;
        crop = Instantiate(cropData.cropPrefub, transform.position, Quaternion.identity, cropParent);

        this.CropData = cropData;
    }

   public void Water(){
        state = TileFieldState.Watered;
        //tileRenderer.material.color = Color.white * .3f;

        tileRenderer.gameObject.LeanColor(Color.white * .3f, 1);

        crop.ScaleUp();
   }

    public void Harvest()
    {
        state = TileFieldState.Empty;

        crop.ScaleDown();
        tileRenderer.gameObject.LeanColor(Color.white, 1);
        onCropHarvested?.Invoke(CropData.cropType);
    }

    public bool IsEmpty()
    {
        return state == TileFieldState.Empty;
    }

    public bool IsSown(){
        return state == TileFieldState.Sown;    
    }
}
