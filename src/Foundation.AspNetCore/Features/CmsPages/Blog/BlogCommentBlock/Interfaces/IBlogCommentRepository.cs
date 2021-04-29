﻿using Foundation.AspNetCore.Features.CmsPages.Blog.BlogCommentBlock.Models;
using System.Collections.Generic;

namespace Foundation.AspNetCore.Features.CmsPages.Blog.BlogCommentBlock.Interfaces
{
    /// <summary>
    /// The IBlogCommentRepository interface defines the operations that can be issued
    /// against a blog comment repository.
    /// </summary>
    public interface IBlogCommentRepository
    {
        /// <summary>
        /// Adds a comment to the underlying comment repository.
        /// </summary>
        /// <param name="comment">The comment to add.</param>
        /// <returns>The added comment.</returns>
        BlogCommentModel Add(BlogCommentModel comment);

        /// <summary>
        /// Gets comments from the underlying comment repository based on a filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>A list of comments.</returns>
        IEnumerable<BlogCommentModel> Get(PageCommentFilter filter, out long total);
    }
}