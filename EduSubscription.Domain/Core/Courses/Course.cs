﻿using EduSubscription.Primitives;

namespace EduSubscription.Core.Courses;

public class Course : Entity
{
    public Course(string name, string description, string cover)
    {
        Name = name;
        Description = description;
        Cover = cover;
    }

    /// <summary>
    /// Creates a new course.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Course Create(string name, string description)
    {
        var course = new Course(name, description, "");
        return course;
    }

    /// <summary>
    /// Updates the current course.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Adds a new lesson to the course.
    /// </summary>
    /// <param name="lesson"></param>
    public void AddLesson(Lesson lesson)
    {
        Lessons.Add(lesson);
    }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Cover { get; private set; }
    public List<Lesson> Lessons { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
}