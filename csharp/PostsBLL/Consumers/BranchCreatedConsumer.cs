using Common.EventModels.Branches;
using MassTransit;
using PostsDAL_EF.Entities;
using PostsDAL_EF.UoW;

namespace PostsBLL.Consumers;

public class BranchCreatedConsumer(IUnitOfWork unitOfWork) : IConsumer<BranchCreated>
{
    public async Task Consume(ConsumeContext<BranchCreated> context)
    {
        await unitOfWork.BeginTransactionAsync();

        var branchEvent = context.Message;
        var branch = new Branch { Id = branchEvent.Id, Name = branchEvent.Name };
        await unitOfWork.Branches.AddAsync(branch);

        await unitOfWork.SaveChangesAsync();
        await unitOfWork.CommitTransactionAsync();
    }
}