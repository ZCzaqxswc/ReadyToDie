using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class HButton : MonoBehaviour
{

    public TextMeshProUGUI Txt;

    // Start is called before the first frame update
    void Start()
    {
        //http://dotween.demigiant.com/documentation.php
        RectTransform rt = GetComponent<RectTransform>();

        //도착지점 , 지속시간, 딜레이, 탄력있게,
        rt.DOAnchorPosY(30, 1.5f).SetDelay(0.5f).SetEase(Ease.OutElastic);
        //rt.DOAnchorPosY(100, 1f).SetDelay(1.5f).SetEase(Ease.InOutBounce);

        //Txt.DOText("welcome to gamescene", 2, true, ScrambleMode.All).SetDelay(2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
