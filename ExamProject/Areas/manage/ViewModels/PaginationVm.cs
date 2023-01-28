namespace ExamProject.Areas.manage.ViewModels
{
    public class PaginationVm<T>
    {
        public List<T> Models { get; set; }
        public int TotalPageCount { get; set; }
        public int CurrentPage { get; set; }
        public bool Previous { get; set; }
        public bool Next { get; set; }
    }
}
