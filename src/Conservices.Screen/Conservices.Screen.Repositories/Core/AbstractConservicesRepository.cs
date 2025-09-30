using Conservices.Screen.Repositories.Serialization;
using Conservices.Screen.Repositories.Serialization.Conservices;
using Demolite.Http.Repository;

namespace Conservices.Screen.Repositories.Core;

public class AbstractConservicesRepository : AbstractHttpRepository
{
	protected readonly ConservicesSerializer Serializer = new();
	public override void SetGetHeaders()
	{
		base.SetGetHeaders();
		Client.DefaultRequestHeaders.Add("accept", "application/json");
	}
}