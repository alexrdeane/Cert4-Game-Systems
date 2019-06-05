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
        //spawn rate of asteroids
        public float spawnRate = 1f;
        //radius for asteroid to spawn within
        public float spawnRadius = 5f;
        #endregion

        #region Start
        void Start()
        {

            InvokeRepeating("Spawn", 0, spawnRate);
        }
        #endregion

        #region Spawn
        void Spawn()
        {
            //randomize the asteroids position within a circle
            Vector2 randomPos = Random.insideUnitCircle * spawnRate;
            //randomize the rotation of the asteroid
            Quaternion randomRot = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            //picks a random index in asteroid array to vary sizes
            int randIndex = Random.Range(0, asteroidPrefabs.Length);
            //gets random asteroid prefab from array with index
            GameObject randomAsteroid = asteroidPrefabs[randIndex];
            //spawn random asteroid with random size, position and rotation
            Instantiate(randomAsteroid, randomPos, randomRot);
        }
        #endregion

        #region OnDraw
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
        #endregion
    }
}

