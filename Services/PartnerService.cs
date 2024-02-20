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

    public void AddPartner(Partner partner)
    {
        _partnerRepository.Add(partner);
    }

    // Ostale metode koje koriste repository...
}
