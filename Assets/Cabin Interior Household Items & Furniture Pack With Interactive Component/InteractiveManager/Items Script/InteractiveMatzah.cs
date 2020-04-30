using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace MB {
    [RequireComponent(typeof(BoxCollider))]
    public class InteractiveMatzah : InteractiveItem
    {
        [TextArea(3, 10)]
        [SerializeField] private string _infoText;
        public int id;

        [SerializeField] private Method _method = Method.Coroutine;
        private bool _isUpdate = false;

        private void Awake()
        {
            if (_method == Method.Update)
                _isUpdate = true;
            else
                _isUpdate = false;
        }

        public override string GetText()
        {
            return _infoText;
        }
        
        
        public override void Activate(PlayerInteractiveManager playerInteractiveManager)
        {
            if(!ApplicationModel.findAll)
                SceneManager.LoadScene("Winner");
            else
            {
                Destroy(this.gameObject);
                ApplicationModel.score++;
                if(ApplicationModel.score> ApplicationModel.matzahs.Length)
                {
                    SceneManager.LoadScene("Winner");
                }
            }
        }
        
    }
}
