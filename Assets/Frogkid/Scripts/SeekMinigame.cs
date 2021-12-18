using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace FROGKID
{
    public class SeekMinigame : MonoBehaviour
    {
        [SerializeField]
        private GameObject frog = null;

        [SerializeField]
        private List<Planet> planets = null;

        private List<Planet> selectedPlanets;

        [SerializeField]
        private List<int> planetSelector;

        int homePlanet;

        // Start is called before the first frame update
        void Start()
        {
            MinigameManager.Instance.minigame.gameWin = false;
            selectedPlanets = new List<Planet>();
            int numPlanets = planets.Count;


            homePlanet = Random.Range(0, 3);

            for(int i = 0; i < 3; i++)
            {
                if(i != homePlanet)
                {
                    // select a sprite at random
                    int index = Random.Range(0, planetSelector.Count);
                    int p = planetSelector[index];
                    planetSelector.RemoveAt(index);
                    planets[i].setPlanetNum(p);
                } else
                {
                    // set home planet sprite
                    planets[i].setPlanetNum(0);
                    Debug.Log(i);
                }
            }

            //// select 3 random planets
            //for(int i = 0; i < 3 && i < numPlanets; i++)
            //{
            //    int index = Random.Range(0, planets.Count);
            //    GameObject p = planets[index];
            //    selectedPlanets.Add(p);
            //    planets.RemoveAt(index);
            //}


            Debug.Log(selectedPlanets.Count);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void doWin()
        {
            Debug.Log("win");
            if (!MinigameManager.Instance.minigame.gameWin)
            {
                MinigameManager.Instance.minigame.gameWin = true;
                MinigameManager.Instance.PlaySound("win");
            }
        }

        public void doLose()
        {
            Debug.Log("lose");
        }
    }
}
