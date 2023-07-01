using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject _deathFX;
    [SerializeField] private int _scoreToAdd = 5;
    [SerializeField] private int hits = 0;
    private ScoreScript _scoreBoard;

    private void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreScript>();      
    }

    private void OnParticleCollision(GameObject other)
    {
        _scoreBoard.ScoreHit(_scoreToAdd);
        hits--;
        if (hits <= 0)
            DeathEnemy();

    }

    private void DeathEnemy()
    {
        GameObject fx = Instantiate(_deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(fx, 3f);
    }
}
