using blogging_platform_api.Models;

namespace blogging_platform_api.Services
{
    public interface IBlogPostService
    {
        public IList<BlogPost> GetAll();

        public BlogPost GetById(int id);

        public BlogPost Create(BlogPostUpsertDto blogPostDto);

        public BlogPost Update(int id, BlogPostUpsertDto blogPostDto);

        public void Delete(int id);
    }
}
