using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SeedParticles : MonoBehaviour
{
    public static Action<Vector3[]> onSeedsColided;

    void OnParticleCollision(GameObject other)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        int colisionAmount = ps.GetCollisionEvents(other, collisionEvents);

        Vector3[] collisionPositions = new Vector3[colisionAmount];

        for (int i = 0; i < colisionAmount; i++)
            collisionPositions[i] = collisionEvents[i].intersection;

        onSeedsColided?.Invoke(collisionPositions);        
    }
}
