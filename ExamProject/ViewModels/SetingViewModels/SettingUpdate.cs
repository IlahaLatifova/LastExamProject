namespace ExamProject.ViewModels.SetingViewModels
{
    public class SettingUpdate
    {
        public SettingGet SettingGet { get; set; }
        public SettingPost SettingPost { get; set; }
        public SettingUpdate()
        {
            SettingPost = new SettingPost();
        }
    }
}
