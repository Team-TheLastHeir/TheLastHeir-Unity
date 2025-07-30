using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;
using System.Text;
using System.Collections;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public string nextSceneName;

    [Header("API URL")]
    [SerializeField] private string loginUrl;

    void Start()
    {
        Debug.Log($"[UIManager] login url: {loginUrl}");
    }
    public void OnLoginButtonClicked()
    {
        TMP_InputField idInput = GameObject.Find("InputID").GetComponent<TMP_InputField>(); // 비활성된 상태에서 찾을 수 없기 때문에 Find 사용
        TMP_InputField passwordInput = GameObject.Find("InputPW").GetComponent<TMP_InputField>();

        if (idInput == null || passwordInput == null)
        {
            Debug.LogError("InputField를 찾을 수 없음");
            return;
        }

        string id = idInput.text;
        string password = passwordInput.text;
        
        Debug.Log($"로그인 정보: {id} / {password}");

        StartCoroutine(TryLogin(id, password));
    }

    private IEnumerator TryLogin(string id, string password)
    {
        Debug.Log("API 요청 시작");
        Debug.Log($"로그인 시도: {id} / {password}");

        LoginRequest requestData = new LoginRequest
        {
            username = id,
            password = password
        };

        string json = JsonUtility.ToJson(requestData);
        byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

        UnityWebRequest request = new UnityWebRequest(loginUrl, "POST");
        request.uploadHandler = new UploadHandlerRaw(jsonBytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log($"[LOGIN] 보낼 JSON: {json}");

        yield return request.SendWebRequest();

        Debug.Log($"API 요청 끝, 상태코드: {request.responseCode}");
        Debug.Log($"응답: {request.downloadHandler.text}");

        if (request.result == UnityWebRequest.Result.Success && request.responseCode == 200)
        {
            TokenResponse token = JsonUtility.FromJson<TokenResponse>(request.downloadHandler.text);

            PlayerPrefs.SetString("jwt_token", token.token);
            PlayerPrefs.Save();

            Debug.Log("로그인 성공! 토큰: " + token.token);
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning($"로그인 실패: {request.responseCode} - {request.downloadHandler.text} / {request.error}");
        }
    }

}