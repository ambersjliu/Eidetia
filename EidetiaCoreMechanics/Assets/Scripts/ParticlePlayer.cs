using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    private Transform characterPosition;
    [SerializeField] private GameObject particlePrefab;
    // Start is called before the first frame update
    private void Start()
    {
        characterPosition = transform;
    }

    public void playEffect()
    {
        Instantiate(particlePrefab, characterPosition.position, Quaternion.identity);
    }
}
