using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [AddComponentMenu("Asteroids/Scripts/AsteroidSpawner")]
    public class AsteroidSpawner : MonoBehaviour
    {
        #region Variables
        [Header("Variables: ")]
        [Header("Asteroid variables: ")]
        //array of asteroids
        public GameObject[] asteroidPrefabs;
        public float spawnPadding = 2f;
        //spawn rate of asteroids
        public float spawnRate = 1f;
        public float maxVelocity = 3f;

        public Color debugColor = Color.cyan;
        #endregion

        #region Start
        void Start()
        {
            InvokeRepeating("SpawnLoop", 0, spawnRate);
        }
        #endregion

        void Spawn(GameObject prefab, Vector3 position)
        {
            Quaternion randomRot = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            GameObject asteroid = Instantiate(prefab, position, randomRot, transform);
            Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>();

            Vector2 randomForce = Random.insideUnitCircle * maxVelocity;
            rigid.AddForce(randomForce, ForceMode2D.Impulse);
        }

        void SpawnLoop()
        {
            Bounds camBounds = Camera.main.GetBounds(spawnPadding);

            Vector2 randomPos = camBounds.GetRandomPosOnBounds();

            int randomIndex = Random.Range(0, asteroidPrefabs.Length);
            GameObject randomAsteroid = asteroidPrefabs[randomIndex];
            Spawn(randomAsteroid, randomPos);
        }

        private void OnDrawGizmos()
        {
            Bounds camBounds = Camera.main.GetBounds(spawnPadding);
            Gizmos.color = debugColor;
            Gizmos.DrawWireCube(camBounds.center, camBounds.size);
        }
    }
}

