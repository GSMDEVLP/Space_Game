using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private int _score = 0;
    private Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        _scoreText.text = _score.ToString();
    }

    public void ScoreHit(int scorePerHit)
    {
        _score += scorePerHit;
        _scoreText.text = _score.ToString();
    }

}
