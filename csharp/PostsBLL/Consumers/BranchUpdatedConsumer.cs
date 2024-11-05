using Common.EventModels.Branches;
using MassTransit;
using PostsDAL_EF.UoW;

namespace PostsBLL.Consumers;

public class BranchUpdatedConsumer(IUnitOfWork unitOfWork) : IConsumer<BranchUpdated>
{
    public async Task Consume(ConsumeContext<BranchUpdated> context1)
    {
        await unitOfWork.BeginTransactionAsync();

        var branchEvent = context1.Message;
        var branch = await unitOfWork.Branches.GetByIdAsync(branchEvent.Id)
                     ?? throw new KeyNotFoundException($"Could not find branch with id {branchEvent.Id}");
        branch.Name = branchEvent.Name;

        await unitOfWork.SaveChangesAsync();
        await unitOfWork.CommitTransactionAsync();
    }
}