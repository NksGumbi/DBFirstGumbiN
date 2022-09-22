using System.Collections.Generic;
using System.Linq;
using DBFirstGumbi.Data;
using DBFirstGumbi.Models;
using DBFirstGumbi.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DBFirstGumbi.Repositories
{
    public class ClientRepository : IClients
    {
        private readonly TransDBContext _context;

        public ClientRepository(TransDBContext context)
        {
            _context = context;
        }

        public Client Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return client;
            //throw new NotImplementedException();
        }

        public Client Delete(Client client)
        {
            _context.Clients.Attach(client);
            _context.Entry(client).State = EntityState.Deleted;
            _context.SaveChanges();
            return client;
            //throw new NotImplementedException();
        }
        public Client Update(Client client)
        {
            _context.Clients.Attach(client);
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
            return client;
            //throw new NotImplementedException();
        }
       
        public List<Client> GetClient(string SortProperty, SortOrder sortOrder, string SearchText = "")
        {
            List<Client> clients = _context.Clients.ToList();

            if (SortProperty.ToLower() == "name")
            {
                if(sortOrder == SortOrder.Ascending)
                    clients = clients.OrderBy(c => c.Name).ToList();
                else
                    clients = clients.OrderByDescending(c => c.Name).ToList();
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    clients = clients.OrderBy(s => s.Surname).ToList();
                else
                    clients = clients.OrderByDescending(s => s.Surname).ToList();
            }
            return clients;
            //throw new NotImplementedException();
        }

        public Client GetClientById(int ClientId)
        {
            Client client = _context.Clients.Where(x => x.ClientId == ClientId).FirstOrDefault();
            return client;
            //throw new NotImplementedException();
        }

        public List<Client> GetClients(string SortProperty, SortOrder sortOrder, string SearchText = "")
        {
            throw new NotImplementedException();
        }
    }
}
