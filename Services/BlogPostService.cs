using blogging_platform_api.Models;

namespace blogging_platform_api.Services
{
    public class BlogPostService : IBlogPostService
    {
        private IList<BlogPost> blogPosts = new List<BlogPost>()
            { new BlogPost() { Id = 1, Title = "Title 1", Body = "Body 1" } };

        public IList<BlogPost> GetAll() 
        {
            return this.blogPosts;
        }

        public BlogPost GetById(int id) 
        {
            var blogPost = this.blogPosts.SingleOrDefault(x => x.Id == id);

            if (blogPost == null)
            {
                throw new Exception($"Blog post with id {id} not found.");
            }

            return blogPost;
        }

        public BlogPost Create(BlogPostUpsertDto blogPostDto)
        {
            var maxId = this.blogPosts.Max(x => x.Id);
            var newBlogPost = new BlogPost() { Id = maxId + 1, Title = blogPostDto.Title, Body = blogPostDto.Body };

            this.blogPosts.Add(newBlogPost);
            
            return newBlogPost;
        }

        public BlogPost Update(int id, BlogPostUpsertDto blogPostDto)
        {
            var blogPostToUpdate = this.blogPosts.SingleOrDefault(x => x.Id == id);

            if (blogPostToUpdate == null) 
            {
                throw new Exception($"Blog post with id {id} not found.");
            }

            blogPostToUpdate.Title = blogPostDto.Title;
            blogPostToUpdate.Body = blogPostDto.Body;

            return blogPostToUpdate;
        }

        public void Delete(int id)
        {
            var blogPostToDelete = this.blogPosts.SingleOrDefault(x => x.Id == id);

            if (blogPostToDelete == null)
            {
                throw new Exception($"Blog post with id {id} not found.");
            }

            this.blogPosts.Remove(blogPostToDelete);
        }
    }
}
