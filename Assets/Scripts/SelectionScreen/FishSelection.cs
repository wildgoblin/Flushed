using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FISH.SelectionScreen
{
    public class FishSelection : MonoBehaviour
    {
        [SerializeField] List<Fish> fish = new List<Fish>();

        Fish selectedFish;

        int fishIndex;

        private void Start()
        {
            DefaultSelection();
        }

        private void Update()
        {
            InputSelectFish();

        }

        private void InputSelectFish()
        {
            

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                UnselectFish();

                if (fishIndex == fish.Count - 1)
                {
                    fishIndex = 0;
                    selectedFish = fish[fishIndex];
                }
                else
                {
                    fishIndex += 1;
                    selectedFish = fish[fishIndex];
                    
                }

                SelectFish();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                UnselectFish();

                if (fishIndex == 0)
                {
                    fishIndex = fish.Count - 1;
                    selectedFish = fish[fishIndex];
                }
                else
                {
                    fishIndex -= 1;
                    selectedFish = fish[fishIndex];
                    
                }

                SelectFish();
            }

            
        }

        private void DefaultSelection()
        {
            if (fish.Count == 0)
            {
                Debug.Log("No Fish added to fish selector");
            }
            else
            {
                fishIndex = 0;
                selectedFish = fish[fishIndex];
                SelectFish();
            }
        }
        private void SelectFish()
        {
            selectedFish.ChangeToSelectedFish();
        }

        private void UnselectFish()
        {
            selectedFish.ChangeToUnselectedFish();
        }
    }


}
