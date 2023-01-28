namespace ExamProject.ViewModels.PortfolioViewModels
{
    public class PortfolioUpdateVm
    {
        public PortfolioGetVm portfolioGet { get; set; }
        public PortfolioPostVm portfolioPost { get;set; }
        public PortfolioUpdateVm()
        {
            portfolioPost = new PortfolioPostVm();
        }
    }
}
