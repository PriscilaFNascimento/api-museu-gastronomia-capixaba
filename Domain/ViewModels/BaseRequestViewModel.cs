namespace Domain.ViewModels
{
    public class BaseRequestViewModel
    {
        public int PageNumber { get; set; } = 1000;
        public int PageSize { get; set; } = 1;
        public bool OrderByRegistro { get; set; }
    }
}
