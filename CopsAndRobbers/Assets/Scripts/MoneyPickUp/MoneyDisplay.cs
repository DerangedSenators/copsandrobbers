using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class MoneyDisplay : MonoBehaviour
    {
        [SerializeField] Text moneyText;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateView(int moneyCount)
        {
            moneyText.text = "$" + moneyCount.ToString();
        }
    }
}