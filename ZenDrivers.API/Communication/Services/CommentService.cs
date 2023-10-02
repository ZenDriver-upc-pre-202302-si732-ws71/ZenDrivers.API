using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Repository;
using ZenDrivers.API.Communication.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Communication.Services;

public class CommentService : CrudService<Comment, int>, ICommentService
{
    private readonly ICommentRepository _commentRepository;
    public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork, IGenericMap<Comment, Comment> genericMap) : base(commentRepository, unitOfWork, genericMap)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IEnumerable<Comment>> FindByPostIdAsync(int postId) =>
        await _commentRepository.FindByPostIdAsync(postId);


    public async Task<IEnumerable<Comment>> FindByAccountIdAsync(int accountId) =>
        await _commentRepository.FindByAccountIdAsync(accountId);

}