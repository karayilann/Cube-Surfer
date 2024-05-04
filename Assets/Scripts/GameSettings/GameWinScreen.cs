using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameWinScreen : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] CharacterStackController stackController;

    [SerializeField] int blockCount, puan;
    public TextMeshProUGUI winText;

    void Start()
    {
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
        stackController = GameObject.FindAnyObjectByType<CharacterStackController>();
        blockCount = stackController.blocks.Count;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("CollactableCube"))
        {
            Debug.Log("Temas var");
            puan = blockCount * 10;
            panel.SetActive(true);
            winText.text = winText.text + puan;
        }
    }
}
