using PostsDAL_EF.Context;
using PostsDAL_EF.Entities;
using PostsDAL_EF.Repositories.Interfaces;

namespace PostsDAL_EF.Repositories;

public class BranchRepository(PostsContext context) : Repository<Branch>(context), IBranchRepository;