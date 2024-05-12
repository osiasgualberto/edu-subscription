using EduSubscription.Core.Courses;
using EduSubscription.Repositories.Contracts;

namespace EduSubscription.Repositories;

public interface ICourseRepository : IWritableRepository<Course>, IReadableRepository<Course>, IReadableAllRepository<Course>, IDeletableRepository;