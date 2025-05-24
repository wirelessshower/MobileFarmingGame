using UnityEngine;

public class Crop : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform cropRenderer;
    [SerializeField] private ParticleSystem harvestedParticles;

    public void ScaleUp()
    {
        cropRenderer.gameObject.LeanScale(Vector3.one, 1).setEase(LeanTweenType.easeOutBack);
    }
    public void ScaleDown()
    {
        cropRenderer.gameObject.LeanScale(Vector3.zero, 1).
        setEase(LeanTweenType.easeOutBack).setOnComplete(() => Destroy(gameObject));

        harvestedParticles.gameObject.SetActive(true);
        harvestedParticles.transform.parent = null;
        harvestedParticles.Play();
    }
}
