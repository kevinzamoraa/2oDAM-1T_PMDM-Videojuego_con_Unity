using UnityEngine;
using UnityEngine.UI;

public class TokenController : MonoBehaviour
{
    public int tokenCount;
    public Text tokenText;
    void Start()
    {
        
    }

    void Update()
    {
        tokenText.text = "Tokens:" + tokenCount.ToString();
    }
}
