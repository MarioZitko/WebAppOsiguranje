using System.Collections.Generic;
using WebAppOsiguranje.Models;

public class PartnerService
{
    private readonly PartnerRepository _partnerRepository;

    public PartnerService(string connectionString)
    {
        _partnerRepository = new PartnerRepository(connectionString);
    }

    public IEnumerable<Partner> GetAllPartners()
    {
        return _partnerRepository.GetAll();
    }
    public IEnumerable<Partner> GetAllPartnersWithPolicyInfo()
    {
        return _partnerRepository.GetAllPartnersWithPolicyInfo();
    }
    public int AddPartner(Partner partner, out string errorMessage)
    {
        return _partnerRepository.Add(partner, out errorMessage);
    }

    public bool DeletePartner(int partnerId)
    {
        return _partnerRepository.Delete(partnerId);
    }
    public Partner GetPartnerById(int partnerId)
    {
        return _partnerRepository.GetPartnerById(partnerId);
    }

}
