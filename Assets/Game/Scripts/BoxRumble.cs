
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BoxRumble : MonoBehaviour, IMovable
{
    Rigidbody rb;
    [SerializeField]
    float _power;
    [SerializeField]
    Image _meter;
    [SerializeField]
    GameObject _boxMeterContainer, _fracturedBox,_player;
    bool _initialized = false;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       

    }

    void OnDisable()
    {
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        #region Only Used For Intro Scene
        if (Input.anyKeyDown && _initialized == false)
        {
            float randomDir = Random.Range(-1f, 1f);
            Debug.Log("anykeypress");
            rb.AddTorque(Vector3.forward * randomDir  * _power, ForceMode.Impulse);
            rb.AddTorque(Vector3.left * randomDir * _power, ForceMode.Impulse);
            _meter.fillAmount += Time.deltaTime*3;
            if (_meter.fillAmount > .95f)
            {
                _boxMeterContainer.SetActive(false);
                _fracturedBox.SetActive(true);//blow up box
                Instantiate(_player, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                Camera.main.transform.parent = GameObject.FindObjectOfType<Player>().transform;
                _initialized = true;
               

                this.gameObject.SetActive(false);
            }
        }

        #endregion




    }
    private void LateUpdate()
    {
        _meter.fillAmount -= Time.deltaTime / 10;
    }
}
