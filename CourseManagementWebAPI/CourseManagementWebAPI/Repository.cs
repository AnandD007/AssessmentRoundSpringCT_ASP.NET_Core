// Please Ignore the Below Approach

//using CourseManagementWebAPI.Services;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel;

//namespace CourseManagementWebAPI
//{
//    public class Repository<T> : IRepository<T> where T : class
//    {
//        private readonly CourseDBContext _context;
//        private readonly DbSet<T> _dbSet;

//        public Repository(CourseDBContext context, DbSet<T> dbSet)
//        {
//            _context = context;
//            _dbSet = dbSet;
//        }

//        public async Task<IEnumerable<T>> GetAllEnrolledStudents() => await _dbSet.ToListAsync();
//        public async Task<T> GetDataByCourseName(int id) => await _dbSet.SingleOrDefaultAsync(x => x.Id == id);

//        public async Task AddStudent(T entity)
//        {
//            await _dbSet.AddAsync(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task Delete(int id)
//        {
//            var entity = await _dbSet.FindAsync(id);
//            if(entity == null)
//            {
//                return;
//            }
//            _dbSet.Remove(entity);
//            await _context.SaveChangesAsync();
//        }


//    }
//}
