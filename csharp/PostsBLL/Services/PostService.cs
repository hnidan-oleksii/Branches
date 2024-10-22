using AutoMapper;
using PostsBLL.DTOs.Post;
using PostsBLL.Helpers;
using PostsBLL.Helpers.Models;
using PostsBLL.Services.Interfaces;
using PostsDAL_EF.Entities;
using PostsDAL_EF.UoW;

namespace PostsBLL.Services;

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PostService(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<PostDTO>> GetPosts(PostParameters parameters)
    {
        var posts = await _unitOfWork.Posts.GetAllAsync();
        var postDTOs = _mapper.Map<IEnumerable<PostDTO>>(posts);

        SearchByTitle(ref postDTOs, parameters.Title);

        return PagedList<PostDTO>.ToPagedList(postDTOs,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<PostDTO> GetPostByIdAsync(int id)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(id);
        if (post == null)
        {
            throw new KeyNotFoundException($"Post with id {id} not found.");
        }

        return _mapper.Map<PostDTO>(post);
    }

    public async Task<PostDTO> CreatePostAsync(CreatePostDTO dto)
    {
        var post = _mapper.Map<Post>(dto);

        await _unitOfWork.BeginTransactionAsync();
        post = await _unitOfWork.Posts.AddAsync(post);

        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();

        return _mapper.Map<PostDTO>(post);
    }

    public async Task UpdatePostAsync(int id, UpdatePostDTO dto)
    {
        await _unitOfWork.BeginTransactionAsync();

        var post = await _unitOfWork.Posts.GetByIdAsync(id);
        if (post == null)
        {
            throw new KeyNotFoundException($"Post with id {id} not found.");
        }

        post.Title = dto.Title;
        post.Content = dto.Content;

        await _unitOfWork.Posts.UpdateAsync(post);
        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();
    }

    public async Task DeletePostAsync(int id)
    {
        await _unitOfWork.BeginTransactionAsync();
        await _unitOfWork.Posts.DeleteAsync(id);

        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();
    }

    public async Task<IEnumerable<PostDTO>> GetPostsByBranchIdAsync(int branchId)
    {
        var posts = await _unitOfWork.Posts.GetPostsByBranchIdAsync(branchId);
        return _mapper.Map<IEnumerable<PostDTO>>(posts);
    }

    public async Task<IEnumerable<PostDTO>> GetPostsByUserIdAsync(int userId)
    {
        var posts = await _unitOfWork.Posts.GetPostsByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<PostDTO>>(posts);
    }

    private void SearchByTitle(ref IEnumerable<PostDTO> posts, string title)
    {
        if (!posts.Any() || string.IsNullOrWhiteSpace(title))
        {
            return;
        }

        posts = posts.Where(p => p.Title.Contains(title.Trim(), StringComparison.InvariantCultureIgnoreCase));
    }
}
