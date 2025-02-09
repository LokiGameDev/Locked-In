using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryManager : MonoBehaviour
{
    public GameObject playerInventory;
    public GameObject[] inventorySlots;
    private int _inventorySlotSelected;
    private int _totalSlots;
    public bool isPlayerInventoryOn
    {
        get; private set;
    }

    void Start()
    {
        isPlayerInventoryOn=false;
        _inventorySlotSelected=0;
        _totalSlots=4;
        DisablePlayerInventory();
    }

    void Update()
    {
        if(Input.inputString!=null && isPlayerInventoryOn)
        {
            bool isNumber=int.TryParse(Input.inputString,out int number);
            if(isNumber && number>0 && number<5)
            {
                ChangeSlotSelection(number-1);
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(isPlayerInventoryOn)
        {
            ScrollSlotChange(scroll);
        }
    }

    public void DisablePlayerInventory()
    {
        isPlayerInventoryOn=false;
        playerInventory.SetActive(false);
    }

    public void EnablePlayerInventory()
    {
        isPlayerInventoryOn=true;
        playerInventory.SetActive(true);
    }


    private void ChangeSlotSelection(int number)
    {
        DeselectSlot(_inventorySlotSelected);
        _inventorySlotSelected=number;
        SelectSlot(number);
    }
    private void SelectSlot(int slotNumber)
    {
        Image image = inventorySlots[slotNumber].GetComponent<Image>();
        Color color=image.color;
        color.a=0.8f;
        image.color=color;
    }

    private void DeselectSlot(int slotNumber)
    {
        Image image = inventorySlots[slotNumber].GetComponent<Image>();
        Color color=image.color;
        color.a=0.5f;
        image.color=color;
    }

    private void ScrollSlotChange(float scroll)
    {
        if (scroll > 0f)
        {
            int currentSlot=_inventorySlotSelected;
            currentSlot++;
            if (currentSlot >= _totalSlots)
            {
                currentSlot = 0;
            }
            ChangeSlotSelection(currentSlot);
        }
        else if (scroll < 0f)
        {
            int currentSlot=_inventorySlotSelected;
            currentSlot--;
            if (currentSlot < 0)
            {
                currentSlot = _totalSlots-1;
            }
            ChangeSlotSelection(currentSlot);
        }
    }
}
