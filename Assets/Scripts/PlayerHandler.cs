using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool _isOnFloor = true;
    private int _direction = 1;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _isOnFloor)
        {
            _isOnFloor = false;
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }
        _rb.velocity = new Vector2(speed * _direction, _rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _isOnFloor = true;
        if (collision.gameObject.tag == "Finish")
        {
            if (SceneManager.GetActiveScene().buildIndex - 1 > YandexGame.savesData.maxLevels)
            {
                YandexGame.savesData.maxLevels += 1;
                YandexGame.SaveProgress();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
