﻿using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class BlogPostCommentRespository : IBlogPostCommentRepository
    {
        private readonly BloggieDbContext bloggieDbContext;
        public BlogPostCommentRespository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await bloggieDbContext.BlogPostComment.AddAsync(blogPostComment);
            await bloggieDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            return await bloggieDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }
    }
}
