using System.Collections.Generic;
using WebAppOsiguranje.Models;

public class PolicyService
{
    private PolicyRepository _policyRepository;

    public PolicyService(string connectionString)
    {
        _policyRepository = new PolicyRepository(connectionString);
    }

    public IEnumerable<Policy> GetAllPolicies()
    {
        return _policyRepository.GetAllPolicies();
    }

    public void AddPolicy(Policy policy)
    {
        _policyRepository.AddPolicy(policy);
    }
}
