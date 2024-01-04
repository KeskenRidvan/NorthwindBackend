using Northwind.Core.Entities.Abstract;

namespace Northwind.Core.Entities.Concrete;

public class UserOperationClaim : IEntity
{
	public int Id { get; set; }
	public int UserId { get; set; }
	public int OperationClaimId { get; set; }
}
