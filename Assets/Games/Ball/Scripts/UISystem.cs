using TMPro;
using Unity.Entities;
using UnityEngine;

namespace Games.Ball
{
    public class UISystem:SystemBase
    {

        private TMP_Text _tmpText;
     


        protected override void OnUpdate()
        {
            if (_tmpText == null)
            {
                var go = GameObject.Find("Score");
                if (go == null) return;
                _tmpText =  go.GetComponent<TMP_Text>();
            }
            
            var value = GetSingleton<GameData>().Value;
            _tmpText.text = value.ToString();

        }
    }
}