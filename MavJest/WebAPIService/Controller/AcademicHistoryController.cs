using MavJest.WebAPIService.Business;
using MavJest.WebAPIService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MavJest.WebAPIService.Controller;

[Route("api/[controller]")]
[ApiController]
public class AcademicHistoryController : ControllerBase
{
    private readonly IAcademicHistoryService academicHistoryService;
    public AcademicHistoryController(IAcademicHistoryService academicHistoryService)
    {
        this.academicHistoryService = academicHistoryService;
    }

    [HttpGet("{id}")]
    public AcademicDetailModel Get(int id)
    {
        return this.academicHistoryService.GetAcademicDetail(id);
    }
}
