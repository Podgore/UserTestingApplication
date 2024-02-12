using Microsoft.EntityFrameworkCore;
using UserTestingApp.DAL.Repository.Interface;
using UserTestingApp.Entities;
using UserTestingApp.Seeding.Interfaces;

namespace UserTestingApp.Seeding.Behaviours
{
    public class SeedingBehaviour : ISeedingBehaviour
    {
        private readonly IRepository<Test> _testRepository;
        private readonly IRepository<User> _userRepository;

        public SeedingBehaviour(
            IRepository<Test> testRepository,
            IRepository<User> userRepository)
        {
            _testRepository = testRepository;
            _userRepository = userRepository;
        }
                    
        public async Task SeedAsync()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.Parse("b22c0374-bd3c-40e5-ba21-3328b9f7fcce"),
                    Email = "student1@gmail.com"
                },
                new User
                {
                    Id = Guid.Parse("7660cf61-86f6-48da-ae6b-ec5427cf7563"),
                    Email = "student2@gmail.com"
                }
            };

            foreach (var user in users)
            {
                if (!await _userRepository.AnyAsync(u => u.Email == user.Email))
                    await _userRepository.InsertAsync(user);
            }

            var tests = new List<Test>
            {
                new Test
                {
                    Id = Guid.Parse("8831d0fc-a79b-4836-835d-c36dfe42bdcb"),
                    Lable = "Math Quiz",
                    MaxMark = 50,
                    TestUsers = new List<TestUser>
                    {
                        new TestUser
                        {
                            UserId = users[0].Id,
                        }
                    },
                    Tasks = new List<TestTask>
                    {
                        new TestTask
                        {
                            Label = "2+2=",
                            Options = new List<Option>
                            {
                                new Option { Label = "5", IsComplited = false },
                                new Option { Label = "3", IsComplited = false },
                                new Option { Label = "4", IsComplited = true }
                            }
                        },
                        new TestTask
                        {
                            Label = "Geometry figure without edges?",
                            Options = new List<Option>
                            {
                                new Option { Label = "Triangle", IsComplited = false },
                                new Option { Label = "Circle", IsComplited = true },
                                new Option { Label = "Square", IsComplited = false }
                            }
                        }
                    }
                },
                new Test
                {
                    Id = Guid.Parse("fba442e0-8ad1-4189-87e0-78c45d114a5d"),
                    Lable = "English Grammar Test",
                    MaxMark = 40,
                    TestUsers = new List<TestUser>
                    {
                        new TestUser
                        {
                            UserId = users[0].Id,
                        }
                    },
                    Tasks = new List<TestTask>
                    {
                        new TestTask
                        {
                            Label = "Sentence Structure",
                            Options = new List<Option>
                            {
                                new Option { Label = "Subject-Verb-Object", IsComplited = true },
                                new Option { Label = "Subject-Object-Verb", IsComplited = false },
                                new Option { Label = "Object-Subject-Verb", IsComplited = false }
                            }
                        },
                        new TestTask
                        {
                            Label = "Select the word with typo:",
                            Options = new List<Option>
                            {
                                new Option { Label = "Benevalent", IsComplited = true },
                                new Option { Label = "Malevolent", IsComplited = false },
                                new Option { Label = "Contentious", IsComplited = false }
                            }
                        }
                    }
                },
                new Test
                {
                    Id = Guid.Parse("bbc3628a-8a6f-49be-b3e8-179f398859c3"),
                    Lable = "Science Quiz",
                    MaxMark = 30,
                    TestUsers = new List<TestUser>
                    {
                        new TestUser
                        {
                            UserId = users[1].Id,
                        }
                    },
                    Tasks = new List<TestTask>
                    {
                        new TestTask
                        {
                            Label = "Explain Newton's First Law of Motion:",
                            Options = new List<Option>
                            {
                                new Option { Label = "Objects at rest stay at rest", IsComplited = true },
                                new Option { Label = "Resistance is futile", IsComplited = false },
                                new Option { Label = "Light travels faster than sound", IsComplited = false }
                            }
                        },
                        new TestTask
                        {
                            Label = "Identify the fundamental property:",
                            Options = new List<Option>
                            {
                                new Option { Label = "Atomic Number", IsComplited = true },
                                new Option { Label = "Molecular Weight", IsComplited = false },
                                new Option { Label = "Density", IsComplited = false }
                            }
                        }
                    }
                }
            };

            foreach (var test in tests)
            {
                if (!await _testRepository.AnyAsync(t => t.Id == test.Id))
                    await _testRepository.InsertAsync(test, false);
            }

            await _testRepository.SaveChangesAsync();
        }
    }
}
