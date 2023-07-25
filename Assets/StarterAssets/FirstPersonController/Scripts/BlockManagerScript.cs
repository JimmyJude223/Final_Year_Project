using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockManagerScript : MonoBehaviour
{
    public GameObject CyanSphere;
    public GameObject YellowSphere;
    public GameObject PinkSphere;
    public GameObject GreenSphere;
    public GameObject RedSphere;

    public GameObject CyanBlock;
    public GameObject YellowBlock;
    public GameObject PinkBlock;
    public GameObject GreenBlock;
    public GameObject RedBlock;

    bool isCyancorrect = false;
    bool isYellowcorrect = false;
    bool isRedcorrect = false;
    bool isPinkcorrect = false;
    bool isGreencorrect = false;

    bool isCyanEmpty = true;
    bool isYellowEmpty = true;
    bool isRedEmpty = true;
    bool isGreenEmpty = true;
    bool isPinkEmpty = true;
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        isCyancorrect = CyanSphere.GetComponent<SnapScript>().IscorrectCube;
        isYellowcorrect = YellowSphere.GetComponent<SnapScript>().IscorrectCube;
        isRedcorrect = RedSphere.GetComponent<SnapScript>().IscorrectCube;
        isGreencorrect = GreenSphere.GetComponent<SnapScript>().IscorrectCube;
        isPinkcorrect = PinkSphere.GetComponent<SnapScript>().IscorrectCube;

        isCyanEmpty = CyanSphere.GetComponent<SnapScript>().IsEmpty;
        isYellowEmpty = YellowSphere.GetComponent<SnapScript>().IsEmpty;
        isRedEmpty= RedSphere.GetComponent<SnapScript>().IsEmpty;
        isGreenEmpty = GreenSphere.GetComponent<SnapScript>().IsEmpty;
        isPinkEmpty = PinkSphere.GetComponent<SnapScript>().IsEmpty;

        if(!isCyanEmpty && !isYellowEmpty && !isRedEmpty && !isGreenEmpty && !isPinkEmpty)
        {
            if (isCyancorrect && isGreencorrect && isYellowcorrect && isRedcorrect && isPinkcorrect)
            {
                Debug.Log("Good job!");
                SceneManager.LoadScene(1);

            }
            else
            {
                CyanBlock.transform.position = this.transform.position;
                YellowBlock.transform.position = this.transform.position;
                RedBlock.transform.position = this.transform.position;
                GreenBlock.transform.position = this.transform.position;
                PinkBlock.transform.position = this.transform.position;
            }
        }

        
    }
}
