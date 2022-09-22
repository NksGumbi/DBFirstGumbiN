using DBFirstGumbi.Models;
using Microsoft.Data.SqlClient;
using SortOrder = DBFirstGumbi.Models.SortOrder;

namespace DBFirstGumbi.Interfaces
{
    public interface IClients
    {
        List<Client> GetClients(string SortProperty, SortOrder sortOrder, string SearchText="");

        Client GetClientById(int ClientId);

        Client Create(Client client);

        Client Update(Client client);

        Client Delete(Client client);  
    }
}
