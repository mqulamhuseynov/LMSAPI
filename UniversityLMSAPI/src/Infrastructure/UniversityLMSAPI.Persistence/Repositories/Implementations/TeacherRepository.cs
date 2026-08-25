
using UniversityLMSAPI.Domain.Entities;
using UniversityLMSAPI.Persistence.Data;
using UniversityLMSAPI.Persistence.Repositories.Interface;

namespace UniversityLMSAPI.Persistence.Repositories.Implementations
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {
        }
    }
}
