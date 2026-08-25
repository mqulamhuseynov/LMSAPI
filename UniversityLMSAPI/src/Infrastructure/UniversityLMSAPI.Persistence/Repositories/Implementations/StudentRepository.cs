
using UniversityLMSAPI.Domain.Entities;
using UniversityLMSAPI.Persistence.Data;
using UniversityLMSAPI.Persistence.Repositories.Interface;

namespace UniversityLMSAPI.Persistence.Repositories.Implementations
{
    public class StudentRepository : Repository<Student>,IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context) 
        {
        
        }
    }
}
