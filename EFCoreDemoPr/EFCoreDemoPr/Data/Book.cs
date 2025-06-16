namespace EFCoreDemoPr.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }

        //ForeignKey
        public int LanguageId { get; set; }


        public Language Language { get; set; }
    }
}
