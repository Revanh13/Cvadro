using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class StartMenu : MonoBehaviour
    {
        public List<Button> buttons = new List<Button>();

        public int selectedIndex;

        public GameObject Player;

        public float menu;
        public float Menu { get => menu; }

        Gamepad gamepad = Gamepad.current;

        void Start()
        {
            selectedIndex = 0;
            highlightButton();
        }

        void Update()
        {
            if (gamepad.aButton.wasPressedThisFrame)
            {
                switch (selectedIndex)
                {
                    case 0:
                        Destroy(Player);
                        SceneManager.LoadScene(1);
                        break;
                    case 1:
                        Destroy(Player);
                        SceneManager.LoadScene(2);
                        break;
                    case 2:
                        Destroy(Player);
                        SceneManager.LoadScene(3);
                        break;
                    case 3:
                        Application.Quit();
                        break;

                }

            }
        }


    private void OnMenu(InputValue value)
        {
            menu = value.Get<float>();
            if (menu < 0 && selectedIndex > 0)
                selectedIndex--;
            if (menu > 0 && selectedIndex < buttons.Count - 1)
                selectedIndex++;
            highlightButton();
        }

        void highlightButton()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                ColorBlock ccb = buttons[i].colors;
                ccb.normalColor = Color.white;
                buttons[i].colors = ccb;
            }

            ColorBlock cb = buttons[selectedIndex].colors;
            cb.normalColor = Color.blue;
            buttons[selectedIndex].colors = cb;
        }
    }
}
