using ApiAggregator.Contracts.Request;
using ApiAggregator.Contracts.Response;

namespace ApiAggregator.Services.Interfaces;

public interface IBriefingService
{
    Task<BriefingResponse> GetBriefing(BriefingRequest request);

}