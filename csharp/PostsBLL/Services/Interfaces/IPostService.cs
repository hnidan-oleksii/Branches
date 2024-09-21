using PostsBLL.DTOs.Post;
using PostsBLL.Helpers;
using PostsBLL.Helpers.Models;

namespace PostsBLL.Services.Interfaces;

public interface IPostService
{
    Task<PostDTO> GetPostByIdAsync(int id);
    Task<IEnumerable<PostDTO>> GetPosts();
    Task<PostDTO> CreatePostAsync(CreatePostDTO dto);
    Task UpdatePostAsync(int id, UpdatePostDTO dto);
    Task DeletePostAsync(int id);
    Task<IEnumerable<PostDTO>> GetPostsByBranchIdAsync(int branchId);
    Task<IEnumerable<PostDTO>> GetPostsByUserIdAsync(int userId);
}
