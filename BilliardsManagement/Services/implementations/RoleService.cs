using BilliardsManagement.Entities;
using BilliardsManagement.Services.Interfaces;

namespace BilliardsManagement.Services.implementations
{
    public class RoleService :IRoleService
    {
        private readonly BilliardsManagementContext _context;

        //Dependency Injection (DI)
        public RoleService(BilliardsManagementContext context)
        {
            _context = context;
        }         
        public ICollection<Role> GetRoles()
        {
            var roles = _context.Roles.ToList();
            return roles;
        }

        public Role? GetRole(Guid id)
        {
            // LinQ
            var role = _context.Roles.FirstOrDefault(x => x.Id.Equals(id));
            return role ?? null!;
        }
        public Role CreateRole(String name)
        { 
            var role = new Role {
                Id = Guid.NewGuid(),
                Name = name 
            };
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }
        public void DeleteRole(Guid id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id.Equals(id));
            if (role == null)
            {
                return;
            } 
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
        
    }   
}
