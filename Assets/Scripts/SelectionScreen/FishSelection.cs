using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FISH.SelectionScreen
{
    public class FishSelection : MonoBehaviour
    {
        [SerializeField] List<Fish> fish = new List<Fish>();

        [SerializeField] GameObject fishParent;

        Fish selectedFish;

        int fishIndex;

        bool inputEnabled;


        private void Start()
        {

            RemoveDeadFish();
            AddFishToList();
            DefaultSelection();
            inputEnabled = true;

            
        }

        private void RemoveDeadFish()
        {

            for (int i = 0; i < fishParent.transform.childCount; i++)
            {

                if (i == GameManager.instance.GetFishCharacterSelectIndex())
                {
                    fish.Remove(fish[i]);
                    Destroy(fishParent.transform.GetChild(i).gameObject);

                }
            }

        }

        private void AddFishToList()
        {
            foreach (Transform fishy in fishParent.transform)
            {
                fish.Add(fishy.transform.GetChild(0).GetComponent<Fish>());
            }
        }

        private void Update()
        {
            InputSelectFish();

        }

        private void InputSelectFish()
        {

            if (inputEnabled)
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

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    inputEnabled = false;
                    GameManager.instance.SetCharacterSprite(selectedFish.GetCharacterSprite());
                    selectedFish.StartCutscene();
                }
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
