using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerHP : MonoBehaviour
{
    public static int playerHP;
    public static bool isGameOver;
    public TextMeshProUGUI playerHPText;
    void Start()
    {
        isGameOver = false;
        playerHP = 100;
    }

    void Update()
    {
        playerHPText.text = "HP:" + playerHP;
        if (isGameOver)
        {
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.Confined;
        }
    }


    public IEnumerator Damage(int damageAmount)
    {

        playerHP -= damageAmount;
        if (playerHP <= 0)
            isGameOver = true;
        yield return new WaitForSeconds(1f);
    }
}
