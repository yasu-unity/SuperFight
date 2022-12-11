using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //static
    public static GameManager instance;
    //�ϐ��̐錾(UI�APlayercontroller)
    [SerializeField]
    private Slider hpslider;
    [SerializeField]
    private PlayerManager player;
    private void Awake()//�X�^�[�g����ɌĂ΂��
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateHealthUI()
    {
        hpslider.maxValue = player.maxHealth;
        hpslider.value = player.currentHealth;
    }
}
