using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginMng : MonoBehaviour
{
    public InputField phoneNumberInput;
    public InputField otpInput;
    public Button sendOtpButton;
    public Button loginButton;
    public TMP_Text otpNotification; // Reference to the OTP notification TMP_Text
    public TMP_Text otpStatusText; // Reference to the OTP status TMP_Text

    private string generatedOtp;

    void Start()
    {
        loginButton.interactable = false;

        // Check if phone number is already stored in PlayerPrefs
        if (PlayerPrefs.HasKey("PhoneNumber"))
        {
            // Skip login if phone number is already stored
            SceneManager.LoadScene("Dashboard");
        }
    }

    public void OnSendOtpButtonClicked()
    {
        if (!string.IsNullOrEmpty(phoneNumberInput.text))
        {
            generatedOtp = Random.Range(1000, 9999).ToString(); // Generate random OTP
            otpNotification.text = "Generated OTP: " + generatedOtp; // Display the OTP
            otpStatusText.text = ""; // Clear any previous status message
            Debug.Log("Generated OTP: " + generatedOtp); // In a real app, send this OTP to the user's phone
            loginButton.interactable = true; // Allow login after OTP is generated
        }
    }

    public void OnLoginButtonClicked()
    {
        if (otpInput.text == generatedOtp)
        {
            PlayerPrefs.SetString("PhoneNumber", phoneNumberInput.text);
            SceneManager.LoadScene("Dashboard");
        }
        else
        {
            otpStatusText.text = "Incorrect OTP. Please try again."; // Display incorrect OTP message
            Debug.Log("Incorrect OTP");
        }
    }
}
