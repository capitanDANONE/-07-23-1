using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Прокошин_Кирилл_ЭФБО_07_23
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                var books = context.Books.ToList();
                return Ok(books); // This will automatically serialize the list to JSON
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
            return Ok(book); // Returns the newly created book as JSON
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Book updatedBook)
        {
            if (updatedBook == null)
                return BadRequest("Invalid book data.");
            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                var existingBook = context.Books.FirstOrDefault(b => b.bookid == updatedBook.bookid);
                if (existingBook == null)
                    return NotFound($"Book with ID {updatedBook.bookid} not found.");
                existingBook.title = updatedBook.title;
                existingBook.authorid = updatedBook.authorid;
                existingBook.publishyear = updatedBook.publishyear;
                existingBook.ISBN = updatedBook.ISBN;
                existingBook.genreid = updatedBook.genreid;
                existingBook.amount = updatedBook.amount;
                context.SaveChanges();
            }
            return Ok(updatedBook); // Returns the updated book as JSON
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                var book = context.Books.FirstOrDefault(b => b.bookid == id);
                if (book == null)
                    return NotFound($"Book with ID {id} not found.");

                context.Books.Remove(book);
                context.SaveChanges();
            }
            return Ok($"Book with ID {id} has been deleted.");
        }
    }

    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                var genres = context.Genres.ToList();
                return Ok(genres); // Returns the list of genres as JSON
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Genre genre)
        {
            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                context.Genres.Add(genre);
                context.SaveChanges();
            }
            return Ok(genre); // Returns the newly created genre as JSON
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Genre updatedGenre)
        {
            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                var existingGenre = context.Genres.FirstOrDefault(g => g.genreid == updatedGenre.genreid);
                if (existingGenre == null)
                    return NotFound($"Genre with ID {updatedGenre.genreid} not found.");

                existingGenre.genrename = updatedGenre.genrename;
                existingGenre.genredescr = updatedGenre.genredescr;

                context.SaveChanges();
            }

            return Ok(updatedGenre);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                var genre = context.Genres.FirstOrDefault(g => g.genreid == id);
                if (genre == null)
                    return NotFound($"Genre with ID {id} not found.");

                context.Genres.Remove(genre);
                context.SaveChanges();
            }
            return Ok($"Genre with ID {id} has been deleted.");
        }
    }

    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                var authors = context.Authors.ToList();
                return Ok(authors);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
            return Ok(author);
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Author updatedAuthor)
        {
            if (updatedAuthor == null)
                return BadRequest("Invalid author data.");

            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                var existingAuthor = context.Authors.FirstOrDefault(a => a.authorid == updatedAuthor.authorid);
                if (existingAuthor == null)
                    return NotFound($"Author with ID {updatedAuthor.authorid} not found.");

                existingAuthor.authorname = updatedAuthor.authorname;
                existingAuthor.author2ndname = updatedAuthor.author2ndname;
                existingAuthor.dob = updatedAuthor.dob;

                context.SaveChanges();
            }
            return Ok(updatedAuthor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new AppDbContext(new ConfigurationBuilder().Build()))
            {
                var author = context.Authors.FirstOrDefault(a => a.authorid == id);
                if (author == null)
                    return NotFound($"Author with ID {id} not found.");

                context.Authors.Remove(author);
                context.SaveChanges();
            }
            return Ok($"Author with ID {id} has been deleted.");
        }
    }
}