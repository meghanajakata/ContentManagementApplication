using ContentManagementApplication.Models;

namespace ContentManagementApplication.Repository
{
    public interface IContentRepository
    {
        public List<Content> GetContents();
        public bool AddContent(Content contentModel);
        public bool DeleteContent(int id);
        public bool UpdateContent(Content contentModel);
    }
}
