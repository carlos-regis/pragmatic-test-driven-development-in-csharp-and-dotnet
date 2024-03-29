﻿using Dapper;
using System.Data;
using Uqs.Blog.Domain.DomainObjects;
using Uqs.Blog.Domain.Interfaces;

namespace Uqs.Blog.Domain.Repositories;
public class PostRepository : IPostRepository
{
    private readonly IDbConnection _dbConnection;

    public PostRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public int CreatePost(int authorId)
    {
        return 0;
    }

    public Post? GetById(int postId)
    {
        _dbConnection.Open();
        var post = _dbConnection.Query<Post>(
            "SELECT * FROM Post WHERE Id = @Id",
            new { Id = postId }).SingleOrDefault();
        _dbConnection.Close();
        return post;
    }

    public void Update(Post post)
    {
        throw new NotImplementedException();
    }
}