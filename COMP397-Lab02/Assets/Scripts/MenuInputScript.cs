using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuInputScript : MonoBehaviour
{
    private InputAction openMenu;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Slider mouseSensitivitySlider;
    [SerializeField] private bool isMenuOpen;

    void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Menu");
        openMenu.started += ToggleMenu;
        mouseSensitivitySlider.onValueChanged.AddListener(delegate { OnSliderChanged(mouseSensitivitySlider.value); });
    }

    private void OnDisable()
    {
        openMenu.started -= ToggleMenu;
        mouseSensitivitySlider.onValueChanged.RemoveListener(delegate { OnSliderChanged(mouseSensitivitySlider.value); });
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        isMenuOpen = !isMenuOpen;
        menuPanel.SetActive(isMenuOpen);
        if (isMenuOpen)
        {
            GetComponent<PlayerInput>().enabled = false;
            InputSystem.actions.FindActionMap("Player").Disable();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            GetComponent<PlayerInput>().enabled = true;
            InputSystem.actions.FindActionMap("Player").Enable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
            
    }

    private void OnSliderChanged(float value)
    {

    }
}
