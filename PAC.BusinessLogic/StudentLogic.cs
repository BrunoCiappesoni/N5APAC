namespace PAC.BusinessLogic;

using IBusinessLogic;
using PAC.Domain;
using PAC.IDataAccess;
using System.Collections.Generic;

public class StudentLogic : IStudentLogic
{
    private readonly IStudentsRepository<Student> _studentsRepository;

    public StudentLogic(IStudentsRepository<Student> repository)
    {
        _studentsRepository = repository;
    }

    public Student GetStudentById(int id)
    {
        return _studentsRepository.GetStudentById(id);
    }

    public IEnumerable<Student> GetStudents(int since, int until)
    {
        List<Student> toReturn = new List<Student>();
        IEnumerable<Student> studentsToFilter = _studentsRepository.GetStudents();
        foreach (Student student in studentsToFilter)
        {
            if (student.Age >= since && student.Age <= until)
            {
                toReturn.Add(student);
            }

        }
        return toReturn;
    }

    public void InsertStudents(Student? student)
    {
        _studentsRepository.InsertStudents(student);
    }
}

