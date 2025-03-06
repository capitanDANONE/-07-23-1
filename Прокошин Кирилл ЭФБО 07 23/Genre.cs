using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Прокошин_Кирилл_ЭФБО_07_23
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int genreid { get; set; }
        public string genrename { get; set; }
        public string genredescr { get; set; }
    }
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookid { get; set; }
        public string title { get; set; }
        public int authorid { get; set; }  // Foreign key for Author
        public int publishyear { get; set; }
        public int ISBN { get; set; }
        public int genreid { get; set; }  // Foreign key for Genre
        public int amount { get; set; }
    }
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int authorid { get; set; }
        public string authorname { get; set; }
        public string author2ndname { get; set; }
        public DateOnly dob { get; set; }
    }
}