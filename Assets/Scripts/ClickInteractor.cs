using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteractor : MonoBehaviour
{
    public Transform cameraTransform;

    public Sprite defaultCrosshair;
    public Sprite activeCrosshair;

    public AudioClip grabSound;
    public AudioClip releaseSound;
    public AudioClip buttonSound;

    private AudioSource audio;

    private Transform originParant;

    private FirstPersonAIO firstPerson;

    private bool isGrabbing = false;

    private GameObject grabbedObject;

    private void Start()
    {
        firstPerson = GetComponent<FirstPersonAIO>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));

        #region 인디케이터
        if (Physics.Raycast(ray, out hit, 2))
        {
            if(hit.transform.CompareTag("Grabbable") || hit.transform.CompareTag("Click"))
            {
                Debug.Log("바까");
                firstPerson.crossHair.sprite = activeCrosshair;
            }
            else
            {
                firstPerson.crossHair.sprite = defaultCrosshair;
            }
        }
        else
        {
            firstPerson.crossHair.sprite = defaultCrosshair;
        }
        #endregion

        if (Input.GetMouseButtonDown(0))
        {
            #region 버튼
            if (Physics.Raycast(ray, out hit, 2))
            {

                MyButton button = hit.transform.GetComponent<MyButton>();
                if (button != null)
                {

                    button.Click();
                    audio.PlayOneShot(buttonSound);
                }
            }
            #endregion

            #region 엘레베이터 버튼
            if (Physics.Raycast(ray, out hit, 2))
            {
                Debug.Log("맞았어");

                ElevatorButton button = hit.transform.GetComponent<ElevatorButton>();
                if (button != null)
                {
                    Debug.Log("좋았어");

                    button.Move();
                }
            }
            #endregion

            #region Grab
            if (isGrabbing)
            {
                grabbedObject.transform.parent = originParant;

                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                audio.PlayOneShot(releaseSound);

                originParant = null;
                grabbedObject = null;

                isGrabbing = false;

                return;
            }


            if (Physics.Raycast(ray, out hit, 2))
            {
                if (!isGrabbing && hit.transform.CompareTag("Grabbable"))
                {
                    Rigidbody hit_Rigidbody = hit.transform.GetComponent<Rigidbody>();

                    audio.PlayOneShot(grabSound);

                    originParant = hit.transform.parent;
                    grabbedObject = hit.transform.gameObject;

                    hit.transform.parent = cameraTransform;
                    hit_Rigidbody.isKinematic = true;
                    Vector3 vec = cameraTransform.position - hit.transform.position;
                    vec.Normalize();
                    Quaternion q = Quaternion.LookRotation(vec);
                    hit.transform.rotation = q;

                    isGrabbing = true;
                }
            }
            #endregion
        }
    }
}
