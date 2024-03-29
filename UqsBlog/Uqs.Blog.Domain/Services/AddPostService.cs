﻿using Uqs.Blog.Domain.Interfaces;

namespace Uqs.Blog.Domain.Services;

public class AddPostService : IAddPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IAuthorRepository _authorRepository;

    public AddPostService(IPostRepository postRepository, IAuthorRepository authorRepository)
    {
        _postRepository = postRepository;
        _authorRepository = authorRepository;
    }

    public int AddPost(int authorId)
    {
        var author = _authorRepository.GetById(authorId) ?? throw new ArgumentException("Author Id not found", nameof(authorId));
        if (author.IsLocked)
        {
            throw new InvalidOperationException("The author is locked");
        }
        var newPostId = _postRepository.CreatePost(authorId);
        return newPostId;
    }
}
