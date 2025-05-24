using UnityEngine;

public class PlayerCropInteractor : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Material[] materials;

    void Update()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetVector("_PlayerPosition", transform.position);
        }
    }
}