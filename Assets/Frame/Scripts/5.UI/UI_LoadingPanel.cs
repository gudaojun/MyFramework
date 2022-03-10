using UnityEngine;
using UnityEngine.UI;

    [UIElement(true, "UI/UI_LoadingPanel", 4)]
    public class UI_LoadingPanel : UI_PanelBase
    {
        [SerializeField]
        private Text progress_Text;
        [SerializeField]
        private Image fill_Image;
        public override void OnShow()
        {
            base.OnShow();
            UpdateProgress(0);
        }

        protected override void RegisterEventListener()
        {
            base.RegisterEventListener();
            EventManager.AddEventListener<float>("LoadingSceneProgress", UpdateProgress);
            EventManager.AddEventListener("LoadSceneSucceed", OnLoadSceneSucceed);
        }

        protected override void CancelEventListener()
        {
            base.CancelEventListener();
            EventManager.RemoveEventListener<float>("LoadingSceneProgress", UpdateProgress);
            EventManager.RemoveEventListener("LoadSceneSucceed", OnLoadSceneSucceed);
        }

        /// <summary>
        /// 当场景加载成功
        /// </summary>
        private void OnLoadSceneSucceed()
        {
            Close();
        }

        /// <summary>
        /// 更新进度
        /// </summary>
        private void UpdateProgress(float progressValue)
        {
            progress_Text.text = (int)(progressValue * 100) + "%";
            fill_Image.fillAmount = (int)(progressValue * 100);
        }
    }
