using Common.EventModels.Branches;
using MassTransit;
using PostsDAL_EF.UoW;

namespace PostsBLL.Consumers;

public class BranchDeletedConsumer(IUnitOfWork unitOfWork) : IConsumer<BranchDeleted>
{
    public async Task Consume(ConsumeContext<BranchDeleted> context)
    {
        await unitOfWork.BeginTransactionAsync();

        var branchEvent = context.Message;
        var branch = await unitOfWork.Branches.GetByIdAsync(branchEvent.Id)
                     ?? throw new KeyNotFoundException($"Could not find branch with id {branchEvent.Id}");
        await unitOfWork.Branches.DeleteAsync(branchEvent.Id);

        await unitOfWork.SaveChangesAsync();
        await unitOfWork.CommitTransactionAsync();
    }
}