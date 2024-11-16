using ContentManagementApplication.Data;
using ContentManagementApplication.Models;

namespace ContentManagementApplication.Repository
{
    public class ContentRepository : IContentRepository
    {
        private readonly Context context;
        public ContentRepository(Context _context)
        {
            context = _context;
        }

        public List<Content> GetContents()
        {
            return context.Contents.ToList();
        }

        public bool AddContent(Content contentModel)
        {
            try
            {
                Content content = context.Contents.Where(x => x.Title == contentModel.Title).FirstOrDefault();
                if (content != null)
                {
                    return false;
                }
                context.Contents.Add(contentModel);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteContent(int Id)
        {
            try
            {
                Content content = context.Contents.Where(x => x.Id == Id).FirstOrDefault();
                if (content != null)
                {
                    context.Contents.Remove(content);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateContent(Content contentModel)
        {
            try
            {
                Content content = context.Contents.Where(x => x.Title == contentModel.Title).FirstOrDefault();
                if (content != null)
                {
                    content.Body = contentModel.Body;
                    content.Category = contentModel.Category;
                    context.SaveChanges();
                }
                context.Contents.Add(content);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
