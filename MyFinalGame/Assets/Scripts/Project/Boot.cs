using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private ItemsConfig itemsConfig;

        private void Awake()
        {
            ProjectContext.Instance.Init(itemsConfig);
        }

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}