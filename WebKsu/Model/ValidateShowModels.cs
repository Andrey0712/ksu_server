namespace WebKsu.Model
{
    public class CreateValidateViewModel
    {
        public string Name { get; set; }
    }

    public class ValidateItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ValidateDelViewModel
    {
        public int Id { get; set; }

    }
    public class ValidateChangeStatusViewModel
    {
        public int Id { get; set; }
        public int ValidateShowId { get; set; }

    }
}
