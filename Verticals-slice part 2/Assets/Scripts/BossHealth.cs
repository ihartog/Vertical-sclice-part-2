﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    public static float health = 20000f;
    [SerializeField]
    public static float bossCurHealth;
    [SerializeField]
    private Image bossHealthBar;
    public Image BossHealthBar { get { return bossHealthBar; } set { bossHealthBar = value; } }
    [SerializeField]
    private GameObject bossHealthUI;
    [SerializeField]
    private GameObject bossDamageUI;
    [SerializeField]
    public static Image bossDamageBar;
    public Image BossDamageBar { get { return bossDamageBar; } set { bossDamageBar = value; } }
    public float BossCurHealth { get { return bossCurHealth; } set { bossCurHealth = value; } }
    [SerializeField]
    private GameObject victory;
    // Start is called before the first frame update
    void Start()
    {
        bossHealthBar = bossHealthUI.GetComponent<Image>();
        bossDamageBar = bossDamageUI.GetComponent<Image>();
        bossCurHealth = health;
     //   bossCurHealth -= CombatSystem.instance.Characters[0].GetComponent<UnitScript>().Strength;
    }

    private void Update()
    {

        bossHealthBar.fillAmount = bossCurHealth / health;

      /*  if (PlayerAttack.TakingDamage)
        {
            StartCoroutine(BossLosingHealth());
        } */ 

        if (bossCurHealth <= 0)
        {
            Time.timeScale = 0;
            victory.SetActive(true);
            Debug.Log("VICTORY SCREECH!!!");
        }
    }

    public static IEnumerator BossLosingHealth()
    {
        yield return new WaitForSeconds(2f);
        bossDamageBar.fillAmount = bossCurHealth / health;
    }
}
