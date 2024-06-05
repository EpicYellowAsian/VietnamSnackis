using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace VietnamSnackis.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string UserId { get; set; }

        private readonly Data.VietnamSnackisContext _context;

        public ErrorModel(Data.VietnamSnackisContext context)
        {
            _context = context;
            CreatePost = new Models.Post();
            Category = new Models.Category();
            Comment = new Models.Comment();
        }

        [BindProperty]
        public Models.Post CreatePost { get; set; }

        [BindProperty]
        public Models.Category Category { get; set; }

        [BindProperty]
        public Models.Comment Comment { get; set; } 

        [BindProperty]
        public IFormFile UploadedImage { get; set; }
        public List<Models.Post> CreatePosts { get; set; }
        public List<Models.Category> Categories { get; set; }
        public List<Models.Comment> Comments { get; set; }

        [BindProperty]
        public int postId { get; set; }

        [BindProperty]
        public string content { get; set; }

        public async Task OnGetAsync(int deleteId)
        {
            Categories = await _context.Category.ToListAsync(); // Läsa från api 
            CreatePosts = await _context.CreatePost.ToListAsync();
            Comments = await _context.Comment.ToListAsync();
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (deleteId != 0)
            {
                Models.Post PostToBeDeleted = await _context.CreatePost.FindAsync(deleteId);

                if (PostToBeDeleted != null)
                {
                    if (System.IO.File.Exists("./wwwroot/userImages/" + PostToBeDeleted.Image))
                    {
                        System.IO.File.Delete("./wwwroot/userImages" + PostToBeDeleted.Image);
                    }

                    _context.CreatePost.Remove(PostToBeDeleted);
                    await _context.SaveChangesAsync();
                }
            }

            CreatePosts = await _context.CreatePost.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var image = UploadedImage;
            string fileName = "";

            if (image != null)
            {
                Random rnd = new Random();
                fileName = rnd.Next(0, 10000).ToString() + image.FileName;

                using (var fileStream = new FileStream("./wwwroot/userImages/" + fileName, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            CreatePost.PostCreated = DateTime.Now;
            CreatePost.Image = fileName;
            CreatePost.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //CreatePost.UserId = User.Identity.Name;
            _context.CreatePost.Add(CreatePost);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Post");
        }

        public async Task<IActionResult> OnPostAddCommentAsync(Models.Comment comment)
        {
            if (!ModelState.IsValid)
            {
                var createPostId = comment.PostId;
                Comment.PostId = CreatePost.Id;
                Comment = comment;
                Comment.DateCommented = DateTime.Now;
                Comment.CommentedByUser = User.Identity.Name;
                _context.Comment.Add(Comment);

                await _context.SaveChangesAsync();

                return RedirectToPage("./Post");
            }
            return RedirectToPage("./Post");
            //return BadRequest();
        }
    }
}
