using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Services;
using Moq;

namespace InterviewsUnitTests;

[TestClass]
public class InterviewServiceUnitTest
{
    private InterviewsService _sut;
    private static List<Interview> _interviews;
    private Mock<IInterviewsRepository> _mockInterviewsRepository;
    private static int _id;

    [TestInitialize]
    public void OneTimeSetup()
    {
        _mockInterviewsRepository = new Mock<IInterviewsRepository>();
        _sut = new InterviewsService(_mockInterviewsRepository.Object);
        _mockInterviewsRepository.Setup(i => i.GetByIdAsync(_id)).ReturnsAsync(_interviews[0]);
        
    }
    
    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        _id = 1;
        _interviews = new List<Interview>()
        {
            new Interview()
            {
                BeginTime = DateTime.Today, CandidateEmail = "tony@gmail.com", Id = 1,
                CandidateFirstName = "Tony", CandidateLastName = "John", CandidateId = 1,
                EndTime = DateTime.Today.AddDays(3), InterviewerId = 1, InterviewTypeId = 1, SubmissionId = 1
            },
            new Interview()
            {
                BeginTime = DateTime.Today, CandidateEmail = "jucy@gmail.com", Id = 2,
                CandidateFirstName = "Jucy", CandidateLastName = "Chao", CandidateId = 2,
                EndTime = DateTime.Today.AddDays(2), InterviewerId = 2, InterviewTypeId = 1, SubmissionId = 2
            }
        };
    }
    
    [TestMethod]
    public async Task TestGetInterviewByIdFromFakeData()
    {
        // InterviewService => GetInterviewById
        var interview = await _sut.GetInterviewById(_id);
        
        // check the actual output with expected value.
        // AAA => arrange, act and assert
        Assert.IsNotNull(interview);
        Assert.IsInstanceOfType(interview, typeof(InterviewResponseModel));
        
    }
}

