using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance { get; private set; }

    [SerializeField] GameObject stickmanSkin;
    [SerializeField] GameObject garbagePrefabs;
    [SerializeField] GameObject garbage;
    [SerializeField] GameObject usedCubePrefabs;
    [SerializeField] float timeTrans;
    [SerializeField] float moveDuration;

    

    public float pointOfPlayer;
    public bool startToCount;
    public float timesToMultiple = 1f;
    

    private string TAG_EAT = "Eat";
    private string TAG_DROP = "Drop";
    private string TAG_USEDCUBE = "Used";
    private string TAG_UNTAGGED = "Untagged";
    private Rigidbody rb;
    private float elapsedTime = 0;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();       
        Instance = this;
    }
    private void Start()
    {
        //startToCount = false;
        garbage = Instantiate(garbagePrefabs);
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAG_EAT))
        {
            // Tạo ra âm thanh ăn gạch
            AudioManager.Instance.Play("Eat");

            // Khớp vị trí của player và gạch cho thẳng hàng
            Vector3 temp = collision.gameObject.transform.position;
            this.transform.position = temp;

            // Lát nền
            GameObject usedCube =  Instantiate(usedCubePrefabs, temp, Quaternion.identity, garbage.transform);
            usedCube.tag = TAG_USEDCUBE;
            collision.gameObject.tag = TAG_UNTAGGED;

            // Nâng tầm người chơi
            rb.useGravity = false;
            stickmanSkin.transform.localPosition += new Vector3(0, 0.1f, 0);
            //Vector3 targetPos = stickmanSkin.transform.position + new Vector3(0, 0.1f, 0);
            //stickmanSkin.transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, timeTrans/Time.deltaTime);
            collision.transform.parent = stickmanSkin.transform.parent;
            collision.transform.localPosition = new Vector3(0, stickmanSkin.transform.localPosition.y - 0.1f, 0);
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            //startToCount = true;
            pointOfPlayer++;
        }
        else if(collision.gameObject.CompareTag(TAG_DROP))
        {
            AudioManager.Instance.Play("Fall");
            collision.gameObject.tag = TAG_UNTAGGED;
            rb.useGravity = false;
            stickmanSkin.transform.localPosition = new Vector3(0, stickmanSkin.transform.localPosition.y - 0.1f, 0);
            // Lấy danh sách các thành phần con
            Transform parentTransform = gameObject.transform;
            int childCount = parentTransform.childCount;
            if (childCount > 1)
            {
                // Lấy đối tượng con ở vị trí cuối cùng
                Transform lastChild = parentTransform.GetChild(childCount - 1);
                // Xóa đối tượng con
                lastChild.parent = garbage.transform;
                lastChild.gameObject.SetActive(false);
                collision.transform.parent = garbage.transform;
                collision.gameObject.SetActive(false);
                pointOfPlayer--;
            }
            else
            {
                GameManager.Instance.lose = true;
            }    
        }
        else if (collision.gameObject.CompareTag(TAG_USEDCUBE))
        {
            Vector3 temp = collision.gameObject.transform.position;
            this.transform.position = temp;
        }
    }
    public void OnDestroy()
    {
        MovingControl2.Instance.getInput = false;
        Destroy(this.gameObject);
        Destroy(garbage);
    }
}
